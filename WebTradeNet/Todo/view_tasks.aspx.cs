using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
public partial class view_todo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    SqlConnection querycon = new SqlConnection(ConfigurationManager.ConnectionStrings["tn_CAREE_bitaConnectionString2"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        int get_task_id = Convert.ToInt32(Request.QueryString["parameter"]);

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_todo = new SqlCommand("view_particular_task", con);
        cmd_get_todo.CommandType = CommandType.StoredProcedure;
        cmd_get_todo.Parameters.Clear();
        cmd_get_todo.Parameters.AddWithValue("@taskid", get_task_id);
        SqlDataReader dr_get_todo = cmd_get_todo.ExecuteReader();

        dr_get_todo.Read();

        lbltaskid.Text = dr_get_todo[0].ToString();
        lblenddatetime.Text = dr_get_todo[1].ToString();
        lblfrom.Text = dr_get_todo[2].ToString();
        lblto.Text = dr_get_todo[3].ToString(); 
        if (dr_get_todo[4].ToString() == "High")
        {
            lblpriority.Text = "High";
        }
        else
        {
            lblpriority.Text = "Normal";
        }     

        lblsubject.Text = dr_get_todo[6].ToString();
        FreeTextBox1.Text = dr_get_todo[7].ToString();
        dr_get_todo.Close();
        con.Close();
    }

    protected void btnsolved_Click(object sender, EventArgs e)
    {
        if (FreeTextBox1.Text.Trim() == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Reply Matter !')</script>");
            //FreeTextBox1.Focus=true;
            return;
        }
        else
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            DateTime solvedate = DateTime.Now;

            con.Open();
            SqlCommand cmd_save_solved_todo = new SqlCommand("save_solved_task", con);
            cmd_save_solved_todo.CommandType = CommandType.StoredProcedure;
            cmd_save_solved_todo.Parameters.Clear();
            cmd_save_solved_todo.Parameters.AddWithValue("@taskid", lbltaskid.Text);
            cmd_save_solved_todo.Parameters.AddWithValue("@enddate", Convert.ToDateTime(lblenddatetime.Text));
            cmd_save_solved_todo.Parameters.AddWithValue("@solvedate", solvedate);
            cmd_save_solved_todo.Parameters.AddWithValue("@creator", lblfrom.Text);
            cmd_save_solved_todo.Parameters.AddWithValue("@assignto", lblto.Text);
            cmd_save_solved_todo.Parameters.AddWithValue("@subject", lblsubject.Text);
            cmd_save_solved_todo.Parameters.AddWithValue("@reply", txtreply.Text);
            cmd_save_solved_todo.Parameters.AddWithValue("@status", "S");
            cmd_save_solved_todo.ExecuteNonQuery();
            //con.Close();
            //con.Open();
            SqlCommand cmd_update_solved_task = new SqlCommand("update t_m_task set SolvedDate=@solvedate , status=@status where id=@taskid ", con);
           // cmd_save_solved_todo.CommandType = CommandType.StoredProcedure;
            cmd_update_solved_task.Parameters.Clear();
            cmd_update_solved_task.Parameters.AddWithValue("@taskid", lbltaskid.Text);
           // cmd_save_solved_todo.Parameters.AddWithValue("@enddate", Convert.ToDateTime(lblenddatetime.Text));
            cmd_update_solved_task.Parameters.AddWithValue("@solvedate", solvedate);
          //  cmd_save_solved_todo.Parameters.AddWithValue("@creator", lblfrom.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@assignto", lblto.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@subject", lblsubject.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@reply", txtreply.Text);
            cmd_update_solved_task.Parameters.AddWithValue("@status", "S");
            cmd_update_solved_task.ExecuteNonQuery();
            SqlCommand cmd_update_overdue_task = new SqlCommand("delete from t_m_task_overdue   where id=@taskid ", con);
            // cmd_save_solved_todo.CommandType = CommandType.StoredProcedure;
            cmd_update_overdue_task.Parameters.Clear();
            cmd_update_overdue_task.Parameters.AddWithValue("@taskid", lbltaskid.Text);
            // cmd_save_solved_todo.Parameters.AddWithValue("@enddate", Convert.ToDateTime(lblenddatetime.Text));
          //  cmd_update_overdue_task.Parameters.AddWithValue("@solvedate", solvedate);
            //  cmd_save_solved_todo.Parameters.AddWithValue("@creator", lblfrom.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@assignto", lblto.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@subject", lblsubject.Text);
            //cmd_save_solved_todo.Parameters.AddWithValue("@reply", txtreply.Text);
            // cmd_save_solved_todo.Parameters.AddWithValue("@status", "S");
            cmd_update_overdue_task.ExecuteNonQuery();
            SendMail(Convert.ToInt64(lbltaskid.Text));
            con.Close();
            if ((Session["type"]).ToString() == "ADMIN")
            {
                Response.Redirect("admin/admin.aspx");
            }
            else if ((Session["type"]).ToString() == "DE")
            {
                Response.Redirect("dept_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "BE")
            {
                Response.Redirect("be_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "BH")
            {
                Response.Redirect("branchhead_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "SRMNG")
            {
                Response.Redirect("senior_manager_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "HOD")
            {
                Response.Redirect("hod_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "SRBMNG")
            {
                Response.Redirect("senior_branch_manager_login_next.aspx");
            }
            else if ((Session["type"]).ToString() == "MNG")
            {
                Response.Redirect("mng_login_next.aspx");
            }
        }
    }

    private void SendMail(long maxid )
    {

        /********************/
        try
        {
            SmtpClient SmtpServer1 = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("techsupport2@tradenetstockbroking.in", "tech123");
            SmtpServer1.Host = "10.53.251.9";
            SmtpServer1.Port = 25;
            SmtpServer1.UseDefaultCredentials = false;
            querycon.Open();
            SqlCommand cmd = querycon.CreateCommand();
            cmd.CommandText = "select email_id from tbl_loginer_master where name_='" + lblto.Text + "'";
            string to_emailid = (string)cmd.ExecuteScalar();

            cmd = querycon.CreateCommand();
            cmd.CommandText = "select email_id from tbl_loginer_master where name_='" + lblfrom.Text.Trim() + "'";
            string From_emailid = (string)cmd.ExecuteScalar();

            querycon.Close();
            //   SmtpServer.EnableSsl = true;
            SmtpServer1.Credentials = myCredential;
            SmtpServer1.ServicePoint.MaxIdleTime = 1;


            if (!lblfrom.Text.ToUpper().Equals(lblto.Text.ToUpper()))
            {
                /***From*/
                MailMessage mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(From_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + lblfrom.Text.ToUpper() + ",</br>Subject:- Answer For " + lblsubject.Text.ToUpper() + " Task Assigned by You to " + lblto.Text + "</br>Details Are As Below.." + "</br>" + txtreply.Text.ToUpper();// +"</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = " Answer For Task ID:-" + maxid + " Subject:-" + lblsubject.Text.ToUpper() + " Answer For Task Assigned by  You to " + lblto.Text.ToUpper();// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);
                /***TO*/
                mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(to_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + lblto.Text.ToUpper() + ",</br>You Answered Assigned Task Subject:-" + lblsubject.Text.ToUpper() + "   Assigned   by " + lblfrom.Text.Trim().ToUpper() + "</br>Details Are As Below.." + "</br>" + txtreply.Text.ToUpper();// +"</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = "You Answered Assigned Task ID:-" + maxid + " Subject:- " + lblsubject.Text.ToUpper() + " Task   by " + lblfrom.Text.Trim().ToUpper();// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);
            }
            else
            {
                MailMessage mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(to_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + lblfrom.Text.ToUpper() + ",</br>You have answered self assigned      task  Subject:-" + lblsubject.Text.ToUpper() + " Task  " + "</br>Details Are As Below.." + "</br>" + txtreply.Text.ToUpper();// +"</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = "You have  answered self assigned   task Task ID:-" + maxid + " Subject:-" + lblsubject.Text.ToUpper();// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);

            }
        }
        catch (Exception ex)
        {

        }


        /********************/
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if ((Session["type"]).ToString() == "ADMIN")
        {
            Response.Redirect("admin/admin.aspx");
        }
        else if ((Session["type"]).ToString() == "DE")
        {
            Response.Redirect("dept_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "BE")
        {
            Response.Redirect("be_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "BH")
        {
            Response.Redirect("branchhead_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "SRMNG")
        {
            Response.Redirect("senior_manager_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "HOD")
        {
            Response.Redirect("hod_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "SRBMNG")
        {
            Response.Redirect("senior_branch_manager_login_next.aspx");
        }
        else if ((Session["type"]).ToString() == "MNG")
        {
            Response.Redirect("mng_login_next.aspx");
        }
    }
}
