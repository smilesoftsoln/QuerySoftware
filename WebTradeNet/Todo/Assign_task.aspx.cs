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
using System.Net;
using System.Net.Mail;
public partial class Admin_Assign_todo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    SqlConnection querycon = new SqlConnection(ConfigurationManager.ConnectionStrings["tn_CAREE_bitaConnectionString2"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        lblloginer.Text = Session["loginer"].ToString();
        if (!IsPostBack)
        {
            //DatePicker1.SelectedDate = DateTime.Now;

            CalDateExtender.StartDate = DateTime.Today;
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
            for (int i = 0; i < 60; i++)
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

            if (Session["type"].ToString() == "MNG")
            {
                
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear(); 
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Management :- ";
                    // get management name
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close(); 
                    }                    
                    dd_all_list.Items.Clear();  
                    con.Open();
                    SqlCommand cmd_get_management = new SqlCommand("select name from t_m_management where id="+ Convert.ToInt32(Session["manage_id"]),con);
                    dd_all_list.Items.Add (cmd_get_management.ExecuteScalar().ToString());
                    con.Close();

                    ddemplist.Items.Clear(); 
                    ddemplist.Items.Add(Session["loginer"].ToString());

                }
                else
                {
                    dduserlist.Items.Add("");
                   dduserlist.Items.Add("SRMNG");
                    dduserlist.Items.Add("HOD");
                    dduserlist.Items.Add("DE");
                    //dduserlist.Items.Add("SRBMNG");
                    dduserlist.Items.Add("BH");
                    dduserlist.Items.Add("BE");
                }
            }
            else if (Session["type"].ToString() == "SRMNG")
            {
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear();
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Management Name :- ";
                    dd_all_list.Items.Clear();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_get_management_name = new SqlCommand("select name from t_m_management where id = " + Convert.ToInt32(Session["manage_id"].ToString()), con);
                    dd_all_list.Items.Add(cmd_get_management_name.ExecuteScalar().ToString());
                    con.Close();

                    ddemplist.Items.Clear();
                    ddemplist.Items.Add(Session["loginer"].ToString());
                }
                else
                {
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("HOD");
                    dduserlist.Items.Add("DE");
                }
            }
            else if (Session["type"].ToString() == "HOD")
            {                
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear(); 
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Department :- ";
                    dd_all_list.Items.Clear();
                    dd_all_list.Items.Add(Session["dept_name"].ToString());

                    ddemplist.Items.Clear();
                    ddemplist.Items.Add(Session["loginer"].ToString()); 
                }
                else
                {
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("DE");
                }
                
            }
            else if (Session["type"].ToString() == "DE")
            {
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear(); 
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Department Name :- ";
                    dd_all_list.Items.Clear();
                    dd_all_list.Items.Add(Session["dept_name"].ToString());

                    ddemplist.Items.Clear(); 
                    ddemplist.Items.Add(Session["loginer"].ToString());
                }               
            }
            else if (Session["type"].ToString() == "SRBMNG")
            {
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear();
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Management Name :- ";
                    dd_all_list.Items.Clear();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close(); 
                    }
                    con.Open();
                    SqlCommand cmd_get_management_name = new SqlCommand("select name from t_m_management where id = " + Convert.ToInt32(Session["manage_id"].ToString()) ,con);
                    dd_all_list.Items.Add(cmd_get_management_name.ExecuteScalar().ToString()); 
                    con.Close(); 

                    ddemplist.Items.Clear();
                    ddemplist.Items.Add(Session["loginer"].ToString());
                }        
                else
                {
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("BH");
                    dduserlist.Items.Add("BE");
                }
            }
            else if (Session["type"].ToString() == "BH")
            {
                lblcaption.Text = "Branch :- ";
                if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                {
                    dduserlist.Items.Clear(); 
                    dduserlist.Items.Add(Session["type"].ToString());

                    lblcaption.Text = "Branch Name :- ";
                    dd_all_list.Items.Clear();
                    dd_all_list.Items.Add(Session["branch_name"].ToString());

                    ddemplist.Items.Clear();
                    ddemplist.Items.Add(Session["loginer"].ToString() ); 
                }
                else
                {
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("BE");
                }
            }
            else if (Session["type"].ToString() == "BE")
            {
                 lblcaption.Text = "Branch :- ";
                 if (Convert.ToInt32(Request.QueryString["parameter"]) == 1)
                 {
                     dduserlist.Items.Clear(); 
                     dduserlist.Items.Add(Session["type"].ToString());

                     lblcaption.Text = "Branch Name :- ";

                     dd_all_list.Items.Clear();
                     dd_all_list.Items.Add(Session["branch_name"].ToString());

                     ddemplist.Items.Clear();
                     ddemplist.Items.Add(Session["loginer"].ToString()); 
                 }                
            }
        }
    }
    private string get_management_name(string manage_id)
    {
        string get_name = "";
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd_get_management_name = new SqlCommand("select name from t_m_management where id =" + Convert.ToInt32(Session["manage_id"]),con);        
        get_name = cmd_get_management_name.ExecuteScalar().ToString() ;
        con.Close();
        return get_name;
    }

    protected void dduserlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["type"].ToString() == "MNG")
        {
            if (dduserlist.Text == "SRMNG")
            {



                con.Open();
                SqlCommand cmd_get_be = new SqlCommand("select name from t_m_login where post = 7 ", con);
                SqlDataReader dr_get_be = cmd_get_be.ExecuteReader();

                ddemplist.Items.Clear();
                ddemplist.Items.Add("");

                while (dr_get_be.Read())
                {
                    ddemplist.Items.Add(dr_get_be[0].ToString());
                }
                dr_get_be.Close();
                con.Close();
                //lblcaption.Text = "Select Department :- ";
                //dd_all_list.Items.Clear();
                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //con.Open();
                //SqlCommand cmd_get_dept = new SqlCommand("select dept_name from t_m_dept where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " and hod_id !=0 order by dept_name", con);
                //SqlDataReader dr_dept1 = cmd_get_dept.ExecuteReader();
                //dd_all_list.Items.Clear();
                //dd_all_list.Items.Add("");

                //while (dr_dept1.Read())
                //{
                //    dd_all_list.Items.Add(dr_dept1[0].ToString());
                //}
                //dr_dept1.Close();
                //con.Close();  


                //lblcaption.Text = "Management :- ";
                //dd_all_list.Items.Clear(); 
                //dd_all_list.Items.Add(get_management_name(Session["manage_id"].ToString() ));

                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //con.Open();
                //SqlCommand cmd_get_srmng_name = new SqlCommand("select name from t_m_login where post = 7 and forign_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                //SqlDataReader dr_srmng = cmd_get_srmng_name.ExecuteReader();
                //ddemplist.Items.Clear();
                //ddemplist.Items.Add("");

                //while (dr_srmng.Read())
                //{
                //    ddemplist.Items.Add(dr_srmng[0].ToString());
                //}
                //dr_srmng.Close(); 
                //con.Close(); 
            }

            else if(dduserlist.Text == "HOD")
            {
               
                lblcaption.Text = "Select Department :- ";
                dd_all_list.Items.Clear();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept_name = new SqlCommand("select dept_name from t_m_dept where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " and hod_id !=0 order by dept_name", con);
                SqlDataReader dr_dept = cmd_get_dept_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_dept.Read())
                {
                    dd_all_list.Items.Add(dr_dept[0].ToString());
                }
                dr_dept.Close();
                con.Close();  
            }
            else if (dduserlist.Text == "DE")
            {
                lblcaption.Text = "Select Department :- ";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept_name = new SqlCommand("select dept_name from t_m_dept where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by dept_name", con);
                SqlDataReader dr_dept = cmd_get_dept_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_dept.Read())
                {
                    dd_all_list.Items.Add(dr_dept[0].ToString());
                }
                dr_dept.Close();
                con.Close();  

            }
            else if (dduserlist.Text == "SRBMNG")
            {

                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Branch :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch_name = new SqlCommand("select name from t_m_branch where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                SqlDataReader dr_branch = cmd_get_branch_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_branch.Read())
                {
                    dd_all_list.Items.Add(dr_branch[0].ToString());
                }
                dr_branch.Close();
                con.Close();

                //lblcaption.Text = "Management :- ";
                //dd_all_list.Items.Clear();
                //dd_all_list.Items.Add(get_management_name(Session["manage_id"].ToString()));

                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //con.Open();
                //SqlCommand cmd_get_srbmng_name = new SqlCommand("select name from t_m_login where post = 8 and forign_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                //SqlDataReader dr_srbmng = cmd_get_srbmng_name.ExecuteReader();
                //ddemplist.Items.Clear();
                //ddemplist.Items.Add("");

                //while (dr_srbmng.Read())
                //{
                //    ddemplist.Items.Add(dr_srbmng[0].ToString());
                //}
                //dr_srbmng.Close();
                //con.Close(); 

            }
            else if (dduserlist.Text == "BH")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Branch :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch_name = new SqlCommand("select name from t_m_branch where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + "and bh_id != 0 order by name", con);
                SqlDataReader dr_branch = cmd_get_branch_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_branch.Read())
                {
                    dd_all_list.Items.Add(dr_branch[0].ToString());
                }
                dr_branch.Close();
                con.Close(); 




            }
            else if (dduserlist.Text == "BE")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Branch :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch_name = new SqlCommand("select name from t_m_branch where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                SqlDataReader dr_branch = cmd_get_branch_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_branch.Read())
                {
                    dd_all_list.Items.Add(dr_branch[0].ToString());
                }
                dr_branch.Close();
                con.Close(); 
            }
        }
        else if (Session["type"].ToString() == "SRMNG")
        {
            if(dduserlist.Text == "HOD")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Department :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept_name = new SqlCommand("select dept_name from t_m_dept where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + "and hod_id != 0 order by dept_name", con);
                SqlDataReader dr_dept = cmd_get_dept_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_dept.Read())
                {
                    dd_all_list.Items.Add(dr_dept[0].ToString());
                }
                dr_dept.Close();
                con.Close();  
            }
            else if (dduserlist.Text == "DE")
            {
                lblcaption.Text = "Select Department :- ";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept_name = new SqlCommand("select dept_name from t_m_dept where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by dept_name", con);
                SqlDataReader dr_dept = cmd_get_dept_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_dept.Read())
                {
                    dd_all_list.Items.Add(dr_dept[0].ToString());
                }
                dr_dept.Close();
                con.Close();  
            } 
        }
        else if (Session["type"].ToString() == "HOD")
        {
            lblcaption.Text = "Department Name :- ";

            dd_all_list.Items.Clear();
            dd_all_list.Items.Add(Session["dept_name"].ToString());

            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
            ddemplist.Items.Clear();
            ddemplist.Items.Add(""); 
            con.Open();
            SqlCommand cmd_get_dept = new SqlCommand("select name from t_m_login where post = 2 and forign_id = " + Convert.ToInt32(Session["dept_id"].ToString()),con);
            SqlDataReader dr_get_dept = cmd_get_dept.ExecuteReader();
            while (dr_get_dept.Read())
            {
                ddemplist.Items.Add(dr_get_dept[0].ToString()); 
            }
            dr_get_dept.Close(); 
            con.Close();                
        
           
        }       
        else if (Session["type"].ToString() == "SRBMNG")
        {
            if (dduserlist.Text == "BH")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Branch :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch_name = new SqlCommand("select name from t_m_branch where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + "and bh_id != 0 order by name", con);
                SqlDataReader dr_branch = cmd_get_branch_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_branch.Read())
                {
                    dd_all_list.Items.Add(dr_branch[0].ToString());
                }
                dr_branch.Close();
                con.Close();


            }
            else if (dduserlist.Text == "BE")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Branch :- ";

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch_name = new SqlCommand("select name from t_m_branch where manage_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                SqlDataReader dr_branch = cmd_get_branch_name.ExecuteReader();
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                while (dr_branch.Read())
                {
                    dd_all_list.Items.Add(dr_branch[0].ToString());
                }
                dr_branch.Close();
                con.Close();
            }
        }
        else if (Session["type"].ToString() == "BH")
        {
            lblcaption.Text = "Branch Name :- ";

            dd_all_list.Items.Clear();
            dd_all_list.Items.Add(Session["branch_name"].ToString());

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            ddemplist.Items.Clear();
            ddemplist.Items.Add("");
            con.Open();
            SqlCommand cmd_get_be = new SqlCommand("select name from t_m_login where post = 1 and forign_id = " + Convert.ToInt32(Session["branch_id"].ToString()), con);
            SqlDataReader dr_get_be = cmd_get_be.ExecuteReader();
            while (dr_get_be.Read())
            {
                ddemplist.Items.Add(dr_get_be[0].ToString());
            }
            dr_get_be.Close();
            con.Close();         
        }
        dd_all_list.Items.Insert(0, " ");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if ((Convert.ToInt32(ddhourlist.SelectedItem.Text) > 6) && (ddampmlist.SelectedItem.Text=="PM"))
        {
            Response.Write(@"<script language='javascript'>alert('Invalid Time...!')</script>");
            ddhourlist.Focus();
            return;
        }
        else if ((Convert.ToInt32(ddhourlist.SelectedItem.Text) < 10) && (ddampmlist.SelectedItem.Text == "AM") )
        {
            Response.Write(@"<script language='javascript'>alert('Invalid Time...!')</script>");
            ddhourlist.Focus();
            return;
        }
        else if ((Convert.ToInt32(ddhourlist.SelectedItem.Text) == 12) && (ddampmlist.SelectedItem.Text == "AM"))
        {
            Response.Write(@"<script language='javascript'>alert('Invalid Time...!')</script>");
            ddhourlist.Focus();
            return;
        }

        
        if (dduserlist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select User Type!')</script>");
            dduserlist.Focus(); 
            return;
        }
        else if (dd_all_list.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select " + lblcaption.Text + " !')</script>");
            dd_all_list.Focus(); 
            return;
        }
        else if (ddemplist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select Employee !')</script>");
            ddemplist.Focus(); 
            return;
        }
        else if (txtsubject.Text.Trim().ToString() == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Subject !')</script>");
            txtsubject.Focus();
            return;
        }
        else if (FreeTextBox1.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Enter Description !')</script>");
           // FreeTextBox1.Focus = true;
            return;
        }
        else 
        {
            int max_id = 0;
            DateTime enddate ;
            int creator = 0;
            int assign_id = 0;
            string usertype = "";
            int branch_id = 0;
            int dept_id = 0;
            int priority = 1;

            if (chknormal.Checked)
            {
                priority = 2;
            }
            else if (chkhigh.Checked)
            {
                priority = 1;
            }

            string stts = "U";
            string _hour = ddhourlist.Text;
            string _min = ddminlist.Text;
            string sec = "00";
            string _ampm = ddampmlist.Text;
            string get_date = TextBox1.Text + " " + _hour + ":" + _min + ":" + sec + " " + _ampm;

            enddate = Convert.ToDateTime(get_date);  


                if(Session["type"].ToString() == dduserlist.Text.ToString())
                {
                    if ((dduserlist.Text == "MNG") || (dduserlist.Text == "SRMNG") || (dduserlist.Text == "SRBMNG"))
                    {
                        if (con.State == ConnectionState.Open )
                        {
                            con.Close(); 
                        }
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_creator_id = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                        creator = Convert.ToInt32(cmd_get_creator_id.ExecuteScalar());
                        assign_id = creator; 
                        con.Close();
                        usertype = Session["type"].ToString();
                    }                    
                    else if ((dduserlist.Text == "HOD") || (dduserlist.Text == "DE"))
                    {                        
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_creator_id = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                        creator = Convert.ToInt32(cmd_get_creator_id.ExecuteScalar());
                        assign_id = creator;
                        con.Close();
                        usertype = Session["type"].ToString();


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_dept_id = new SqlCommand("select id from t_m_dept where dept_name = '" + dd_all_list.Text.ToString() + "'", con);
                        dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());                        
                        con.Close();

                    }  
                    else if ((dduserlist.Text == "BH") || (dduserlist.Text == "BE"))
                    {
                       
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_creator_id = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                        creator = Convert.ToInt32(cmd_get_creator_id.ExecuteScalar());
                        assign_id = creator;
                        con.Close();
                        usertype = Session["type"].ToString();


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_branch_id = new SqlCommand("select id from t_m_branch where name = '" + dd_all_list.Text.ToString() + "'", con);
                        branch_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());
                        con.Close();
                    }                   
                }
                else
                {
                    if ((dduserlist.Text == "SRMNG") || (dduserlist.Text == "SRBMNG"))
                    {
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open(); 
                        SqlCommand cmd_get_creator = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString()  + "'",con ); 
                        creator = Convert.ToInt32(cmd_get_creator.ExecuteScalar());
                        con.Close(); 

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_assign_to_id = new SqlCommand("select id from t_m_login where name = '" + ddemplist.Text + "'", con);
                        assign_id = Convert.ToInt32(cmd_get_assign_to_id.ExecuteScalar());
                        con.Close();                        

                        usertype = dduserlist.Text.ToString();                        
                    }
                    else if ((dduserlist.Text == "HOD") || (dduserlist.Text == "DE"))
                    {
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_creator = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                        creator = Convert.ToInt32(cmd_get_creator.ExecuteScalar());
                        con.Close();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_assign_to_id = new SqlCommand("select id from t_m_login where name = '" + ddemplist.Text + "'", con);
                        assign_id = Convert.ToInt32(cmd_get_assign_to_id.ExecuteScalar());
                        con.Close();


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_dept_id = new SqlCommand("select id from t_m_dept where dept_name = '" + dd_all_list.Text.ToString() + "'", con);
                        dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());
                        con.Close();

                        usertype = dduserlist.Text.ToString();
                    }                   
                    else if ((dduserlist.Text == "BH") || (dduserlist.Text == "BE"))
                    {
                        max_id = get_max_id();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open(); 
                        SqlCommand cmd_get_creator = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                        creator = Convert.ToInt32(cmd_get_creator.ExecuteScalar());
                        con.Close();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_assign_to_id = new SqlCommand("select id from t_m_login where name = '" + ddemplist.Text + "'", con);
                        assign_id = Convert.ToInt32(cmd_get_assign_to_id.ExecuteScalar());
                        con.Close();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_get_branch_id = new SqlCommand("select id from t_m_branch where name = '" + dd_all_list.Text.ToString() + "'", con);
                        branch_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());
                        con.Close();

                        usertype = dduserlist.Text.ToString();
                    }
                }             
                // check holidays

                string get_date1 = enddate.ToShortDateString();

                if (enddate.DayOfWeek.ToString()  == "Sunday")
                {
                    DateTime dt = enddate.AddDays(1);

                    string dt1 = dt.ToShortDateString();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    int check1 = 0;
                    con.Open();

                    SqlCommand cmd_check_holiday1 = new SqlCommand("select id from t_m_holidays where holiday = '" + dt1 + "'", con);
                    check1 = Convert.ToInt32(cmd_check_holiday1.ExecuteScalar());
                    con.Close();

                    if (check1 == 0)
                    {
                        // save code
                       
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_save_task = new SqlCommand("insert into t_m_task values (" + max_id + ",'" + dt.ToString("dd-MMM-yyyy HH:mm:ss") + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + txtsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "',NULL)", con);
                        cmd_save_task.ExecuteNonQuery();
                        con.Close();
                        /********************/
                        SendMail(max_id, dt);

                        /********************/
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
                    else
                    {
                        DateTime dt11 = dt.AddDays(1);

                        string dt2 = dt11.ToShortDateString();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        int check3 = 0;
                        con.Open();

                        SqlCommand cmd_check_holiday3 = new SqlCommand("select id from t_m_holidays where holiday = '" + dt2 + "'", con);
                        check3 = Convert.ToInt32(cmd_check_holiday3.ExecuteScalar());
                        con.Close();

                        if (check3 == 0)
                        {
                            // save code

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_save_task2 = new SqlCommand("insert into t_m_task values (" + max_id + ",'" + dt11.ToString("dd-MMM-yyyy HH:mm:ss") + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + txtsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "',NULL)", con);
                            cmd_save_task2.ExecuteNonQuery();

                            con.Close();




                            /********************/
                            SendMail(max_id, dt11);
                            /********************/















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
                }
                else
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    int check = 0;
                    con.Open();

                    SqlCommand cmd_check_holiday = new SqlCommand("select id from t_m_holidays where holiday = '" + get_date1 + "'", con);
                    check = Convert.ToInt32(cmd_check_holiday.ExecuteScalar());
                    con.Close();

                    if (check == 0)
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd_save_task = new SqlCommand("insert into t_m_task values (" + max_id + ",'" + enddate.ToString("dd-MMM-yyyy HH:mm:ss") + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + txtsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "',NULL)", con);
                        cmd_save_task.ExecuteNonQuery();
                        con.Close();
                        /********************/

                        SendMail(max_id, enddate);
                        /********************/
                    }

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

                    // save code

                    
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd_save_task1 = new SqlCommand("insert into t_m_task values (" + max_id + ",'" + enddate + "'," + creator + "," + assign_id + ",'" + usertype + "'," + branch_id + "," + dept_id + "," + priority + ",'" + txtsubject.Text.Trim().ToString() + "','" + FreeTextBox1.Text.ToString() + "','" + stts + "',NULL)", con);
                    cmd_save_task1.ExecuteNonQuery();
                    con.Close();
                   /***********/
                    SendMail(max_id, enddate);

                    /***********/
                    // end save code

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
    }



    private void SendMail(long maxid,DateTime enddate)
    {

        /********************/
        try
        {
            SmtpClient SmtpServer1 = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("techsupport2@tradenetstockbroking.in", "tech123");
            SmtpServer1.Host = "10.53.251.9";
            SmtpServer1.Port = 25;
            SmtpServer1.UseDefaultCredentials = false;
            querycon.Open();
            SqlCommand cmd = querycon.CreateCommand();
            cmd.CommandText = "select email_id from tbl_loginer_master where name_='" + ddemplist.Text.Trim() + "'";
            string to_emailid =(string) cmd.ExecuteScalar();

      cmd = querycon.CreateCommand();
            cmd.CommandText = "select email_id from tbl_loginer_master where name_='" + lblloginer.Text.Trim() + "'";
            string From_emailid = (string)cmd.ExecuteScalar();

            querycon.Close();
            //   SmtpServer.EnableSsl = true;
            SmtpServer1.Credentials = myCredential;
            SmtpServer1.ServicePoint.MaxIdleTime = 1;


            if (!lblloginer.Text.ToUpper().Equals(ddemplist.Text.ToUpper()))
            {
                /***TO*/
                MailMessage mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(to_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + ddemplist.Text.ToUpper() + ",</br>Subject:-" + txtsubject.Text.ToUpper() + " Task Assigned to You By " + lblloginer.Text + "</br>Details Are As Below.." + "</br>" + FreeTextBox1.Text.ToUpper() + "</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = "Task ID:-" + maxid + " Subject:-" + txtsubject.Text.ToUpper() + " Task Assigned to You By " + lblloginer.Text.ToUpper();// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);
                /***from*/
                mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(From_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + lblloginer.Text.ToUpper() + ",</br>You Assigned Task Subject:-" + txtsubject.Text.ToUpper() + "   Assigned   To " + ddemplist.Text.Trim().ToUpper() + "</br>Details Are As Below.." + "</br>" + FreeTextBox1.Text.ToUpper() + "</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = "You Assigned Task ID:-" + maxid + " Subject:- " + txtsubject.Text.ToUpper() + " Task    To " + ddemplist.Text.Trim().ToUpper();// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);
            }
            else
            {
                MailMessage mailSubBRok = new MailMessage();
                mailSubBRok.From = new MailAddress("techsupport2@tradenetstockbroking.in", "Task Assignment");
                mailSubBRok.To.Add(to_emailid);
                mailSubBRok.Bcc.Add("techsupport2@tradenetstockbroking.in");
                mailSubBRok.Body = "Dear " + ddemplist.Text.ToUpper() + ",</br>You have assigned yourself a task  Subject:-" + txtsubject.Text.ToUpper() + " Task  "+ "</br>Details Are As Below.." + "</br>" + FreeTextBox1.Text.ToUpper() + "</br>End Date:-" + enddate.ToString("dd-MMM-yyy hh:mm tt");//"Dear Sir,<br/>PFA the Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy") + "<br/>";
                mailSubBRok.Subject = "You have assigned yourself a task Task ID:-" + maxid + " Subject:-" + txtsubject.Text.ToUpper() ;// drw["SubBrokerCode"].ToString() + " Trade Summary for the Date " + DateTime.Today.ToString("dd-MMM-yyyy");
                mailSubBRok.IsBodyHtml = true;
                mailSubBRok.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer1.Send(mailSubBRok);
            
            }
        }
        catch (Exception ex)
        {

        }


        /********************/
    }
    protected void ddemplist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private int get_max_id()
    {
        int x = 0;
        if (con.State == ConnectionState.Open)
        {
            con.Close(); 
        }
        con.Open();
        SqlCommand cmd_get_max_id = new SqlCommand("select isnull(max(id),0)+1 from t_m_task ", con);
        x = Convert.ToInt32(cmd_get_max_id.ExecuteScalar());
        con.Close();        
        return x;
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
    protected void dd_all_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dduserlist.Text == "HOD")
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            
            ddemplist.Items.Clear();
            ddemplist.Items.Add("");

            con.Open();
            SqlCommand cmd_get_hod = new SqlCommand("select name from t_m_login where id = (select hod_id from t_m_dept where dept_name = '" + dd_all_list.Text + "')",con);            
            ddemplist.Items.Add(cmd_get_hod.ExecuteScalar().ToString());            
            con.Close(); 
        }     
        else if (dduserlist.Text == "DE")
        {
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //con.Open();
            //SqlCommand cmd_get_dept_id = new SqlCommand("select id from t_m_dept where dept_name = '" + dd_all_list.Text + "'",con); 
            //int get_dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());
            //con.Close(); 

            
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //con.Open();
            //SqlCommand cmd_get_de = new SqlCommand("select name from t_m_login where post = 2 and forign_id = " + get_dept_id, con);
            //SqlDataReader dr_get_de = cmd_get_de.ExecuteReader();

            //ddemplist.Items.Clear();
            //ddemplist.Items.Add(""); 

            //while (dr_get_de.Read())
            //{
            //    ddemplist.Items.Add(dr_get_de[0].ToString());
            //}
            //dr_get_de.Close(); 
            //con.Close();
            if (dd_all_list.Text == "")
            {

            }
            else
            {
                if (querycon.State == ConnectionState.Open)
                {
                    querycon.Close();
                }
                //string branch_name;

                querycon.Open();
                SqlCommand cmd_get_demp = new SqlCommand("sp_get_all_de", querycon);
                cmd_get_demp.CommandType = CommandType.StoredProcedure;
                cmd_get_demp.Parameters.Clear();
                cmd_get_demp.Parameters.AddWithValue("@dept", dd_all_list.Text.ToString());
                SqlDataReader dr_demp = cmd_get_demp.ExecuteReader();
                ddemplist.Items.Clear();
                while (dr_demp.Read())
                {
                    ddemplist.Items.Add(dr_demp[1].ToString());
                }
                dr_demp.Close();
                querycon.Close();
            }
        }
        else if (dduserlist.Text == "SRMNG")
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_dept_id = new SqlCommand("select id from t_m_dept where dept_name = '" + dd_all_list.Text + "'", con);
            int get_dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_de = new SqlCommand("select l.name from t_m_login as l,t_m_assign_srmng_dept as srm where srm.srmng_id=l.id and srm.dept_id=" + get_dept_id + " ", con);
            SqlDataReader dr_get_de = cmd_get_de.ExecuteReader();

            ddemplist.Items.Clear();
            ddemplist.Items.Add("");

            while (dr_get_de.Read())
            {
                ddemplist.Items.Add(dr_get_de[0].ToString());
            }
            dr_get_de.Close();
            con.Close();
        }

        else if (dduserlist.Text == "SRBMNG")
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_br_id = new SqlCommand("select id from t_m_Branch where name = '" + dd_all_list.Text + "'", con);
            int get_br_id = Convert.ToInt32(cmd_get_br_id.ExecuteScalar());
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_de = new SqlCommand("select l.name from t_m_login as l,t_m_assign_srbmng_branch as srm where srm.srbmng_id=l.id and srm.branch_id=" + get_br_id + " ", con);
            SqlDataReader dr_get_de = cmd_get_de.ExecuteReader();

            ddemplist.Items.Clear();
            ddemplist.Items.Add("");

            while (dr_get_de.Read())
            {
                ddemplist.Items.Add(dr_get_de[0].ToString());
            }
            dr_get_de.Close();
            con.Close();
        }

        else if (dduserlist.Text == "BH") 
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            ddemplist.Items.Clear();
            ddemplist.Items.Add("");
            con.Open();
          //  SqlCommand cmd_get_bh = new SqlCommand("select name from t_m_login where id = (select bh_id from t_m_branch where name = '" + dd_all_list.Text + "')",con);
            SqlCommand cmd_get_bh = new SqlCommand("select l.name from t_m_login as l, t_m_branch as b where b.bh_id = l.id and b.name = '" + dd_all_list.Text + "'", con);              
            ddemplist.Items.Add(cmd_get_bh.ExecuteScalar().ToString());           
            con.Close(); 
        }
        else if (dduserlist.Text == "BE")
        {
             if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_branch_id = new SqlCommand("select id from t_m_branch where name = '" + dd_all_list.Text + "'",con);
            int get_branch_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());
            con.Close(); 

            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd_get_be = new SqlCommand("select name from t_m_login where post = 1 and forign_id = " + get_branch_id, con);
            SqlDataReader dr_get_be = cmd_get_be.ExecuteReader();

            ddemplist.Items.Clear();
            ddemplist.Items.Add("");
 
            while (dr_get_be.Read())
            {
                ddemplist.Items.Add(dr_get_be[0].ToString());
            }
            dr_get_be.Close(); 
            con.Close();
        }
    }
}