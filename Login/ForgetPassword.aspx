<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Login_ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="./css/Common.css" type="text/css" />
    <link rel="stylesheet" href="./css/Register.css" type="text/css" />
    <link rel="stylesheet" href="./css/ForgetPwd.css" type="text/css" />
    <script>
        $().ready(function () {
            $("#registerForm").validate();
        });
    </script>
    <title>用户忘记密码</title>
</head>
<body>
    <form id="registerForm" runat="server">
        <div id="Div1" class="container" runat="server">
            <div class="title">
                <h1>零食铺子</h1>
                <asp:LinkButton ID="backLogin" runat="server" OnClick="backLogin_Click">返回登录</asp:LinkButton>
            </div>
            <div class="div_container">
                <div class="line">
                    <label class="LabelTxt">用户名</label>
                    <asp:TextBox ID="txtName" CssClass="textBox" runat="server" required="true" ReadOnly="true"></asp:TextBox>
                </div>
                 <div class="line">
                    <label class="LabelTxt">手机号验证</label>
                    <asp:TextBox ID="phoneText" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="phone_confirmTextChanged" AutoPostBack="true" autocomplete="off"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" runat="server" ID="phoneConfirmSpan" Visible ="false">手机号不正确</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">密码</label>
                    <asp:TextBox ID="txtPasswordForget" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="pwd_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" runat="server" ID="pwdNew" Visible="false">密码6-18位</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">确认密码</label>
                    <asp:TextBox ID="confrimPwd" CssClass="textBox" runat="server" required="true" minlength="6" equalTo="#txtPassword" OnTextChanged="pwdAgain_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" CssClass="prompt" runat="server" ID="confrimPwdSpan" Visible="false">两次密码不一致</asp:Label>
                </div>
                <div class="line">
                    <asp:Button CssClass="btnChangePwd" ID="btnChangePwd" runat="server" Text="修改密码" OnClick="btn_ChangePwdClick"></asp:Button>
                </div>
            </div>
            <div class="bottom">
                <label>© 2017-2100 美美版权所有</label>
            </div>
        </div>
    </form>
</body>
</html>
