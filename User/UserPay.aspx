<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserPay.aspx.cs" Inherits="User_UserPay" %>
<asp:Content ID="contentPay" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <table style="margin:50px auto">
        <tr>
            <td>
                <h2>支付</h2>
                <asp:Label runat="server" ID="orderID">订单ID：xx</asp:Label>&nbsp;&nbsp;
                <asp:Label runat="server" ID="orderPrice">订单总金额：￥xx</asp:Label>&nbsp;&nbsp;
                <asp:Button ID="payBtn" runat="server" Text="确认支付" onClick="payBtn_onCLick" style="padding:5px 10px;background-color:#FF4400;color:#ffffff;"/>
                <asp:LinkButton ID="cancelBtn" runat="server" Text="放弃支付" onClick="cancelBtn_onCLick" style="color:#FF4400;"/>
            </td>
       </tr>
    </table>
</asp:Content>
