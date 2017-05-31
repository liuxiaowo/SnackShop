using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_UserPay : System.Web.UI.Page
{
    int OrderID = 0;
    int UserID = -1;
    OrderClass oc = new OrderClass();
    CommonClass cc = new CommonClass();
    DBClass dbobj = new DBClass();
    BuyCart bc = new BuyCart();
    GoodsClass gc = new GoodsClass();
    GiftPacksClass gpc = new GiftPacksClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserID = Convert.ToInt32(Session["UserID"]);
        if (Request.QueryString["OrderID"] != null)
        {
            OrderID = int.Parse(Request.QueryString["OrderID"]);
        }
        if (UserID != -1)
        {
            this.orderID.Text = "订单ID：" + OrderID;
            //总金额
            string strSql = "select * from tb_OrderInfo where OrderID="+OrderID;
            DataTable dsTable = dbobj.GetDataSetStr(strSql, "tbOrderInfo");
            float price = float.Parse(dsTable.Rows[0]["TotalFee"].ToString());
            //float price = oc.SearchOrderPriceByOrderID(OrderID);
            this.orderPrice.Text = "订单总金额：￥" + price;
        }
        else
        {
            //重新登录
            Response.Write(cc.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
    }
    //确定支付按钮
    protected void payBtn_onCLick(object sender, EventArgs e)
    {
        oc.UpdateOrderState(OrderID, 1);
        //oc.UpdateGoodsInfoByOrderID(OrderID);
        //总金额
        string strSql = "select * from tb_OrderDetail where OrderID=" + OrderID;
        DataTable dsTable = dbobj.GetDataSetStr(strSql, "tbOrderDetail");
        for (int i = 0; i < dsTable.Rows.Count; i++)
        {
            int num = int.Parse(dsTable.Rows[i]["GoodsNum"].ToString());
            int id = int.Parse(dsTable.Rows[i]["GoodsID"].ToString());
            gc.UpdateGoodsInfoByGoodsID(id, num);
            //大礼包数量处理
            string sql = "select * from tb_GiftPacks where GiftPacksID=" + id;
            DataTable ds = dbobj.GetDataSetStr(sql, "tbGiftPacks");
            for (int j = 0; j < ds.Rows.Count; j++)
            {
                int goodId = int.Parse(ds.Rows[j]["GoodsID"].ToString());
                int goodNum = int.Parse(ds.Rows[i]["GoodsNum"].ToString());
                gc.UpdateGoodsInfoByGoodsID(goodId, goodNum);
            }
        }
        //付款完成后清除购物车
        bc.ClearCartGoods(UserID);
        //订单完成
        Response.Write(cc.MessageBox("支付成功！", "UserMyOrders.aspx"));
    }
    //放弃支付按钮
    protected void cancelBtn_onCLick(object sender, EventArgs e)
    {
        //删除对应订单信息
        //oc.DelOrderByOrderID(OrderID);
        oc.UpdateOrderState(OrderID,0);
        Response.Redirect("UserIndex.aspx");
    }
}