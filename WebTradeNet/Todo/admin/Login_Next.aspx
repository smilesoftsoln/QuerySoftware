﻿
<%@ Page Language="VB" MasterPageFile="admin_Pnl.master" AutoEventWireup="false" CodeFile="Login_Next.aspx.vb" Inherits="Login_Next" title="TradeNET : Admin Login Screen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="one/jquery.js"></script>
<script type="text/javascript" src="one/drupal.js"></script>
<script type="text/javascript" src="one/panels.js"></script>
<script type="text/javascript" src="one/gamabhana_drupal.js"></script>
<script type="text/javascript" src="one/GA1000.js"></script>
<script type="text/javascript" src="one/GA0010.js"></script>
<script type="text/javascript" src="one/gamabhanaLib.js"></script>
<script type="text/javascript">Drupal.extend({ settings: { "googleanalytics": { "trackOutgoing": 1, "trackMailto": 1, "trackDownload": 1, "trackDownloadExtensions": "7z|aac|avi|csv|doc|exe|flv|gif|gz|jpe?g|js|mp(3|4|e?g)|mov|pdf|phps|png|ppt|rar|sit|tar|torrent|txt|wma|wmv|xls|xml|zip", "LegacyVersion": 0 } } });</script>
 
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
						</ul>
					</div>
        </td>
    </tr>
    
  <tr>
        <td style="width:50%" valign="top">
                <div class="eny_cantrol_pnl">
						<img src= "images/icp_Q.gif" /> #### Controls<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="JavaScript:Return False()">##### ## #####</a></li>
							<li><a href="JavaScript:Return False()">##### ## #####</a></li>
                            <li><a href="JavaScript:Return False()">##### ## #####</a></li>
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
						<img src= "images/ico_feed.gif" /> ###### Controls<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="JavaScript:Return False()">###### ###### ###### </a></li>
                            <li><a href="JavaScript:Return False()">###### ###### </a></li>
						</ul>
					</div>
        </td>
        <td style="width:50%" valign="top">
         <div class="eny_cantrol_pnl">
						<img src="images/ico_app.gif" /> Other Controls <br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="manage_hod.aspx">Manage HODs</a></li>
                            <%--<li><a href="viwe_branch_n_heads.aspx">View Branch and Branch Heads</a></li>--%>
                            <li><a href="Application_Tree.aspx">Application Tree</a> <img src="images/123.gif" /></li> 
					    </ul>
					</div>
        </td>
    </tr>
    <!--
    <tr>
        <td style="width:50%" valign="top">
                <div class="eny_cantrol_pnl">
						<img src= "images/ico_img_gall.gif" /> User Reports<br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="delly_login_report.aspx">Login Report (ALL)</a></li>
							<li><a href="perticular_login_report2.aspx">Perticular Login Reports</a></li>
						</ul>
					</div>
        </td>
        <td style="width:50%" valign="top">
         <div class="eny_cantrol_pnl">
						<img src="images/ico_slider.gif" /> //Reserved// Controls <br />
						<img src="images/main_body_bg_sep.jpg"  />
						<ul>
							<li><a href="JavaScript:Return false()">//Reserved//</a></li><li><a href="JavaScript:Return false()">//Reserved//</a>
						</li></ul>
					</div>
        </td>
    </tr>
    -->
</table>



	
				
</asp:Content>

