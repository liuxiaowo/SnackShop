<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserChangePwd.aspx.cs" Inherits="Login_ForgetPassword" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/Register.css" type="text/css" />
    <div class="div_container">
        <div class="line" style="width: 80%; margin: 0 auto;">
            <h3>修改用户密码</h3>
        </div>
        <div class="line" style="width:80%;margin:0 auto;">
            <asp:LinkButton ID="LinkButton1" runat="server" Text="返回个人中心" OnClick="backPersonInfo"/>
        </div>
        <div class="line" style="width: 80%; margin: 0 auto;">
            <label class="LabelTxt">用户名</label>
            <asp:TextBox ID="txtName" CssClass="textBox" runat="server" required="true" ReadOnly="true" BorderWidth="1"></asp:TextBox>
        </div>
         <div class="line" style="width: 80%; margin: 0 auto;">
            <label class="LabelTxt">旧密码</label>
            <asp:TextBox ID="pwdOld" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="pwdOld_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off" BorderWidth="1"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
            <asp:Label Style="color: #ff0000" class="prompt" runat="server" ID="pwdOldText" Visible="false">与旧密码不符</asp:Label>
        </div>
        <div class="line" style="width: 80%; margin: 0 auto;">
            <label class="LabelTxt">新密码</label>
            <asp:TextBox ID="txtPasswordForget" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="pwd_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off" BorderWidth="1"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
            <asp:Label Style="color: #ff0000" class="prompt" runat="server" ID="pwdNew" Visible="false">密码6-18位</asp:Label>
        </div>
        <div class="line" style="width: 80%; margin: 0 auto;">
            <label class="LabelTxt">确认密码</label>
            <asp:TextBox ID="confrimPwd" CssClass="textBox" runat="server" required="true" minlength="6" equalTo="#txtPassword" OnTextChanged="pwdAgain_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off" BorderWidth="1"></asp:TextBox>
            <span style="color: #ff0000" class="prompt">*</span>
            <asp:Label Style="color: #ff0000" CssClass="prompt" runat="server" ID="confrimPwdSpan" Visible="false">两次密码不一致</asp:Label>
        </div>
        <div class="line" style="width: 80%; margin: 0 auto;margin-top:10px">
            <asp:Button CssClass="btnRegister" ID="btnChangePwd" runat="server" Text="修改密码" OnClick="btn_ChangePwdClick"></asp:Button>
        </div>
    </div>
</asp:Content>
