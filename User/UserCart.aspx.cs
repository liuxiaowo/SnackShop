using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserCart : System.Web.UI.Page
{
    BuyCart bc = new BuyCart();
    GoodsClass gc = new GoodsClass();
    OrderClass oc = new OrderClass();
    DBClass dbobj = new DBClass();
    float AllPriceValue = 0.0f;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlBind();       //显示浏览的商品信息

        }

    }
    /// <summary>
    /// 说明：dlBind方法用于绑定相关的商品信息
    public void dlBind()
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        int num = bc.SearchGoodsIDNumByUserID(UserID);
        this.AllGoodsNum.Text = num + "";
        //绑定商品数据
        DataTable db = bc.SearchCartGoods(UserID);
        this.goodCartList.DataSource = db;
        this.goodCartList.DataBind();
        //总金额
        string strSql = "select * from tb_GoodsInfo g,tb_ShoppingCart s where g.GoodsID = s.GoodsID And s.UserID=" + UserID;
        DataTable dsTable = dbobj.GetDataSetStr(strSql, "tbGoodsInfo");
        for (int i = 0; i < dsTable.Rows.Count; i++)
        {
            float price = float.Parse(dsTable.Rows[i]["DiscountPrice"].ToString());
            float fee = float.Parse(dsTable.Rows[i]["Freight"].ToString());
            int numtemp = int.Parse(dsTable.Rows[i]["GoodsNum"].ToString());
            AllPriceValue += price * numtemp + fee;
        }
        this.AllPrice.Text = AllPriceValue + "";
        //goodId[0] = bc.SearchGoodsCartReturnID(UserID);
    }
    //点击删除按钮
    protected void lnkbtnDelete_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        bc.DeleteCartGoods(id);
        //刷新页面
        Response.Redirect(Request.Url.ToString()); 
    }
    //清理购物车
    protected void clearCart(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        bc.ClearCartGoods(UserID);
        //刷新页面
        Response.Redirect(Request.Url.ToString()); 
    }
    //购物车结算
    protected void settleAccounts_onClick(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        //总金额
        string strSql = "select * from tb_GoodsInfo g,tb_ShoppingCart s where g.GoodsID = s.GoodsID And s.UserID=" + UserID;
        DataTable dsTable = dbobj.GetDataSetStr(strSql, "tbGoodsInfo");
        for (int i = 0; i < dsTable.Rows.Count; i++)
        {
            float price = float.Parse(dsTable.Rows[i]["DiscountPrice"].ToString());
            float fee = float.Parse(dsTable.Rows[i]["Freight"].ToString());
            int numtemp = int.Parse(dsTable.Rows[i]["GoodsNum"].ToString());
            AllPriceValue += price * numtemp + fee;
        }
        int orderID = oc.AddOrder(DateTime.Now, 0, "申通快递", "在线支付", AllPriceValue, UserID, "无");
        DataTable db = bc.SearchCartGoods(UserID);
        int GoodsNum = bc.SearchGoodsIDNumByUserID(UserID);
        for (int i = 0; i < GoodsNum; i++)
        {
            int goodID = int.Parse(db.Rows[i]["GoodsID"].ToString());
            int num = bc.SearchCartGoodsNumByGoodsID(goodID);
            oc.AddOrderDetails(goodID, num, orderID);
        }
        Session["BackOrderID"] = orderID;
        Response.Redirect("UserOrders.aspx?OrderID=" + orderID);
    }

}


