using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// OrderClass 的摘要说明
/// </summary>
public class OrderClass
{
    DBClass db = new DBClass();
	public OrderClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************立即购买生成订单************************************************************
    /// <summary>
    /// 立即购买生成订单
    public int BuyNowGenerateOrder(int GoodsID, int GoodsNum, DateTime OrderDate, float ShipFee, string ShipType, string PayWay, float TotalFee, int UserID, string Remark)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_BuyNowGenerateOrder");
        //添加参数
        SqlParameter goodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        goodID.Value = GoodsID;
        myCmd.Parameters.Add(goodID);
        //添加参数
        SqlParameter goodsNum = new SqlParameter("@GoodsNum", SqlDbType.Int, 20);
        goodsNum.Value = GoodsNum;
        myCmd.Parameters.Add(goodsNum);
        //添加参数
        SqlParameter orderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
        orderDate.Value = OrderDate;
        myCmd.Parameters.Add(orderDate);
        //添加参数
        SqlParameter shipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        shipFee.Value = ShipFee;
        myCmd.Parameters.Add(shipFee);
        //添加参数
        SqlParameter shipType = new SqlParameter("@ShipType", SqlDbType.VarChar, 50);
        shipType.Value = ShipType;
        myCmd.Parameters.Add(shipType);
        //添加参数
        SqlParameter payWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        payWay.Value = PayWay;
        myCmd.Parameters.Add(payWay);
        //添加参数
        SqlParameter totalFee = new SqlParameter("@TotalFee", SqlDbType.Float, 8);
        totalFee.Value = TotalFee;
        myCmd.Parameters.Add(totalFee);
        //添加参数
        SqlParameter userID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userID.Value = UserID;
        myCmd.Parameters.Add(userID);
        //添加参数
        SqlParameter remark = new SqlParameter("@Remark", SqlDbType.VarChar, 200);
        remark.Value = Remark;
        myCmd.Parameters.Add(remark);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        db.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //***************************************购物车结算生成订单************************************************************
    /// <summary>
    /// 购物车结算生成订单
    public int AddOrder(DateTime OrderDate, float ShipFee, string ShipType, string PayWay, float TotalFee, int UserID, string Remark)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_AddOrder");
        //添加参数
        SqlParameter orderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime, 8);
        orderDate.Value = OrderDate;
        myCmd.Parameters.Add(orderDate);
        //添加参数
        SqlParameter shipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        shipFee.Value = ShipFee;
        myCmd.Parameters.Add(shipFee);
        //添加参数
        SqlParameter shipType = new SqlParameter("@ShipType", SqlDbType.VarChar, 50);
        shipType.Value = ShipType;
        myCmd.Parameters.Add(shipType);
        //添加参数
        SqlParameter payWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        payWay.Value = PayWay;
        myCmd.Parameters.Add(payWay);
        //添加参数
        SqlParameter totalFee = new SqlParameter("@TotalFee", SqlDbType.Float, 8);
        totalFee.Value = TotalFee;
        myCmd.Parameters.Add(totalFee);
        //添加参数
        SqlParameter userID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userID.Value = UserID;
        myCmd.Parameters.Add(userID);
        //添加参数
        SqlParameter remark = new SqlParameter("@Remark", SqlDbType.VarChar, 200);
        remark.Value = Remark;
        myCmd.Parameters.Add(remark);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        db.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //添加订单详情
    public void AddOrderDetails(int GoodsID,int GoodsNum,int OrderID)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_AddOrderDetails");
        //添加参数
        SqlParameter goodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        goodID.Value = GoodsID;
        myCmd.Parameters.Add(goodID);
        //添加参数
        SqlParameter goodsNum = new SqlParameter("@GoodsNum", SqlDbType.Int, 20);
        goodsNum.Value = GoodsNum;
        myCmd.Parameters.Add(goodsNum);
        //添加参数
        SqlParameter orderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderID.Value = OrderID;
        myCmd.Parameters.Add(orderID);
        db.ExecNonQuery(myCmd);
    }

    //***************************************查询所有订单、订单详情、商品详情By OrderID************************************************************
    ///传入参数（订单ID）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchOrderInfo(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderInfo");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    //***************************************查询所有订单商品详情By OrderID************************************************************
    ///传入参数（订单ID）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchOrderInfoGoods(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderInfoGoods");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    //***************************************查询所有订单某些信息By OrderID************************************************************
    ///传入参数（订单ID）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchOrderLessInfo(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderLessInfo");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    ///更新备注信息
    public DataTable UpdateLeavingMsg(int Orderid,string msg)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_UpdateLeavingMsg");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = Orderid;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter remark = new SqlParameter("@Remark", SqlDbType.VarChar, 200);
        remark.Value = msg;
        myCmd.Parameters.Add(remark);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    /// 根据订单ID获取订单总金额
    public float SearchOrderPriceByOrderID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderPriceByOrderID");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Float, 8);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        db.ExecNonQuery(myCmd);
        return float.Parse(ReturnValue.Value.ToString());
    }
    /// 删除订单和订单详情
    public void DelOrderByOrderID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_DelOrderByOrderID");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
    }
    /// 更新商品信息
    public void UpdateGoodsInfoByOrderID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_UpdateGoodsInfoByOrderID");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
    }
    ///搜索订单信息
    public DataTable SearchOrderInfoByUserID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderInfoByUserID");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    ///根据订单状态搜索订单信息
    public DataTable SearchOrderByOrderState(int state,int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderByOrderState");
        //添加参数
        SqlParameter State = new SqlParameter("@OrderState", SqlDbType.Int, 4);
        State.Value = state;
        myCmd.Parameters.Add(State);
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    ///更新订单状态
    public DataTable UpdateOrderState(int id,int state)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_UpdateOrderState");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter State = new SqlParameter("@OrderState", SqlDbType.Int, 4);
        State.Value = state;
        myCmd.Parameters.Add(State);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
}