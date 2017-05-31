using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// GiftPacksClass 的摘要说明
/// </summary>
public class GiftPacksClass
{
    DBClass dbObj = new DBClass();
	public GiftPacksClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    ///添加大礼包信息
    public int AddGiftPacks(int giftPacksID, int goodsID, int GoodsNum)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_AddGiftPacks");
        //添加参数
        SqlParameter GiftPacksID = new SqlParameter("@GiftPacksID", SqlDbType.Int, 4);
        GiftPacksID.Value = giftPacksID;
        myCmd.Parameters.Add(GiftPacksID);
        //添加参数
        SqlParameter GoodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        GoodID.Value = goodsID;
        myCmd.Parameters.Add(GoodID);
        //添加参数
        SqlParameter goodsNum = new SqlParameter("@GoodsNum", SqlDbType.Int, 20);
        goodsNum.Value = GoodsNum;
        myCmd.Parameters.Add(goodsNum);
        dbObj.ExecNonQuery(myCmd);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    ///由大礼包更新商品数量
    public void ChangeGoodsSalesNumByGoodsID(int Goodid)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ChangeGoodsSalesNumByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = Goodid;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
    }
}