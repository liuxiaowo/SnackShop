<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserGoodDetails.aspx.cs" Inherits="User_UserGoodDetails" %>

<asp:Content ID="contentGoodDetails" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/GoodDetailsContent.css" type="text/css" />
    <asp:DataList ID="goodDatailsList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
        <ItemTemplate>
            <table class="contentGoodDetails" runat="server">
                <tr>
                    <td>
                        <asp:Image runat="server" ImageUrl =<%#DataBinder.Eval(Container.DataItem,"GoodUrl")%> Width="350" Height="350" CssClass="image" />
                    </td>
                    <td class="rightGoodsDetails">
                        <table>
                            <tr class="lineGoodsDetails">
                                <td>
                                    <h3><%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%></h3>
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>价格：<span style="color:#797777;text-decoration:line-through;">￥<%#DataBinder.Eval(Container.DataItem, "MarketPrice","{0:f2}")%></span>
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>折扣价：<span style="color:#f00;font-size:24px;">￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%></span>
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>运费：￥<%#DataBinder.Eval(Container.DataItem, "Freight","{0:f2}")%>,包邮
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>销量：<span style="color:#f00;"><%#DataBinder.Eval(Container.DataItem, "SalesVolume")%></span>
                                </td>
                                <td>
                                    <asp:LinkButton ID="Button1" runat="server" Text="收藏" OnClick="collect_onClick"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>数量：
                                    <asp:ImageButton ID="NumReduceBtn" runat="server" ImageUrl="./images/numReduce.png" OnClick="NumReduceBtn_onClick"/>
                                    <asp:TextBox ID="txtNum" runat="server" CssClass="Num">1</asp:TextBox>
                                    <asp:ImageButton ID="NumAddBtn" runat="server" ImageUrl="./images/numAdd.png" OnClick="NumAddBtn_onClick"/>
                                </td>
                                <td>库存：<%#DataBinder.Eval(Container.DataItem, "Surplus")%>件
                                </td>
                            </tr>
                            <tr class="lineGoodsDetails">
                                <td>
                                    <asp:Button ID="buy" runat="server" CssClass="btnBuy" Text="立即购买" OnClick="buy_onClick"></asp:Button>
                                </td>
                                <td>
                                    <asp:Button ID="addCart" runat="server" CssClass="btnAddCart" Text="加入购物车" OnClick="addCart_onClick"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
