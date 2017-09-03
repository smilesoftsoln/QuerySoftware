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

public partial class admin_admin_create_department : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd_get_management = new SqlCommand("sp_get_managements", con);
            cmd_get_management.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_management.ExecuteReader();
            ddselectmngmnt.Items.Clear();
            while (dr.Read())
            {
                //  ddselectuser.DataValueField = (dr[id].ToString());
                //  ddselectuser.DataTextField = dr["designation"].ToString();
                ddselectmngmnt.Items.Add(dr["name"].ToString());

            }
            ddselectmngmnt.DataBind();
            con.Close();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        // for check dept is exist or not  10/03
        int dept_id = 0;

        con.Open();
        SqlCommand cmd_check_dept = new SqlCommand("admin_check_dept", con);
        cmd_check_dept.CommandType = CommandType.StoredProcedure;
        cmd_check_dept.Parameters.Add("@dept_name", SqlDbType.NVarChar).Value = txtdept.Text.Trim().ToString();
        dept_id = Convert.ToInt32(cmd_check_dept.ExecuteScalar());
        con.Close();

        if (dept_id == 0)
        {
            con.Open();
            SqlCommand cmd_insert_dept = new SqlCommand("admin_insert_new_dept", con);
            cmd_insert_dept.CommandType = CommandType.StoredProcedure;
            cmd_insert_dept.Parameters.Clear();

            cmd_insert_dept.Parameters.AddWithValue("@dept_name", txtdept.Text.Trim().ToString());
            cmd_insert_dept.Parameters.AddWithValue("@dept_desc", txtdescription.Text.Trim().ToString());
            cmd_insert_dept.Parameters.AddWithValue("@manager", ddselectmngmnt.SelectedItem.Text.ToString());
            cmd_insert_dept.ExecuteNonQuery();
            con.Close();

            Response.Write(@"<script language='javascript'>alert('" + txtdept.Text.Trim().ToString() + "  Department Saved Successfully..!')</script>");

            txtdept.Text = "";
            txtdescription.Text = "";
            txtdept.Focus();
          
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('" + txtdept.Text.Trim().ToString() + "  Department Already Exist..!')</script>");
            txtdept.Focus();
            return;
        }


        
        

    }
}
