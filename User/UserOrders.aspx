<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserOrders.aspx.cs" Inherits="User_UserOrders" %>

<asp:Content ID="contentOrders" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/GoodOrderContent.css" type="text/css" />
    <table id="goodCart" class="goodCart">
        <tr class="line">
            <td>
                <h2>我的订单</h2>
            </td>
        </tr>
        <asp:DataList ID="OrderAddressList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line">
                    <td>
                        <h4>确定收货地址</h4>
                    </td>
                </tr>
                <tr class="line">
                    <td>收货人：<%#DataBinder.Eval(Container.DataItem, "RealName")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "Phonecode")%>
                        &nbsp;详细地址：<%#DataBinder.Eval(Container.DataItem, "Address")%>
                    </td>
                    <td>
                        &nbsp;
                        <asp:LinkButton runat="server" Text="编辑" OnClick="ChangedUserInfo_onClick"></asp:LinkButton>
                    </td>
                </tr>
                <tr  class="line">
                    <td>
                        <h4>确定订单信息</h4>
                    </td>
                </tr>
                <tr>
                    <th style="height:40px;line-height:40px;text-align:center;width:50px;">商品信息</th>
                    <th style="height:40px;line-height:40px;text-align:center;width:50px;">单价</th>
                    <th style="height:40px;line-height:40px;text-align:center;width:50px;">数量</th>
                    <th style="height:40px;line-height:40px;text-align:center;width:50px;">小计</th>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="goodOrderList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr>
                    <td style="float: left; margin-left: 50px;margin-top:10px; width:300px">
                        <%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
                        <asp:Image runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="50" Height="50" Style="vertical-align: middle;" />
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td style="width:90px;height:50px;text-align:center">￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td style="width:90px;height:50px;text-align:center">
                        <asp:Label ID="txtNum" runat="server"><%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                    <td style="width:80px;height:50px;text-align:center">￥<asp:Label runat="server" Style="color: #f00;" ID="SinglePrice"><%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>*<%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <asp:DataList ID="PayWayList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line" style="margin-top:10px;margin-left:40px;">
                     <td style="padding:0 10px;">运输方式：<%#DataBinder.Eval(Container.DataItem, "ShipType")%>
                    </td>
                    <td style="padding:0 10px;">运费：￥<span style="color:#f00"><%#DataBinder.Eval(Container.DataItem, "ShipFee","{0:f2}")%></span>
                    </td>
                    <td style="padding:0 10px;">付款方式：<%#DataBinder.Eval(Container.DataItem, "PayWay")%>
                    </td>
                    <td style="padding:0 10px;">给卖家留言：<asp:TextBox ID="LeavingMsg" runat="server">无</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="line_right">合计(不含运费)：￥<asp:Label ID="AllPrice" runat="server" Style="color: #f00"><%#DataBinder.Eval(Container.DataItem, "TotalFee","{0:f2}")%></asp:Label>
                        <asp:Button ID="submitOrderBtn" runat="server" Text="提交订单" CssClass="Settlement" OnClick="submitOrderBtn_onClick" />
                        <asp:LinkButton runat="server" Text="取消订单" OnClick="cancelOrder"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>

