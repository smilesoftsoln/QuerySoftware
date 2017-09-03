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
            SqlCommand cmd_get_branch = new SqlCommand("admin_get_branch", con);
            cmd_get_branch.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_branch.ExecuteReader();
            ddselectbranch.Items.Clear();
            while (dr.Read())
            {
                ddselectbranch.Items.Add(dr["name"].ToString());
            }
            ddselectbranch.DataBind();
            con.Close();


            con.Open();
            SqlCommand cmd_get_branch_bh = new SqlCommand("admin_get_branch_bh", con);
            cmd_get_branch_bh.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_bh = cmd_get_branch_bh.ExecuteReader();
            ddselectbh.Items.Clear();
            while (dr_bh.Read())
            {
                ddselectbh.Items.Add(dr_bh["name"].ToString());
            }
            ddselectbh.DataBind();
            con.Close();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        int branch_id;
        int login_id;

        con.Open();
        SqlCommand cmd_get_branch_id = new SqlCommand("admin_get_branch_id_by_branch_name", con);
        cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
        cmd_get_branch_id.Parameters.AddWithValue("@branch_name", ddselectbranch.Text.Trim());
        branch_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());
        con.Close();
        
        con.Open();
        SqlCommand cmd_get_login_id = new SqlCommand("admin_get_loginid",con);
        cmd_get_login_id.CommandType = CommandType.StoredProcedure;
        cmd_get_login_id.Parameters.AddWithValue("@login_name", ddselectbh.Text.Trim());
        login_id = Convert.ToInt32(cmd_get_login_id.ExecuteScalar());
        con.Close();
                
        con.Open();
        SqlCommand cmd_set_bh = new SqlCommand("admin_set_bh_to_branch", con);
        cmd_set_bh.CommandType = CommandType.StoredProcedure;
        cmd_set_bh.Parameters.AddWithValue("@branch_id", branch_id);
        cmd_set_bh.Parameters.AddWithValue("@bh_loginer_id", login_id);
        if (Convert.ToBoolean(cmd_set_bh.ExecuteNonQuery()))
        {
           Response.Write(@"<script language='javascript'>alert('Branch Transferred TO BH Successfully..!')</script>");
        }        
        con.Close();
    }
}
