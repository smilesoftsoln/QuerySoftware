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

public partial class admin_admin_temp : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 


    protected void Page_Load(object sender, EventArgs e)
    {
        long get_todo_id=Convert.ToInt64( Request.QueryString["parameter"]);

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_todo = new SqlCommand("admin_view_particular_todo",con);
        cmd_get_todo.CommandType = CommandType.StoredProcedure;
        cmd_get_todo.Parameters.Clear();
        cmd_get_todo.Parameters.AddWithValue("@todoid",get_todo_id);
        SqlDataReader dr_get_todo = cmd_get_todo.ExecuteReader();

        dr_get_todo.Read();

        lbltodoid.Text = dr_get_todo[0].ToString();
        lblenddatetime.Text=dr_get_todo[1].ToString();
        lblfrom.Text=dr_get_todo[2].ToString();
        lblto.Text=dr_get_todo[3].ToString()+ " [" + dr_get_todo[4].ToString() + "]";

        if (Convert.ToInt32(dr_get_todo[5].ToString()) == 1)
        {
            lblpriority.Text = "Normal";
        }
        else
        {
            lblpriority.Text = "High";
        }

        if (Convert.ToInt32(dr_get_todo[6].ToString()) == 1)
        {
            lbltype.Text = "Daily";
        }
        else if (Convert.ToInt32(dr_get_todo[6].ToString()) == 2)
        {
            lbltype.Text = "Weekly";
        }
        else if (Convert.ToInt32(dr_get_todo[6].ToString()) == 3)
        {
            lbltype.Text = "Monthly";
        }

        lblsubject.Text=dr_get_todo[7].ToString();

        FreeTextBox1.Text=dr_get_todo[8].ToString();
        dr_get_todo.Close();
        con.Close();


    }
}
