<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserMyOrders.aspx.cs" Inherits="User_UserMyOrders" %>

<asp:Content ID="contentPay" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/MyOrdersContent.css" type="text/css" />
    <table class="contentGoodDetails">
        <tr class="line">
            <td>
                <h3>我的订单</h3>
                <span>【注】订单状态：0-未付款，1-未发货，2-未接收，3-已接收，4-退单，5-退单完成</span>
            </td>
        </tr>
        <tr class="line">
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="全部"  OnClick="allBtn_onClick"/>&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Text="代付款" OnClick="payBtn_onClick"/>&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" Text="待发货" OnClick="sendBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" Text="待收货" OnClick="takeOverBtn_onClick"/>&nbsp;
                <asp:LinkButton ID="LinkButton5" runat="server" Text="完成" OnClick="FinishBtn_onClick"/>
            </td>
        </tr>
        <asp:DataList ID="myOrderList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background:#fff;" OnItemDataBound="myOrderGoodList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>订单号：<%#DataBinder.Eval(Container.DataItem, "OrderID")%>&nbsp;
                        下单时间：<%#DataBinder.Eval(Container.DataItem, "OrderDate")%>&nbsp;
                        订单状态：<%#DataBinder.Eval(Container.DataItem, "OrderState")%>&nbsp;
                         <asp:LinkButton ID="LinkButton6" runat="server" Text="详情" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "OrderID")%>' OnCommand ="lnkbtnDetails_Command"/>
                    </td>
                </tr>
                <asp:DataList ID="myOrderGoodList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background:#fff">
                    <ItemTemplate>
                        <asp:GridView ID="GridView1" runat="server" DataSource='<%# Container.DataItem %>' Width="100%" style="text-align:center;">
                        </asp:GridView>
                    </ItemTemplate>
                </asp:DataList>
                <tr>
                    <td>
                        总金额：￥<%#DataBinder.Eval(Container.DataItem, "TotalFee","{0:f2}")%>&nbsp;
                        (运费：￥<%#DataBinder.Eval(Container.DataItem, "ShipFee","{0:f2}")%>)
                    </td>
                </tr>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>

