<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="User_UserControl_Menu" %>
<link rel="stylesheet" href="./css/Common.css" type="text/css" />
<link rel="stylesheet" href="./css/Menu.css" type="text/css" />
<div runat="server" class="container">
        <div class="left">
            <asp:LinkButton ID="Loginbtn" runat="server" OnClick="goLogin_Click">亲，请登录</asp:LinkButton>
            <asp:LinkButton ID="Registerbtn"  runat="server" OnClick="goRegister_Click">免费注册</asp:LinkButton>
            <asp:Label ID="welcome" runat="server">欢迎,</asp:Label>
            <asp:LinkButton ID="LoginedUserName"  runat="server">用户</asp:LinkButton>
            <asp:LinkButton ID="exit"  runat="server" CssClass="exit" OnClick="Exit_Click">退出登录</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2"  runat="server" CssClass="exit" OnClick="BackToIndex_Click">返回首页</asp:LinkButton>
        </div>
        <div class="right">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Minebtn_onClick">个人中心</asp:LinkButton>
            <asp:LinkButton ID="MineOrderbtn" runat="server" OnClick="MineOrderbtn_onClick">我的订单</asp:LinkButton>
            <asp:LinkButton ID="ShoppingCartbtn"  runat="server" OnClick="ShoppingCartbtn_onClick">购物车<asp:Label ID="cartGoodsNum" runat="server" style="color:#f00"></asp:Label></asp:LinkButton>
            <asp:LinkButton ID="Favoritebtn"  runat="server" OnClick="Favoritebtn_onClick">收藏夹</asp:LinkButton>
        </div>
</div>
