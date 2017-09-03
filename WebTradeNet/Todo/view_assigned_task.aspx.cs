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
        string st;

        strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='45px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Task ID";
        strim += "</th>";

        strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "End Time";
        strim += "</th>";

        strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Pr.";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Assign To";
        strim += "</th>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Post";
        strim += "</th>";       

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Department";
        strim += "</th>";

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Branch";
        strim += "</th>";

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Status";
        strim += "</th>";
        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "Solved Date";
        strim += "</th>";
        strim += "<th width='70px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
        strim += "View / Cancel";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";

       
        DateTime dt = DateTime.Now;
        string sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
        DateTime startdate = Convert.ToDateTime(sdt);

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
        SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " ",con );
        //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
        int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
        int []rowcount = new int [a];
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }
        con.Open();
        SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " order by enddate desc",con );
        //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
        SqlDataReader dr = cmd_get_record.ExecuteReader();

        int xy = 0;
        while (dr.Read())
        {
            rowcount[xy] = Convert.ToInt32(dr[0].ToString());
            xy = xy + 1;
        }
        dr.Close();
        con.Close();

        // fill details section 

        for (int i = 0; i < rowcount.Length; i++)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
            con.Open();
            SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con); 
            string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
            con.Close();

            if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG" ))          
            { 
                if(con.State == ConnectionState.Open)                
                {
                    con.Close(); 
                }
                con.Open();
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status,t.SolvedDate from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " +  rowcount[i] ,con);
               
              //SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status,t.SolvedDate from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
 
                
                
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();
                
                while (dr_get_info.Read())
                {

                    strim += "<tr>";
                   
                    strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";                   
                    strim += dr_get_info[0];
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[5].ToString();
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='15%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[3]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[4].ToString();
                    strim += "</td >";
                 
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[2].ToString();
                    strim += "</td >";                    

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "---";
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "---";
                    strim += "</td >";
                  
                    st = "";
                    st=dr_get_info[6].ToString();

                    if (st == "S")
                    {
                        st = "SOLVED";
                    }
                    else if (st == "U")
                    {
                        st = "UNSOLVED";
                    }
                    else if (st == "C")
                    {
                        st = "CANCELED";
                    }
                    else if (st == "O")
                    {
                        st = "OVERDUE";
                    }

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += st;
                    strim += "</td >";
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[7].ToString();
                    strim += "</td >";
                    if (st == "SOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "UNSOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "CANCELED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "OVERDUE")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                        strim += "</td >";
                    }
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
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status,t.SolvedDate from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {

                    strim += "<tr>";

                    strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                    strim += dr_get_info[0];
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[5].ToString();
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='15%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[3]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[4].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[2].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[6].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "---";
                    strim += "</td >";
                    
                    st = "";
                    st = dr_get_info[7].ToString();

                    if (st == "S")
                    {
                        st = "SOLVED";
                    }
                    else if (st == "U")
                    {
                        st = "UNSOLVED";
                    }
                    else if (st == "C")
                    {
                        st = "CANCELED";
                    }
                    else if (st == "O")
                    {
                        st = "OVERDUE";
                    }

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += st;
                    strim += "</td >";
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[8].ToString();
                    strim += "</td >";
                    if (st == "SOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "UNSOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                        strim += "</td >"; 
                    }
                    else if (st == "CANCELED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "OVERDUE")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                        strim += "</td >";
                    }
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
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status,t.SolvedDate from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                while (dr_get_info.Read())
                {

                    strim += "<tr>";

                    strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                    strim += dr_get_info[0];
                    strim += "</td >";

                    //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                    //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                    //strim += "</td >";
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[6].ToString();
                    strim += "</td >";

                    strim += "<td bgcolor='#FCFFD9' width='18%'>";
                    DateTime x = Convert.ToDateTime(dr_get_info[3]);
                    string dat = x.ToString("dd/MM/yyyy");
                    string tm = x.ToLongTimeString();
                    dat = dat + " " + tm;
                    strim += dat;
                    strim += "</td >";
                   
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[4].ToString();
                    strim += "</td >";                  

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[1].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[2].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "---";
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[5].ToString();
                    strim += "</td >";
                   
                    st = "";
                    st = dr_get_info[7].ToString();

                    if (st == "S")
                    {
                        st = "SOLVED";
                    }
                    else if (st == "U")
                    {
                        st = "UNSOLVED";
                    }
                    else if (st == "C")
                    {
                        st = "CANCELED";
                    }
                    else if (st == "O")
                    {
                        st = "OVERDUE";
                    }

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += st;
                    strim += "</td >";
                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += dr_get_info[8].ToString();
                    strim += "</td >";
                    if (st == "SOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "UNSOLVED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                        strim += "</td >"; 
                    }
                    else if (st == "CANCELED")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                        strim += "</td >";
                    }
                    else if (st == "OVERDUE")
                    {
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "<a href = 'view_cancel_tasks.aspx.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                        strim += "</td >";
                    }

                }
                con.Close(); 
            }
        }
        strim += "</table>";

        view_self_assigned_task.InnerHtml = strim;
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
    protected void btnview_Click(object sender, EventArgs e)
    {
        if(ddtype.SelectedItem.Text=="ALL")
        {

            string strim = "";
            string st;

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Task ID";
            strim += "</th>";

            strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Subject";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "End Time";
            strim += "</th>";

            strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Pr.";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Assign To";
            strim += "</th>";

            strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Status";
            strim += "</th>";
            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "SolvedDate";
            strim += "</th>";
            strim += "<th width='20px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "View / Cancel";
            strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            DateTime dt = DateTime.Now;
            string sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
            DateTime startdate = Convert.ToDateTime(sdt);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'", con);
            int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " ", con);
            //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
            int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
            int[] rowcount = new int[a];
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " order by enddate desc", con);
            //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
            SqlDataReader dr = cmd_get_record.ExecuteReader();

            int xy = 0;
            while (dr.Read())
            {
                rowcount[xy] = Convert.ToInt32(dr[0].ToString());
                xy = xy + 1;
            }
            dr.Close();
            con.Close();

            // fill details section 

            for (int i = 0; i < rowcount.Length; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con);
                string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
                con.Close();

                if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status,t.SolvedDate from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[6].ToString();

                        if (st == "S")
                        {
                            st = "SOLVED";
                        }
                        else if (st == "U")
                        {
                            st = "UNSOLVED";
                        }
                        else if (st == "C")
                        {
                            st = "CANCELED";
                        }
                        else if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[8].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status,t.SolvedDate from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "S")
                        {
                            st = "SOLVED";
                        }
                        else if (st == "U")
                        {
                            st = "UNSOLVED";
                        }
                        else if (st == "C")
                        {
                            st = "CANCELED";
                        }
                        else if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[8].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status,,t.SolvedDate from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                        //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                        //strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='18%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "S")
                        {
                            st = "SOLVED";
                        }
                        else if (st == "U")
                        {
                            st = "UNSOLVED";
                        }
                        else if (st == "C")
                        {
                            st = "CANCELED";
                        }
                        else if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[8].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
                        else if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }

                    }
                    con.Close();
                }
            }
            strim += "</table>";

            view_self_assigned_task.InnerHtml = strim;

        }
        else if (ddtype.SelectedItem.Text == "Solved")
        {

            string strim = "";
            string st="S";

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Task ID";
            strim += "</th>";

            strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Subject";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "End Time";
            strim += "</th>";

            strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Pr.";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Assign To";
            strim += "</th>";

            strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Status";
            strim += "</th>";
            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "SolvedDate";
            strim += "</th>";
            strim += "<th width='20px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "View / Cancel";
            strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";           

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'", con);
            int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and status='"+ st +"' ", con);
            //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
            int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
            int[] rowcount = new int[a];
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' order by enddate desc", con);
            //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
            SqlDataReader dr = cmd_get_record.ExecuteReader();

            int xy = 0;
            while (dr.Read())
            {
                rowcount[xy] = Convert.ToInt32(dr[0].ToString());
                xy = xy + 1;
            }
            dr.Close();
            con.Close();

            // fill details section 

            for (int i = 0; i < rowcount.Length; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con);
                string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
                con.Close();

                if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status,t.SolvedDate from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[6].ToString();

                        if (st == "S")
                        {
                            st = "SOLVED";
                        }                        

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[7].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }                        
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status,t.SolvedDate from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();
                       
                        if (st == "S")
                        {
                            st = "SOLVED";
                        }                       

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[8].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }                        
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status,t.SolvedDate from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                        //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                        //strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='18%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "S")
                        {
                            st = "SOLVED";
                        }                        

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[8].ToString();
                        strim += "</td >";
                        if (st == "SOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_solved_particular_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/done.gif'> </a>";
                            strim += "</td >";
                        }
                    }
                    con.Close();
                }
            }
            strim += "</table>";

            view_self_assigned_task.InnerHtml = strim; 
        }

        else if (ddtype.SelectedItem.Text == "Unsolved")
        {
            string strim = "";
            string st = "U";

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Task ID";
            strim += "</th>";

            strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Subject";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "End Time";
            strim += "</th>";

            strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Pr.";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Assign To";
            strim += "</th>";

            strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Status";
            strim += "</th>";

            strim += "<th width='20px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "View / Cancel";
            strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'", con);
            int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' ", con);
            //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
            int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
            int[] rowcount = new int[a];
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' order by enddate desc", con);
            //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
            SqlDataReader dr = cmd_get_record.ExecuteReader();

            int xy = 0;
            while (dr.Read())
            {
                rowcount[xy] = Convert.ToInt32(dr[0].ToString());
                xy = xy + 1;
            }
            dr.Close();
            con.Close();

            // fill details section 

            for (int i = 0; i < rowcount.Length; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con);
                string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
                con.Close();

                if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[6].ToString();

                        if (st == "U")
                        {
                            st = "UNSOLVED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "U")
                        {
                            st = "UNSOLVED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                        //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                        //strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='18%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "U")
                        {
                            st = "UNSOLVED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "UNSOLVED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                            strim += "</td >";
                        }
                    }
                    con.Close();
                }
            }
            strim += "</table>";

            view_self_assigned_task.InnerHtml = strim; 
        }

        else if (ddtype.SelectedItem.Text == "Overdue")
        {
            string strim = "";
            string st = "O";

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Task ID";
            strim += "</th>";

            strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Subject";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "End Time";
            strim += "</th>";

            strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Pr.";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Assign To";
            strim += "</th>";

            strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Status";
            strim += "</th>";

            strim += "<th width='20px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "View / Cancel";
            strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'", con);
            int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' ", con);
            //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
            int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
            int[] rowcount = new int[a];
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' order by enddate desc", con);
            //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
            SqlDataReader dr = cmd_get_record.ExecuteReader();

            int xy = 0;
            while (dr.Read())
            {
                rowcount[xy] = Convert.ToInt32(dr[0].ToString());
                xy = xy + 1;
            }
            dr.Close();
            con.Close();

            // fill details section 

            for (int i = 0; i < rowcount.Length; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con);
                string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
                con.Close();

                if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[6].ToString();

                        if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }                       
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }                       
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                        //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                        //strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='18%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "O")
                        {
                            st = "OVERDUE";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "OVERDUE")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/overdue.gif'> </a>";
                            strim += "</td >";
                        }                       
                    }
                    con.Close();
                }
            }
            strim += "</table>";

            view_self_assigned_task.InnerHtml = strim;
        }

        else if (ddtype.SelectedItem.Text == "Canceled")
        {
            string strim = "";
            string st = "C";

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Task ID";
            strim += "</th>";

            strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Subject";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "End Time";
            strim += "</th>";

            strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Pr.";
            strim += "</th>";

            strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Assign To";
            strim += "</th>";

            strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Status";
            strim += "</th>";

            strim += "<th width='20px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "View / Cancel";
            strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_loginer_id = new SqlCommand("select id from t_m_login where loginid ='" + Session["loginid"].ToString() + "'", con);
            int get_id = Convert.ToInt32(cmd_get_loginer_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' ", con);
            //SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + " and enddate >= '" + startdate + "'", con);
            int a = Convert.ToInt32(cmd_get_records.ExecuteScalar());
            int[] rowcount = new int[a];
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + " and status='" + st + "' order by enddate desc", con);
            //SqlCommand cmd_get_record = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and enddate >= '" + startdate + "' order by enddate", con);
            SqlDataReader dr = cmd_get_record.ExecuteReader();

            int xy = 0;
            while (dr.Read())
            {
                rowcount[xy] = Convert.ToInt32(dr[0].ToString());
                xy = xy + 1;
            }
            dr.Close();
            con.Close();

            // fill details section 

            for (int i = 0; i < rowcount.Length; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount[i]), con);
                string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
                con.Close();

                if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,t.status from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[6].ToString();

                        if (st == "C")
                        {
                            st = "CANCELED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name,t.status from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td bgcolor='#FCFFD9' align = 'center' width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='15%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "C")
                        {
                            st = "CANCELED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
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
                    SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject,t.status from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount[i], con);
                    SqlDataReader dr_get_info = cmd_get_info.ExecuteReader();

                    while (dr_get_info.Read())
                    {

                        strim += "<tr>";

                        strim += "<td  bgcolor='#FCFFD9' align = 'center'  width='Auto'>";
                        strim += dr_get_info[0];
                        strim += "</td >";

                        //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                        //strim += "<a href=view_tasks.aspx?parameter=" + rdr[0] + ">" + "View" + "</a>";
                        //strim += "</td >";
                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[6].ToString();
                        strim += "</td >";

                        strim += "<td bgcolor='#FCFFD9' width='18%'>";
                        DateTime x = Convert.ToDateTime(dr_get_info[3]);
                        string dat = x.ToString("dd/MM/yyyy");
                        string tm = x.ToLongTimeString();
                        dat = dat + " " + tm;
                        strim += dat;
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[4].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[1].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[2].ToString();
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += "---";
                        strim += "</td >";

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += dr_get_info[5].ToString();
                        strim += "</td >";

                        st = "";
                        st = dr_get_info[7].ToString();

                        if (st == "C")
                        {
                            st = "CANCELED";
                        }

                        strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                        strim += st;
                        strim += "</td >";

                        if (st == "CANCELED")
                        {
                            strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                            strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/line.jpg'> </a>";
                            strim += "</td >";
                        }
                    }
                    con.Close();
                }
            }
            strim += "</table>";

            view_self_assigned_task.InnerHtml = strim;
        }

    }
}
