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
public partial class admin_admin_view_department : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        // get dept for table 15/03

        string strim = "";
        int i;

        strim += "<table border= '5' rules ='rows' style='border-style:single;border-color:#C66300;font:Arial;font-size:13px' bgcolor='#FCFFD9'>";
        //strim += "<table border= '20' style= 'border-color:#CC0000'" + ";" + "'border-style:double'" + ">";

        strim += "<thead style='font:Arial;font-size:16px'>";
        strim += "<tr>";
        strim += "<th width='50px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "ID";
        strim += "</th>";

        strim += "<th width='200px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Department Name";
        strim += "</th>";

        strim += "<th width='200px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "H.O.D.";
        strim += "</th>";

        strim += "<th width='200px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Management";
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

        //for get dept info 15/03

        con.Open();
        SqlCommand cmd_get_dept_inf = new SqlCommand("admin_view_dept_inf", con);
        cmd_get_dept_inf.CommandType = CommandType.StoredProcedure;
        SqlDataReader rdr = cmd_get_dept_inf.ExecuteReader();

        while (rdr.Read())
        {
            strim += "<tr >";
            strim += "<td align='left' height='30'  valign='middle' bgcolor='#FCFFD9' style='border-right:hidden'>";
            strim += rdr["id"].ToString();
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9' height='30' valign='middle' style='border-left :hidden;border-right:hidden' >";
            strim += rdr["dept_name"].ToString();
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9' height='30' valign='middle' style='border-left :hidden;border-right:hidden' >";
            strim += rdr["hod"].ToString();
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9' height='30' valign='middle' style='border-left :hidden;border-right:hidden'>";
            strim += rdr["manage_name"].ToString();
            strim += "</td >";
            strim += "<td  bgcolor='#FCFFD9' height='30' valign='middle' style='border-left:hidden'>";
            strim += "<a href='admin_edit_dept.aspx'> Edit" + "</a>";

            strim += "</td >";
            strim += "</tr >";

        }


        strim += "</table>";

        viewdepartment.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 
	
    }
}
