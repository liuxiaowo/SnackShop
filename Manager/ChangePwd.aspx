<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master"  AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Manager_ChangePwd" %>

<asp:Content ID="changePwd" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
     <link rel="stylesheet" href="./css/changePwd.css" type="text/css" />
    <table style="margin:0 auto;width:100%;">
        <tr>
            <td>
               <h3>修改密码</h3> 
            </td>
        </tr>
        <tr>
            <td>
                <div class="line">
                    <label class="LabelTxt">管理员名</label>
                    <asp:TextBox ID="txtName" CssClass="textBox" runat="server" required="true" ReadOnly="true" style="border:1px solid"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                </div>
                <div class="line">
                    <label class="LabelTxt">输入密码</label>
                    <asp:TextBox ID="txtPasswordForget" CssClass="textBox" runat="server" required="true" minlength="6" OnTextChanged="pwd_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off" style="border:1px solid"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" class="prompt" runat="server" ID="pwdNew" Visible="false">密码6-18位</asp:Label>
                </div>
                <div class="line">
                    <label class="LabelTxt">确认密码</label>
                    <asp:TextBox ID="confrimPwd" CssClass="textBox" runat="server" required="true" minlength="6" equalTo="#txtPassword" OnTextChanged="pwdAgain_textChanged" AutoPostBack="true" TextMode="Password" autocomplete="off" style="border:1px solid"></asp:TextBox>
                    <span style="color: #ff0000" class="prompt">*</span>
                    <asp:Label style="color: #ff0000" CssClass="prompt" runat="server" ID="confrimPwdSpan" Visible="false">密码不一致</asp:Label>
                </div>
                <div class="line">
                    <asp:Button CssClass="btnChangePwd" ID="btnChangePwd" runat="server" Text="修改密码" OnClick="btn_ChangePwdClick"></asp:Button>
                </div>
            </td>
            </tr>
    </table>
</asp:Content>
