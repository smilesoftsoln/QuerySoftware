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
public partial class admin_admin_assign_srmng_to_dept : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        //get srmng names 16/03
        if (!IsPostBack)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_srbmng = new SqlCommand("admin_get_srbmng", con);
            cmd_get_srbmng.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_srbmng.ExecuteReader();
            ddsrbmng.Items.Clear();
            while (dr.Read())
            {
                ddsrbmng.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();

            //get dept but not in t_m_assigm_srmng_dept 16/03
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_branch = new SqlCommand("admin_get_not_exist_branch", con);
            cmd_get_branch.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_branch = cmd_get_branch.ExecuteReader();
            ddbranch.Items.Clear();
            while (dr_branch.Read())
            {
                ddbranch.Items.Add(dr_branch[0].ToString());
            }
            dr_branch.Close();
            con.Close();
        }



    }
    protected void btnassign_Click(object sender, EventArgs e)
    {
        // save data in admin_save_assign_srmng_dept 16/03

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_save = new SqlCommand("admin_save_assign_srbmng_branch", con);
        cmd_save.CommandType = CommandType.StoredProcedure;
        cmd_save.Parameters.Clear();
        cmd_save.Parameters.AddWithValue("@srbmngname", ddsrbmng.Text.ToString());
        cmd_save.Parameters.AddWithValue("@brname", ddbranch.Text.ToString());
        cmd_save.ExecuteNonQuery();
        con.Close();
        Response.Redirect("admin_assign_srbmng_to_branch.aspx");
    }
}
