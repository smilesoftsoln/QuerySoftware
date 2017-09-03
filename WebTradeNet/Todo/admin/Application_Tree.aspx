<%@ Page Language="VB" MasterPageFile="~/todo/admin/admin_Pnl.master" AutoEventWireup="false" CodeFile="Application_Tree.aspx.vb" Inherits="admin_Application_Tree" title="Application Tree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="sitemapstyler/sitemapstyler.css" rel="stylesheet" type="text/css" media="screen" />
<script type="text/javascript" src="sitemapstyler/sitemapstyler.js"></script>
    <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Application Tree</h2>
( <img src="sitemapstyler/collapsed.gif" /> Collapsed | <img src="sitemapstyler/expanded.gif" /> Expand )
<hr />
<div class="div_samp_one">
    <div id="content">
    
   
        <div id="Disp_result" runat="server"></div>
    </div>
    </div>
</asp:Content>

