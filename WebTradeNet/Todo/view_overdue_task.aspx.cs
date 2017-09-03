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

public partial class view_assigned_task : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strim = "";


        strim += "<table border= '5' width = '100%' rules='all' style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "ID";
        strim += "</th>";

        strim += "<th width='75px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Task Assigned By";
        strim += "</th>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Post";
        strim += "</th>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Dept";
        strim += "</th>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Branch";
        strim += "</th>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "End Date";
        strim += "</th>";

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='15px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "View";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";
               
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'",con);
        int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar()); 
        con.Close();

        
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task_overdue where assign_to=" + get_id + " and status = 'O'", con);
        //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task_overdue where creator=" + get_id + " and status = 'O'", con);
        int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
        int []rowcount = new int [a];
        int []assign_to = new int[a];
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_record = new SqlCommand("select id,assign_to from t_m_task_overdue where assign_to=" + get_id + " and status = 'O' order by enddate desc", con);
        //SqlCommand cmd_get_record = new SqlCommand("select id,assign_to from t_m_task_overdue where creator=" + get_id + " and status = 'O' order by enddate desc", con);
        SqlDataReader dr = cmd_get_record.ExecuteReader();

        int xy = 0;
        while (dr.Read())
        {
            rowcount[xy] = Convert.ToInt32(dr[0].ToString());
            assign_to[xy] = Convert.ToInt32(dr[1].ToString());
            xy = xy + 1;
        }
        dr.Close();
        con.Close();

        //// fill details section 

        for (int i = 0; i < rowcount.Length; i++)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_assign_designation = new SqlCommand("select d.designation from t_m_task_overdue as ts, t_m_login as l,t_m_designation as d where ts.assign_to=l.id and l.post=d.id and ts.id=" + rowcount[i], con);
            string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
            con.Close();

            if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
               SqlCommand cmd_get_info = new SqlCommand("select ts.id,l.name,ts.enddate,ts.subject from t_m_task_overdue as ts,t_m_login as l where ts.assign_to=l.id and ts.id=" + rowcount[i], con);
               // SqlCommand cmd = new SqlCommand("select ts.id,l.name,ts.enddate,ts.subject from t_m_task_overdue as ts,t_m_login as l where ts.assign_to=l.id and ts.id=" + rowcount[i], con);
                
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {

                    strim += "<tr>";

                    strim += "<td bgcolor='#FCFFD9' align = 'left' width='Auto'>";
                    strim += dr_get_info[0].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += assign_type;
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "--";
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "--";
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='15%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[2]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";
                    
                    //strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    //strim += dr_get_info[2].ToString();
                    //strim += "</td >";
                    
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[3].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto' align='center'>";
                    strim += "<a href = 'view_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '>View";
                    strim += "</td >";

                }
                con.Close();
            }

            else if ((assign_type == "HOD") || (assign_type == "DE"))
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
               // SqlCommand cmd_get_info = new SqlCommand("select ts.id,l.name,d.dept_name,ts.enddate,ts.solveddate,ts.subject,ts.reply from t_m_task_solved as ts,t_m_dept as d,t_m_login as l where ts.assign_to=l.id and l.forign_id=d.id and ts.id=" + rowcount[i], con);
                  //SqlCommand cmd_get_info = new SqlCommand("select ts.id,l.name,d.dept_name,ts.enddate,ts.subject from t_m_task_overdue as ts,t_m_login as l,t_m_dept as d where l.forign_id=d.id and ts.assign_to=l.id and ts.id=" + rowcount[i], con);
                SqlCommand cmd_get_info = new SqlCommand("select ts.id,l.name,d.dept_name,ts.enddate,ts.subject,desg.designation from t_m_task_overdue as ts,t_m_login as l,t_m_dept as d ,t_m_designation as desg where l.forign_id=d.id and ts.creator=l.id and l.post=desg.id and ts.id=" + rowcount[i], con);

                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {

                    strim += "<tr>";

                    strim += "<td bgcolor='#FCFFD9' align = 'left' width='Auto'>";                    
                    strim += dr_get_info[0].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[5].ToString(); ;
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[2].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "--";
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='15%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[3]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";

                    //strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    //strim += dr_get_info[3].ToString();
                    //strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[4].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto' align='center'>";
                    strim += "<a href = 'view_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '>Veiw";
                    strim += "</td >";

                }
                con.Close();
 
            }

            else if ((assign_type == "BH") || (assign_type == "BE"))
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_info = new SqlCommand("select ts.id,l.name,b.name as bname,ts.enddate,ts.subject, desg.designation from t_m_task_overdue as ts,t_m_login as l,t_m_branch as b,t_m_designation as desg where l.forign_id=b.id and l.post=desg.id and ts.creator=l.id and ts.id=" + rowcount[i], con);
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {

                    strim += "<tr>";

                    strim += "<td bgcolor='#FCFFD9' align = 'left' width='Auto'>";
                    strim += dr_get_info[0].ToString();
                    //strim += "<a href = '?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '>" + dr_get_info[0].ToString() + "</a>";
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[5].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "--";
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[2].ToString();
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='15%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[3]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";

                    //strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    //strim += dr_get_info[3].ToString();
                    //strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[4].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto' align='center'>";
                    strim += "<a href = 'view_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '>View";
                    strim += "</td >";

                }
                con.Close();

            }
        }
        strim += "</table>";

        div_overdue_task.InnerHtml = strim;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["type"].ToString() == "MNG")
        {
            Response.Redirect("mng_login_next.aspx");
        }
        else if (Session["type"].ToString() == "SRMNG")
        {
            Response.Redirect("senior_manager_login_next.aspx");
        }
        else if (Session["type"].ToString() == "HOD")
        {
            Response.Redirect("hod_login_next.aspx");
        }
        else if (Session["type"].ToString() == "SRBMNG")
        {
            Response.Redirect("senior_branch_manager_login_next.aspx");
        }
        else if (Session["type"].ToString() == "BH")
        {
            Response.Redirect("branchhead_login_next.aspx");
        }
        else if (Session["type"].ToString() == "DE")
        {
            Response.Redirect("dept_login_next.aspx");
        }
        else if (Session["type"].ToString() == "BE")
        {
            Response.Redirect("be_login_next.aspx");
        }        
    }
}
