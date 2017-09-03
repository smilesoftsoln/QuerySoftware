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

public partial class admin_admin_view_all_branches : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {

       
        // fill the datagrid on load event 13/03

        //
        string strim = "";
        int i = 1;


        strim += "<table border= '5' rules ='rows' style='border-style:single','border-color:#C66300' " + ">";
        //strim += "<table border= '20' style= 'border-color:#CC0000'" + ";" + "'border-style:double'" + ">";

		strim += "<thead>";
		strim += "<tr>";
        strim += "<th width='50px'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=	"No.";
		strim +=		"</th>";

        strim += "<th width='150px' align='left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=			"Branch Name";
		strim +=		"</th>";

        strim += "<th width='250px' align='left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=			"Branch Description";
		strim +=		"</th>";

        //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        //strim +=        "Manage";
        //strim +=        "</th>";

		strim +=	"</tr>";
		strim +=    "</thead>";
		 
         if (con.State == ConnectionState.Open) 
        {
            con.Close(); 
        }

        con.Open();
        SqlCommand cmd_get_branches = new SqlCommand("admin_get_all_branch", con);
        cmd_get_branches.CommandType = CommandType.StoredProcedure;
        SqlDataReader rdr = cmd_get_branches.ExecuteReader();
       
        while (rdr.Read())
        {
            strim += "<tr >";
            strim += "<td align='center'  bgcolor='#FCFFD9'>";
            strim += i;
            strim += "</td>";
            strim += "<td bgcolor='#FCFFD9'>";
            strim += rdr["name"];
            strim += "</td >";
            strim += "<td bgcolor='#FCFFD9'>";
            strim += rdr["descp"];
            strim += "</td >";
            strim += "<td bgcolor='#FCFFD9' align='center'>";
            //strim += "<a href='admin_edit_branch.aspx?parameter='" + rdr["Name"].ToString()  + "'> Edit" + "</a>";

            //  strim += "<a href=admin_edit_branch.aspx?parameter=" + rdr["id"].ToString()  + ">" + "Edit" + "</a>";
            strim += "</td >";          
            strim += "</tr >";
            i = i + 1;
        }


        strim += "</table>";

        disp_all_branchs.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 
	
    }
}
