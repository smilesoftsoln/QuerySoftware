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
        strim += "<th width='80px'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=	"No.";
		strim +=		"</th>";

        strim += "<th width='175px' align='left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=			"Department Name";
		strim +=		"</th>";

        strim += "<th width='250px' align='left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
		strim +=			"HOD";
		strim +=		"</th>";      

		strim +=	"</tr>";
		strim +=    "</thead>";
		 
         if (con.State == ConnectionState.Open) 
        {
            con.Close(); 
        }

        con.Open();
        SqlCommand cmd_get_branches_heads = new SqlCommand("SELECT d.id,d.dept_name,l.name AS dt FROM t_m_dept as d LEFT OUTER JOIN t_m_login as l ON d.hod_id = l.id", con);        
        SqlDataReader rdr = cmd_get_branches_heads.ExecuteReader();       
        while (rdr.Read())
        {
            strim += "<tr >";
            strim += "<td align='center'  bgcolor='#FCFFD9'>";
            strim += rdr[0];
            strim += "</td>";
            strim += "<td bgcolor='#FCFFD9' width='175px' >";
            strim += rdr[1];
            strim += "</td >";
            strim += "<td bgcolor='#FCFFD9' width='250px'>";
            strim += rdr[2];
            strim += "</td >";

            //strim += "<td bgcolor='#FCFFD9'>";
            //strim += rdr[1];
            //strim += "</td >";

            //strim += "<td bgcolor='#FCFFD9' align='center'>";
            ////strim += "<a href='admin_edit_branch.aspx?parameter='" + rdr["Name"].ToString()  + "'> Edit" + "</a>";

            ////  strim += "<a href=admin_edit_branch.aspx?parameter=" + rdr["id"].ToString()  + ">" + "Edit" + "</a>";
            //strim += "</td >";          
            //strim += "</tr >";
            //i = i + 1;
        }


        strim += "</table>";

        disp_all_branchs_branch_heads.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 
	
    }
}
