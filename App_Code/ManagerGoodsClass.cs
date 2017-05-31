using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// ManagerGoodsClass 的摘要说明
/// </summary>
public class ManagerGoodsClass
{
    DBClass dbObj = new DBClass();
	public ManagerGoodsClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************搜索所有商品************************************************************
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllGoods()
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchAllGoods");
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************删除商品信息************************************************************
    public void DeleteGoodByGoodsID(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_DeleteGoodByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);        
    }
    ///更新商品下架或上架状态
    public void UpdateGoodIsShow(int Goodid, bool isShow)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_UpdateGoodIsShow");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = Goodid;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter isDisplay = new SqlParameter("@IsDisplay", SqlDbType.Bit, 1);
        isDisplay.Value = isShow;
        myCmd.Parameters.Add(isDisplay);
        dbObj.ExecNonQuery(myCmd);
    }
    //搜索Good上下架状态
    public Boolean SearchGoodsIsDisplayByGoodsID(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsIsDisplayByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Bit, 1);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToBoolean(ReturnValue.Value.ToString());
    }
}