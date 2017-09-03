<%@ Page Language="VB" MasterPageFile="admin_Pnl.master" AutoEventWireup="false" CodeFile="Login_Next.aspx.vb" Inherits="Login_Next" title="TradeNET : Admin Login Screen"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="one/jquery.js"></script>
<script type="text/javascript" src="one/drupal.js"></script>
<script type="text/javascript" src="one/panels.js"></script>
<script type="text/javascript" src="one/gamabhana_drupal.js"></script>
<script type="text/javascript" src="one/GA1000.js"></script>
<script type="text/javascript" src="one/GA0010.js"></script>
<script type="text/javascript" src="one/gamabhanaLib.js"></script>
<script type="text/javascript">Drupal.extend({ settings: { "googleanalytics": { "trackOutgoing": 1, "trackMailto": 1, "trackDownload": 1, "trackDownloadExtensions": "7z|aac|avi|csv|doc|exe|flv|gif|gz|jpe?g|js|mp(3|4|e?g)|mov|pdf|phps|png|ppt|rar|sit|tar|torrent|txt|wma|wmv|xls|xml|zip", "LegacyVersion": 0 } } });</script>
<style type="text/css">
    .style2
    {
        color: #000000;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
    <tr>
        <td style="width:50%" valign="top">
                <div class="eny_cantrol_pnl">
						<img src= "images/send_initiatecontact.gif" /> User Controls<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="add_new_user.aspx">Add New User</a></li>
							<li><a href="view_all_users.aspx">View All Users</a></li>
							<li><a href="search_user.aspx">Search User</a></li>
                           <!-- <li><a href="Online_users.aspx">View Online Users</a></li> -->
                            <li><a href="delly_login_report.aspx">Login Report (ALL)</a></li>
							<li><a href="perticular_login_report2.aspx">Particular Login Reports</a></li>
							</ul>
					</div>
        </td>
        <td style="width:50%" valign="top">
         <div class="eny_cantrol_pnl">
						<img src="images/somebackground.gif" /> Departments Controls <br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="add_new_dept.aspx">Add New Departments</a></li>
							<li><a href="Assign_Exist_HOD.aspx">Assign Exist HOD To Department</a></li>
							<li><a href="transffer_dept.aspx">Transfer Department</a></li>
							<li><a href="edit_dept.aspx">Edit Department info.</a></li>
                            <li><a href="view_all_dept.aspx">View All Departments</a></li>
                                            <li><a href="assign_dept_to_srmgr.aspx">Assign Department to Sr Manager</a></li>
						</ul>
					</div>
        </td>
    </tr>
    
  <tr>
        <td style="width:50%" valign="top">
                <div class="eny_cantrol_pnl">
						<img src= "images/icp_Q.gif" /> Branch Controls<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="add_new_branch.aspx">Add New Branch</a></li>
							<li><a href="edit_branch.aspx">Edit Branch Details</a></li>
                            <li><a href="view_all_Branch.aspx">View All Branches</a></li>
						</ul>
					</div>
        </td>
        <td style="width:50%" valign="top">
         <div class="eny_cantrol_pnl">
						<img src="images/ico_testi.gif" /> Management Controls <br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="add_new_mng.aspx">Add New Management</a></li>
							<li><a href="edit_mng.aspx">Edit Management Info.</a></li>
                            <li><a href="view_all_mangs.aspx">View All Managements.</a></li>
							</ul>
					</div>
        </td>
    </tr>
    
     <tr>
        <td style="width:50%" valign="top">
                <div class="eny_cantrol_pnl">
						<img src= "images/ico_feed.gif" /> Tickets Controls<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="view_all_ticks.aspx">View All Tickets </a></li>
                            <li><a href="search_ticket.aspx">Search Tickets </a></li>
                              <li><a href="view_escal.aspx">Ticket Escalation Logs </a> <img src="images/123.gif" /></li>
                            <li><a href="view_penalty.aspx">Penalty Report</a> <img src="images/123.gif" /></li>
						</ul>
					</div>
        </td>
        <td style="width:50%" valign="top">
         <div class="eny_cantrol_pnl">
						<img src="images/ico_app.gif" /> Other Controls <br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="manage_hod.aspx">Manage HODs</a></li>
                            <li><a href="viwe_branch_n_heads.aspx">View Branch and Branch Heads</a></li>
                            <li><a href="Application_Tree.aspx">Application Tree</a> <img src="images/123.gif" /></li>
                            <li><a href="admin/Backup_Restore.aspx">Take Backup</a></li>
                            <li class="style2">
                                <asp:HyperLink ID="hl_assigntodos" runat="server" 
                                    NavigateUrl="~/Todo/Assign_task.aspx" Target="_blank">Assign Todos</asp:HyperLink>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Todo/All_task_admin.aspx" 
                                    Target="_blank">View All Todos</asp:HyperLink>
                            </li>
                            <li class="style2">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Todo/Alltask.aspx" 
                                    Target="_blank">View all Task</asp:HyperLink>
                            </li>
					    </ul>
					    <p>
                            &nbsp;</p>
					</div>
        </td>
    </tr>
</table>
</asp:Content>

