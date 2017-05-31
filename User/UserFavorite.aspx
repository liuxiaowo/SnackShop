<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserFavorite.aspx.cs" Inherits="User_UserFavorite" %>

<asp:Content ID="contentFavorite" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <div style="background:#fff;margin-top:20px;padding:20px;">
        <h3>收藏夹</h3>
    </div>
    <table style="background:#fff;padding:20px;">
        <asp:DataList ID="goodFavorite" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%" style="background:#fff;padding:20px;">
            <ItemTemplate>
                <tr style="text-align:center">
                    <td>
                        <asp:Image runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="80" Height="80" />
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" Text="移除收藏夹" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>' OnCommand ="lnkbtnDelete_Command" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>
