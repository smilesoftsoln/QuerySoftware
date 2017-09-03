<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mng_online_users.aspx.vb" Inherits="mng_online_users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="stylesheet" type="text/css" href="jTable/css/flexigrid/flexigrid.css">
<script type="text/javascript" src="jTable/lib/jquery/jquery.js"></script>
<script type="text/javascript" src="jTable/flexigrid.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Online Users</h2>
<hr />
<div id="disp_online_stts" runat="server"></div>
<script type="text/javascript">
			$('.flexme1').flexigrid();
			$('.flexme2').flexigrid({height:'auto',striped:false});
</script>
    </div>
    </form>
</body>
</html>
