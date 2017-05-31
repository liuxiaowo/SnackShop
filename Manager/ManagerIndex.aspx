<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="ManagerIndex.aspx.cs" Inherits="Manager_ManagerIndex" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="../css/index.css" type="text/css" />
    <table>
        <tr class="line">
            <td>
                <h3>订单管理</h3>
                <span>【注】订单状态：0-未付款，1-未发货，2-未接收，3-已接收，4-退单，5-退单完成</span>
            </td>
        </tr>
        <tr>
            <td><asp:LinkButton runat="server" Text="营业额统计" OnClick="allMoney_onClick"/>
                ￥<asp:Label runat="server" ID="AllMoneyLabel" style="color:#f00" Text="0"></asp:Label>
            </td>
        </tr>
        <tr class="line">
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="全部" OnClick="allBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Text="代付款" OnClick="payBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" Text="待发货" OnClick="sendBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" Text="待收货" OnClick="takeOverBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton5" runat="server" Text="已接收" OnClick="FinishBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton7" runat="server" Text="退单" OnClick="ExitBtn_onClick" />&nbsp;
                <asp:LinkButton ID="LinkButton8" runat="server" Text="退单完成" OnClick="ExitFinishBtn_onClick" />
            </td>
        </tr>
        <asp:DataList ID="myOrderListMag" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff;" OnItemDataBound="myOrderGoodList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>订单号：<%#DataBinder.Eval(Container.DataItem, "OrderID")%>&nbsp;
                        下单时间：<%#DataBinder.Eval(Container.DataItem, "OrderDate")%>&nbsp;
                        订单状态：<%#DataBinder.Eval(Container.DataItem, "OrderState")%>&nbsp;
                        <asp:LinkButton ID="sendOrder" runat="server" Text="发货" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "OrderID")%>' OnCommand="lnkbtnsend_Command" Visible="false" />
                        <asp:LinkButton ID="exitOrder" runat="server" Text="退单" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "OrderID")%>' OnCommand="lnkbtnexit_Command" Visible="false" />
                        <asp:LinkButton ID="LinkButton6" runat="server" Text="详情" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "OrderID")%>' OnCommand="lnkbtnDetails_Command" />
                    </td>
                </tr>
                <asp:DataList ID="myOrderGoodList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
                    <ItemTemplate>
                        <asp:GridView ID="GridView1" runat="server" DataSource='<%# Container.DataItem %>' Width="100%" Style="text-align: center;">
                        </asp:GridView>
                    </ItemTemplate>
                </asp:DataList>
                <tr>
                    <td>总金额：￥<%#DataBinder.Eval(Container.DataItem, "TotalFee","{0:f2}")%>&nbsp;
                        (运费：￥<%#DataBinder.Eval(Container.DataItem, "ShipFee","{0:f2}")%>)
                    </td>
                </tr>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>
