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
       // DatePicker1.SelectedDate = "31/04/2012";

     // DatePicker1.SelectedDate = DateTime.Now;
       
        
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}
