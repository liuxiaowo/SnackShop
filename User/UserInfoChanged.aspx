<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserInfoChanged.aspx.cs" Inherits="User_UserInfoChanged" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/Register.css" type="text/css" />
    <div class="div_container">
        <div class="line" style="width:80%;margin:0 auto;">
            <h3>修改收货地址</h3>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <asp:LinkButton ID="LinkButton1" runat="server" Text="返回个人中心" OnClick="backPersonInfo"/>&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Text="返回提交订单界面" OnClick="backUpOrders"/>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <label class="LabelTxt">用户名</label>
            <asp:TextBox ID="txtName" CssClass="textBox" runat="server" required="true" ReadOnly="true" BorderWidth="1" width="200px"></asp:TextBox>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <label class="LabelTxt">收货人</label>
            <asp:TextBox ID="textRevName" CssClass="textBox" runat="server" required="true" autocomplete="off" BorderWidth="1" width="200px"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <label class="LabelTxt">手机号</label>
            <asp:TextBox ID="textPhone" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="phone_textChanged" AutoPostBack="true"  autocomplete="off" BorderWidth="1" width="200px"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
            <asp:Label Style="color: #ff0000" class="prompt" runat="server" ID="textPhoneLabel" Visible="false">手机号不正确</asp:Label>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <label class="LabelTxt">收货地址</label>
            <asp:TextBox ID="Address" CssClass="textBox" runat="server" required="true"  autocomplete="off" BorderWidth="1" width="200px"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
        </div>
        <div class="line" style="width:80%;margin:0 auto;margin-top:20px">
            <asp:Button  ID="btnChangeAddress" runat="server" Text="修改收货地址" OnClick="btn_ChangeAddressClick" CssClass="btnRegister" width="200px"></asp:Button>
        </div>
    </div>
</asp:Content>
