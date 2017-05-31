<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master"  AutoEventWireup="true" CodeFile="MangerOrderDetails.aspx.cs" Inherits="Manager_MangerGoodsDetails" %>

<asp:Content ID="contentOrderDetails" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="../css/OrderDetailsContent.css" type="text/css" />
    <table class="goodCart">
        <asp:DataList ID="orderList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line" style="text-align:left;">
                    <td>
                        <h3>订单详情</h3>
                        <span>【注】订单状态：0-未付款，1-未发货，2-未接收，3-已接收，4-退单，5-退单完成</span>
                    </td>
                </tr>
                <tr class="line">
                    <td>订单号：<%#DataBinder.Eval(Container.DataItem, "OrderID")%>
                    </td>
                    <td>订单状态：<%#DataBinder.Eval(Container.DataItem, "OrderState")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        下单时间：<%#DataBinder.Eval(Container.DataItem, "OrderDate")%>
                    </td>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="OrderAddressList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line" style="text-align:left;">
                    <td>
                        <h4>收货地址</h4>
                    </td>
                </tr>
                <tr class="line_left">
                    <td>收货人：<%#DataBinder.Eval(Container.DataItem, "RealName")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "Phonecode")%>
                &nbsp;详细地址：<%#DataBinder.Eval(Container.DataItem, "Address")%>
                    </td>
                </tr>
                <tr class="line" style="text-align:left;">
                    <td>
                        <h4>商品信息</h4>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="goodOrderList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line">
                    <td style="margin-left:30px;float:left;">
                        <%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
                    </td>
                    <td style="float: left; margin-left: 50px; margin-top: 10px; width: 340px">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="50" Height="50" Style="vertical-align: middle;" />
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td style="float: left; width: 50px; height: 50px; margin-top: 20px; text-align: center">￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td style="float: left; width: 180px; height: 50px; margin-top: 20px; text-align: center">
                        <asp:Label ID="txtNum" runat="server"><%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                    <td style="float: left; width: 60px; height: 50px; margin-top: 20px;">￥<asp:Label runat="server" Style="color: #f00;" ID="SinglePrice"><%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>*<%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="PayWayList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line" style="margin-top: 10px; margin-left: 40px;">
                    <td style="padding: 0 10px;">运输方式：<%#DataBinder.Eval(Container.DataItem, "ShipType")%>
                    </td>
                    <td style="padding: 0 10px;">运费：￥<span style="color: #f00"><%#DataBinder.Eval(Container.DataItem, "ShipFee","{0:f2}")%></span>
                    </td>
                    <td style="padding: 0 10px;">付款方式：<%#DataBinder.Eval(Container.DataItem, "PayWay")%>
                    </td>
                    <td style="padding: 0 10px;">给卖家留言：<%#DataBinder.Eval(Container.DataItem, "Remark")%>
                    </td>
                    <td>
                        总金额:￥<asp:Label ID="Label1" runat="server" Style="color: #f00"><%#DataBinder.Eval(Container.DataItem, "TotalFee","{0:f2}")%></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>

