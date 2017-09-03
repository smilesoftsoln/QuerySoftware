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

public partial class admin_admin_create_branch : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
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
        // for check brach is exist or not  10/03

        int branch_id = 0;

        con.Open();
        SqlCommand cmd_check_branch = new SqlCommand("admin_check_branch",con);
        cmd_check_branch.CommandType = CommandType.StoredProcedure;
        cmd_check_branch.Parameters.Add("@bname", SqlDbType.NVarChar).Value = txtbranch.Text.Trim().ToString();
        branch_id = Convert.ToInt32(cmd_check_branch.ExecuteScalar()); 
        con.Close();

        if (branch_id == 0)
        {
            con.Open();
            SqlCommand cmd_save_branch = new SqlCommand("admin_save_branch",con);
            cmd_save_branch.CommandType = CommandType.StoredProcedure;
            cmd_save_branch.Parameters.Add("@name",SqlDbType.NVarChar,100).Value = txtbranch.Text.Trim().ToString();           
            cmd_save_branch.Parameters.Add("@mng_name", SqlDbType.NVarChar, 200).Value =ddselectmngmnt.SelectedItem.Text.ToString();
            cmd_save_branch.Parameters.Add("@descp", SqlDbType.NVarChar, 200).Value = txtdescription.Text.Trim().ToString();

            cmd_save_branch.ExecuteNonQuery(); 
            con.Close();
            Response.Write(@"<script language='javascript'>alert('Branch Information Saved Successfully....!')</script>");

            txtbranch.Text = "";
            txtdescription.Text = "";
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert(' this Branch is already exist  !')</script>");
            txtbranch.Focus();
            return;
        }
       
        

    }
}
