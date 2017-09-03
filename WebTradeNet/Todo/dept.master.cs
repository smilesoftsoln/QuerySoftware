using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient; 

public partial class dept : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        //con.Open();
        //SqlCommand cmd_save_logout_information = new SqlCommand("update t_m_login_information set outdate = '" + DateTime.Now.ToShortDateString() + "',outtime = '" + DateTime.Now.ToLongTimeString() + "' where id = " + Convert.ToInt32(Session["login_inf_id"].ToString()), con);
        //cmd_save_logout_information.ExecuteNonQuery();
        //con.Close();

        //if (con.State == ConnectionState.Open)
        //{
        //    con.Close();
        //}
        //con.Open();
        //SqlCommand cmd_get_id = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
        //int x = Convert.ToInt32(cmd_get_id.ExecuteScalar().ToString());
        //con.Close();

        //if (con.State == ConnectionState.Open)
        //{
        //    con.Close();
        //}
        //con.Open();
        //SqlCommand cmd_update_loginstatus = new SqlCommand("update t_m_login_status set status = 'OFF' where id = " + x, con);
        //cmd_update_loginstatus.ExecuteNonQuery();
        //con.Close();   

        //Session.Abandon();
        //Response.Redirect("Default.aspx");
        Response.Write("<script>window.close()</script>");
    }
}
