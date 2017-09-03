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

public partial class admin_admin_create_user : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString);
    int foreign_id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd_get_designation = new SqlCommand("admin_get_designation", con);
            cmd_get_designation.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd_get_designation.ExecuteReader();
            ddselectuser.Items.Clear();
            ddselectuser.Items.Add("");            
            while (dr.Read())
            {
                //  ddselectuser.DataValueField = (dr[id].ToString());
                //  ddselectuser.DataTextField = dr["designation"].ToString();
                ddselectuser.Items.Add(dr["designation"].ToString());


                //  ddselectuser.Items.Add(dr[0].ToString());  
            }
            ddselectuser.DataBind();
            con.Close();
        }
    }
    
    protected void ddselectuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddselectuser.SelectedItem.ToString() == "BE") || (ddselectuser.SelectedItem.ToString() == "BH"))
        {
            lblcaption.Text = "Select Branch :- ";
            con.Open();
            SqlCommand cmd_get_branch = new SqlCommand("admin_get_branch", con);
            cmd_get_branch.CommandType = CommandType.StoredProcedure; 
            SqlDataReader dr_get_branch = cmd_get_branch.ExecuteReader();

            ddparameter.Items.Clear();

            while (dr_get_branch.Read())
            {
                ddparameter.Items.Add( dr_get_branch[0].ToString()); 
            }

            dr_get_branch.Close(); 
            con.Close(); 
        }
        else if ((ddselectuser.SelectedItem.ToString() == "DE") || (ddselectuser.SelectedItem.ToString() == "HOD"))
        {
            lblcaption.Text = "Select Department :- ";
            con.Open();
            SqlCommand cmd_get_dept = new SqlCommand("admin_get_dept_create_user", con);
            cmd_get_dept.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_dept = cmd_get_dept.ExecuteReader();

            ddparameter.Items.Clear();

            while (dr_get_dept.Read())
            {
                ddparameter.Items.Add(dr_get_dept[0].ToString());
            }

            dr_get_dept.Close();
            con.Close(); 
        }
        else if ((ddselectuser.SelectedItem.ToString() == "MNG") || (ddselectuser.SelectedItem.ToString() == "SRMNG") || (ddselectuser.SelectedItem.ToString() == "SRBMNG"))
        {
            lblcaption.Text = "Select Management :- ";
            con.Open();
            SqlCommand cmd_get_management = new SqlCommand("admin_get_all_management_inf", con);
            cmd_get_management.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_management = cmd_get_management.ExecuteReader();

            ddparameter.Items.Clear();

            while (dr_get_management.Read())
            {
                ddparameter.Items.Add(dr_get_management["name"].ToString());
            }
            dr_get_management.Close();
            con.Close(); 
        }
    }
   
    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        // for checking loginid already exist 19/03

        //if (con.State == ConnectionState.Open)
        //{
        //    con.Close();
        //}
        //int x = 0;
        //con.Open();
        //SqlCommand cmd_check_loginid = new SqlCommand("admin_check_loginid", con);
        //cmd_check_loginid.CommandType = CommandType.StoredProcedure;
        //cmd_check_loginid.Parameters.Clear();
        //cmd_check_loginid.Parameters.AddWithValue("@loginname", txtusername.Text.Trim().ToString());
        //x = Convert.ToInt32(cmd_check_loginid.ExecuteScalar());

        //if (x == 0)
        //{

        //}
        //else
        //{
        //    Response.Write(@"<script language='javascript'>alert(' " + txtusername.Text.Trim().ToString() + " :- Login ID is Already Exist..!')</script>");
        //    txtusername.Text = "";
        //    txtusername.Focus();

        //}
        //con.Close();
        
    }
    protected void txtname_TextChanged(object sender, EventArgs e)
    {
        ////// for checking user already exist 19/03
        ////if (con.State == ConnectionState.Open)
        ////{
        ////    con.Close();
        ////}
        ////int x = 0;
        ////con.Open();
        ////SqlCommand cmd_check_user = new SqlCommand("admin_check_user", con);
        ////cmd_check_user.CommandType = CommandType.StoredProcedure;
        ////cmd_check_user.Parameters.Clear();
        ////cmd_check_user.Parameters.AddWithValue("@uname", txtname.Text.Trim().ToString());
        ////x = Convert.ToInt32(cmd_check_user.ExecuteScalar());

        ////if (x == 0)
        ////{

        ////}
        ////else
        ////{
        ////    Response.Write(@"<script language='javascript'>alert(' " + txtname.Text.Trim().ToString() + " User is Already Exist..!')</script>");
        ////    txtname.Text = "";
        ////    txtname.Focus();
        ////}
        ////con.Close();
    }

    protected void btnsave_Click(object sender, EventArgs e)
   {

       if (con.State == ConnectionState.Open)
       {
           con.Close();
       }
       
       int x = 0;
       con.Open();
       SqlCommand cmd_check_loginid = new SqlCommand("admin_check_loginid", con);
       cmd_check_loginid.CommandType = CommandType.StoredProcedure;
       cmd_check_loginid.Parameters.Clear();
       cmd_check_loginid.Parameters.AddWithValue("@loginname", txtusername.Text.Trim().ToString());
       x = Convert.ToInt32(cmd_check_loginid.ExecuteScalar());
       con.Close();
       if (x == 0)
       {

       }
       else
       {
           Response.Write(@"<script language='javascript'>alert(' " + txtusername.Text.Trim().ToString() + " :- Login ID is Already Exist..!')</script>");
           txtusername.Text = "";
           txtusername.Focus();
           return;
       }


       // for checking user already exist 19/03
       if (con.State == ConnectionState.Open)
       {
           con.Close();
       }
       int x1 = 0;
       con.Open();
       SqlCommand cmd_check_user = new SqlCommand("admin_check_user", con);
       cmd_check_user.CommandType = CommandType.StoredProcedure;
       cmd_check_user.Parameters.Clear();
       cmd_check_user.Parameters.AddWithValue("@uname", txtname.Text.Trim().ToString());
       x1 = Convert.ToInt32(cmd_check_user.ExecuteScalar());
       con.Close();
       if (x1 == 0)
       {

       }
       else
       {
           Response.Write(@"<script language='javascript'>alert(' " + txtname.Text.Trim().ToString() + " User is Already Exist..!')</script>");
           txtname.Text = "";
           txtname.Focus();
           return;
       }
       
       
        
        
        
        
            string block = "no";
            int chkbh=0;

    //////////////////////////////check for existing BH //////////////////////////////////////////////////

            if(ddselectuser.Text=="BH")
            
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_check_bh_exist = new SqlCommand("admin_check_bh_exist_or_not", con);
                cmd_check_bh_exist.CommandType = CommandType.StoredProcedure;
                cmd_check_bh_exist.Parameters.Clear();
                cmd_check_bh_exist.Parameters.AddWithValue("@branch_name", ddparameter.Text.Trim());
                chkbh = Convert.ToInt32(cmd_check_bh_exist.ExecuteScalar());

                if (chkbh > 0)
                {
                    Response.Write(@"<script language='javascript'>alert('Branch Head already Exist For " + ddparameter.Text + " Branch..!')</script>");
                    ddparameter.Focus();
                }

                else
                {

                    if (txtconfirmpass.Text == txtpassword.Text)
                    {

                        if (lblcaption.Text == "Select Branch :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);
                            cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_branch_id.Parameters.Clear();
                            cmd_get_branch_id.Parameters.AddWithValue("@bname", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Department :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
                            cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_dept_id.Parameters.Clear();
                            cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Management :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                            cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_mng_id.Parameters.Clear();
                            cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());
                            con.Close();
                        }


                        // save user information 19/03

                        con.Open();
                        SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                        cmd_insert_user.CommandType = CommandType.StoredProcedure;
                        cmd_insert_user.Parameters.Clear();

                        cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                        cmd_insert_user.Parameters.AddWithValue("@block", block);
                        cmd_insert_user.ExecuteNonQuery();
                        con.Close();                


                       if (ddselectuser.SelectedItem.ToString() == "BH")
                        {

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_update_dept = new SqlCommand("admin_update_branch_login", con);
                            cmd_update_dept.CommandType = CommandType.StoredProcedure;
                            cmd_update_dept.Parameters.Clear();
                            cmd_update_dept.Parameters.AddWithValue("@brname", ddparameter.SelectedItem.ToString());
                            cmd_update_dept.Parameters.AddWithValue("@bhname", txtname.Text.Trim().ToString());
                            cmd_update_dept.ExecuteNonQuery();
                            con.Close();

                        }


                        // create login status

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();
                        SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status", con);
                        cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                        cmd_create_loing_status_master.Parameters.Clear();
                        cmd_create_loing_status_master.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_create_loing_status_master.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("admin_create_user.aspx");
                    }

                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");
                    } 

                    return;
                }

                con.Close();
                return;
             }

            ///////////////////////////////// End of check for existing BH///////////////////////////////////


            ////////////////////////////////Check for existing HOD////////////////////////////////////////////

            if (ddselectuser.Text == "HOD")
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_check_hod_exist = new SqlCommand("admin_check_hod_exist_or_not", con);
                cmd_check_hod_exist.CommandType = CommandType.StoredProcedure;
                cmd_check_hod_exist.Parameters.Clear();
                cmd_check_hod_exist.Parameters.AddWithValue("@dept_name", ddparameter.Text.Trim());
                chkbh = Convert.ToInt32(cmd_check_hod_exist.ExecuteScalar());

                if (chkbh > 0)
                {
                    Response.Write(@"<script language='javascript'>alert('HOD already Exist For " + ddparameter.Text + " Department..!')</script>");
                    ddparameter.Focus();
                }

                else
                {

                    if (txtconfirmpass.Text == txtpassword.Text)
                    {

                        if (lblcaption.Text == "Select Branch :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);
                            cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_branch_id.Parameters.Clear();
                            cmd_get_branch_id.Parameters.AddWithValue("@bname", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Department :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
                            cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_dept_id.Parameters.Clear();
                            cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Management :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                            cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_mng_id.Parameters.Clear();
                            cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());
                            con.Close();
                        }


                        // save user information 19/03

                        con.Open();
                        SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                        cmd_insert_user.CommandType = CommandType.StoredProcedure;
                        cmd_insert_user.Parameters.Clear();

                        cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                        cmd_insert_user.Parameters.AddWithValue("@block", block);
                        cmd_insert_user.ExecuteNonQuery();
                        con.Close();


                        if (ddselectuser.SelectedItem.ToString() == "HOD")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_update_dept = new SqlCommand("admin_update_dept_login", con);
                            cmd_update_dept.CommandType = CommandType.StoredProcedure;
                            cmd_update_dept.Parameters.Clear();
                            cmd_update_dept.Parameters.AddWithValue("@deptname", ddparameter.SelectedItem.ToString());
                            cmd_update_dept.Parameters.AddWithValue("@hname", txtname.Text.Trim().ToString());
                            cmd_update_dept.ExecuteNonQuery();
                            con.Close();

                        }
                       





                        // create login status

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();
                        SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status", con);
                        cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                        cmd_create_loing_status_master.Parameters.Clear();
                        cmd_create_loing_status_master.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_create_loing_status_master.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("admin_create_user.aspx");
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");
                    }
                    return;
                }

                con.Close();
                return; 
            }

            ////////////////////////////////End of Check existing HOD/////////////////////////////////////////


            ///////////////////////////////check for Manager Exist or not/////////////////////////////////////
            if(ddselectuser.Text=="MNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_check_mng_exist = new SqlCommand("admin_check_mnger_exist_or_not", con);
                cmd_check_mng_exist.CommandType = CommandType.StoredProcedure;
                cmd_check_mng_exist.Parameters.Clear();
                cmd_check_mng_exist.Parameters.AddWithValue("@mngmnt_name", ddparameter.Text.Trim());
                chkbh = Convert.ToInt32(cmd_check_mng_exist.ExecuteScalar());

                if (chkbh > 0)
                {
                    Response.Write(@"<script language='javascript'>alert('Manager already Exist For " + ddparameter.Text + " Management..!')</script>");
                    ddparameter.Focus();
                }

                else
                {

                    if (txtconfirmpass.Text == txtpassword.Text)
                    {

                        if (lblcaption.Text == "Select Branch :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);
                            cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_branch_id.Parameters.Clear();
                            cmd_get_branch_id.Parameters.AddWithValue("@bname", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Department :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
                            cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_dept_id.Parameters.Clear();
                            cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Management :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                            cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_mng_id.Parameters.Clear();
                            cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());
                            con.Close();
                        }


                        // save user information 19/03

                        con.Open();
                        SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                        cmd_insert_user.CommandType = CommandType.StoredProcedure;
                        cmd_insert_user.Parameters.Clear();

                        cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                        cmd_insert_user.Parameters.AddWithValue("@block", block);
                        cmd_insert_user.ExecuteNonQuery();
                        con.Close();

                        // create login status

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();
                        SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status", con);
                        cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                        cmd_create_loing_status_master.Parameters.Clear();
                        cmd_create_loing_status_master.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_create_loing_status_master.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("admin_create_user.aspx");
                    }

                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");
                    }

                    return;
                }

                con.Close();
                return; 

            }
            ///////////////////////////////end of check manager exist or not//////////////////////////////////


            //////////////////////////////check for srbmng exist or not///////////////////////////////////////

            if(ddselectuser.Text=="SRBMNG")
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_check_srbmng_exist = new SqlCommand("admin_check_srbmng_exist_or_not", con);
                cmd_check_srbmng_exist.CommandType = CommandType.StoredProcedure;
                cmd_check_srbmng_exist.Parameters.Clear();
                cmd_check_srbmng_exist.Parameters.AddWithValue("@branch_name", ddparameter.Text.Trim());
                chkbh = Convert.ToInt32(cmd_check_srbmng_exist.ExecuteScalar());

                if (chkbh > 0)
                {
                    Response.Write(@"<script language='javascript'>alert('SRBMNG already Exist For " + ddparameter.Text + " Branch..!')</script>");
                    ddparameter.Focus();
                }

                else
                {

                    if (txtconfirmpass.Text == txtpassword.Text)
                    {

                        if (lblcaption.Text == "Select Branch :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);
                            cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_branch_id.Parameters.Clear();
                            cmd_get_branch_id.Parameters.AddWithValue("@bname", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Department :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
                            cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_dept_id.Parameters.Clear();
                            cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Management :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                            cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_mng_id.Parameters.Clear();
                            cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());
                            con.Close();
                        }


                        // save user information 19/03

                        con.Open();
                        SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                        cmd_insert_user.CommandType = CommandType.StoredProcedure;
                        cmd_insert_user.Parameters.Clear();

                        cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                        cmd_insert_user.Parameters.AddWithValue("@block", block);
                        cmd_insert_user.ExecuteNonQuery();
                        con.Close();

                        // create login status

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();
                        SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status", con);
                        cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                        cmd_create_loing_status_master.Parameters.Clear();
                        cmd_create_loing_status_master.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_create_loing_status_master.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("admin_create_user.aspx");
                    }

                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");
                    }

                    return;
                }

                con.Close();
                return; 

            }
            /////////////////////////////End of check srbmng exist or not////////////////////////////////////


            /////////////////////////////Check for srmng exist or not////////////////////////////////////////

            if(ddselectuser.Text=="SRMNG")
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_check_srmng_exist = new SqlCommand("admin_check_srmng_exist_or_not", con);
                cmd_check_srmng_exist.CommandType = CommandType.StoredProcedure;
                cmd_check_srmng_exist.Parameters.Clear();
                cmd_check_srmng_exist.Parameters.AddWithValue("@dept_name", ddparameter.Text.Trim());
                chkbh = Convert.ToInt32(cmd_check_srmng_exist.ExecuteScalar());

                if (chkbh > 0)
                {
                    Response.Write(@"<script language='javascript'>alert('SRMNG already Exist For " + ddparameter.Text + " Department..!')</script>");
                    ddparameter.Focus();
                }

                else
                {

                    if (txtconfirmpass.Text == txtpassword.Text)
                    {

                        if (lblcaption.Text == "Select Branch :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);
                            cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_branch_id.Parameters.Clear();
                            cmd_get_branch_id.Parameters.AddWithValue("@bname", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Department :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);
                            cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_dept_id.Parameters.Clear();
                            cmd_get_dept_id.Parameters.AddWithValue("@dept_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar());

                            con.Close();
                        }
                        else if (lblcaption.Text == "Select Management :- ")
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                            cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                            cmd_get_mng_id.Parameters.Clear();
                            cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                            foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());
                            con.Close();
                        }


                        // save user information 19/03

                        con.Open();
                        SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                        cmd_insert_user.CommandType = CommandType.StoredProcedure;
                        cmd_insert_user.Parameters.Clear();

                        cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString());
                        cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                        cmd_insert_user.Parameters.AddWithValue("@block", block);
                        cmd_insert_user.ExecuteNonQuery();
                        con.Close();

                        // create login status

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();
                        SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status", con);
                        cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                        cmd_create_loing_status_master.Parameters.Clear();
                        cmd_create_loing_status_master.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString());
                        cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                        cmd_create_loing_status_master.ExecuteNonQuery();
                        con.Close();

                        Response.Redirect("admin_create_user.aspx");
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");
                    }
                    return;
                }
                con.Close();
                return;
            }

      ///////////////////////////////////////////////// end of check srmng exist or not////////////////////////////////////

            if (txtconfirmpass.Text == txtpassword.Text)
            {

                if (lblcaption.Text == "Select Branch :- ")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Open();
                    }
                    con.Open();
                    SqlCommand cmd_get_branch_id = new SqlCommand("admin_check_branch", con);                
                    cmd_get_branch_id.CommandType = CommandType.StoredProcedure;
                    cmd_get_branch_id.Parameters.Clear();
                    cmd_get_branch_id.Parameters.AddWithValue("@bname",ddparameter.SelectedItem.ToString() );
                    foreign_id = Convert.ToInt32(cmd_get_branch_id.ExecuteScalar()); 
                
                    con.Close(); 
                }

                else if (lblcaption.Text == "Select Department :- ")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Open();
                    }
                    con.Open();
                    SqlCommand cmd_get_dept_id = new SqlCommand("admin_get_dept_id_by_dept_name", con);                
                    cmd_get_dept_id.CommandType = CommandType.StoredProcedure;
                    cmd_get_dept_id.Parameters.Clear();
                    cmd_get_dept_id.Parameters.AddWithValue("@dept_name",ddparameter.SelectedItem.ToString() );
                    foreign_id = Convert.ToInt32(cmd_get_dept_id.ExecuteScalar()); 
                
                    con.Close();                 
                }
                else if (lblcaption.Text == "Select Management :- ")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Open();
                    }
                    con.Open();
                    SqlCommand cmd_get_mng_id = new SqlCommand("admin_get_mng_id", con);
                    cmd_get_mng_id.CommandType = CommandType.StoredProcedure;
                    cmd_get_mng_id.Parameters.Clear();
                    cmd_get_mng_id.Parameters.AddWithValue("@mng_name", ddparameter.SelectedItem.ToString());
                    foreign_id = Convert.ToInt32(cmd_get_mng_id.ExecuteScalar());                 
                    con.Close();                 
                }


                // save user information 19/03

                con.Open();
                SqlCommand cmd_insert_user = new SqlCommand("sp_insert_new_user", con);
                cmd_insert_user.CommandType = CommandType.StoredProcedure;
                cmd_insert_user.Parameters.Clear();

                cmd_insert_user.Parameters.AddWithValue("@loginid", txtusername.Text.Trim().ToString()  );
                cmd_insert_user.Parameters.AddWithValue("@pass", txtpassword.Text.Trim().ToString()  );
                cmd_insert_user.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString()  );
                cmd_insert_user.Parameters.AddWithValue("@post", ddselectuser.Text.Trim().ToString());
                cmd_insert_user.Parameters.AddWithValue("@phone", txtphoneno.Text.Trim().ToString() );
                cmd_insert_user.Parameters.AddWithValue("@email_id", txtemail.Text.Trim().ToString() );
                cmd_insert_user.Parameters.AddWithValue("@forign_id", foreign_id);
                cmd_insert_user.Parameters.AddWithValue("@block", block);
                cmd_insert_user.ExecuteNonQuery();
                con.Close();

                // create login status

                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }

                con.Open();
                SqlCommand cmd_create_loing_status_master = new SqlCommand("admin_create_login_status",con);
                cmd_create_loing_status_master.CommandType = CommandType.StoredProcedure;
                cmd_create_loing_status_master.Parameters.Clear();
                cmd_create_loing_status_master.Parameters.AddWithValue("@loginid",txtusername.Text.Trim().ToString() );
                cmd_create_loing_status_master.Parameters.AddWithValue("@name", txtname.Text.Trim().ToString());
                cmd_create_loing_status_master.ExecuteNonQuery();
                con.Close(); 

               Response.Redirect("admin_create_user.aspx");
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Password don't match with Confirm Password..!')</script>");         
            } 
   }

    protected void txtconfirmpass_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtpassword_TextChanged(object sender, EventArgs e)
    {

    }
}
