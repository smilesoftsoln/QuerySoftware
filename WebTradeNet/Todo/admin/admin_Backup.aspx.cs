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


public partial class admin_admin_Backup : System.Web.UI.Page
{
   
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {      
         try
          {
              if (con.State == ConnectionState.Open)
              {
                  con.Close();
              }

            con.Open();
            SqlCommand cmd = new SqlCommand(@"backup database todo to disk = 'D:\amol\todo_new.bak' with noformat, noinit, name=N'todo Backup-Full Database Backup',SKIP,NOREWIND,NOUNLOAD, STATS = 10", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write(@"<script language='javascript'>alert('Backup File Created Successfully..!')</script>");
          }
          catch (Exception ex)
          {
            Response.Write(ex.Message);
          }

        
         
    }
}
