<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="./css/Common.css" type="text/css" />
    <link rel="stylesheet" href="./css/Login.css" type="text/css" />
    <title>登录</title>
</head>
<body>
    <form id="form1" runat="Server">
        <div class="container" runat="server">
            <div class="title">
                <h1>零食铺子</h1>
                <asp:LinkButton ID="goRegister" CssClass="goRegister" runat="server" OnClick="goRegister_Click">前往注册</asp:LinkButton>
            </div>
            <table class="div_container">
                <tr>
                    <td class="logo"></td>
                    <td class="right">
                        <table class="right_table">
                            <tr class="line">
                                <td>
                                    <asp:RadioButtonList ID="identity" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="identity_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Selected="True">  用户</asp:ListItem>
                                        <asp:ListItem class="manager">  管理员</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr class="line">
                                <td>登录名:
                                    <br />
                                    <asp:TextBox ID="txtName" runat="server" class="inputstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="line">
                                <td>密码:
                                    <br />
                                    <asp:TextBox ID="txtPasswordLogin" runat="server" class="inputstyle" autocomplete="off" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="line">
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                验证码:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtValid" runat="server" class="inputstyle_code" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="labValid" runat="server" class="code" Text="8888" BackColor="#F7CC42" Font-Names="幼圆"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="codeAgain" runat="server" OnClick="codeAgain_Click" CssClass="codeAgain">换一张</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="line">
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin" Text="登录" OnClick="btnLogin_Click"></asp:Button>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="forgetPwd" runat="server" OnClick="forgetPwd_Click">忘记密码？</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div class="bottom">
                <label>© 2017-2100 美美版权所有</label>
            </div>
        </div>
    </form>
</body>
</html>
