<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="User_UserControl_Search" %>
<link rel="stylesheet" href="./css/Common.css" type="text/css" />
<link rel="stylesheet" href="./css/Search.css" type="text/css" />
<link rel="stylesheet" type="text/css" href="./css/normalize.css" />
<div id="title" runat="server" class="title">
    <h1>零食铺子</h1>
    <asp:DropDownList ID="type" runat="server" CssClass="DropDownList">
        <asp:ListItem>商品名称</asp:ListItem>
        <asp:ListItem>品牌</asp:ListItem>
        <asp:ListItem>类别</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="searchBox" runat="server" CssClass="searchBox" autocomplete="on"></asp:TextBox>
    <asp:Button ID="searchbtn" runat="server" Text="搜索" CssClass="searchbtn" OnClick="searchbtn_onClick" />
</div>
