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
public partial class admin_admin_edit_management : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        //for get management 15/03
        if (!IsPostBack)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_management = new SqlCommand("admin_get_mngmnt", con);
            cmd_get_management.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_management.ExecuteReader();
            ddmanagement.Items.Clear();
            while (dr.Read())
            {
                ddmanagement.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //for checking existing or not 15/03

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        int x = 0;
        con.Open();
        SqlCommand cmd_chek_existing = new SqlCommand("admin_check_management", con);
        cmd_chek_existing.CommandType = CommandType.StoredProcedure;
        cmd_chek_existing.Parameters.Clear();
        cmd_chek_existing.Parameters.AddWithValue("@mname",txtmanagement.Text.ToString());
        x =Convert.ToInt32(cmd_chek_existing.ExecuteScalar());
        con.Close();

        if (x > 0)
        {
            Response.Write(@"<script language='javascript'>alert('" + txtmanagement.Text + "  Management is Already Exist')</script>");
            return;
        }
        else
        {
        //    for Update management 15/03
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_update_management = new SqlCommand("admin_update_management", con);
            cmd_update_management.CommandType = CommandType.StoredProcedure;
            cmd_update_management.Parameters.Clear();
            cmd_update_management.Parameters.AddWithValue("@mname",ddmanagement.Text.ToString());
            cmd_update_management.Parameters.AddWithValue("@name", txtmanagement.Text.ToString());
            cmd_update_management.Parameters.AddWithValue("@descp", txtdescription.Text.ToString());
            cmd_update_management.ExecuteNonQuery();
            con.Close();
            Response.Redirect("admin.aspx");
        }
    }
    protected void ddmanagement_SelectedIndexChanged(object sender, EventArgs e)
    {
        //for get existing management information 15/03
        if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }
        con.Open();
        SqlCommand cmd_get_mng_inf = new SqlCommand("admin_get_mngmnt_inf", con);
        cmd_get_mng_inf.CommandType = CommandType.StoredProcedure;
        cmd_get_mng_inf.Parameters.Clear();
        cmd_get_mng_inf.Parameters.AddWithValue("@mname",ddmanagement.Text.ToString());
        SqlDataReader dr = cmd_get_mng_inf.ExecuteReader();
        dr.Read();
        txtmanagement.Text = dr["name"].ToString();
        txtdescription.Text = dr["descp"].ToString();

        dr.Close();
        con.Close(); 
    }
}
