<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="User_UserControl_List" %>
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<link rel="stylesheet" href="./css/Common.css" type="text/css" />
<link rel="stylesheet" href="./css/List.css" type="text/css" />
<script type="text/javascript" src="./js/jquery-1.11.1.min.js"></script>
<script type="text/javascript" src="./js/List.js"></script>
<table id="list" runat="server" class="list">
    <tr>
        <td class="listtd">
            <div class="sidebar">
                <div class="sidebar_top sidebar_top_tc">全部宝贝分类</div>
                <div class="sidebar_con">
                    <dl class="sidebar_item">
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=坚果类">坚果类</a></h3>
                            <s></s>
                            <div class="sidebar_popup dis1" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="./UserIndex.aspx?class=树坚果">树坚果</a></strong>
                                        <p><span class="linesbg"><a href="./UserIndex.aspx?class=杏仁">杏仁</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=腰果">腰果</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=榛子">榛子</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=核桃">核桃</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=松子">松子</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=板栗">板栗</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=白果">白果</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=开心果">开心果</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=夏威夷果">夏威夷果</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="./UserIndex.aspx?class=种子">种子</a></strong>
                                        <p><span class="linesbg"><a href="./UserIndex.aspx?class=花生">花生</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=西瓜子">西瓜子</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=南瓜子">南瓜子</a></span><span class="linesbg"><a href="./UserIndex.aspx?class=葵花子">葵花子</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="./UserIndex.aspx?class=坚果类"><span class="linesbg">查看全部坚果</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=零食类">零食类</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis2" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">巧克力</a></strong>
                                        <p><span class="linesbg"><a href="#">酒心巧克力</a></span><span class="linesbg"><a href="#">德芙巧克力</a></span><span class="linesbg"><a href="#">榛子巧克力</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">糖果</a></strong>
                                        <p><span class="linesbg"><a href="#">真知棒</a></span><span class="linesbg"><a href="#">阿尔卑斯棒棒糖</a></span><span class="linesbg"><a href="#">彩虹糖</a></span><span class="linesbg"><a href="#">大白兔奶糖</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">饼干</a></strong>
                                        <p><span class="linesbg"><a href="#">苏打饼干</a></span><span class="linesbg"><a href="#">奥利奥饼干</a></span><span class="linesbg"><a href="#">草莓夹心饼干</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">薯片</a></strong>
                                        <p><span class="linesbg"><a href="#">呀！土豆</a></span><span class="linesbg"><a href="#">薯愿</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">果脯|蜜饯</a></strong>
                                        <p><span class="linesbg"><a href="#">蜜枣</a></span><span class="linesbg"><a href="#">香蕉干</a></span><span class="linesbg"><a href="#">芒果干</a></span><span class="linesbg"><a href="#">情人梅</a></span><span class="linesbg"><a href="#">乌梅</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item nobg">
                                        <strong><a href="#">其它</a></strong>
                                        <p><span class="linesbg"><a href="#">辣条</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部零食</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=特产">特产</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis3" style="display: none;">
                                <div class="sidebar_popup_box">
                                    <div class="sidebar_popup_class clearfix">
                                        <div class="sidebar_popup_item">
                                            <strong><a href="#">所有</a></strong>
                                            <p><span class="linesbg"><a href="#">紫薯花生</a></span><span class="linesbg"><a href="#">酥脆花生豆</a></span><span class="linesbg"><a href="#">奶油味山核桃</a></span><span class="linesbg"><a href="#">东北红松子</a></span><span class="more"><a href="#">更多</a></span></p>
                                        </div>
                                    </div>
                                    <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部特产</span></a></div>
                                </div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=肉制品">肉制品</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis4" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">肉脯</a></strong>
                                        <p><span class="linesbg"><a href="#">猪肉脯</a></span><span class="linesbg"><a href="#">牛肉干</a></span><span class="linesbg"><a href="#">牛板筋</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">香肠</a></strong>
                                        <p><span class="linesbg"><a href="#">小香肠</a></span><span class="linesbg"><a href="#">烤肠</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">卤蛋</a></strong>
                                        <p><span class="linesbg"><a href="#">五香味卤蛋</a></span><span class="linesbg"><a href="#">鹌鹑蛋</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">肉粒</a></strong>
                                        <p><span class="linesbg"><a href="#">牛肉粒</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部肉制品</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=干果类">干果类</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis5" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">干果</a></strong>
                                        <p><span class="linesbg"><a href="#">莲子</a></span><span class="linesbg"><a href="#">核桃</a></span><span class="linesbg"><a href="#">腰果</a></span><span class="linesbg"><a href="#">花生</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">果干</a></strong>
                                        <p><span class="linesbg"><a href="#">苹果干</a></span><span class="linesbg"><a href="#">芒果干</a></span><span class="linesbg"><a href="#">香蕉干</a></span><span class="linesbg"><a href="#">柿饼</a></span><span class="linesbg"><a href="#">葡萄干</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部干果</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=糕点">糕点</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis6" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">中式糕点</a></strong>
                                        <p><span class="linesbg"><a href="#">曲奇</a></span><span class="linesbg"><a href="#">饼干</a></span><span class="linesbg"><a href="#">酥点</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">西式糕点</a></strong>
                                        <p><span class="linesbg"><a href="#">蛋挞</a></span><span class="linesbg"><a href="#">蛋糕</a></span><span class="linesbg"><a href="#">泡芙</a></span><span class="linesbg"><a href="#">披萨</a></span><span class="linesbg"><a href="#">提拉米苏</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部糕点</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3 class=""><a href="./UserIndex.aspx?class=点心">点心</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis7" style="display: none;">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">酥皮类</a></strong>
                                        <p><span class="linesbg"><a href="#">京八件</a></span><span class="linesbg"><a href="#">紫薯酥</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">酥类</a></strong>
                                        <p><span class="linesbg"><a href="#">桃酥</a></span><span class="linesbg"><a href="#">杏仁酥</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">油炸类</a></strong>
                                        <p><span class="linesbg"><a href="#">芙蓉糕</a></span><span class="linesbg"><a href="#">开口笑</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">浆皮类</a></strong>
                                        <p><span class="linesbg"><a href="#">双麻月饼</a></span><span class="linesbg"><a href="#">提浆月饼</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">蛋糕类</a></strong>
                                        <p><span class="linesbg"><a href="#">蛋糕</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="#">混糖皮类</a></strong>
                                        <p><span class="linesbg"><a href="#">蛋黄</a></span><span class="linesbg"><a href="#">桃杏果</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item nobg">
                                        <strong><a href="#">饼干类</a></strong>
                                        <p><span class="linesbg"><a href="#">饼干</a></span></p>
                                    </div>
                                    <div class="sidebar_popup_item nobg">
                                        <strong><a href="#">其他类</a></strong>
                                        <p><span class="linesbg"><a href="#">元宵</a></span><span class="linesbg"><a href="#">绿豆糕</a></span><span class="more"><a href="#">更多</a></span></p>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="#"><span class="linesbg">查看全部点心</span></a></div>
                            </div>
                        </dd>
                        <dd>
                            <h3><a href="./UserIndex.aspx?class=大礼包">大礼包</a></h3>
                            <s></s>
                            <!-- 弹出层 -->
                            <div class="sidebar_popup dis8">
                                <div class="sidebar_popup_class clearfix">
                                    <div class="sidebar_popup_item">
                                        <strong><a href="./UserIndex.aspx?class=坚果大礼包">坚果大礼包</a></strong>
                                    </div>
                                    <div class="sidebar_popup_item">
                                        <strong><a href="./UserIndex.aspx?class=零食大礼包">零食大礼包</a></strong>
                                    </div>
                                </div>
                                <div class="sidebar_popup_all"><a href="./UserIndex.aspx?class=大礼包"><span class="linesbg">查看全部大礼包</span></a></div>
                            </div>
                        </dd>
                    </dl>
                </div>
                <div class="sidebar_bottom"></div>
                <div class="sidebar_con"></div>
                <div class="sidebar_bottom"></div>
            </div>
        </td>
        <td colspan="2" class="middle listtd">
            <div class="lunbo">
                <div class="fugai">
                    <div class="fugai1"></div>
                    <div class="fugai2"></div>
                    <div class="fugai3"></div>
                    <div class="cb"></div>
                </div>

                <div class="dianzui">
                    <div class="dian"></div>
                </div>
                <div class="box">
                    <img src="./images/lunbo1.png">
                    <img src="./images/lunbo2.png">
                    <img src="./images/lunbo3.png">
                    <img src="./images/lunbo4.png">
                    <img src="./images/lunbo1.png">
                </div>
                <div class="btn">
                    <div class="btn-l fl"><</div>
                    <div class="btn-con-l fl"></div>
                    <div class="btn-r fr">></div>
                    <div class="btn-con-r fr">r</div>
                </div>

                <ul class="list-li">
                    <li><a href="./UserGoodDetails.aspx?goodID=18" style="color:#FFF">1</a></li>
                    <li><a href="./UserGoodDetails.aspx?goodID=20" style="color:#FFF">2</a></li>
                    <li><a href="./UserGoodDetails.aspx?goodID=21" style="color:#FFF">3</a></li>
                    <li><a href="./UserGoodDetails.aspx?goodID=19" style="color:#FFF">4</a></li>
                </ul>
            </div>
        </td>
        <td class="listtd">
            <section id="ranking">
                <span id="ranking_title">销量排行榜</span>
                <section id="ranking_list">
                    <asp:DataList ID="goodSalesList" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%" OnItemCommand="goodSalesList_onItemCommand">
                        <ItemTemplate>
                            <section class="boxlist">
                                <section class="col_1" title="1"><%#Container.ItemIndex+1 %></section>
                                <section class="col_2">
                                    <asp:Image runat="server" ImageUrl=<%#DataBinder.Eval(Container.DataItem,"GoodUrl")%> CssClass="salesListImage" />
                                </section>
                                <asp:LinkButton runat="server" CommandName="name" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"GoodsID")%>' CssClass="col_3" ForeColor="OrangeRed"><%#DataBinder.Eval(Container.DataItem,"GoodsName")%></asp:LinkButton>
                                <section class="col_4"><%#DataBinder.Eval(Container.DataItem,"SalesVolume")%></section>
                            </section>
                        </ItemTemplate>
                    </asp:DataList>
                </section>
            </section>
        </td>
    </tr>
</table>
