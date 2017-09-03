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

public partial class admin_admin_view_all_user : System.Web.UI.Page
{
    SqlConnection con =new SqlConnection(ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString );
    string strim = "";
    int i = 1;



    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack) 
        {
            // get user for dduser 19/03

            if (con.State == ConnectionState.Open)
            {
                con.Open();
            }
            
            con.Open();
            SqlCommand cmd_get_designation = new SqlCommand("admin_get_designation",con);
            cmd_get_designation.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_designation = cmd_get_designation.ExecuteReader();
            dduser.Items.Clear();
            dduser.Items.Add("All");

            while (dr_get_designation.Read())
            {
                dduser.Items.Add(dr_get_designation[0].ToString());
            }
            dr_get_designation.Close();
            con.Close();


            if (con.State == ConnectionState.Open)
            {
                con.Close(); 
            }
                // to fill department 19/03

                con.Open();
                SqlCommand cmd_get_dept = new SqlCommand("admin_get_dept", con);
                cmd_get_dept.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr_dept = cmd_get_dept.ExecuteReader();
                ddlist_dept.Items.Clear();
                ddlist_dept.Items.Add("ALL"); 
                while (dr_dept.Read())
                {            
                    ddlist_dept.Items.Add(dr_dept["dept_name"].ToString());
          
                }
                dr_dept.Close(); 
                con.Close();

            ///// to fill management....

                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }

                con.Open();
                SqlCommand cmd_get_management = new SqlCommand("sp_get_managements", con);
                cmd_get_management.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr_mngment = cmd_get_management.ExecuteReader();
                ddlist_mng.Items.Clear();
                ddlist_mng.Items.Add("ALL");
                while (dr_mngment.Read())
                {            
                   ddlist_mng.Items.Add(dr_mngment["name"].ToString());
          
                }
                dr_mngment.Close(); 
                con.Close();         

            // for get branches 19/03

                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
                con.Open();
                SqlCommand cmd_get_branch = new SqlCommand("admin_get_branch", con);
                cmd_get_branch.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr_branch = cmd_get_branch.ExecuteReader();
                ddlist_branch.Items.Clear();
                ddlist_branch.Items.Add("ALL");
                while (dr_branch.Read())
                {
                    ddlist_branch.Items.Add(dr_branch["name"].ToString());

                }
                dr_branch.Close();
                con.Close();         
        }

        if (dduser.Text == "All")
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_all = new SqlCommand("admin_get_user_view__all", con);
            cmd_get_all.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_all = cmd_get_all.ExecuteReader();

            while (dr_get_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";
                              

                //strim += "<img src ='../images/.gif'>";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["email"];
                strim += "</td >";

                //strim += "<td  bgcolor='#FCFFD9' align='center'>";
                //strim += "<a href> Manage </a>";
                //strim += "</td >";

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_all.Close();
            con.Close();

            div_view.InnerHtml = strim;
        }

    }
    
    protected void dduser_SelectedIndexChanged(object sender, EventArgs e)
    {



        if (dduser.Text == "BE" || dduser.Text == "BH" ||dduser.Text == "SRBMNG")
        {
            pnl_be.Visible = true;
            pnl_de.Visible = false;
            pnl_mng.Visible = false;
        }

        else if (dduser.Text == "DE" || dduser.Text == "HOD" || dduser.Text == "SRMNG")
        {
            pnl_be.Visible = false;
            pnl_de.Visible = true;
            pnl_mng.Visible = false;
        }

        else if (dduser.Text == "MNG")
        {
            pnl_be.Visible = false;
            pnl_de.Visible = false;
            pnl_mng.Visible = true;
        }
       
        else if (dduser.Text == "All")
        {
            pnl_be.Visible = false;
            pnl_de.Visible = false;
            pnl_mng.Visible = false;
        }        
    }


    protected void btnview_Click(object sender, EventArgs e)
    {
     
        string get_user_type="";
        
        string get_parameter = "";

        get_user_type = dduser.Text.ToString();
        
        // admin get parameters 20/03

        if (get_user_type == "BE" || get_user_type == "BH" || get_user_type == "SRBMNG" )
        {
            get_parameter = ddlist_branch.Text.ToString(); 
        }
        else if (get_user_type == "DE" || get_user_type == "HOD" || get_user_type == "SRMNG")
        {
            get_parameter = ddlist_dept.Text.ToString();
        }
        else if (get_user_type == "MNG")
        {
            get_parameter = ddlist_mng.Text.ToString(); 
        }

        // check parameter and show details       

        if (get_user_type == "BE" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";



            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_branch_all = new SqlCommand("admin_get_user_view_inf_branch_all", con);
            cmd_get_branch_all.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_branch_all = cmd_get_branch_all.ExecuteReader();

            while (dr_get_branch_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                // strim += "<td align='center' bgcolor='white'>";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_branch_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_all["email"];
                strim += "</td >";
                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_branch_all.Close(); 
            con.Close();



            div_view.InnerHtml = strim;

        }
           // admin_get_user_view_inf_all

        else if ((get_user_type == "BE" ) && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";            

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_branch_particular = new SqlCommand("admin_get_user_view_inf_branch_particular", con);
            cmd_get_branch_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_branch_particular.Parameters.Clear();
            cmd_get_branch_particular.Parameters.AddWithValue("@branch_name", get_parameter);

            SqlDataReader dr_get_branch_particular = cmd_get_branch_particular.ExecuteReader();

            while (dr_get_branch_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_branch_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_branch_particular["email"];
                strim += "</td >";
                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_branch_particular.Close(); 
            con.Close();            
            div_view.InnerHtml = strim;
        }

        if (get_user_type == "BH" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";                        

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_all = new SqlCommand("admin_get_user_view_inf_all", con);
            cmd_get_inf_all.CommandType = CommandType.StoredProcedure;
            cmd_get_inf_all.Parameters.Clear();
            cmd_get_inf_all.Parameters.AddWithValue("@design", 4);
            SqlDataReader dr_get_all = cmd_get_inf_all.ExecuteReader();

            while (dr_get_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_all["email"];
                strim += "</td >";

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_all.Close();
            con.Close();
            div_view.InnerHtml = strim;

        }



        else if ((get_user_type == "BH") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_bh_particular = new SqlCommand("admin_get_user_view_inf_bh_particular", con);
            cmd_get_bh_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_bh_particular.Parameters.Clear();
            cmd_get_bh_particular.Parameters.AddWithValue("@branch_name", get_parameter);
            cmd_get_bh_particular.Parameters.AddWithValue("@design", 4);

            SqlDataReader dr_get_bh_particular = cmd_get_bh_particular.ExecuteReader();

            while (dr_get_bh_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_bh_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_bh_particular["email"];
                strim += "</td >";

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_bh_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }


        if (get_user_type == "SRBMNG" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";



            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_srbmng_all = new SqlCommand("admin_get_user_view_inf_all", con);
            cmd_get_inf_srbmng_all.CommandType = CommandType.StoredProcedure;
            cmd_get_inf_srbmng_all.Parameters.Clear();
            cmd_get_inf_srbmng_all.Parameters.AddWithValue("@design", 8);
            SqlDataReader dr_get_srbmng_all = cmd_get_inf_srbmng_all.ExecuteReader();

            while (dr_get_srbmng_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_srbmng_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_all["email"];
                strim += "</td >";
               
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_srbmng_all.Close();
            con.Close();
            div_view.InnerHtml = strim;

        }



        else if ((get_user_type == "SRBMNG") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Branch";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_srbmng_particular = new SqlCommand("admin_get_user_view_inf_bh_particular", con);
            cmd_get_srbmng_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_srbmng_particular.Parameters.Clear();
            cmd_get_srbmng_particular.Parameters.AddWithValue("@branch_name", get_parameter);
            cmd_get_srbmng_particular.Parameters.AddWithValue("@design", 8);

            SqlDataReader dr_get_srbmng_particular = cmd_get_srbmng_particular.ExecuteReader();

            while (dr_get_srbmng_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_srbmng_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["branch"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srbmng_particular["email"];
                strim += "</td >";  

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_srbmng_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }


        if (get_user_type == "DE" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";



            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_de_all = new SqlCommand("admin_get_user_view_inf_de_all", con);
            cmd_get_inf_de_all.CommandType = CommandType.StoredProcedure;
            cmd_get_inf_de_all.Parameters.Clear();
            SqlDataReader dr_get_de_all = cmd_get_inf_de_all.ExecuteReader();

            while (dr_get_de_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_de_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["Department"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_de_all["email"];
                strim += "</td >";

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_de_all.Close();
            con.Close();
            div_view.InnerHtml = strim;

        }


        else if ((get_user_type == "DE") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_dept_particular = new SqlCommand("admin_get_user_view_inf_de_particular", con);
            cmd_get_dept_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_dept_particular.Parameters.Clear();
            cmd_get_dept_particular.Parameters.AddWithValue("@dept_name", get_parameter);
            cmd_get_dept_particular.Parameters.AddWithValue("@design", 2);

            SqlDataReader dr_get_dept_particular = cmd_get_dept_particular.ExecuteReader();

            while (dr_get_dept_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_dept_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["username"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["design"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["dept"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["email"];
                strim += "</td >";
                              

                strim += "</tr >";
                i = i + 1;
            }
            dr_get_dept_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }



        if (get_user_type == "HOD" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";



            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_hod_all = new SqlCommand("admin_get_user_view_inf_hod_all", con);
            cmd_get_inf_hod_all.CommandType = CommandType.StoredProcedure;            
            SqlDataReader dr_get_hod_all = cmd_get_inf_hod_all.ExecuteReader();

            while (dr_get_hod_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_hod_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["Department"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_hod_all["email"];
                strim += "</td >";
                                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_hod_all.Close();
            con.Close();
            div_view.InnerHtml = strim;

        }

        else if ((get_user_type == "HOD") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Department";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_dept_particular = new SqlCommand("admin_get_user_view_inf_de_particular", con);
            cmd_get_dept_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_dept_particular.Parameters.Clear();
            cmd_get_dept_particular.Parameters.AddWithValue("@dept_name", get_parameter);
            cmd_get_dept_particular.Parameters.AddWithValue("@design", 3);

            SqlDataReader dr_get_dept_particular = cmd_get_dept_particular.ExecuteReader();

            while (dr_get_dept_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_dept_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["username"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["design"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["dept"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_dept_particular["email"];
                strim += "</td >";
                                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_dept_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }
        ///////////////////////

        if (get_user_type == "MNG" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Management";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_mngmnt_all = new SqlCommand("admin_get_user_view_inf_managment_all", con);
            cmd_get_inf_mngmnt_all.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_mngmnt_all = cmd_get_inf_mngmnt_all.ExecuteReader();

            while (dr_get_mngmnt_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_mngmnt_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["design"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["management"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_all["email"];
                strim += "</td >";
               
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_mngmnt_all.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }

        else if ((get_user_type == "MNG") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Management";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_mngmnt_particular = new SqlCommand("admin_get_user_view_inf_mngmnt_particular", con);
            cmd_get_mngmnt_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_mngmnt_particular.Parameters.Clear();
            cmd_get_mngmnt_particular.Parameters.AddWithValue("@mngmnt_name", get_parameter);
            cmd_get_mngmnt_particular.Parameters.AddWithValue("@design", 6);

            SqlDataReader dr_get_mngmnt_particular = cmd_get_mngmnt_particular.ExecuteReader();

            while (dr_get_mngmnt_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_mngmnt_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["username"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["design"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["management"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_mngmnt_particular["email"];
                strim += "</td >";

               
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_mngmnt_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }


        //////////////////


        if (get_user_type == "SRMNG" && get_parameter == "ALL")
        {

            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Management";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";



            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_inf_srmng_all = new SqlCommand("admin_get_user_view_inf_srmng_all", con);
            cmd_get_inf_srmng_all.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr_get_srmng_all = cmd_get_inf_srmng_all.ExecuteReader();

            while (dr_get_srmng_all.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_srmng_all["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["name"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["designation"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["Department"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_all["email"];
                strim += "</td >";
                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_srmng_all.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }

        else if ((get_user_type == "SRMNG") && (get_parameter != "ALL"))
        {
            strim += "<table border= '5' rules='rows' style='border-style:single;border-color:#C66300'>";

            strim += "<thead>";
            strim += "<tr>";

            strim += "<th width='30px' align = 'center'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "No.";
            strim += "</th>";

            strim += "<th width='50px' align = 'center'  valign = 'center' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "L S";
            strim += "</th>";

            strim += "<th width='100px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Login ID";
            strim += "</th>";

            strim += "<th width='230px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Name";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Post";
            strim += "</th>";

            strim += "<th width='80px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Management";
            strim += "</th>";

            strim += "<th width='120px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Phone No.";
            strim += "</th>";

            strim += "<th width='200px' align = 'left'  bgcolor='#EEEEEE' style='color:#000000'" + ">";
            strim += "Email ID";
            strim += "</th>";

            //strim += "<th width='70px' bgcolor='#EEEEEE' style='color:#000000'" + ">";
            //strim += "Manage";
            //strim += "</th>";

            strim += "</tr>";
            strim += "</thead>";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            SqlCommand cmd_get_srmng_particular = new SqlCommand("admin_get_user_view_inf_srmng_particular", con);
            cmd_get_srmng_particular.CommandType = CommandType.StoredProcedure;
            cmd_get_srmng_particular.Parameters.Clear();
            cmd_get_srmng_particular.Parameters.AddWithValue("@dept_name", get_parameter);
            cmd_get_srmng_particular.Parameters.AddWithValue("@design", 7);

            SqlDataReader dr_get_srmng_particular = cmd_get_srmng_particular.ExecuteReader();

            while (dr_get_srmng_particular.Read())
            {
                strim += "<tr >";

                strim += "<td align='left' bgcolor='#FCFFD9'>";
                strim += i;
                strim += "</td >";

                strim += "<td align='center' bgcolor='#FCFFD9'>";

                if ((dr_get_srmng_particular["login_status"].ToString() == "OFF"))
                {
                    strim += "<img src ='../ico_offline.png'>";
                }
                else
                {
                    strim += "<img src ='../ico_online.gif'>";
                }
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["loginid"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["username"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["design"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["dept"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["phno"];
                strim += "</td >";

                strim += "<td  bgcolor='#FCFFD9'>";
                strim += dr_get_srmng_particular["email"];
                strim += "</td >";
                
                strim += "</tr >";
                i = i + 1;
            }
            dr_get_srmng_particular.Close();
            con.Close();
            div_view.InnerHtml = strim;
        }
    }
}
/////////////////page End///////////////////
