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

public partial class admin_Admin_asign_exist_hod : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 
    
    protected void Page_Load(object sender, EventArgs e)
    {

        // For Getting Departments of HOD_less   14/03 

        if (!IsPostBack)
        {

            con.Open();
            SqlCommand cmd_get_dept_hodless = new SqlCommand("admin_get_dept_hodless", con);
            cmd_get_dept_hodless.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_dept_hodless.ExecuteReader();
            ddselectdept.Items.Clear();
            while (dr.Read())
            {
                ddselectdept.Items.Add(dr["dept_name"].ToString());
            }
            ddselectdept.DataBind();
            con.Close();


            con.Open();
            SqlCommand cmd_get_dept_hod = new SqlCommand("admin_get_dept_hod", con);
            cmd_get_dept_hod.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_hod = cmd_get_dept_hod.ExecuteReader();
            ddselecthod.Items.Clear();
            while (dr_hod.Read())
            {
                ddselecthod.Items.Add(dr_hod["name"].ToString());
            }
            ddselecthod.DataBind();
            con.Close();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        int dept_id;
        int login_id;

        con.Open();
        SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
        cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
        cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddselectdept.Text.Trim());
        dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());
        con.Close();
        
        con.Open();
        SqlCommand cmd_get_login_id = new SqlCommand("admin_get_loginid",con);
        cmd_get_login_id.CommandType = CommandType.StoredProcedure;
        cmd_get_login_id.Parameters.AddWithValue("@login_name", ddselecthod.Text.Trim());
        login_id = Convert.ToInt32(cmd_get_login_id.ExecuteScalar());
        con.Close();
                
        con.Open();
        SqlCommand cmd_set_hod = new SqlCommand("admin_set_hod_to_dept", con);
        cmd_set_hod.CommandType = CommandType.StoredProcedure;
        cmd_set_hod.Parameters.AddWithValue("@dept_id", dept_id);
        cmd_set_hod.Parameters.AddWithValue("@hod_loginer_id", login_id);
        if (Convert.ToBoolean(cmd_set_hod.ExecuteNonQuery()))
        {
             Response.Write(@"<script language='javascript'>alert('Department Assigned TO Existing HOD Successfully..!')</script>");
        }        
        con.Close();

        if (!IsPostBack)
        {
            
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('Department Assigned TO Existing HOD Successfully..!')</script>");
            Response.Redirect("Admin_asign_exist_hod.aspx");
        }
      

    }
}
