<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/CommonMasterPage.master" AutoEventWireup="true" CodeFile="ManagerAddGoods.aspx.cs" Inherits="Manager_ManagerAddGoods" %>

<asp:Content ID="contentBuyCart" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div class="line">
        <h3>添加商品</h3>
    </div>
    <table style="margin-left:25%;">
        <tr class="line" style="text-align:right;">
            <td>
                商品名称：<asp:TextBox id="goodName" runat="server" style="border:1px solid" required="true" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                商品简介：<asp:TextBox ID="goodInfo" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                商品图片：
                <asp:DropDownList ID="ddlUrl" runat="server" OnSelectedIndexChanged="ddlUrl_SelectedIndexChanged" AutoPostBack="True" style="width:165px">
                </asp:DropDownList>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>
                <asp:ImageMap ID="ImageMapPhoto" runat="server" Width="80" Height="80" >
                                    </asp:ImageMap>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                商品类别：<asp:TextBox ID="goodClass" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                商品品牌：<asp:TextBox ID="goodBrand" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                是否推荐：
                <asp:DropDownList id="isDropDownList" runat="server" style="width:165px">
                    <asp:ListItem Text="True" />
                    <asp:ListItem Text="False" Selected="true"/>
                </asp:DropDownList>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                市场价：<asp:TextBox ID="marketPrice" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                折扣价：<asp:TextBox ID="DisPrice" runat="server" style="border:1px solid" required="true" />
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                进货价：<asp:TextBox ID="inPrice" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                进货量：<asp:TextBox ID="inNum" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:right">
            <td>
                运费：<asp:TextBox ID="Fee" runat="server" style="border:1px solid" required="true"/>
                <span style="color: #ff0000" class="prompt">*</span>
            </td>
        </tr>
        <tr class="line" style="text-align:center">
            <td>
                <asp:Button runat="server" Text="添加商品" CssClass="btn" OnClick="btn_OnClickAddGoods"/>
            </td>
        </tr>
    </table>
</asp:Content>
