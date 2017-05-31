using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// BuyCart 的摘要说明
/// </summary>
public class BuyCart
{
    DBClass dbObj = new DBClass();
	public BuyCart()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************添加到购物车（商品详情界面）************************************************************
    /// <summary>
    /// 向购物车表中插入信息
    /// </summary>
    /// <param name="GoodsID">商品ID</param>
    /// <param name="GoodsNum">商品数量</param>
    /// <param name="UserID">用户ID</param>
    /// <param name="UpdateTime">更新时间</param>
    /// <returns>返回购物车ID代号</returns>
    public void AddCart(int GoodsID, int GoodsNum, int UserID, DateTime UpdateTime)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_AddCart");
        //添加参数
        SqlParameter goodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        goodID.Value = GoodsID;
        myCmd.Parameters.Add(goodID);
        //添加参数
        SqlParameter goodsNum = new SqlParameter("@GoodsNum", SqlDbType.Int, 20);
        goodsNum.Value = GoodsNum;
        myCmd.Parameters.Add(goodsNum);
        //添加参数
        SqlParameter userID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userID.Value = UserID;
        myCmd.Parameters.Add(userID);
        //添加参数
        SqlParameter date = new SqlParameter("@UpdateTime", SqlDbType.DateTime, 8);
        date.Value = UpdateTime;
        myCmd.Parameters.Add(date);
        dbObj.ExecNonQuery(myCmd);
    }
    //***************************************查询所有商品信息By用户ID************************************************************
    ///传入参数（用户ID）
    /// <returns>返回该用户底下的商品个数</returns>
    public int SearchGoodsIDNumByUserID(int userID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsIDNumByUserID");
        //添加参数
        SqlParameter UserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        UserID.Value = userID;
        myCmd.Parameters.Add(UserID);
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //搜索当前用户购物车所有商品
    public DataTable SearchCartGoods(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchCartGoods");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = UserID;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbShoppingCart");
        return dsTable;
    }
    //搜索当前用户购物车所有商品总金额
    public float SearchCartGoodsAllPrice(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchCartGoodsAllPrice");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = UserID;
        myCmd.Parameters.Add(ID);
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Float, 8);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return float.Parse(ReturnValue.Value.ToString());
    }

    //搜索当前用户购物车所有商品返回goodID数组
    public int SearchGoodsCartReturnID(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsCartReturnID");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = UserID;
        myCmd.Parameters.Add(ID);
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //搜索商品数量
    public int SearchCartGoodsNumByGoodsID(int GoodID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchCartGoodsNumByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = GoodID;
        myCmd.Parameters.Add(ID);
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 20);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return int.Parse(ReturnValue.Value.ToString());
    }
    //删除购物车单个Good
    public void DeleteCartGoods(int GoodID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_DeleteCartGoods");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = GoodID;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
    }
    //删除购物车所有Good
    public void ClearCartGoods(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ClearCartGoods");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = UserID;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
    }
   
}