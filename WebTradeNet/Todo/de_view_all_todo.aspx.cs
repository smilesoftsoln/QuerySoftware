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
public partial class de_view_all_todo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        string strim = "";


        strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "TODO ID";
        strim += "</th>";

        strim += "<th width='200px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='70px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "End Time";
        strim += "</th>";

        strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Pr.";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Assigner";
        strim += "</th>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "View";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        DateTime dt = DateTime.Now;
        string sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
        DateTime startdate = Convert.ToDateTime(sdt);

        DateTime edt = DateTime.Now;
        string edt1 = edt.ToString("dd-MMM-yyyy 23:59:59");
        DateTime enddate = Convert.ToDateTime(edt1);

        //int get_month=Convert.ToInt32(dt.Month);
        //int get_year= Convert.ToInt32(dt.Year);
        //string start_date = get_month + "/" + "1" + "/" + get_year;
        //DateTime startdt = Convert.ToDateTime(start_date);
        //int get_lastdy_month =Convert.ToInt32(System.DateTime.DaysInMonth(get_year,get_month));
        //string end_date = get_month + "/" + get_lastdy_month + "/" + get_year;
        //DateTime enddt = Convert.ToDateTime(end_date);

        con.Open();
        SqlCommand cmd_get_Todo = new SqlCommand("get_de_view_all_todo", con);
        cmd_get_Todo.CommandType = CommandType.StoredProcedure;
        cmd_get_Todo.Parameters.Clear();
        cmd_get_Todo.Parameters.AddWithValue("@startdate", startdate);
        cmd_get_Todo.Parameters.AddWithValue("@enddate", enddate);
        cmd_get_Todo.Parameters.AddWithValue("@loginid",Session["loginid"].ToString()); 

        SqlDataReader rdr = cmd_get_Todo.ExecuteReader();

        while (rdr.Read())
        {
            strim += "<tr>";
            //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
            //strim += "<a href=admin_temp.aspx?parameter=" + rdr[0] + ">" + rdr[0].ToString() + "</a>";
            //strim += "</td >";

            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[0].ToString();
            strim += "</td >";


            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[4].ToString();
            strim += "</td >";


            strim += "<td bgcolor='#FCFFD9' width='Auto'>";
            string x = rdr[2].ToString();

            DateTime dt1 = Convert.ToDateTime(x);
            string xy = dt1.ToString();
            string _hour = dt1.Hour.ToString();

            string _min = dt1.Minute.ToString();
            string sec = "00";
            string ampm = xy.Substring(Convert.ToInt32(xy.Length) - 2, 2);

            if (ampm == "PM")
            {
                _hour = (Convert.ToInt32(_hour) - 12).ToString();
            }
            if (Convert.ToInt32(_min.Length) == 1)
            {
                _min = "0" + _min;
            }
            strim += (_hour + ":" + _min + ":" + sec + " " + ampm).ToString();
            // strim += rdr[2];
            strim += "</td >";



            if (rdr[3].ToString() == "1")
            {
                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += "High";
                strim += "</td >";
            }
            else
            {
                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += "Normal";
                strim += "</td >";
            }


            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
            strim += rdr[1];
            strim += "</td >";


            strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
            strim += "<a href=view_todo.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
            strim += "</td >";


            //strim += "<td  bgcolor='#FCFFD9' align='center'>";


            //strim += "<a href=admin_edit_management.aspx?parameter='" + rdr["name"] + "'>" + rdr[0].ToString() + "</a>";

            //strim += "</td >";
            //strim += "</tr >";

        }


        strim += "</table>";

        view_de_todo.InnerHtml = strim;

        rdr.Close();
        con.Close();   		 

    }
    }

