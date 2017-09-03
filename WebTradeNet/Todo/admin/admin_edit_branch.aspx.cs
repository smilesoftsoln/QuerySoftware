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
public partial class admin_admin_edit_branch : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // for fill the ddbranch on load event 13/03

        if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd_get_branch = new SqlCommand("admin_get_branch", con);
            SqlDataReader dr_get_branch = cmd_get_branch.ExecuteReader();
            ddbranch.Items.Clear();
            while (dr_get_branch.Read())
            {
                ddbranch.Items.Add(dr_get_branch["name"].ToString());
            }

            dr_get_branch.Close();
            con.Close();

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
                ddmanagement.Items.Add(dr_mng["name"].ToString());
            }
           // ddmanagement.DataBind();
            dr_mng.Close();
            con.Close();
        }

        if (Request.QueryString["parameter"] == null )
        {

        }
        else
        {
            int x = Convert.ToInt32(Request.QueryString["parameter"].ToString());
            
            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
            con.Open();            
            SqlCommand cmd_get_inf = new SqlCommand("select b.id,b.name,b.descp,m.name from t_m_branch b,t_m_management m where b.manage_id=m.id and b.id = " + x ,con);
            SqlDataReader dr = cmd_get_inf.ExecuteReader();
            dr.Read();
            ddbranch.Text = dr[1].ToString(); 
            txtbranch.Text = dr[1].ToString();
            txtdescription.Text = dr[2].ToString();
            ddmanagement.Text = dr[3].ToString();
            ddbranch.Enabled = false;
            dr.Close(); 
            con.Close(); 
        }
    }
    protected void ddbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
       //  for fetch the branch information 13/03
      if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }

        con.Open();
        SqlCommand cmd_get_inf = new SqlCommand("admin_get_branch_information", con);
        cmd_get_inf.CommandType = CommandType.StoredProcedure;
        cmd_get_inf.Parameters.Clear();
        cmd_get_inf.Parameters.AddWithValue("@bname", ddbranch.Text.ToString());

        SqlDataReader dr = cmd_get_inf.ExecuteReader();
        dr.Read();
        txtbranch.Text = dr[0].ToString();
        txtdescription.Text = dr[1].ToString();
        ddmanagement.SelectedItem.Text = dr[2].ToString();
        dr.Close();
        con.Close(); 

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {               
        
        // for checking existing branch..13/03
        int x = 0;

        if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }

        con.Open();
        SqlCommand cmd_check_branch = new SqlCommand("admin_check_branch", con);
        cmd_check_branch.CommandType = CommandType.StoredProcedure;
        cmd_check_branch.Parameters.AddWithValue("@bname",txtbranch.Text.Trim().ToString());
        x = Convert.ToInt32(cmd_check_branch.ExecuteScalar());  
       
        con.Close();

        if (x == 0)
        {
           
            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
            con.Open();
            SqlCommand cmd_update_branch = new SqlCommand("admin_update_branch", con);
            cmd_update_branch.CommandType = CommandType.StoredProcedure;
            cmd_update_branch.Parameters.Clear();
            cmd_update_branch.Parameters.AddWithValue("@bname", ddbranch.Text.ToString());
            cmd_update_branch.Parameters.AddWithValue("@name", txtbranch.Text.Trim().ToString());
            cmd_update_branch.Parameters.AddWithValue("@mng_name",ddmanagement.SelectedItem.Text.ToString());
            cmd_update_branch.Parameters.AddWithValue("@descp", txtdescription.Text.Trim().ToString());
            cmd_update_branch.ExecuteNonQuery();
            con.Close();

            //Response.Write(@"<script language='javascript'>alert('"+ ddbranch.Text.ToString()  + " Branch Updated as " + txtbranch.Text.Trim().ToString()  + " Successfully..!')</script>");
            Response.Write("updated"); 
            txtbranch.Text = "";
            txtdescription.Text = "";
            Response.Redirect("admin_edit_branch.aspx");
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('This Branch is Already Exist..!')</script>");
            txtbranch.Text = "";
            txtdescription.Text = "";
            txtbranch.Focus();
            return;
        }
 
    }
  
}
