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

        int get_todo_id = Convert.ToInt32(Request.QueryString["parameter"]);

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_todo = new SqlCommand("view_particular_todo", con);
        cmd_get_todo.CommandType = CommandType.StoredProcedure;
        cmd_get_todo.Parameters.Clear();
        cmd_get_todo.Parameters.AddWithValue("@todoid", get_todo_id);
        SqlDataReader dr_get_todo = cmd_get_todo.ExecuteReader();

        dr_get_todo.Read();

        lbltodoid.Text = dr_get_todo[0].ToString();
        lblenddatetime.Text = dr_get_todo[1].ToString();
        lblfrom.Text = dr_get_todo[2].ToString();
        lblto.Text = dr_get_todo[3].ToString(); 
        if (Convert.ToInt32(dr_get_todo[5].ToString()) == 1)
        {
            lblpriority.Text = "High";
        }
        else
        {
            lblpriority.Text = "Normal";
        }

        if (Convert.ToInt32(dr_get_todo[4].ToString()) == 1)
        {
            lbltype.Text = "Daily";
        }
        else if (Convert.ToInt32(dr_get_todo[6].ToString()) == 2)
        {
            lbltype.Text = "Weekly";
        }
        else if (Convert.ToInt32(dr_get_todo[6].ToString()) == 3)
        {
            lbltype.Text = "Monthly";
        }

        lblsubject.Text = dr_get_todo[6].ToString();
        FreeTextBox1.Text = dr_get_todo[7].ToString();
        dr_get_todo.Close();
        con.Close();

    }

    protected void btnsolved_Click(object sender, EventArgs e)
    {
        if (FreeTextBox1.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Reply Matter !')</script>");
           // FreeTextBox1.Focus = true;
            return;
        }

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        DateTime solvedate=DateTime.Now;

        con.Open();

        SqlCommand cmd_save_solved_todo = new SqlCommand("save_solved_todo", con);
        cmd_save_solved_todo.CommandType = CommandType.StoredProcedure;
        cmd_save_solved_todo.Parameters.Clear();
        cmd_save_solved_todo.Parameters.AddWithValue("@todoid",lbltodoid.Text);
        cmd_save_solved_todo.Parameters.AddWithValue("@enddate",Convert.ToDateTime(lblenddatetime.Text));
        cmd_save_solved_todo.Parameters.AddWithValue("@solvedate",solvedate);
        cmd_save_solved_todo.Parameters.AddWithValue("@creator",lblfrom.Text);
        cmd_save_solved_todo.Parameters.AddWithValue("@assignto",lblto.Text);
        cmd_save_solved_todo.Parameters.AddWithValue("@subject",lblsubject.Text);
        cmd_save_solved_todo.Parameters.AddWithValue("@reply",txtreply.Text);
        cmd_save_solved_todo.Parameters.AddWithValue("@status","S");
        cmd_save_solved_todo.ExecuteNonQuery();
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
