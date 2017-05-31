<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="ManagerGoods.aspx.cs" Inherits="Manager_ManagerGoods" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <link rel="stylesheet" href="../css/index.css" type="text/css" />
    <table>
        <tr class="line">
            <td>
                <h3>商品管理</h3>
                <asp:LinkButton runat="server" Text="添加商品" OnClick="AddGood_onCLick"/>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="添加大礼包" OnClick="AddGift_onCLick"/>
            </td>
        </tr>
        <asp:DataList ID="MsgGoodsList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff;" OnItemDataBound="MsgGoodsList_onItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                       ID：<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>
                    </td>
                    <td>
                        <asp:Image runat="server" imageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="50" Height="50" Style="vertical-align: middle;"/>
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td>
                        ￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td>
                        类别：<%#DataBinder.Eval(Container.DataItem, "Class")%>
                    </td>
                    <td>
                        销量：<%#DataBinder.Eval(Container.DataItem, "SalesVolume")%>
                    </td>
                    <td>
                         <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>' OnCommand ="lnkbtnChange_Command">修改</asp:LinkButton>
                    </td>
                    <td>
                         <asp:LinkButton ID="Drop" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>' OnCommand ="lnkbtnDrop_Command">下架</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>
