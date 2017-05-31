<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="./css/Common.css" type="text/css" />
    <link rel="stylesheet" href="./css/Register.css" type="text/css" />
    <script>
        $().ready(function () {
            $("#registerForm").validate();
        });
    </script>
    <title>用户注册</title>
</head>
<body>
    <form id="registerForm" runat="server">
        <div class="container" runat="server">
            <div class="title">
                <h1>零食铺子</h1>
                <asp:LinkButton ID="backLogin" runat="server" OnClick="backLogin_Click">返回登录</asp:LinkButton>
            </div>
            <div class="div_container">
                <div class="line">
                    <label class="LabelTxt">用户名</label>
                    <asp:TextBox ID="txtName" CssClass="textBox" runat="server" required="true" autocomplete="off" OnTextChanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <span  style="color: #ff0000" CssClass="prompt">*</span>
                    <asp:Label style="color: #ff0000" CssClass="prompt" runat="server" ID="UserNameIsExist" Visible="false">用户名已经存在</asp:Label>
            <br/>
                </div>
                <div class="line">
                    <label class="LabelTxt">密码</label>
                    <asp:TextBox ID="txtPassword" CssClass="textBox" runat="server" required="true" TextMode="Password" autocomplete="off" OnTextChanged="txtPwd_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <span  style="color: #ff0000" CssClass="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" runat="server" ID="PwdIsExist" Visible="false">密码6-18位</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">确认密码</label>
                    <asp:TextBox ID="confrimPwd" CssClass="textBox" runat="server" required="true" minlength="6" equalTo="#txtPassword" TextMode="Password" autocomplete="off" OnTextChanged="txtPwdAgain_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <span  style="color: #ff0000" CssClass="prompt">*</span>
                    <asp:Label style="color: #ff0000" CssClass="prompt" runat="server" ID="confrimPwdSpan" Visible="false">两次密码不一致</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">性别</label>
                    <asp:DropDownList ID="ddlSex" runat="server" CssClass="textBox">
                        <asp:ListItem Selected="True">男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="line">
                    <label class="LabelTxt">收货人</label>
                    <asp:TextBox ID="txtTrueName" CssClass="textBox" runat="server" autocomplete="off" required="true" OnTextChanged="txtTrueName_onTextChanged" AutoPostBack="true"></asp:TextBox>
                    <span  style="color: #ff0000" CssClass="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" ID="txtTrueNameLabel" runat="server" Visible="false">收货人不能为空</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">手机号</label>
                    <asp:TextBox ID="txtPhone" CssClass="textBox" runat="server" required="true" TextMode="Phone" autocomplete="off" OnTextChanged="txtPhone_textChanged" AutoPostBack="true"></asp:TextBox>
                    <span  style="color: #ff0000" CssClass="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" ID="txtPhoneLabel" runat="server" Visible="false">手机号码有误</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">详细地址</label>
                    <asp:TextBox ID="txtAddress" CssClass="textBox" runat="server" Height="80px" TextMode="MultiLine" required="true" autocomplete="off" OnTextChanged="address_textChanged" AutoPostBack="true"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" ID="textAddressLabel" runat="server" Visible="false">地址不能为空</asp:Label>
                </div>
                <div class="line">
                    <asp:Button CssClass="btnRegister" ID="btnRegister" runat="server" Text="立即注册" OnClick="btnRegister_Click"></asp:Button>
                    <asp:LinkButton CssClass="btnReset" ID="btnReset" runat="server" CausesValidation="False" Text="重置" OnClick="btnReset_Click" />
                </div>
            </div>
            <div class="bottom">
                <label>© 2017-2100 美美版权所有</label>
            </div>
        </div>
    </form>
</body>
</html>
