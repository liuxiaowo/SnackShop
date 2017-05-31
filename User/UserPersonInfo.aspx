<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="UserPersonInfo.aspx.cs" Inherits="User_UserPersonInfo" %>

<asp:Content ID="contentOrders" ContentPlaceHolderID="ContentPlaceHolderCommon" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/GoodOrderContent.css" type="text/css" />
    <table id="PersonInfo" class="goodCart" style="width: 100%">
        <tr class="line" style="width: 100%">
            <td>
                <h2>个人中心</h2>
            </td>
        </tr>
        <tr class="line" style="width: 100%">
            <td>
                <asp:LinkButton runat="server" OnClick="userInfo" Text="用户信息" />&nbsp;
                <asp:LinkButton runat="server" OnClick="MyOrderList" Text="我的订单" />&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Favoirite" Text="收藏夹" />
            </td>
        </tr>
         <asp:DataList ID="userList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="background: #fff">
            <ItemTemplate>
                <tr class="line" style="width: 100%">
                    <td><strong>用户基本信息</strong>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="changePwd" Text="修改密码" />
                    </td>
                </tr>
                <tr class="line" style="width: 100%">
                    <td>用户ID：<%#DataBinder.Eval(Container.DataItem, "UserID")%>&nbsp;
                        用户名：<%#DataBinder.Eval(Container.DataItem, "UserName")%>&nbsp;
                        性别：<%#DataBinder.Eval(Container.DataItem, "Sex")%>&nbsp;
                        手机号：<%#DataBinder.Eval(Container.DataItem, "Phonecode")%>
                    </td>
                </tr>
                <tr class="line" style="width: 100%">
                    <td><strong>收货地址信息</strong>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="changeAddress" Text="修改收货地址" />
                    </td>
                </tr>
                <tr class="line" style="width: 100%">
                    <td>
                        收货人：<%#DataBinder.Eval(Container.DataItem, "RealName")%>&nbsp;<%#DataBinder.Eval(Container.DataItem, "Phonecode")%>&nbsp;
                        详细地址：<%#DataBinder.Eval(Container.DataItem, "Address")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
    </table>
</asp:Content>
