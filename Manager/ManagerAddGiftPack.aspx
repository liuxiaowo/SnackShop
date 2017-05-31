<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="ManagerAddGiftPack.aspx.cs" Inherits="Manager_ManagerAddGoods" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="line">
        <h3>添加大礼包</h3>
    </div>
    <table style="margin-left: 25%;">
        <tr class="line" style="text-align:center">
            <td>大礼包名称：<asp:TextBox ID="goodName" runat="server" Style="border: 1px solid" required="true" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>大礼包简介：<asp:TextBox ID="goodInfo" runat="server" Style="border: 1px solid" required="true" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>大礼包图片：
                <asp:DropDownList ID="ddlUrl" runat="server" OnSelectedIndexChanged="ddlUrl_SelectedIndexChanged" AutoPostBack="True" Style="width: 165px">
                </asp:DropDownList>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>
                <asp:ImageMap ID="ImageMapPhoto" runat="server" Width="80" Height="80">
                </asp:ImageMap>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>
                大礼包类别：
                 <asp:DropDownList ID="goodClass" runat="server" Style="width: 165px" OnSelectedIndexChanged="goodClass_SelectedChanged" AutoPostBack="True">
                    <asp:ListItem Text="坚果大礼包"/>
                    <asp:ListItem Text="零食大礼包" />
                </asp:DropDownList>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>大礼包品牌：<asp:TextBox ID="goodBrand" runat="server" Style="border: 1px solid" required="true" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>是否推荐：
                <asp:DropDownList ID="isDropDownList" runat="server" Style="width: 165px">
                    <asp:ListItem Text="True" />
                    <asp:ListItem Text="False" Selected="true" />
                </asp:DropDownList>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>大礼包打折：<asp:TextBox ID="Discount" runat="server" Style="border: 1px solid" required="true" Text="0.9" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>商品选择列表
            </td>
        </tr>
        <asp:DataList ID="GoodsChooseList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" Style="margin:0 auto;">
            <ItemTemplate>
                <tr class="line">
                    <td>
                        <asp:CheckBox runat="server" ID="chooseBox" OnCheckedChanged="goodChecked_OnCheckedChanged" AutoPostBack="true" Text='<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>'/>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "GoodUrl")%>' Width="50" Height="50" />
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%>
                    </td>
                    <td>￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%>
                    </td>
                    <td>
                        数量：<asp:TextBox ID="num" runat="server" Text="1" Style="border: 1px solid;text-align:center" Width="20px"/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:DataList>
        <tr class="line" style="text-align:center;">
            <td>市场价：<asp:Label runat="server" ID="marketPrice" Text="0.00"/>
                折扣价：<asp:Label ID="DisPrice" runat="server" Text="0.00"/>
                进货价：<asp:Label ID="RPrice" runat="server" Text="0.00" />
                进货量：<asp:Label ID="RNum" runat="server" Text="0"/>
                运费：<asp:Label ID="Fee" runat="server" Text="0.00"/>
            </td>
        </tr>
        <tr class="line" style="text-align: center;">
            <td>
                <asp:Button runat="server" Text="添加大礼包" CssClass="btn" OnClick="btn_OnClickAddGoods" width="200px" style="margin-top:20px"/>
            </td>
        </tr>
    </table>
</asp:Content>
