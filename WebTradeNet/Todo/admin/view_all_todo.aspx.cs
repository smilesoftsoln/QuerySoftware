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

public partial class admin_view_all_todo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        string strim = "";
        int i;

        strim += "<table border= '5' width = '100%' rules='rows'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";
        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "TODO ID";
        strim += "</th>";
        if (Convert.ToInt32(Request.QueryString["parameter"]) != 2)
        {
            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Edit";
            strim += "</th>";
        }
        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Creator";
        strim += "</th>";

        strim += "<th width='100px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "To";
        strim += "</th>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Type";
        strim += "</th>";

        strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_Todo=new SqlCommand();
        cmd_get_Todo.Parameters.Clear();
        if (Convert.ToInt32(Request.QueryString["parameter"]) == 2)
        {
            cmd_get_Todo = new SqlCommand("to_me_view_todo", con);
            cmd_get_Todo.Parameters.AddWithValue("@creator_id", Session["lgid"].ToString());
        }
        else if (Convert.ToInt32(Request.QueryString["parameter"]) == 3)
        {
            cmd_get_Todo = new SqlCommand("user_view_todo", con);
            cmd_get_Todo.Parameters.AddWithValue("@creator_id", Session["lgid"].ToString());
        }
        else
        {
           // cmd_get_Todo = new SqlCommand("admin_view_todo", con);
            cmd_get_Todo = new SqlCommand("user_view_todo", con);
            cmd_get_Todo.Parameters.AddWithValue("@creator_id", Session["lgid"].ToString());
        }
        cmd_get_Todo.CommandType = CommandType.StoredProcedure;
        SqlDataReader rdr = cmd_get_Todo.ExecuteReader();

        while (rdr.Read())
        {
            strim += "<tr>";
            strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
            strim += "<a href=admin_temp.aspx?parameter=" + rdr[0] + ">" + rdr[0].ToString() + "</a>";
            strim += "</td >";
            if (Convert.ToInt32(Request.QueryString["parameter"]) != 2)
            {
                if (rdr[1].ToString().Equals(rdr[2].ToString()))
                {
                    strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                    strim += "<a href=Admin_Edit_Assign_todo.aspx?parameter=" + rdr[0] + "&self=1>" + "Edit" + "</a>";
                    strim += "</td >";
                }
                else
                {
                    strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                    strim += "<a href=Admin_Edit_Assign_todo.aspx?parameter=" + rdr[0] + "&self=0>" + "Edit" + "</a>";
                    strim += "</td >";
                }
            }
            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[1];
            strim += "</td >";

            strim += "<td bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[2];
            strim += "</td >";

            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[3];
            strim += "</td >";

            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[4];
            strim += "</td >";


            //strim += "<td  bgcolor='#FCFFD9' align='center'>";


            //strim += "<a href=admin_edit_management.aspx?parameter='" + rdr["name"] + "'>" + rdr[0].ToString() + "</a>";

            //strim += "</td >";
            //strim += "</tr >";

        }


        strim += "</table>";

        viewtodo.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 

    }
}
