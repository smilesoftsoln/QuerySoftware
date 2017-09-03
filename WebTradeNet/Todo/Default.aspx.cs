using System;
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
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data; 

public partial class _Default : System.Web.UI.Page 
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString); 
    protected void Page_Load(object sender, EventArgs e)
    {
        //con.ConnectionString = constr;         
        txtloginid.Focus();        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        // for username & password checking  08/03 amar

        string userid = "";
        string password = "";

        userid = txtloginid.Text.Trim().ToString();
        password = txtpassword.Text.Trim().ToString();

        int x = 0;

        con.Open();
        SqlCommand cmd_check_loginid = new SqlCommand("login_check_userid", con);
        cmd_check_loginid.CommandType = CommandType.StoredProcedure;
        cmd_check_loginid.Parameters.Add("@u_id", SqlDbType.NVarChar).Value = txtloginid.Text.Trim().ToString();
        x = Convert.ToInt32(cmd_check_loginid.ExecuteScalar());
        con.Close();

        if (x == 0)
        {
            Response.Write(@"<script language='javascript'>alert('This User is not valid please enter correct loginid !')</script>");
            txtloginid.Text = "";
            txtloginid.Focus();
            return;
        }
        else
        {
            string catch_pass = "";
            con.Open();
            SqlCommand cmd_check_pass = new SqlCommand("login_check_password", con);
            cmd_check_pass.CommandType = CommandType.StoredProcedure;
            cmd_check_pass.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(x);
            catch_pass = (cmd_check_pass.ExecuteScalar().ToString());
            con.Close();

            if (password == catch_pass)
            {

                //string loginer = "";
                //string type = "";
                //string loginid = "";
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd_get_login_information = new SqlCommand("get_login_information", con);
                cmd_get_login_information.CommandType = CommandType.StoredProcedure;
                cmd_get_login_information.Parameters.Clear();
                cmd_get_login_information.Parameters.AddWithValue("@id", x);
                SqlDataReader dr = cmd_get_login_information.ExecuteReader();
                dr.Read();
                
                // update login status

              
                Session.Add("loginid", dr[1].ToString());
                Session.Add("type", dr[2].ToString());
                Session.Add("loginer", dr[3].ToString());
                Session.Add("forign_id", dr[4].ToString());
                int xyz = Convert.ToInt32(Session["forign_id"]);
               
                dr.Close();
                con.Close();


                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_update_loginstatus = new SqlCommand("update t_m_login_status set status = 'ON' where id = " + x, con);
                cmd_update_loginstatus.ExecuteNonQuery();
                con.Close();                
                 

                string get_login_date = DateTime.Now.ToShortDateString();
                string tmp = DateTime.Now.ToLongTimeString();
                                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_login_inf_id = new SqlCommand("select isnull(max(id),0)+1 from t_m_login_information",con);
                Session.Add("login_inf_id", Convert.ToInt32(cmd_get_login_inf_id.ExecuteScalar()));
                con.Close();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_get_id = new SqlCommand("select id from t_m_login where loginid = '" + Session["loginid"].ToString() + "'", con);
                int get_id = Convert.ToInt32(cmd_get_id.ExecuteScalar());
                con.Close(); 

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd_save_login_inf = new SqlCommand("insert into t_m_login_information values(" + Convert.ToInt32(Session["login_inf_id"].ToString()) + ","+ get_id + ",'" + Session["type"].ToString() + "','" + get_login_date + "','" + tmp + "','','')", con);
                cmd_save_login_inf.ExecuteNonQuery();
                con.Close(); 
                               

                if ((Session["type"]).ToString() == "ADMIN")
                {
                    Response.Redirect("admin/admin.aspx");
                }

                else if ((Session["type"]).ToString() == "DE")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_mng_id_by_dept_id = new SqlCommand("select manage_id from t_m_dept as d  where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    Session.Add("manage_id", cmd_get_mng_id_by_dept_id.ExecuteScalar().ToString());                    
                    con.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_dept_name_and = new SqlCommand("select id,dept_name from t_m_dept where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    SqlDataReader dr1 = cmd_get_dept_name_and.ExecuteReader();
                    dr1.Read();
                    Session.Add("dept_id", dr1[0].ToString());
                    Session.Add("dept_name", dr1[1].ToString());
                    dr1.Close();
                    con.Close();

                    Response.Redirect("dept_login_next.aspx");
                }

                else if ((Session["type"]).ToString() == "BE")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_mng_id_by_branch_id = new SqlCommand("select manage_id from t_m_branch where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    Session.Add("manage_id", cmd_get_mng_id_by_branch_id.ExecuteScalar().ToString());
                    con.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_branch_name_and = new SqlCommand("select id,name from t_m_branch where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    SqlDataReader dr1 = cmd_get_branch_name_and.ExecuteReader();
                    dr1.Read();
                    Session.Add("branch_id", dr1[0].ToString());
                    Session.Add("branch_name", dr1[1].ToString());
                    dr1.Close();
                    con.Close();

                    Response.Redirect("be_login_next.aspx");

                }

                else if ((Session["type"]).ToString() == "SRMNG")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_srmng_id_by_id = new SqlCommand("select forign_id from t_m_login where post = 7 and loginid = '" + Session["loginid"].ToString()  + "'", con);
                    Session.Add("manage_id", cmd_get_srmng_id_by_id.ExecuteScalar().ToString());
                    con.Close();

                    Response.Redirect("senior_manager_login_next.aspx");
                }
                else if ((Session["type"]).ToString() == "HOD")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_mng_id_by_dept_id = new SqlCommand("select manage_id from t_m_dept where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    Session.Add("manage_id", cmd_get_mng_id_by_dept_id.ExecuteScalar().ToString());
                    con.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_dept_name_and = new SqlCommand("select id,dept_name from t_m_dept where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    SqlDataReader dr1 = cmd_get_dept_name_and.ExecuteReader();
                    dr1.Read();
                    Session.Add("dept_id", dr1[0].ToString());
                    Session.Add("dept_name", dr1[1].ToString());
                    dr1.Close();
                    con.Close();

                    Response.Redirect("hod_login_next.aspx");
                }
                else if ((Session["type"]).ToString() == "SRBMNG")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_srbmng_id_by_id = new SqlCommand("select forign_id from t_m_login where post = 8 and loginid = '" + Session["loginid"].ToString() + "'", con);
                    Session.Add("manage_id", cmd_get_srbmng_id_by_id.ExecuteScalar().ToString());
                    con.Close();
                    
                    Response.Redirect("senior_branch_manager_login_next.aspx");
                }
                else if ((Session["type"]).ToString() == "BH")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_mng_id_by_branch_id = new SqlCommand("select manage_id from t_m_branch where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    Session.Add("manage_id", cmd_get_mng_id_by_branch_id.ExecuteScalar().ToString());
                    con.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_branch_name_and = new SqlCommand("select id,name from t_m_branch where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    SqlDataReader dr1 = cmd_get_branch_name_and.ExecuteReader();
                    dr1.Read();
                    Session.Add("branch_id", dr1[0].ToString());
                    Session.Add("branch_name", dr1[1].ToString());
                    dr1.Close();
                    con.Close();

                    Response.Redirect("branchhead_login_next.aspx");
                }


                else if ((Session["type"]).ToString() == "MNG")
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();
                    SqlCommand cmd_get_mng_id_by_mng_login = new SqlCommand("select id from t_m_management where id = " + Convert.ToInt32(Session["forign_id"]), con);
                    Session.Add("manage_id", cmd_get_mng_id_by_mng_login.ExecuteScalar().ToString());
                    con.Close();

                    Response.Redirect("mng_login_next.aspx");
                }
            }
            else
            {

                Response.Write(@"<script language='javascript'>alert('Please enter correct Password !')</script>");
                txtpassword.Text = "";
                txtpassword.Focus();
                return;
            }
        }
    }

    private void MsgBox(string msg)
    {
        //string showMsg = "<script language='javascript'>" +
        //"alert(" + msg + ");</script>";
        //RegisterStartupScript("ds", msg);
        //string str = "<script language='javascript'>";
        //str = str + "alert('" + msg + "' )";
        //str = str + "</script>";
        //RegisterStartupScript("ds", str);
       
    }


    protected void txtloginid_TextChanged(object sender, EventArgs e)
    {

    }
}
