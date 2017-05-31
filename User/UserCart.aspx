<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserCart.aspx.cs" Inherits="User_UserCart" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/GoodCartContent.css" type="text/css" />
    <table id="goodCart" class="goodCart">
        <tr style="float: left; margin-left: 20px; margin-top: 10px;">
            <td>
                <h2>购物车</h2>
                <br />
                全部商品
                (<asp:Label ID="AllGoodsNum" runat="server" Style="color: #f00">0</asp:Label>)
            </td>
        </tr>
        <tr class="line">
            <th>商品信息</th>
            <th>单价</th>
            <th>数量</th>
            <th>金额</th>
            <th>操作</th>
        </tr>
        <asp:DataList ID="goodCartList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" style="background:#fff">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
                    </td>
                    <td style="float: left; margin-left: 50px;margin-top:10px; width:340px">
                        <asp:Image runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="50" Height="50" Style="vertical-align: middle;" />
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td  style="float: left; width:50px;height:50px;margin-top:20px;text-align:center">
                        ￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td style="float: left; width:180px;height:50px;margin-top:20px;text-align:center">
                        <asp:Label ID="txtNum" runat="server"><%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                    <td style="float: left; width:60px;height:50px;margin-top:20px;">￥<asp:Label runat="server" Style="color: #f00;" ID="SinglePrice"><%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>*<%#DataBinder.Eval(Container.DataItem, "GoodsNum")%></asp:Label>
                    </td>
                    <td style="float: left; width:80px;height:50px;margin-top:20px;text-align:right">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>' OnCommand ="lnkbtnDelete_Command">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>

    <table class="goodCart">
        <tr>
            <td class="line_left">
                <asp:LinkButton ID="clearBuyCart" runat="server" OnClick="clearCart">清空购物车</asp:LinkButton>
            </td>
            <td class="line_right">合计(不含运费)：￥<asp:Label ID="AllPrice" runat="server" Style="color: #f00">0.00</asp:Label>
                <asp:Button runat="server" Text="结算" CssClass="Settlement" OnClick="settleAccounts_onClick" />
            </td>
        </tr>
    </table>
</asp:Content>
