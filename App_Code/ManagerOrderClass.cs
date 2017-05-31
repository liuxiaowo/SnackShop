using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// ManagerOrderClass 的摘要说明
/// </summary>
public class ManagerOrderClass
{
    DBClass db = new DBClass();
	public ManagerOrderClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************查询所有订单************************************************************
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllOrders()
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchAllOrders");
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    //***************************************查询所有订单根据订单状态************************************************************
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllOrderByOrderState(int state)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchAllOrderByOrderState");
        //添加参数
        SqlParameter State = new SqlParameter("@OrderState", SqlDbType.Int, 4);
        State.Value = state;
        myCmd.Parameters.Add(State);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    //***************************************订单收货人信息************************************************************
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchOrderUserInfoByOrderID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderUserInfoByOrderID");
        //添加参数
        SqlParameter State = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        State.Value = id;
        myCmd.Parameters.Add(State);
        db.ExecNonQuery(myCmd);
        DataTable dsTable = db.GetDataSet(myCmd, "tbOrderInfo");
        return dsTable;
    }
    /// 根据订单id查询订单状态
    public int SearchOrderStateByOrderID(int id)
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrderStateByOrderID");
        //添加参数
        SqlParameter ID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        db.ExecNonQuery(myCmd);
        return int.Parse(ReturnValue.Value.ToString());
    }
    /// 根据订单状态查询所有金额
    public float SearchOrdersAllMoneyByOrderState()
    {
        SqlCommand myCmd = db.GetCommandProc("pro_SearchOrdersAllMoneyByOrderState");
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Float, 8);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        db.ExecNonQuery(myCmd);
        return float.Parse(ReturnValue.Value.ToString());
    }

}