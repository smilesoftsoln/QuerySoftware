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

public partial class admin_admin_view_management : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        // get managemet for table 15/03

        string strim = "";
        int i;

        strim += "<table border= '5' rules='rows'  style='border-style:single;border-color:#C66300'>";
        //strim += "<table border= '20' style= 'border-color:#CC0000'" + ";" + "'border-style:double'" + ">";

        strim += "<thead>";
        strim += "<tr>";
        strim += "<th width='50px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "No.";
        strim += "</th>";

        strim += "<th width='150px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Branch Name";
        strim += "</th>";

        strim += "<th width='250px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Branch Description";
        strim += "</th>";

        strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Manage";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";

        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        con.Open();
        SqlCommand cmd_get_managements = new SqlCommand("admin_get_all_management_inf", con);
        cmd_get_managements.CommandType = CommandType.StoredProcedure;
        SqlDataReader rdr = cmd_get_managements.ExecuteReader();

        while (rdr.Read())
        {
            strim += "<tr >";
            strim += "<td align='center'  bgcolor='#FCFFD9'>";
            strim += rdr[0].ToString();
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9'>";
            strim += rdr["name"];
            strim += "</td >";
            strim += "<td align='Center' bgcolor='#FCFFD9'>";
            strim += rdr["descp"];
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9' align='center'>";
            strim += "<a href=admin_edit_management.aspx?parameter='" + rdr["name"] + "'>" + rdr[0].ToString() + "</a>";

            strim += "</td >";
            strim += "</tr >";
           
        }


        strim += "</table>";

        viewmanagement.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 
	

    }
}
