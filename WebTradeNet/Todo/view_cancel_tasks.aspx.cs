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
public partial class view_todo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);

    int max_id = 0;
    DateTime enddate;
    int creator = 0;
    int assign_id = 0;
    string usertype = "";
    int usertypeid = 0;
    int branch_dept_id = 0;
    //int dept_id = 0;
    int priority = 1;



    protected void Page_Load(object sender, EventArgs e)
    {

        int get_task_id = Convert.ToInt32(Request.QueryString["parameter"]);

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_st = new SqlCommand("select status from t_m_task where id=" + get_task_id + "", con);
        string st = cmd_get_st.ExecuteScalar().ToString();
        con.Close();

        if(st=="U")
        {
            btncancel.Enabled = true;
        }
        else
        {
            btncancel.Enabled = false;
        }        

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
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["type"].ToString() == "MNG")
        {
            Response.Redirect("mng_login_next.aspx");
        }
        else if (Session["type"].ToString() == "SRMNG")
        {
            Response.Redirect("senior_manager_login_next.aspx");
        }
        else if (Session["type"].ToString() == "HOD")
        {
            Response.Redirect("hod_login_next.aspx");
        }
        else if (Session["type"].ToString() == "SRBMNG")
        {
            Response.Redirect("senior_branch_manager_login_next.aspx");
        }
        else if (Session["type"].ToString() == "BH")
        {
            Response.Redirect("branchhead_login_next.aspx");
        }
        else if (Session["type"].ToString() == "DE")
        {
            Response.Redirect("dept_login_next.aspx");
        }
        else if (Session["type"].ToString() == "BE")
        {
            Response.Redirect("be_login_next.aspx");
        }        
    }
    
    protected void btncancel_Click(object sender, EventArgs e)
    {

        DateTime cncdate = Convert.ToDateTime(lblenddatetime.Text.Trim());
        string dt = cncdate.ToString("dd-MMM-yyyy");
        string tm = cncdate.ToLongTimeString();
        string tot = dt + " " + tm;

        string stts = "C";       

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_creator = new SqlCommand("select id from t_m_login where name='" + lblfrom.Text.Trim() + "' ",con);
        creator =Convert.ToInt32(cmd_get_creator.ExecuteScalar());
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_assignto = new SqlCommand("select id from t_m_login where name='" + lblto.Text.Trim() + "' ",con);
        assign_id =Convert.ToInt32( cmd_get_assignto.ExecuteScalar());
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_usertypeid = new SqlCommand("select post from t_m_login where name='" + lblto.Text.Trim() + "'", con);
        usertypeid = Convert.ToInt32(cmd_get_usertypeid.ExecuteScalar());
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

        SqlCommand cmd_get_usertype = new SqlCommand("select designation from t_m_designation where id=" + usertypeid + "", con);
        usertype = Convert.ToString(cmd_get_usertype.ExecuteScalar());
        con.Close();
        
        if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_branch_dept_id = new SqlCommand("select forign_id from t_m_login where name='" + lblto.Text.Trim() + "'", con);
            branch_dept_id = Convert.ToInt32(cmd_get_branch_dept_id.ExecuteScalar());
            con.Close();


            if (lblpriority.Text.Trim() == "HIGH")
            {
                priority = 1;
            }
            else
            {
                priority = 2;
            }


            if ((usertype == "BH") || (usertype == "BE"))
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_task = new SqlCommand("insert into t_m_canceled_task values (" + lbltaskid.Text.Trim() + ",'" + tot + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_dept_id + "," + 0 + "," + priority + ",'" + lblsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "')", con);
                cmd_save_task.ExecuteNonQuery();
                con.Close(); 
            }
            else if ((usertype == "HOD") || (usertype == "DE"))
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_task = new SqlCommand("insert into t_m_canceled_task values (" + lbltaskid.Text.Trim() + ",'" + tot + "'," + creator + "," + assign_id + ",'" + usertype + "'," + 0 + "," + branch_dept_id + "," + priority + ",'" + lblsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "')", con);
                cmd_save_task.ExecuteNonQuery();
                con.Close();

            }
            else if ((usertype == "SRMNG") || (usertype == "SRBMNG") || (usertype == "MNG"))
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_task = new SqlCommand("insert into t_m_canceled_task values (" + lbltaskid.Text.Trim() + ",'" + tot + "'," + creator + "," + assign_id + ",'" + usertype + "'," + 0 + "," + 0 + "," + priority + ",'" + lblsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "')", con);
                cmd_save_task.ExecuteNonQuery();
                con.Close();
            }

             
            string sts="C";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_update_task = new SqlCommand("update t_m_task set status='"+ sts +"' where id= " + lbltaskid.Text.Trim() + "", con);
            cmd_update_task.ExecuteNonQuery();
            con.Close();
            if (Session["type"].ToString() == "MNG")
            {
                Response.Redirect("mng_login_next.aspx");
            }
            else if (Session["type"].ToString() == "SRMNG")
            {
                Response.Redirect("senior_manager_login_next.aspx");
            }
            else if (Session["type"].ToString() == "HOD")
            {
                Response.Redirect("hod_login_next.aspx");
            }
            else if (Session["type"].ToString() == "SRBMNG")
            {
                Response.Redirect("senior_branch_manager_login_next.aspx");
            }
            else if (Session["type"].ToString() == "BH")
            {
                Response.Redirect("branchhead_login_next.aspx");
            }
            else if (Session["type"].ToString() == "DE")
            {
                Response.Redirect("dept_login_next.aspx");
            }
            else if (Session["type"].ToString() == "BE")
            {
                Response.Redirect("be_login_next.aspx");
            }        
          //  Response.Redirect("view_assigned_task.aspx");
    }   
}
