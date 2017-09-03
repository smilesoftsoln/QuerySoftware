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

public partial class admin_admin_new_management : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        int mng_id = 0;
        con.Open();
        SqlCommand cmd_check_mngmnt = new SqlCommand("admin_check_management",con);
        cmd_check_mngmnt.CommandType = CommandType.StoredProcedure;
        cmd_check_mngmnt.Parameters.Clear();
        cmd_check_mngmnt.Parameters.AddWithValue("@mname", txtmngmnt.Text.Trim().ToString());
        mng_id = Convert.ToInt32(cmd_check_mngmnt.ExecuteScalar());
        con.Close();

        if (mng_id == 0)
        {
            con.Open();
            SqlCommand cmd_save_mngmnt = new SqlCommand("admin_save_management", con);
            cmd_save_mngmnt.CommandType = CommandType.StoredProcedure;
            cmd_save_mngmnt.Parameters.AddWithValue("@name", txtmngmnt.Text.Trim().ToString());
            cmd_save_mngmnt.Parameters.AddWithValue("@descp",txtdescription.Text.Trim().ToString());
            cmd_save_mngmnt.ExecuteNonQuery();
            con.Close();

            Response.Write(@"<script language='javascript'>alert('" + txtmngmnt.Text.Trim().ToString() + " Management Information Saved Successfully....!')</script>");

            txtmngmnt.Text = "";
            txtdescription.Text = "";

        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('" + txtmngmnt.Text.Trim().ToString() +" is Already Exist..!')</script>");
            txtmngmnt.Text = "";
            txtmngmnt.Focus();
            txtdescription.Text = "";
        }
    }
}
