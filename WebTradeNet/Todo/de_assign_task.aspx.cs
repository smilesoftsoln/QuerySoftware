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

public partial class Admin_Assign_todo : System.Web.UI.Page
{
  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
  string month_day = "";
  int get_max_id = 0;
  int get_max_todo_id_1 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

       //DatePicker1.SelectedDate = DateTime.Now;
        if (!IsPostBack)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
            con.Open();
            SqlCommand cmd_get_designation = new SqlCommand("admin_get_designation", con);
            cmd_get_designation.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_designation.ExecuteReader();
            dduserlist.Items.Clear();
            dduserlist.Items.Add("");
            while (dr.Read())
            {
                dduserlist.Items.Add(dr["designation"].ToString());
            }
            dduserlist.DataBind();
            con.Close();

            ddampmlist.Items.Clear();
            ddampmlist.Items.Add("AM");
            ddampmlist.Items.Add("PM"); 

            ddhourlist.Items.Clear(); 
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    ddhourlist.Items.Add("0" + i);
                }
                else
                {
                    ddhourlist.Items.Add(i.ToString());
                }
            }

            ddminlist.Items.Clear(); 
            for (int i = 1; i < 60; i++)
            {
                if (i < 10)
                {
                    ddminlist.Items.Add("0" + i);
                }
                else
                {
                    ddminlist.Items.Add(i.ToString()); 
                }
            }
        }
    }
    protected void dduserlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((dduserlist.SelectedItem.ToString() == "BE") || (dduserlist.SelectedItem.ToString() == "SRBMNG") || (dduserlist.SelectedItem.ToString() == "BH"))
        {
            lblcaption.Text = "Select Branch :- ";
            con.Open();
            SqlCommand cmd_get_branch = new SqlCommand("admin_get_branch", con);
            cmd_get_branch.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_branch = cmd_get_branch.ExecuteReader();

            dd_all_list.Items.Clear();
            dd_all_list.Items.Add("");


            while (dr_get_branch.Read())
            {
                dd_all_list.Items.Add(dr_get_branch[0].ToString());
            }

            dr_get_branch.Close();
            con.Close();
        }
        else if ((dduserlist.SelectedItem.ToString() == "DE") || (dduserlist.SelectedItem.ToString() == "HOD") || (dduserlist.SelectedItem.ToString() == "SRMNG"))
        {
            lblcaption.Text = "Select Department :- ";
            con.Open();
            SqlCommand cmd_get_dept = new SqlCommand("admin_get_dept_create_user", con);
            cmd_get_dept.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_dept = cmd_get_dept.ExecuteReader();

            dd_all_list.Items.Clear();
            dd_all_list.Items.Add("");
            while (dr_get_dept.Read())
            {
                dd_all_list.Items.Add(dr_get_dept[0].ToString());
            }
            dr_get_dept.Close();
            con.Close();
        }
        else if (dduserlist.SelectedItem.ToString() == "MNG")
        {
            lblcaption.Text = "Select Management :- ";
            con.Open();
            SqlCommand cmd_get_management = new SqlCommand("admin_get_all_management_inf", con);
            cmd_get_management.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_management = cmd_get_management.ExecuteReader();

            dd_all_list.Items.Clear();
            dd_all_list.Items.Add("");
            while (dr_get_management.Read())
            {
                dd_all_list.Items.Add(dr_get_management["name"].ToString());
            }

            dr_get_management.Close();
            con.Close(); 
        }
    }
    protected void dd_all_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dduserlist.Text == "HOD")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State== ConnectionState.Open)
                {
                    con.Close();
                }
                string hod_name;

                con.Open();
                SqlCommand cmd_get_hod_name = new SqlCommand("admin_get_hod_by_dept_id",con);
                cmd_get_hod_name.CommandType = CommandType.StoredProcedure;
                cmd_get_hod_name.Parameters.Clear();
                cmd_get_hod_name.Parameters.AddWithValue("@dept_name",dd_all_list.Text.Trim());
                hod_name = cmd_get_hod_name.ExecuteScalar().ToString();
                con.Close();

                ddemplist.Items.Clear();
                ddemplist.Items.Add("");

                ddemplist.Items.Add(hod_name);
            }
        }

        else if (dduserlist.Text == "BE")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_be = new SqlCommand("admin_get_be_by_branch_id", con);
                cmd_get_be.CommandType = CommandType.StoredProcedure;
                cmd_get_be.Parameters.Clear();
                cmd_get_be.Parameters.AddWithValue("@branch_name", dd_all_list.Text.ToString());
                SqlDataReader dr_be = cmd_get_be.ExecuteReader();
                ddemplist.Items.Clear();
                while(dr_be.Read())
                {
                    ddemplist.Items.Add(dr_be[0].ToString());
                }
                dr_be.Close();
                con.Close();               
            }
        }

        else if (dduserlist.Text == "BH")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_bhead = new SqlCommand("admin_get_bhead_by_branch_id", con);
                cmd_get_bhead.CommandType = CommandType.StoredProcedure;
                cmd_get_bhead.Parameters.Clear();
                cmd_get_bhead.Parameters.AddWithValue("@branch_name", dd_all_list.Text.ToString());
                SqlDataReader dr_bhead = cmd_get_bhead.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_bhead.Read())
                {
                    ddemplist.Items.Add(dr_bhead[0].ToString());
                }
                dr_bhead.Close();
                con.Close();
            }
        }


        else if (dduserlist.Text == "DE")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_demp = new SqlCommand("admin_get_DE_by_dept_id", con);
                cmd_get_demp.CommandType = CommandType.StoredProcedure;
                cmd_get_demp.Parameters.Clear();
                cmd_get_demp.Parameters.AddWithValue("@dept_name", dd_all_list.Text.ToString());
                SqlDataReader dr_demp = cmd_get_demp.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_demp.Read())
                {
                    ddemplist.Items.Add(dr_demp[0].ToString());
                }
                dr_demp.Close();
                con.Close();
            }
        }


        else if (dduserlist.Text == "MNG")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_mng = new SqlCommand("admin_get_MNG_by_mngmnt_id", con);
                cmd_get_mng.CommandType = CommandType.StoredProcedure;
                cmd_get_mng.Parameters.Clear();
                cmd_get_mng.Parameters.AddWithValue("@mngmnt_name", dd_all_list.Text.ToString());
                SqlDataReader dr_mng = cmd_get_mng.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_mng.Read())
                {
                    ddemplist.Items.Add(dr_mng[0].ToString());
                }
                dr_mng.Close();
                con.Close();
            }
        }

        else if (dduserlist.Text == "SRMNG")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_srmng = new SqlCommand("admin_get_srmng_by_dept_id", con);
                cmd_get_srmng.CommandType = CommandType.StoredProcedure;
                cmd_get_srmng.Parameters.Clear();
                cmd_get_srmng.Parameters.AddWithValue("@dept_name", dd_all_list.Text.ToString());
                SqlDataReader dr_srmng = cmd_get_srmng.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_srmng.Read())
                {
                    ddemplist.Items.Add(dr_srmng[0].ToString());
                }
                dr_srmng.Close();
                con.Close();
            }
        }

        else if (dduserlist.Text == "SRBMNG")
        {
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //string branch_name;

                con.Open();
                SqlCommand cmd_get_srbrmng = new SqlCommand("admin_get_srbrmng_by_branch_id", con);
                cmd_get_srbrmng.CommandType = CommandType.StoredProcedure;
                cmd_get_srbrmng.Parameters.Clear();
                cmd_get_srbrmng.Parameters.AddWithValue("@branch_name", dd_all_list.Text.ToString());
                SqlDataReader dr_srbrmng = cmd_get_srbrmng.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_srbrmng.Read())
                {
                    ddemplist.Items.Add(dr_srbrmng[0].ToString());
                }
                dr_srbrmng.Close();
                con.Close();
            }
        }
    }

    protected void ddtodotype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddselectday.Items.Clear();
            if (ddtodotype.SelectedItem.Text == "Daily")
            {
                ddselectday.Visible = false;
            }
       
            else if (ddtodotype.SelectedItem.Text == "Weekly")
            {
                ddselectday.Visible = true;
            //  ddselectday.Items.Clear();
                             
                ddselectday.Items.Add("Monday");
                ddselectday.Items.Add("Tuesday");
                ddselectday.Items.Add("Wednesday");
                ddselectday.Items.Add("Thursday");
                ddselectday.Items.Add("Friday");
                ddselectday.Items.Add("Saturday");              
            }
            else if (ddtodotype.SelectedItem.Text == "Monthly")
            {
                ddselectday.Visible = true;
              //  ddselectday.Items.Clear();                                            
                for (int i = 1; i <= 30; i++)
                    {
                        if (i < 10)
                        {
                            ddselectday.Items.Add("0" + i.ToString());
                        }
                        else
                        {
                            ddselectday.Items.Add(i.ToString());
                        }
                    }                     
            }        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        int get_max_todo_id_1 = 0;
        con.Open();
        SqlCommand cmd_get_max_todo_id = new SqlCommand("select isnull(max(id),0) as maxid from t_m_todo", con);
        get_max_todo_id_1 = Convert.ToInt32(cmd_get_max_todo_id.ExecuteScalar())+1;
        con.Close();


       

        string _hour = ddhourlist.Text;
        string _min = ddminlist.Text;
        string sec = "00";
        string _ampm = ddampmlist.Text;
        string get_date = DatePicker1.SelectedDate.ToShortDateString() + " " + _hour + ":" + _min + ":" + sec + " " + _ampm;
        
        DateTime final_date = Convert.ToDateTime(get_date);              
        
      

        if (DatePicker1.SelectedDate.ToString() == "1/1/0001 12:00:00 AM")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select End Date..!')</script>");
            DatePicker1.Focus(); 
            return;
        }
        else if (dduserlist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select User Type..!')</script>");
            dduserlist.Focus(); 
            return;
        }
        else if (dd_all_list.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select Department or Branch or Management..!')</script>");
            dd_all_list.Focus(); 
            return;
        }
        else if (ddemplist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select Employee..!')</script>");
            ddemplist.Focus(); 
            return;
        }
        else if (txtsubject.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Subject for TODO..!')</script>");
            txtsubject.Focus();
            return; 
        }
        else if(FreeTextBox1.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Description for TODO..!')</script>");
            FreeTextBox1.Focus();
            return; 
        }
        else
        {
            string  enddatetime;
            enddatetime = Convert.ToString(DatePicker1.SelectedDate);
            enddatetime = Convert.ToString(DatePicker1.SelectedDateString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            } 

            con.Open();
            SqlCommand cmd_assign_to_do = new SqlCommand("admin_assign_todo",con);
            cmd_assign_to_do.CommandType = CommandType.StoredProcedure;
            cmd_assign_to_do.Parameters.Clear();
            cmd_assign_to_do.Parameters.AddWithValue("@enddate", final_date);
           // cmd_assign_to_do.Parameters.AddWithValue("@endtime",ddhourlist.Text +":" + ddminlist.Text + ":00" + ddampmlist.Text);
            cmd_assign_to_do.Parameters.AddWithValue("@usertype",dduserlist.Text.ToString());
            cmd_assign_to_do.Parameters.AddWithValue("@br_dept",dd_all_list.Text);
            cmd_assign_to_do.Parameters.AddWithValue("@assign_to", ddemplist.Text.ToString());

            if (chkhigh.Checked)
            {
                cmd_assign_to_do.Parameters.AddWithValue("@priority", 2);
            }
            else
            {
                cmd_assign_to_do.Parameters.AddWithValue("@priority", 1);
            }

            cmd_assign_to_do.Parameters.AddWithValue("@type", Convert.ToInt32(ddtodotype.SelectedValue));

            if (Convert.ToInt32( ddtodotype.SelectedValue) == 1)
            {
                cmd_assign_to_do.Parameters.AddWithValue("@day_month", 0);

            }
            else if (Convert.ToInt32(ddtodotype.SelectedValue) == 2)
            {
                cmd_assign_to_do.Parameters.AddWithValue("@day_month", ddselectday.Text.ToString());
            }
            else if (Convert.ToInt32(ddtodotype.SelectedValue) == 3)
            {
                cmd_assign_to_do.Parameters.AddWithValue("@day_month", ddselectday.Text.ToString());
            }

            cmd_assign_to_do.Parameters.AddWithValue("@subject", txtsubject.Text.ToString());
            cmd_assign_to_do.Parameters.AddWithValue("@descp", FreeTextBox1.Text.ToString());

            cmd_assign_to_do.ExecuteNonQuery();
            con.Close();

             
            
            // fill the t_d_todo in short

            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }

            // get max id ;
           

            DateTime startdate = DateTime.Now;
            DateTime enddate = final_date;
            System.TimeSpan datediff = enddate.Subtract(startdate);
            int get_days = Convert.ToInt32(datediff.Days)+2;

            if (ddtodotype.Text == "1")
            {

                for (int i = 1; i <= get_days; i++)
                {

                    if (startdate.DayOfWeek.ToString() == "Sunday")
                    {

                    }
                    else
                    {

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        int check = 0;
                        con.Open();
                        string xy = startdate.ToString("dd/MM/yyyy");
                        SqlCommand cmd_get_id = new SqlCommand("Select id from t_m_holidays where holiday='" + xy + "'", con);
                        check = Convert.ToInt32(cmd_get_id.ExecuteScalar());
                        con.Close();

                        if (check == 0)
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            
                            con.Open();
                            SqlCommand cmd_get_t_d_to_max_id = new SqlCommand("select isnull(max(id),0)+1 as maxid from t_d_todo", con);
                            get_max_id = Convert.ToInt32(cmd_get_t_d_to_max_id.ExecuteScalar());
                            con.Close();

                            ////if (con.State == ConnectionState.Open)
                            ////{
                            ////    con.Close();
                            ////}
                            
                            ////con.Open();
                            ////SqlCommand cmd_get_max_todo_id_1 = new SqlCommand("select max(id) from t_m_todo", con);
                            ////get_max_todo_id_1 = Convert.ToInt32(cmd_get_max_todo_id_1.ExecuteScalar()) + 1;
                            ////con.Close();


                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_save_todo_details = new SqlCommand("insert into t_d_todo values(" + get_max_id + "," + get_max_todo_id_1 + ",'" + startdate + "','U'," + 1 + ",'x')", con);
                            cmd_save_todo_details.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    DateTime tmp_start_date;
                    tmp_start_date = startdate.AddDays(1);
                    startdate = tmp_start_date;
                } 
            }
            else if (ddtodotype.Text == "2")
            {
                DateTime Final_date_for_week = Convert.ToDateTime("01/02/2012");
                DateTime get_weekly_date = Convert.ToDateTime("01/02/2012");
                DateTime temp_weekly_date;
                temp_weekly_date = startdate;              

               

                for (int i = 0; i < 10; i++)
                {
                   string get_week_day = temp_weekly_date.DayOfWeek.ToString();  //////Sunday

                   if (get_week_day == ddselectday.Text.ToString())
                   {
                       get_weekly_date = temp_weekly_date;
                       Final_date_for_week = temp_weekly_date;
                       //   temp_weekly_date = Convert.ToDateTime("01/02/2012");
                       break;
                   }
                   else
                   {
                       DateTime tmp_start_date_1;
                       tmp_start_date_1 = temp_weekly_date.AddDays(1);
                       temp_weekly_date = tmp_start_date_1;
                   }

                }
                        int a=0;
                        int x =Convert.ToInt32( get_days / 7);
                        for ( a = 1; a <= x; a++)
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            int check = 0;
                            con.Open();
                            string xy_weekly = Final_date_for_week.ToString("dd/MM/yyyy");
                            SqlCommand cmd_get_weekly_id = new SqlCommand("Select id from t_m_holidays where holiday='" + xy_weekly + "'", con);
                            check = Convert.ToInt32(cmd_get_weekly_id.ExecuteScalar());
                            con.Close();

                            if (check == 0)
                            {

                                if (con.State == ConnectionState.Open)
                                {
                                    con.Close();
                                }

                                con.Open();
                                SqlCommand cmd_get_t_d_to_max_id = new SqlCommand("select isnull(max(id),0)+1 as maxid from t_d_todo", con);
                                get_max_id = Convert.ToInt32(cmd_get_t_d_to_max_id.ExecuteScalar());
                                con.Close();


                                if (con.State == ConnectionState.Open)
                                    {
                                        con.Close();
                                    }
                                    con.Open();
                                    SqlCommand cmd_save_todo_details = new SqlCommand("insert into t_d_todo values(" + get_max_id + "," + get_max_todo_id_1 + ",'" + Final_date_for_week + "','U'," + 1 + ",'x')", con);
                                    cmd_save_todo_details.ExecuteNonQuery();
                                    con.Close();


                                    DateTime tmp_start_date_7;                                    
                                    tmp_start_date_7 = get_weekly_date.AddDays(7);
                                    get_weekly_date = tmp_start_date_7; 
                                    Final_date_for_week = tmp_start_date_7;
                            }
                            else
                            {
                                DateTime tmp_start_date_2;
                                tmp_start_date_2 = Final_date_for_week.AddDays(1);
                                Final_date_for_week = tmp_start_date_2;
                                a = a - 1;

                                if (Final_date_for_week.DayOfWeek.ToString() == "Sunday")
                                {
                                    DateTime tmp_start_date_9;
                                    tmp_start_date_9 = Final_date_for_week.AddDays(1);
                                    Final_date_for_week = tmp_start_date_9;                                   
                                }
                                else
                                {

                                }
                            }                     
     //break;
                    }              
            }
            else if(ddtodotype.Text=="3")
            {
                    DateTime Final_date_for_monthly = Convert.ToDateTime("01/02/2012");
                    DateTime get_monthly_date = Convert.ToDateTime("01/02/2012");
                    DateTime temp_monthly_date;
                    temp_monthly_date = startdate;

                    string mont = DateTime.Now.Month.ToString();
                    string yer = DateTime.Now.Year.ToString();

                    Final_date_for_monthly = Convert.ToDateTime(mont + "/" + ddselectday.Text + "/" + yer + " " + _hour + ":" + _min + ":" + sec + " " + _ampm);
                    get_monthly_date = Final_date_for_monthly;

                    int a = 0;
                    int x = Convert.ToInt32(get_days / 30);

                    for (a = 1; a <= x; a++)
                    {

                        if (Final_date_for_monthly.DayOfWeek.ToString() == "Sunday")
                        {
                            DateTime tmp_start_month_9;
                            tmp_start_month_9 = Final_date_for_monthly.AddDays(1);
                            Final_date_for_monthly = tmp_start_month_9;
                        }

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        int check_m = 0;
                        con.Open();
                        string xy_Monthly = Final_date_for_monthly.ToString("dd/MM/yyyy");
                        SqlCommand cmd_get_Monthly_id = new SqlCommand("Select id from t_m_holidays where holiday='" + xy_Monthly + "'", con);
                        check_m = Convert.ToInt32(cmd_get_Monthly_id.ExecuteScalar());
                        con.Close();

                        if (check_m == 0)
                        {

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }

                            con.Open();
                            SqlCommand cmd_get_t_d_to_max_id = new SqlCommand("select isnull(max(id),0)+1 as maxid from t_d_todo", con);
                            get_max_id = Convert.ToInt32(cmd_get_t_d_to_max_id.ExecuteScalar());
                            con.Close();


                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_save_todo_details = new SqlCommand("insert into t_d_todo values(" + get_max_id + "," + get_max_todo_id_1 + ",'" + Final_date_for_monthly + "','U'," + 1 + ",'x')", con);
                            cmd_save_todo_details.ExecuteNonQuery();
                            con.Close();


                            DateTime tmp_start_month;
                            tmp_start_month = get_monthly_date.AddMonths(1);
                            get_monthly_date = tmp_start_month;
                            Final_date_for_monthly = tmp_start_month;

                            ////if (Final_date_for_monthly.DayOfWeek.ToString() == "Sunday")
                            ////{
                            ////    DateTime tmp_start_month_1;
                            ////    tmp_start_month_1 = Final_date_for_monthly.AddDays(1);
                            ////    Final_date_for_monthly = tmp_start_month_1;
                            ////}

                        }
                        else
                        {
                            DateTime tmp_start_month_2;
                            tmp_start_month_2 = Final_date_for_monthly.AddDays(1);
                            Final_date_for_monthly = tmp_start_month_2;
                            a = a - 1;

                            ////if (Final_date_for_monthly.DayOfWeek.ToString() == "Sunday")
                            ////{
                            ////    DateTime tmp_start_month_9;
                            ////    tmp_start_month_9 = Final_date_for_monthly.AddDays(1);
                            ////    Final_date_for_monthly = tmp_start_month_9;
                            ////}
                            ////else
                            ////{

                            ////}
                        }
                        //break;
                    }
             }          
                Response.Write(@"<script language='javascript'>alert('TODO Assigned Successfully..!')</script>");
                Response.Redirect("Admin_Assign_todo.aspx");
        } 
    
    }
}
