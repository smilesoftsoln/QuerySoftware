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

    protected void Page_Load(object sender, EventArgs e)
    {
        int get_task_id = Convert.ToInt32(Request.QueryString["parameter"]);

        //if (con.State == ConnectionState.Open)
        //{
        //    con.Close();
        //}

        //con.Open();
        //SqlCommand cmd_get_todo = new SqlCommand("view_particular_task", con);
        //cmd_get_todo.CommandType = CommandType.StoredProcedure;
        //cmd_get_todo.Parameters.Clear();
        //cmd_get_todo.Parameters.AddWithValue("@taskid", get_task_id);
        //SqlDataReader dr_get_todo = cmd_get_todo.ExecuteReader();

        //dr_get_todo.Read();

        //lbltaskid.Text = dr_get_todo[0].ToString();
        //lblenddatetime.Text = dr_get_todo[1].ToString();
        //lblfrom.Text = dr_get_todo[2].ToString();
        //lblto.Text = dr_get_todo[3].ToString(); 
        //if (dr_get_todo[4].ToString() == "High")
        //{
        //    lblpriority.Text = "High";
        //}
        //else
        //{
        //    lblpriority.Text = "Normal";
        //}     

        //lblsubject.Text = dr_get_todo[6].ToString();
        //FreeTextBox1.Text = dr_get_todo[7].ToString();
        //dr_get_todo.Close();
        //con.Close();

        con.Open();
        SqlCommand cmd_get_task = new SqlCommand("select ts.enddate,ts.solveddate,l.name,d.designation,l2.name,p.[desc],ts.subject,t.descp,ts.reply from t_m_designation as d,t_m_login as l2,t_m_task as t,t_m_priority as p,t_m_task_solved as ts,t_m_login as l where l.post=d.id and ts.id=t.id and t.priority=p.id and ts.creator=l.id and ts.assign_to=l2.id and ts.id="+ get_task_id +"  ",con);
        SqlDataReader dr = cmd_get_task.ExecuteReader();
        dr.Read();

        lbltaskid.Text = get_task_id.ToString();
        lblenddatetime.Text = dr[0].ToString();
        lblsolveddatetime0.Text = dr[1].ToString();
        lblfrom.Text = dr[2].ToString()+"[ "+ dr[3].ToString() +" ]" ;
        lblto.Text = dr[4].ToString();
        lblpriority.Text = dr[5].ToString();
        lblsubject.Text = dr[6].ToString();
        FreeTextBox1.Text=dr[7].ToString();
        txtreply.Text=dr[8].ToString();
        dr.Close();
        con.Close();


    }

    protected void link_home_Click(object sender, EventArgs e)
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
    protected void link_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_assigned_task.aspx");
    }
}
