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

public partial class View_login_information : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            dtfrom.SelectedDate = DateTime.Now;
            dtto.SelectedDate = DateTime.Now;

            if (Session["type"].ToString() == "ADMIN" )
            {
                dduserlist.Items.Add("");
                dduserlist.Items.Add("MNG"); 
                dduserlist.Items.Add("SRMNG");
                dduserlist.Items.Add("HOD");
                dduserlist.Items.Add("DE");
                dduserlist.Items.Add("SRBMNG");
                dduserlist.Items.Add("BH");
                dduserlist.Items.Add("BE");
            }
            else if (Session["type"].ToString() == "MNG")
            {    
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("SRMNG");
                    dduserlist.Items.Add("HOD");
                    dduserlist.Items.Add("DE");
                    dduserlist.Items.Add("SRBMNG");
                    dduserlist.Items.Add("BH");
                    dduserlist.Items.Add("BE");            
            }
            else if (Session["type"].ToString() == "SRMNG")
            {
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("HOD");
                    dduserlist.Items.Add("DE");               
            }
            else if (Session["type"].ToString() == "HOD")
            {              
              
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("DE");                

            }            
            else if (Session["type"].ToString() == "SRBMNG")
            {               
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("BH");
                    dduserlist.Items.Add("BE");                
            }
            else if (Session["type"].ToString() == "BH")
            { 
                    dduserlist.Items.Add("");
                    dduserlist.Items.Add("BE");                
            }          
        }

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
        else if (Session["type"].ToString() == "ADMIN")
        {
            Response.Redirect("admin/admin.aspx"); 
        }
    }
    protected void dduserlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddemplist.Items.Clear();
        dd_all_list.Items.Clear();
 
        if (Session["type"].ToString() == "ADMIN")
        {
            if (dduserlist.Text == "MNG")
            {
                lblcaption.Text = "Select Management :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_managements = new SqlCommand("select name from t_m_management order by name", con);
                SqlDataReader dr = cmd_get_managements.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();  
            }
            else if (dduserlist.Text == "SRMNG")
            {
                lblcaption.Text = "Select Senior Manager :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_managements = new SqlCommand("select name from t_m_management order by name", con);
                SqlDataReader dr = cmd_get_managements.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();  
            }

            else if (dduserlist.Text == "HOD")
            {
                lblcaption.Text = "Select HOD :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
                con.Open();
                SqlCommand cmd_get_dept = new SqlCommand("select dept_name from t_m_dept order by dept_name",con);
                SqlDataReader dr = cmd_get_dept.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();  
               
            }
            else if (dduserlist.Text == "DE")
            {
                lblcaption.Text = "Select HOD :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept = new SqlCommand("select dept_name from t_m_dept order by dept_name", con);
                SqlDataReader dr = cmd_get_dept.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();  
            }
            else if (dduserlist.Text == "SRBMNG")
            {
                lblcaption.Text = "Select  Manager :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_managements = new SqlCommand("select name from t_m_management order by name", con);
                SqlDataReader dr = cmd_get_managements.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();                  
            }
            else if (dduserlist.Text == "BH")
            {
                lblcaption.Text = "Select Branch :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch = new SqlCommand("select name from t_m_branch order by name", con);
                SqlDataReader dr = cmd_get_branch.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();                 
            }
            else if (dduserlist.Text == "BE")
            {
                lblcaption.Text = "Select Branch :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add("");

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_branch = new SqlCommand("select name from t_m_branch order by name", con);
                SqlDataReader dr = cmd_get_branch.ExecuteReader();
                while (dr.Read())
                {
                    dd_all_list.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();           
            } 
        }
        else if (Session["type"].ToString() == "MNG")
        {
            if (dduserlist.Text == "SRMNG")
            {
                lblcaption.Text = "Management :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add(get_management_name(Session["manage_id"].ToString()));

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_srmng_name = new SqlCommand("select name from t_m_login where post = 7 and forign_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                SqlDataReader dr_srmng = cmd_get_srmng_name.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");

                while (dr_srmng.Read())
                {
                    ddemplist.Items.Add(dr_srmng[0].ToString());
                }
                dr_srmng.Close();
                con.Close();
            }

            else if (dduserlist.Text == "HOD")
            {
                dd_all_list.Items.Clear();
                lblcaption.Text = "Select Department :- ";

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
                lblcaption.Text = "Management :- ";
                dd_all_list.Items.Clear();
                dd_all_list.Items.Add(get_management_name(Session["manage_id"].ToString()));

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_srbmng_name = new SqlCommand("select name from t_m_login where post = 8 and forign_id = " + Convert.ToInt32(Session["manage_id"].ToString()) + " order by name", con);
                SqlDataReader dr_srbmng = cmd_get_srbmng_name.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");

                while (dr_srbmng.Read())
                {
                    ddemplist.Items.Add(dr_srbmng[0].ToString());
                }
                dr_srbmng.Close();
                con.Close();
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
            if (dduserlist.Text == "HOD")
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
            SqlCommand cmd_get_dept = new SqlCommand("select name from t_m_login where post = 2 and forign_id = " + Convert.ToInt32(Session["dept_id"].ToString()), con);
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
    }
    protected void dd_all_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ( Session["type"].ToString() == "ADMIN")
        {
            if (dduserlist.Text == "MNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_mng = new SqlCommand("select name from t_m_login where post = 6 and forign_id = (select id from t_m_management where name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_mng.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            
            }
            else if (dduserlist.Text == "SRMNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
                con.Open();
                SqlCommand cmd_get_srmng = new SqlCommand("select name from t_m_login where post = 7 and forign_id = (select id from t_m_management where name = '" + dd_all_list.Text + "')"  ,con);
                SqlDataReader dr = cmd_get_srmng.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");  
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());  
                }
                dr.Close(); 
                con.Close();
            }
            else if (dduserlist.Text == "HOD")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_hod = new SqlCommand("select name from t_m_login where post = 3 and forign_id = (select id from t_m_dept where dept_name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_hod.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            else if (dduserlist.Text == "DE")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_hod = new SqlCommand("select name from t_m_login where post = 2 and forign_id = (select id from t_m_dept where dept_name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_hod.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close(); 
            }
            else if (dduserlist.Text == "SRBMNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_srbmng = new SqlCommand("select name from t_m_login where post = 8 and forign_id = (select id from t_m_management where name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_srbmng.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            else if (dduserlist.Text == "BH")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_bh = new SqlCommand("select name from t_m_login where post = 4 and forign_id = (select id from t_m_branch where name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_bh.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
            else if (dduserlist.Text == "BE")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_be = new SqlCommand("select name from t_m_login where post = 1 and forign_id = (select id from t_m_branch where name = '" + dd_all_list.Text + "')", con);
                SqlDataReader dr = cmd_get_be.ExecuteReader();
                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                while (dr.Read())
                {
                    ddemplist.Items.Add(dr[0].ToString());
                }
                dr.Close();
                con.Close();
            }
        }
        else
        {
            if (dduserlist.Text == "MNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ddemplist.Items.Clear();
                con.Open();
                SqlCommand cmd_get_management_name = new SqlCommand("select name from t_m_login where post = 6 and forign_id = (select id from t_m_management where name = '" + dd_all_list.Text + "')", con);
                ddemplist.Items.Add(cmd_get_management_name.ExecuteScalar().ToString());
                con.Close();
            }

            else if (dduserlist.Text == "HOD")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ddemplist.Items.Clear();
                con.Open();
                SqlCommand cmd_get_hod = new SqlCommand("select name from t_m_login where id = (select hod_id from t_m_dept where dept_name = '" + dd_all_list.Text + "')", con);
                ddemplist.Items.Add(cmd_get_hod.ExecuteScalar().ToString());
                con.Close();
            }
            else if (dduserlist.Text == "DE")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_dept_id = new SqlCommand("select id from t_m_dept where dept_name = '" + dd_all_list.Text + "'", con);
                int get_dept_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());
                con.Close();

                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_de = new SqlCommand("select name from t_m_login where post = 2 and forign_id = " + get_dept_id, con);
                SqlDataReader dr_get_de = cmd_get_de.ExecuteReader();

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
                SqlCommand cmd_get_branch_id = new SqlCommand("select id from t_m_branch where name = '" + dd_all_list.Text + "'", con);
                int get_branch_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());
                con.Close();

                ddemplist.Items.Clear();
                ddemplist.Items.Add("");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_be = new SqlCommand("select name from t_m_login where post = 1 and forign_id = " + get_branch_id, con);
                SqlDataReader dr_get_be = cmd_get_be.ExecuteReader();

                while (dr_get_be.Read())
                {
                    ddemplist.Items.Add(dr_get_be[0].ToString());
                }
                dr_get_be.Close();
                con.Close();
            }
        }
    }
    protected void ddemplist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        if (dduserlist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select User Type.. !')</script>");
            dduserlist.Focus();
            return;
        }
        else if (dd_all_list.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select "+ lblcaption.Text + ".. !')</script>");
            dd_all_list.Focus();
            return;
        }
        else if (ddemplist.Text == "")
        {
            Response.Write(@"<script language='javascript'>alert('Please Select Employee.. ')</script>");
            dd_all_list.Focus();
            return;
        }
        else if (dtto.SelectedDate < dtfrom.SelectedDate)
        {
            Response.Write(@"<script language='javascript'>alert('Please Select Valid Date Range.. ')</script>");
            dd_all_list.Focus();
            return;
        }
        else
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            //DateTime dt = DateTime.Now;
            string dt_from1 = dtfrom.SelectedDate.ToString();

            //DateTime dt1 = DateTime.Now;
            string dt_to1 = dtto.SelectedDate.ToString();

            con.Open();
            SqlCommand cmd_get_inf = new SqlCommand("SELECT dbo.t_m_login_information.loginid,dbo.t_m_login_information.usertype, dbo.t_m_login_information.indate, dbo.t_m_login_information.intime,dbo.t_m_login_information.outdate, dbo.t_m_login_information.outtime FROM dbo.t_m_login RIGHT OUTER JOIN dbo.t_m_login_information ON dbo.t_m_login.id = dbo.t_m_login_information.loginid WHERE (dbo.t_m_login_information.loginid =(SELECT id FROM dbo.t_m_login AS t_m_login_1 WHERE (name = '" + ddemplist.Text + "')) and dbo.t_m_login_information.indate >='" + dt_from1 + "' and dbo.t_m_login_information.indate <='" + dt_to1 + "')", con);
            //int get =Convert.ToInt32(cmd_get_inf.ExecuteScalar());
            SqlDataReader rdr = cmd_get_inf.ExecuteReader();

            string strim = "";

            strim += "<table border= '5' width = '100%' rules='all'  style='border-style:single;border-color:#C66300'>";
            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='50px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='60px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "In Date";
            strim += "</th>";

            strim += "<th width='60px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "In Time";
            strim += "</th>";

            strim += "<th width='60px' align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Out Date";
            strim += "</th>";

            strim += "<th width='60px'align = 'left' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Out Time";
            strim += "</th>";                 

            strim += "</tr>";
            strim += "</thead>";
            
            while (rdr.Read())
            {
                strim += "<tr>";                

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr[1];
                strim += "</td >";
                            
                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr[2].ToString();
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr[3].ToString();
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr[4];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9' width='Auto'>";
                strim += rdr[5];
                strim += "</td >";               
            }

            strim += "</table>";
            view_login_info.InnerHtml = strim;
            rdr.Close();
            con.Close(); 
 
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
        SqlCommand cmd_get_management_name = new SqlCommand("select name from t_m_management where id =" + Convert.ToInt32(Session["manage_id"]), con);
        get_name = cmd_get_management_name.ExecuteScalar().ToString();
        con.Close();
        return get_name;
    }
 
}
