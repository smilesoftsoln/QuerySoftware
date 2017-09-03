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

public partial class admin_admin_create_user_step2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd_get_dept = new SqlCommand("admin_get_dept", con);
        cmd_get_dept.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr_dept = cmd_get_dept.ExecuteReader();
        dddepartmetnt.Items.Clear();
        while (dr_dept.Read())
        {            
            dddepartmetnt.Items.Add(dr_dept["dept_name"].ToString());
  
        }
        dddepartmetnt.DataBind();
        con.Close();

    }
    protected void btncomplete_Click(object sender, EventArgs e)
    {
        Response.Write(@"<script language='javascript'>alert('This User Created Successfully..!')</script>");

    }
}
