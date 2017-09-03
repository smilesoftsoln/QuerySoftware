<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="admin_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<link href="sitemapstyler/sitemapstyler.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="sitemapstyler/sitemapstyler.js"></script>
<head runat="server">
    <title>Untitled Page</title>
    <style>
a{
	text-decoration:none;
	color:#057fac;
}
a:hover{
	text-decoration:none;
	color:#999;
}

#container{
	margin:0 auto;
	width:680px;
	background:#fff;
	padding-bottom:20px;
}
#content{margin:0 20px;}
p{	
	margin:0 auto;
	width:680px;
	padding:1em 0;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="content">
        <div id="Disp_result" runat="server"></div>
    </div>
    </div>
    </form>
</body>
</html>
