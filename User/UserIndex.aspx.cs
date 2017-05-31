using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserIndex : System.Web.UI.Page
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
        String className = Server.UrlDecode(Request.QueryString["class"]);
        if (className != null) //默认类型（类别）
        {
            DataTable db = gc.SearchAllGoodsInfoByClass(className);
            this.goodList.DataSource = db;
            this.goodList.DataBind();
        }
        else
        {
            className = "坚果类";
            DataTable db = gc.SearchAllGoodsInfoByClass(className);
            this.goodList.DataSource = db;
            this.goodList.DataBind();
        }
        String name = Server.UrlDecode(Request.QueryString["name"]);
        if (name != null)  //商品名称
        {
            DataTable db = gc.SearchAllGoodsInfoByName(name);
            this.goodList.DataSource = db;
            this.goodList.DataBind();
        }
        String brand = Server.UrlDecode(Request.QueryString["brand"]);
        if (brand != null) //品牌
        {
            DataTable db = gc.SearchAllGoodsInfoByBrand(brand);
            this.goodList.DataSource = db;
            this.goodList.DataBind();
        }
    }
}