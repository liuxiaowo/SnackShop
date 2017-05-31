using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControl_List : System.Web.UI.UserControl
{
    GoodsClass gc = new GoodsClass();
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
        DataTable db = gc.GoodsSalesCharts();
        this.goodSalesList.DataSource = db;
        this.goodSalesList.DataBind();
    }

    //排行榜数据点击
    protected void goodSalesList_onItemCommand(object sender, DataListCommandEventArgs e)
    {
        if (e.CommandName == "name")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("./UserGoodDetails.aspx?goodID=" + id);
        }
    }
}