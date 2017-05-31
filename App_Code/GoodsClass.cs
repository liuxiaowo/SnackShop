using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// GoodsClass 的摘要说明
/// </summary>
public class GoodsClass
{
    DBClass dbObj = new DBClass();
    public GoodsClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //***************************************添加商品信息************************************************************
    /// <summary>
    /// 向商品信息表中插入信息
    /// </summary>
    /// <param name="Class">类别</param>
    /// <param name="GoodsName">商品名称</param>
    /// <param name="GoodsInfo">商品介绍</param>
    /// <param name="GoodUrl">商品图片</param>
    /// <param name="MarketPrice">市场价</param>
    /// <param name="DiscountPrice">折扣价</param>
    /// <param name="StockPrice">进货价</param>
    /// <param name="Isrefinement">是否推荐</param>
    /// <param name="SalesVolume">销量</param>
    /// <param name="RetailPurchases">进货量</param>
    /// <param name="Surplus">剩余量</param>
    /// <param name="LocalDate">进货时间</param>
    /// <param name="GoodsBrand">品牌</param>
    /// <param name="Freight">运费</param>
    /// <param name="IsDisplay">是否显示（上架或下架）</param>
    /// <returns>返回商品ID代号</returns>
    public int AddGoodsInfo(string Class, string GoodsName, string GoodsInfo, string GoodUrl, double MarketPrice,
        double DiscountPrice, double StockPrice, bool Isrefinement, int SalesVolume, int RetailPurchases,
        int Surplus, DateTime localdate, string GoodsBrand, double Freight,bool IsDisplay)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_AddGoodsInfo");
        //添加参数
        SqlParameter GoodsClass = new SqlParameter("@Class", SqlDbType.VarChar, 50);
        GoodsClass.Value = Class;
        myCmd.Parameters.Add(GoodsClass);
        //添加参数
        SqlParameter goodsName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        goodsName.Value = GoodsName;
        myCmd.Parameters.Add(goodsName);
        //添加参数
        SqlParameter goodsInfo = new SqlParameter("@GoodsInfo", SqlDbType.NText, 200);
        goodsInfo.Value = GoodsInfo;
        myCmd.Parameters.Add(goodsInfo);
        //添加参数
        SqlParameter goodUrl = new SqlParameter("@GoodUrl", SqlDbType.VarChar, 200);
        goodUrl.Value = GoodUrl;
        myCmd.Parameters.Add(goodUrl);
        //添加参数
        SqlParameter marketPrice = new SqlParameter("@MarketPrice", SqlDbType.Float, 8);
        marketPrice.Value = MarketPrice;
        myCmd.Parameters.Add(marketPrice);
        //添加参数
        SqlParameter discountPrice = new SqlParameter("@DiscountPrice", SqlDbType.Float, 8);
        discountPrice.Value = DiscountPrice;
        myCmd.Parameters.Add(discountPrice);
        //添加参数
        SqlParameter stockPrice = new SqlParameter("@StockPrice", SqlDbType.Float, 8);
        stockPrice.Value = StockPrice;
        myCmd.Parameters.Add(stockPrice);
        //添加参数
        SqlParameter isrefinement = new SqlParameter("@Isrefinement", SqlDbType.Bit, 1);
        isrefinement.Value = Isrefinement;
        myCmd.Parameters.Add(isrefinement);
        //添加参数
        SqlParameter salesVolume = new SqlParameter("@SalesVolume", SqlDbType.Int, 20);
        salesVolume.Value = SalesVolume;
        myCmd.Parameters.Add(salesVolume);
        //添加参数
        SqlParameter retailPurchases = new SqlParameter("@RetailPurchases", SqlDbType.Int, 20);
        retailPurchases.Value = RetailPurchases;
        myCmd.Parameters.Add(retailPurchases);
        //添加参数
        SqlParameter surplus = new SqlParameter("@Surplus", SqlDbType.Int, 20);
        surplus.Value = Surplus;
        myCmd.Parameters.Add(surplus);
        //添加参数
        SqlParameter date = new SqlParameter("@LocalDate", SqlDbType.DateTime, 8);
        date.Value = localdate;
        myCmd.Parameters.Add(date);
        //添加参数
        SqlParameter goodsBrand = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        goodsBrand.Value = GoodsBrand;
        myCmd.Parameters.Add(goodsBrand);
        //添加参数
        SqlParameter freight = new SqlParameter("@Freight", SqlDbType.Float, 8);
        freight.Value = Freight;
        myCmd.Parameters.Add(freight);
        //添加参数
        SqlParameter isDisplay = new SqlParameter("@IsDisplay", SqlDbType.Bit, 1);
        isDisplay.Value = IsDisplay;
        myCmd.Parameters.Add(isDisplay);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //***************************************修改商品信息************************************************************
    /// <summary>
    /// 向商品信息表中插入信息
    /// </summary>
    /// <param name="Class">类别</param>
    /// <param name="GoodsName">商品名称</param>
    /// <param name="GoodsInfo">商品介绍</param>
    /// <param name="GoodUrl">商品图片</param>
    /// <param name="MarketPrice">市场价</param>
    /// <param name="DiscountPrice">折扣价</param>
    /// <param name="StockPrice">进货价</param>
    /// <param name="Isrefinement">是否推荐</param>
    /// <param name="SalesVolume">销量</param>
    /// <param name="RetailPurchases">进货量</param>
    /// <param name="Surplus">剩余量</param>
    /// <param name="LocalDate">进货时间</param>
    /// <param name="GoodsBrand">品牌</param>
    /// <param name="Freight">运费</param>
    /// <returns>返回商品ID代号</returns>
    public int ChangeGoodsInfo(int goodID,string Class, string GoodsName, string GoodsInfo, string GoodUrl, double MarketPrice,
        double DiscountPrice, double StockPrice, bool Isrefinement, int SalesVolume, int RetailPurchases,
        int Surplus, DateTime localdate, string GoodsBrand, double Freight)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ChangeGoodsInfo");
        //添加参数
        SqlParameter GoodID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        GoodID.Value = goodID;
        myCmd.Parameters.Add(GoodID);
        //添加参数
        SqlParameter GoodsClass = new SqlParameter("@Class", SqlDbType.VarChar, 50);
        GoodsClass.Value = Class;
        myCmd.Parameters.Add(GoodsClass);
        //添加参数
        SqlParameter goodsName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        goodsName.Value = GoodsName;
        myCmd.Parameters.Add(goodsName);
        //添加参数
        SqlParameter goodsInfo = new SqlParameter("@GoodsInfo", SqlDbType.NText, 200);
        goodsInfo.Value = GoodsInfo;
        myCmd.Parameters.Add(goodsInfo);
        //添加参数
        SqlParameter goodUrl = new SqlParameter("@GoodUrl", SqlDbType.VarChar, 200);
        goodUrl.Value = GoodUrl;
        myCmd.Parameters.Add(goodUrl);
        //添加参数
        SqlParameter marketPrice = new SqlParameter("@MarketPrice", SqlDbType.Float, 8);
        marketPrice.Value = MarketPrice;
        myCmd.Parameters.Add(marketPrice);
        //添加参数
        SqlParameter discountPrice = new SqlParameter("@DiscountPrice", SqlDbType.Float, 8);
        discountPrice.Value = DiscountPrice;
        myCmd.Parameters.Add(discountPrice);
        //添加参数
        SqlParameter stockPrice = new SqlParameter("@StockPrice", SqlDbType.Float, 8);
        stockPrice.Value = StockPrice;
        myCmd.Parameters.Add(stockPrice);
        //添加参数
        SqlParameter isrefinement = new SqlParameter("@Isrefinement", SqlDbType.Bit, 1);
        isrefinement.Value = Isrefinement;
        myCmd.Parameters.Add(isrefinement);
        //添加参数
        SqlParameter salesVolume = new SqlParameter("@SalesVolume", SqlDbType.Int, 20);
        salesVolume.Value = SalesVolume;
        myCmd.Parameters.Add(salesVolume);
        //添加参数
        SqlParameter retailPurchases = new SqlParameter("@RetailPurchases", SqlDbType.Int, 20);
        retailPurchases.Value = RetailPurchases;
        myCmd.Parameters.Add(retailPurchases);
        //添加参数
        SqlParameter surplus = new SqlParameter("@Surplus", SqlDbType.Int, 20);
        surplus.Value = Surplus;
        myCmd.Parameters.Add(surplus);
        //添加参数
        SqlParameter date = new SqlParameter("@LocalDate", SqlDbType.DateTime, 8);
        date.Value = localdate;
        myCmd.Parameters.Add(date);
        //添加参数
        SqlParameter goodsBrand = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        goodsBrand.Value = GoodsBrand;
        myCmd.Parameters.Add(goodsBrand);
        //添加参数
        SqlParameter freight = new SqlParameter("@Freight", SqlDbType.Float, 8);
        freight.Value = Freight;
        myCmd.Parameters.Add(freight);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //***************************************查询所有商品信息By类型************************************************************
    ///传入参数（类型）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllGoodsInfoByClass(String className)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsInfoByClass");
        //添加参数
        SqlParameter ClassName = new SqlParameter("@Class", SqlDbType.VarChar, 50);
        ClassName.Value = className;
        myCmd.Parameters.Add(ClassName);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************查询所有商品信息by品牌************************************************************
    ///传入参数（品牌）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllGoodsInfoByBrand(String className)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsInfoByBrand");
        //添加参数
        SqlParameter ClassName = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        ClassName.Value = className;
        myCmd.Parameters.Add(ClassName);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************查询所有商品信息By商品名称************************************************************
    ///传入参数（商品名称）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllGoodsInfoByName(String className)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsInfoByGoodName");
        //添加参数
        SqlParameter ClassName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        ClassName.Value = className;
        myCmd.Parameters.Add(ClassName);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************查询所有商品信息By商品ID************************************************************
    ///传入参数（商品ID）
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchAllGoodsInfoByID(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsByID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************商品销量排行榜前十************************************************************
    /// <returns>返回数据源的数据表</returns>
    public DataTable GoodsSalesCharts()
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_GoodsSalesCharts");       
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGoodsInfo");
        return dsTable;
    }
    //***************************************商品价格获取************************************************************
    /// <returns>返回商品价格</returns>
    public float SearchGoodPriceByGoodsID(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodPriceByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Float, 8);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return float.Parse(ReturnValue.Value.ToString());
    }
    //***************************************商品运费获取************************************************************
    /// <returns>返回商品价格</returns>
    public float SearchGoodsFeightByID(int id)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchGoodsFeightByID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Float, 8);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return float.Parse(ReturnValue.Value.ToString());
    }
    ///更新商品数量
    public void UpdateGoodsInfoByGoodsID(int Goodid, int goodsNum)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_UpdateGoodsInfoByGoodsID");
        //添加参数
        SqlParameter ID = new SqlParameter("@GoodsID", SqlDbType.Int, 4);
        ID.Value = Goodid;
        myCmd.Parameters.Add(ID);
        //添加参数
        SqlParameter GoodsNum = new SqlParameter("@GoodsNum", SqlDbType.Int, 4);
        GoodsNum.Value = goodsNum;
        myCmd.Parameters.Add(GoodsNum);
        dbObj.ExecNonQuery(myCmd);
    }
}
