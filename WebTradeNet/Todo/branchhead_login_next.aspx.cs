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

public partial class branchhead_login_next : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ToString());
    string strim = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        con.Open();
        SqlCommand cmd_get_branch_name_and = new SqlCommand("select id,name from t_m_branch where id = " + Convert.ToInt32(Session["forign_id_todo"]), con);
        SqlDataReader dr1 = cmd_get_branch_name_and.ExecuteReader();
        dr1.Read();
        Session.Add("branch_id", dr1[0].ToString());
        Session.Add("branch_name", dr1[1].ToString());
        dr1.Close();
        con.Close();




        lblloginer.Text = Session["loginer"].ToString();
        lblmanageid.Text = Session["manage_id"].ToString();
        lblbranchname.Text = Session["branch_name"].ToString();
        lblusertype.Text = Session["type"].ToString();

        DateTime dt = DateTime.Now;
        string sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
        DateTime startdate = Convert.ToDateTime(sdt);

        DateTime edt = DateTime.Now;
        string edt1 = edt.ToString("dd-MMM-yyyy 23:59:59");
        DateTime enddate = Convert.ToDateTime(edt1);


        DateTime edt2 = DateTime.Now;
        string edt3 = edt.ToString("dd-MMM-yyyy 23:59:59");
        DateTime enddate_overdue = Convert.ToDateTime(edt1);


        /////////////////////////////// for overdue task ..  ///////////////////////////////////////

        con.Open();
        //SqlCommand cmd_todays_task_id = new SqlCommand("SELECT count(t.id) as cnt FROM t_m_task as t,t_m_login as l Where t.assign_to=l.id and t.enddate>='" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "' and t.enddate<='" + enddate_overdue.ToString("dd-MMM-yyyy 23:59:59") + "' and t.status='U' and l.loginid='" + Session["loginid"] + "' ", con);
        SqlCommand cmd_todays_task_id = new SqlCommand("SELECT count(t.id) as cnt FROM t_m_task as t,t_m_login as l Where t.assign_to=l.id and t.enddate<='" +  dt.ToString() + "'   and t.status='U' and l.loginid='" + Session["loginid"] + "' ", con);

        int a = Convert.ToInt32(cmd_todays_task_id.ExecuteScalar());
        int[] rowcount = new int[a];
        DateTime[] dttm = new DateTime[a];
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
//SqlCommand cmd_get_record = new SqlCommand("select t.id,t.enddate from t_m_task as t,t_m_login as l Where t.assign_to=l.id and t.enddate>='" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "' and t.enddate<='" + enddate_overdue.ToString("dd-MMM-yyyy 23:59:59") + "' and t.status='U' and l.loginid='" + Session["loginid"] + "' ", con);
        SqlCommand cmd_get_record = new SqlCommand("select t.id,t.enddate from t_m_task as t,t_m_login as l Where t.assign_to=l.id and t.enddate<='" + dt. ToString() + "'  and t.status='U' and l.loginid='" + Session["loginid"] + "' ", con);
        
        
        SqlDataReader dr = cmd_get_record.ExecuteReader();

        int xyi = 0;
        while (dr.Read())
        {
            rowcount[xyi] = Convert.ToInt32(dr[0].ToString());
            dttm[xyi] = Convert.ToDateTime(dr[1].ToString());
            xyi = xyi + 1;
        }
        dr.Close();
        con.Close();


        for (int i = 0; i < rowcount.Length; i++)
        {


            lbl_overdue.Visible = true;
            lbl_overdue.Text = "(" + rowcount.Length + ")";
            img_overd_alert.Visible = true;
            int sh = 0;
            int sm = 0;
            int h = 0;
            int m = 0;

            h = dttm[i].Hour;
            m = dttm[i].Minute;


            DateTime tms = DateTime.Now;
            sh = tms.Hour;
            sm = tms.Minute;

            //if (h < sh)
            //{
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_update_overdue = new SqlCommand("update_task_table_overdue", con);
                cmd_update_overdue.CommandType = CommandType.StoredProcedure;
                cmd_update_overdue.Parameters.Clear();
                cmd_update_overdue.Parameters.AddWithValue("@id", rowcount[i]);
                cmd_update_overdue.ExecuteNonQuery();
                con.Close();

                DateTime dttms;
                int creator;
                int assign_id;
                string usertype;
                int branch_id;
                int dept_id;
                int priority;
                string sub;
                string descpr;
                string stts;


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_select_task = new SqlCommand("select * from t_m_task where id=" + rowcount[i] + "", con);
                SqlDataReader dr_select = cmd_select_task.ExecuteReader();
                dr_select.Read();

                dttms = Convert.ToDateTime(dr_select[1]);
                creator = Convert.ToInt32(dr_select[2]);
                assign_id = Convert.ToInt32(dr_select[3]);
                usertype = dr_select[4].ToString();
                branch_id = Convert.ToInt32(dr_select[5]);
                dept_id = Convert.ToInt32(dr_select[6]);
                priority = Convert.ToInt32(dr_select[7]);
                sub = dr_select[8].ToString();
                descpr = dr_select[9].ToString();
                stts = dr_select[10].ToString();

                dr_select.Close();
                con.Close();


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_task = new SqlCommand("insert into t_m_task_overdue values (" + rowcount[i] + ",'" + dttms + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + sub + "','" + descpr + "','" + stts + "')", con);
                cmd_save_task.ExecuteNonQuery();
                con.Close();
            //}

            //else if (h == sh)
            //{
            //    if (m <= sm)
            //    {

            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //        }
            //        con.Open();
            //        SqlCommand cmd_update_overdue = new SqlCommand("update_task_table_overdue", con);
            //        cmd_update_overdue.CommandType = CommandType.StoredProcedure;
            //        cmd_update_overdue.Parameters.Clear();
            //        cmd_update_overdue.Parameters.AddWithValue("@id", rowcount[i]);
            //        cmd_update_overdue.ExecuteNonQuery();
            //        con.Close();

            //        DateTime dttms;
            //        int creator;
            //        int assign_id;
            //        string usertype;
            //        int branch_id;
            //        int dept_id;
            //        int priority;
            //        string sub;
            //        string descpr;
            //        string stts;


            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //        }
            //        con.Open();
            //        SqlCommand cmd_select_task = new SqlCommand("select * from t_m_task where id=" + rowcount[i] + "", con);
            //        SqlDataReader dr_select = cmd_select_task.ExecuteReader();
            //        dr_select.Read();

            //        dttms = Convert.ToDateTime(dr_select[1]);
            //        creator = Convert.ToInt32(dr_select[2]);
            //        assign_id = Convert.ToInt32(dr_select[3]);
            //        usertype = dr_select[4].ToString();
            //        branch_id = Convert.ToInt32(dr_select[5]);
            //        dept_id = Convert.ToInt32(dr_select[6]);
            //        priority = Convert.ToInt32(dr_select[7]);
            //        sub = dr_select[8].ToString();
            //        descpr = dr_select[9].ToString();
            //        stts = dr_select[10].ToString();

            //        dr_select.Close();
            //        con.Close();

            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //        }
            //        con.Open();
            //        SqlCommand cmd_save_task = new SqlCommand("insert into t_m_task_overdue values (" + rowcount[i] + ",'" + dttms + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + sub + "','" + descpr + "','" + stts + "')", con);
            //        cmd_save_task.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
        }
        ///////////////////////////////////// task overdue complete /////////////////////////////////////////////////////


        /////////////////////////////////////////for todays task ///////////////////////////////////////////////////////////////

        strim = "";

        strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Task ID";
        strim += "</th>";

        strim += "<th width='200px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='70px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "End Time";
        strim += "</th>";

        strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Pr.";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Assigner";
        strim += "</th>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "View";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        dt = DateTime.Now;
        sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
        startdate = Convert.ToDateTime(sdt);

        edt = DateTime.Now;
        edt1 = edt.AddDays(0).ToString("dd-MMM-yyyy 23:59:59");
        enddate = Convert.ToDateTime(edt1);

        //int get_month=Convert.ToInt32(dt.Month);
        //int get_year= Convert.ToInt32(dt.Year);
        //string start_date = get_month + "/" + "1" + "/" + get_year;
        //DateTime startdt = Convert.ToDateTime(start_date);
        //int get_lastdy_month =Convert.ToInt32(System.DateTime.DaysInMonth(get_year,get_month));
        //string end_date = get_month + "/" + get_lastdy_month + "/" + get_year;
        //DateTime enddt = Convert.ToDateTime(end_date);

        con.Open();
        SqlCommand cmd_get_Task = new SqlCommand("get_view_all_task", con);
        cmd_get_Task.CommandType = CommandType.StoredProcedure;
        cmd_get_Task.Parameters.Clear();
        cmd_get_Task.Parameters.AddWithValue("@startdate", startdate);
        cmd_get_Task.Parameters.AddWithValue("@enddate", enddate);
        cmd_get_Task.Parameters.AddWithValue("@loginid", Session["loginid"].ToString());

        SqlDataReader rdr1 = cmd_get_Task.ExecuteReader();

        while (rdr1.Read())
        {

            if (rdr1[7].ToString().Equals("U"))
            {



                strim += "<tr>";
                //strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                //strim += "<a href=admin_temp.aspx?parameter=" + rdr[0] + ">" + rdr[0].ToString() + "</a>";
                //strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr1[0];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr1[6];
                strim += "</td >";

                strim += "<td bgcolor='#FCFFD9' width='15%'>";
                DateTime x = Convert.ToDateTime(rdr1[4]);
                string dat = x.ToString("dd/MM/yyyy");
                string xy = x.ToLongTimeString();
                dat = dat + " " + xy;
                strim += dat;
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr1[5];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr1[1].ToString() + "[" + rdr1[2].ToString() + "]";
                strim += "</td >";

                strim += "<td align='left' width='Auto'  bgcolor='#FCFFD9'>";
                strim += "<a href=view_tasks.aspx?parameter=" + rdr1[0] + ">" + "View" + "</a>";
                strim += "</td >";


                //strim += "<td  bgcolor='#FCFFD9' align='center'>";


                //strim += "<a href=admin_edit_management.aspx?parameter='" + rdr["name"] + "'>" + rdr[0].ToString() + "</a>";

                //strim += "</td >";
                //strim += "</tr >";

            }
        }
        strim += "</table>";

        div_todays_task.InnerHtml = strim;

        rdr1.Close();
        con.Close();

        ////////////////////////////////////////// End todays task /////////////////////////////////////////////////////////////

        //////////////////////////////////////start for todo overdue //////////////////////////////////////////////////////////

        con.Open();
        SqlCommand cmd_todays_todo_id = new SqlCommand("SELECT Count(td.id) as cnt FROM t_m_todo as tm RIGHT OUTER JOIN t_d_todo as td ON tm.id = td.master_id LEFT OUTER JOIN t_m_login as l ON tm.assign_to = l.id WHERE td.status = 'U' AND td.tododate >='" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "' AND td.tododate <='" + enddate_overdue.ToString("dd-MMM-yyyy 23:59:59") + "' AND l.loginid='" + Session["loginid"] + "' ", con);
        int b = Convert.ToInt32(cmd_todays_todo_id.ExecuteScalar());
        int[] rowcount_todo = new int[b];
        DateTime[] dttm_todo = new DateTime[b];
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_todo_record = new SqlCommand("SELECT td.id,td.tododate FROM t_m_todo as tm RIGHT OUTER JOIN t_d_todo as td ON tm.id = td.master_id LEFT OUTER JOIN t_m_login as l ON tm.assign_to = l.id WHERE td.status = 'U' AND (td.tododate >= '" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "' AND td.tododate <= '" + enddate_overdue.ToString("dd-MMM-yyyy 23:59:59") + "') AND l.loginid = '" + Session["loginid"] + "' ", con);
        SqlDataReader dr_todo = cmd_get_todo_record.ExecuteReader();
        int xyt = 0;
        while (dr_todo.Read())
        {
            rowcount_todo[xyt] = Convert.ToInt32(dr_todo[0].ToString());
            dttm_todo[xyt] = Convert.ToDateTime(dr_todo[1].ToString());
            xyt = xyt + 1;
        }
        dr.Close();
        con.Close();


        for (int i = 0; i < rowcount_todo.Length; i++)
        {

            int sh_todo = 0;
            int sm_todo = 0;
            int h_todo = 0;
            int m_todo = 0;

            h_todo = dttm_todo[i].Hour;
            m_todo = dttm_todo[i].Minute;


            DateTime tms_todo = DateTime.Now;
            sh_todo = tms_todo.Hour;
            sm_todo = tms_todo.Minute;

            if (h_todo < sh_todo)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_update_overdue = new SqlCommand("update_todo_table_overdue", con);
                cmd_update_overdue.CommandType = CommandType.StoredProcedure;
                cmd_update_overdue.Parameters.Clear();
                cmd_update_overdue.Parameters.AddWithValue("@id", rowcount_todo[i]);
                cmd_update_overdue.ExecuteNonQuery();
                con.Close();

                DateTime dttms_todo;
                long _master_id;
                string _stats;
                int _levelid;
                string _remark;



                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_select_task = new SqlCommand("select id,master_id,tododate,status,levelid,remark from t_d_todo where id=" + rowcount_todo[i] + "", con);
                SqlDataReader dr_select_todo = cmd_select_task.ExecuteReader();
                dr_select_todo.Read();


                _master_id = Convert.ToInt64(dr_select_todo[1]);
                dttms_todo = Convert.ToDateTime(dr_select_todo[2]);
                _stats = dr_select_todo[3].ToString();
                _levelid = Convert.ToInt32(dr_select_todo[4]);
                _remark = dr_select_todo[5].ToString();

                dr_select_todo.Close();
                con.Close();


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_task = new SqlCommand("insert into t_m_todo_overdue values(" + rowcount_todo[i] + "," + _master_id + ",'" + dttms_todo + "','" + _stats + "'," + _levelid + ",'" + _remark + "')", con);
                cmd_save_task.ExecuteNonQuery();
                con.Close();

                //////////////////////////////////// coding for email /////////////////////////////////////// 


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_hod = new SqlCommand("select l.name as name,l.email_id from t_m_login as l,t_m_branch as b where b.name='" + Session["branch_name"].ToString() + "' and l.post=" + 6 + " and l.forign_id=b.manage_id ", con);
                SqlDataReader dr_get_email_id = cmd_get_hod.ExecuteReader();
                dr_get_email_id.Read();
                string hod = dr_get_email_id[0].ToString();
                string emailid = dr_get_email_id[1].ToString();
                con.Close();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_email_data = new SqlCommand("select tm.subject,tm.descp from t_m_todo as tm,t_d_todo as td where td.id=" + rowcount_todo[i] + " and td.master_id=tm.id", con);
                SqlDataReader dr_email_data = cmd_get_email_data.ExecuteReader();
                dr_email_data.Read();
                string subj = dr_email_data[0].ToString();
                string desc = dr_email_data[1].ToString();
                dr_email_data.Close();
                con.Close();

                //email obj_send_mail = new email();
                //obj_send_mail.MailSend(emailid, subj, desc, "");
                //obj_send_mail.MailSend();

                ////////////////////////////////// End of coding for email /////////////////////////////////////// 


            }

            else if (h_todo == sh_todo)
            {
                if (m_todo <= sm_todo)
                {

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_update_overdue = new SqlCommand("update_todo_table_overdue", con);
                    cmd_update_overdue.CommandType = CommandType.StoredProcedure;
                    cmd_update_overdue.Parameters.Clear();
                    cmd_update_overdue.Parameters.AddWithValue("@id", rowcount_todo[i]);
                    cmd_update_overdue.ExecuteNonQuery();
                    con.Close();

                    DateTime dttms_todo;
                    long _master_id;
                    string _stats;
                    int _levelid;
                    string _remark;



                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_select_task = new SqlCommand("select id,master_id,tododate,status,levelid,remark from t_d_todo where id=" + rowcount_todo[i] + "", con);
                    SqlDataReader dr_select_todo = cmd_select_task.ExecuteReader();
                    dr_select_todo.Read();


                    _master_id = Convert.ToInt64(dr_select_todo[1]);
                    dttms_todo = Convert.ToDateTime(dr_select_todo[2]);
                    _stats = dr_select_todo[3].ToString();
                    _levelid = Convert.ToInt32(dr_select_todo[4]);
                    _remark = dr_select_todo[5].ToString();

                    dr_select_todo.Close();
                    con.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_save_task = new SqlCommand("insert into t_m_todo_overdue values (" + rowcount_todo[i] + ",'" + _master_id + "','" + dttms_todo + "','" + _stats + "'," + _levelid + ",'" + _remark + "')", con);
                    cmd_save_task.ExecuteNonQuery();
                    con.Close();


                    //////////////////////////////////// coding for email /////////////////////////////////////// 

                   
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_hod = new SqlCommand("select l.name as name,l.email_id from t_m_login as l,t_m_branch as b where b.name='" + Session["branch_name"].ToString() + "' and l.post=" + 6 + " and l.forign_id=b.manage_id ", con);
                    SqlDataReader dr_get_email_id = cmd_get_hod.ExecuteReader();
                    dr_get_email_id.Read();
                    string hod = dr_get_email_id[0].ToString();
                    string emailid = dr_get_email_id[1].ToString();
                    con.Close();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_email_data = new SqlCommand("select tm.subject,tm.descp from t_m_todo as tm,t_d_todo as td where td.id=" + rowcount_todo[i] + " and td.master_id=tm.id", con);
                    SqlDataReader dr_email_data = cmd_get_email_data.ExecuteReader();
                    dr_email_data.Read();
                    string subj = dr_email_data[0].ToString();
                    string desc = dr_email_data[1].ToString();
                    dr_email_data.Close();
                    con.Close();

                    //email obj_send_mail = new email();
                    //obj_send_mail.MailSend(emailid, subj, desc, "");
                    //obj_send_mail.MailSend();

                    ////////////////////////////////// End of coding for email /////////////////////////////////////// 


                }
            }
        }
        //////////////////////////////////////////////////todo overdue complete /////////////////////////////////////
      
        ////////////////////////////////////// for todays todo /////////////////////////////////////////////////////////////

        strim = "";

        strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "TODO ID";
        strim += "</th>";

        strim += "<th width='200px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='70px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "End Time";
        strim += "</th>";

        strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Pr.";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Assigner";
        strim += "</th>";

        strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "View";
        strim += "</th>";


        strim += "</tr>";
        strim += "</thead>";


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        

        //DateTime dt = DateTime.Now;
        //int get_month = Convert.ToInt32(dt.Month);
        //int get_year = Convert.ToInt32(dt.Year);
        //string start_date = get_month + "/" + "1" + "/" + get_year;
        //DateTime startdt = Convert.ToDateTime(start_date);
        //int get_lastdy_month = Convert.ToInt32(System.DateTime.DaysInMonth(get_year, get_month));
        //string end_date = get_month + "/" + get_lastdy_month + "/" + get_year;
        //DateTime enddt = Convert.ToDateTime(end_date);

        con.Open();
        SqlCommand cmd_get_Todo = new SqlCommand("get_de_view_all_todo", con);
        cmd_get_Todo.CommandType = CommandType.StoredProcedure;
        cmd_get_Todo.Parameters.Clear();
        cmd_get_Todo.Parameters.AddWithValue("@startdate", startdate);
        cmd_get_Todo.Parameters.AddWithValue("@enddate", enddate);
        cmd_get_Todo.Parameters.AddWithValue("@loginid", Session["loginid"].ToString());
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
            //string _hour = dt1.Hour.ToString();

            //string _min = dt1.Minute.ToString();
            //string sec = "00";
            //string ampm = xy.Substring(Convert.ToInt32(xy.Length) - 2, 2);

            //if (ampm == "PM")
            //{
            //    _hour = (Convert.ToInt32(_hour) - 12).ToString();
            //}
            //if (Convert.ToInt32(_min.Length) == 1)
            //{
            //    _min = "0" + _min;
            //}
            //strim += (_hour + ":" + _min + ":" + sec + " " + ampm).ToString();
            strim += dt1.ToString();
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

        div_todays_todo.InnerHtml = strim;

        rdr.Close();
        con.Close();

        ////////////////////////////////////////// end todays todo /////////////////////////////////////////////////////////////


        

        ////////////////////////////for Assigned Task//////////////////////////////////////////////////////////////////////////

        strim = "";
        strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
        strim += "<thead>";
        strim += "<tr>";

        strim += "<th width='40px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Task ID";
        strim += "</th>";

        strim += "<th width='150px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Subject";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "End Time";
        strim += "</th>";

        strim += "<th width='50px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Pr.";
        strim += "</th>";

        strim += "<th width='100px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Assign To";
        strim += "</th>";

        strim += "<th width='25px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Post";
        strim += "</th>";

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Department";
        strim += "</th>";

        strim += "<th width='35px'align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "Branch";
        strim += "</th>";

        strim += "<th width='45px' align = 'left' bgcolor='#EEEEEE' style='fontcolor=#0000FF' style='color:#000000'" + ">";
        strim += "View / Cancel";
        strim += "</th>";

        strim += "</tr>";
        strim += "</thead>";


        dt = DateTime.Now;
        sdt = dt.ToString("dd-MMM-yyyy 00:00:00");
        startdate = Convert.ToDateTime(sdt);

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
        SqlCommand cmd_get_records = new SqlCommand("select count(id) as cnt from t_m_task where creator = " + get_id + "and status = 'U' and enddate >= '" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "'", con);
        int f = Convert.ToInt32(cmd_get_records.ExecuteScalar());
        int[] rowcount1 = new int[f];
        con.Close();


        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_record1 = new SqlCommand("select id as cnt from t_m_task where creator = " + get_id + "and status = 'U' and enddate >= '" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "'", con);
        SqlDataReader dr2 = cmd_get_record1.ExecuteReader();

        int xa = 0;
        while (dr2.Read())
        {
            rowcount1[xa] = Convert.ToInt32(dr2[0].ToString());
            xa = xa + 1;
        }
        dr2.Close();
        con.Close();

        // fill details section 

        for (int i = 0; i < rowcount1.Length; i++)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_assign_designation = new SqlCommand("select usertype from t_m_task where id = " + Convert.ToInt32(rowcount1[i]), con);
            string assign_type = cmd_get_assign_designation.ExecuteScalar().ToString();
            con.Close();

            if ((assign_type == "SRBMNG") || (assign_type == "SRMNG") || (assign_type == "MNG"))
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject from t_m_task as t, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.priority = p.id and t.id = " + rowcount1[i], con);
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

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
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
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],t.subject,d.dept_name from t_m_task as t,t_m_dept as d, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.dept = d.id and t.priority = p.id and t.id = " + rowcount1[i], con);
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

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
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
                SqlCommand cmd_get_info = new SqlCommand("select t.id,l.name,t.usertype,t.enddate,p.[desc],b.name ,t.subject from t_m_task as t,t_m_branch as b, t_m_login as l, t_m_priority as p where t.assign_to = l.id and t.branch = b.id and t.priority = p.id and t.id = " + rowcount1[i], con);
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
                    strim += dr_get_info[5].ToString();
                    strim += "</td >";

                    strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                    strim += "<a href = 'view_cancel_tasks.aspx?parameter= " + Convert.ToInt32(dr_get_info[0].ToString()) + " '> <img src = 'images/Cancel.gif'> </a>";
                    strim += "</td >";
                }
                con.Close();
            }
        }
        strim += "</table>";

        div_assigned_task.InnerHtml = strim;

        ////////////////////////////////////// overdue alert .///////////////////

        //con.Open();
        //SqlCommand cmd_todays_task_over = new SqlCommand("SELECT count(t.id) as cnt FROM t_m_task as t,t_m_login as l Where t.assign_to=l.id and t.enddate>='" + startdate.ToString("dd-MMM-yyyy 00:00:00") + "' and t.enddate<='" + enddate_overdue.ToString("dd-MMM-yyyy 23:59:59") + "' and t.status='O' and l.loginid='" + Session["loginid"] + "' ", con);
        //int o = Convert.ToInt32(cmd_todays_task_over.ExecuteScalar());
        //con.Close();
        //if (o > 0)
        //{
        //    lbl_overdue.Visible = true;
        //    lbl_overdue.Text = "(" + o + ")";
        //    img_overd_alert.Visible = true;
        //}
        //else
        //{
        //    lbl_overdue.Visible = false;
        //    img_overd_alert.Visible = false;
        //}
        con.Open();
        SqlCommand cmd_todays_task_over = new SqlCommand("SELECT count(t.id) as cnt FROM t_m_task_overdue as t,t_m_login as l Where t.assign_to=l.id  and l.loginid='" + Session["loginid"] + "' ", con);
        int o = Convert.ToInt32(cmd_todays_task_over.ExecuteScalar());
        con.Close();
        if (o > 0)
        {
            lbl_overdue.Visible = true;
            lbl_overdue.Text = "(" + o + ")";
            img_overd_alert.Visible = true;
        }
        else
        {
            lbl_overdue.Visible = false;
            img_overd_alert.Visible = false;
        }      
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("/WebTradeNet/todo/admin/Admin_Assign_todo.aspx?parameter=0");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/WebTradeNet/todo/admin/Admin_Assign_todo.aspx?parameter=1");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/WebTradeNet/todo/admin/view_all_todo.aspx?parameter=2");//assigned to me
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/WebTradeNet/todo/admin/view_all_todo.aspx?parameter=3");//assigned by me
    }
}
