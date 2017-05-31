<%@ Page Language="C#" MasterPageFile="~/User/MasterPage/IndexMasterPage.master" AutoEventWireup="true" CodeFile="UserIndex.aspx.cs" Inherits="User_UserIndex" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--本地js-->
    <link rel="stylesheet" href="./css/Content.css" type="text/css" />
    <!--引入瀑布流显示商品-->
    <script type="text/javascript" src="./js/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="./js/blocksit.min.js"></script>
    <!--本地js-->
    <script type="text/javascript" src="./js/Content.js"></script>
    <div id="wrapper">

        <div id="container">
            <asp:DataList ID="goodList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                <ItemTemplate>
                    <div class="grid">
                        <div class="imgholder">
                            <asp:Image class="lazy" runat="server"  width="175" ImageUrl =<%#DataBinder.Eval(Container.DataItem,"GoodUrl")%>/>
                        </div>
                        <strong><%#DataBinder.Eval(Container.DataItem, "GoodsName")%></strong>
                        <p><%#DataBinder.Eval(Container.DataItem, "GoodsInfo")%></p>
                        <p style="color:#797777;text-decoration:line-through;">￥<%#DataBinder.Eval(Container.DataItem, "MarketPrice","{0:f2}")%></p> 
                        <p style="color:#f00">￥<%#DataBinder.Eval(Container.DataItem, "DiscountPrice","{0:f2}")%></p>
                        <div class="meta"><a href="./UserGoodDetails.aspx?goodID=<%#DataBinder.Eval(Container.DataItem, "GoodsID")%>">点击购买>>></a></div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </div>

</asp:Content>
