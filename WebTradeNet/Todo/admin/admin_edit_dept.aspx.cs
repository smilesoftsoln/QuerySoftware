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

public partial class admin_admin_edit_dept : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        // for get dept name 14/03
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd_get_dept = new SqlCommand("admin_get_dept",con);
            cmd_get_dept.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_dept = cmd_get_dept.ExecuteReader();
            dddept.Items.Clear(); 
            while (dr_get_dept.Read())
            {
                dddept.Items.Add(dr_get_dept["dept_name"].ToString());
            }
            dddept.DataBind(); 
            con.Close();
        }



    }    
    protected void dddept_SelectedIndexChanged(object sender, EventArgs e)
    {        
         ////for get selected department information
      
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_management = new SqlCommand("admin_get_mngmnt", con);
            cmd_get_management.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_mng = cmd_get_management.ExecuteReader();
            ddmanagement.Items.Clear();
            while (dr_mng.Read())
            {
                ddmanagement.Items.Add(dr_mng[0].ToString());
            }
            ddmanagement.DataBind();
            dr_mng.Close();
            con.Close();
        
        //get hod for updating 15/03

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_hod = new SqlCommand("admin_get_dept_hod", con);
        cmd_get_hod.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr_hod = cmd_get_hod.ExecuteReader();
        ddhod.Items.Clear();
        while (dr_hod.Read())
        {
            ddhod.Items.Add(dr_hod[0].ToString());
        }
        ddhod.DataBind();
        dr_hod.Close();
        con.Close();

        
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_dept_inf = new SqlCommand("admin_get_dept_inf", con);
        cmd_get_dept_inf.CommandType = CommandType.StoredProcedure;
        cmd_get_dept_inf.Parameters.Clear();
        cmd_get_dept_inf.Parameters.AddWithValue("@deptname",dddept.Text.ToString());
        SqlDataReader dr_get = cmd_get_dept_inf.ExecuteReader();        
        dr_get.Read();

            txtdept.Text = dr_get["d_name"].ToString();
            ddmanagement.Text = dr_get["mng_name"].ToString();
            txtdescription.Text = dr_get["d_desc"].ToString();
            ddhod.Text = dr_get["hod_name"].ToString();

         dr_get.Close();
       con.Close();

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        // for updateing dept info 15/03
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_update_dept = new SqlCommand("admin_update_dept",con);
        cmd_update_dept.CommandType = CommandType.StoredProcedure;
        cmd_update_dept.Parameters.Clear();
        cmd_update_dept.Parameters.AddWithValue("@dname",dddept.Text.ToString());
        cmd_update_dept.Parameters.AddWithValue("@mname", ddmanagement.Text.ToString());
        cmd_update_dept.Parameters.AddWithValue("@hname", ddhod.Text.ToString());
        cmd_update_dept.Parameters.AddWithValue("@deptname", txtdept.Text.ToString());
        cmd_update_dept.Parameters.AddWithValue("@descp", txtdescription.Text.ToString());
        cmd_update_dept.ExecuteNonQuery();
        con.Close();
        Response.Redirect("admin.aspx");
    }
}
