using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserGoodDetails : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    GoodsClass gc = new GoodsClass();
    BuyCart bc = new BuyCart();
    OrderClass oc = new OrderClass();
    FavoiriteClass fc = new FavoiriteClass();
    DBClass db = new DBClass();
    GiftPacksClass gpc = new GiftPacksClass();
    int goodID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //商品到商品详情页传值
        if (Request.QueryString["goodID"] != null)
        {
            goodID = int.Parse(Request.QueryString["goodID"]);
        }
        if (!IsPostBack)
        {
            dlBind();       //显示浏览的商品信息

        }
    }
    /// <summary>
    /// 说明：dlBind方法用于绑定相关的商品信息
    public void dlBind()
    {
        DataTable dbtable = gc.SearchAllGoodsInfoByID(goodID);
        this.goodDatailsList.DataSource = dbtable;
        this.goodDatailsList.DataBind();
    }
    //数据减少键
    protected void NumReduceBtn_onClick(object sender, EventArgs e)
    {
        TextBox tb = goodDatailsList.Items[0].FindControl("txtNum") as TextBox;
        if (int.Parse(tb.Text) > 1)
        {
            tb.Text = (int.Parse(tb.Text) - 1) + "";
        }
    }
    //数据增加键
    protected void NumAddBtn_onClick(object sender, EventArgs e)
    {
        TextBox tb = goodDatailsList.Items[0].FindControl("txtNum") as TextBox;
        tb.Text = (int.Parse(tb.Text) + 1) + "";
    }
    //立即购买
    protected void buy_onClick(object sender, EventArgs e)
    {
       //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            //立即购买生成订单
            TextBox numT = goodDatailsList.Items[0].FindControl("txtNum") as TextBox;
            int num = int.Parse(numT.Text);
            string strSql = "select * from tb_GoodsInfo where GoodsID=" + goodID;
            DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
            float price = float.Parse(dsTable.Rows[0][6].ToString());
            //float price = gc.SearchGoodPriceByGoodsID(goodID);
            int UserID = Convert.ToInt32(Session["UserID"]);
            float fee = float.Parse(dsTable.Rows[0][14].ToString());
            float allPrice =num * price + fee;
            int orderID = oc.AddOrder(DateTime.Now, fee, "申通快递", "在线支付", allPrice, UserID, "无");
            oc.AddOrderDetails(goodID, num, orderID);
            Session["BackOrderID"] = orderID;
            Response.Redirect("UserOrders.aspx?OrderID="+orderID);
        }
    }
    //加入购物车
    protected void addCart_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            TextBox tb2 = goodDatailsList.Items[0].FindControl("txtNum") as TextBox;
            int UserID = Convert.ToInt32(Session["UserID"]);
            //将用户输入的信息插入到用户表tb_User中
            bc.AddCart(goodID, int.Parse(tb2.Text), UserID, DateTime.Now);
            ccObj.ShowConfirm("成功添加到购物车！（确定：到购物车中查看，取消：继续购物）", "UserCart.aspx", "");
            //跳转到购物车界面（带参数）
            //Response.Redirect("UserCart.aspx");
        }
    }
    //收藏
    protected void collect_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            int returnValue = fc.AddFavoirite(goodID, DateTime.Now, UserID);
            if (returnValue == 100) //收藏成功
            {
                Response.Write(ccObj.MessageBox("成功添加到收藏夹！"));
            }
            else
            {
                Response.Write(ccObj.MessageBox("该商品已经添加到收藏夹！"));
            }
        }
    }
}