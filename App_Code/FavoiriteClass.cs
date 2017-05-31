using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// FavoiriteClass 的摘要说明
/// </summary>
public class FavoiriteClass
{
    DBClass dbObj = new DBClass();
	public FavoiriteClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向收藏夹表中插入信息
    /// <returns>返回收藏夹ID代号</returns>
    public int AddFavoirite(int goodid, DateTime localdate,int userid)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_AddFavoirite");
        //添加参数
        SqlParameter goodId = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        goodId.Value = goodid;
        myCmd.Parameters.Add(goodId);
        //添加参数
        SqlParameter date = new SqlParameter("@LocalDate", SqlDbType.DateTime, 8);
        date.Value = localdate;
        myCmd.Parameters.Add(date);
        //添加参数
        SqlParameter userId = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userId.Value = userid;
        myCmd.Parameters.Add(userId);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //***************************************查询所有商品信息By用户id************************************************************
    ///传入参数（用户id）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchFavorite(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchFavorite");
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbFavorite");
        return dsTable;
    }
    //***************************************删除该收藏************************************************************
    ///传入参数（商品id和用户id）
    /// <returns>返回数据源的数据表</returns>
    public void DeleteFavoriteGoods(int goodid, int userid)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_DeleteFavoriteGoods");
        //添加参数
        SqlParameter GoodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        GoodID.Value = goodid;
        myCmd.Parameters.Add(GoodID);
        //添加参数
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = userid;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
    }

  
}