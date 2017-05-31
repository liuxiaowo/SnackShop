using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_UserFavorite : System.Web.UI.Page
{
    FavoiriteClass fc = new FavoiriteClass();
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
        int UserID = Convert.ToInt32(Session["UserID"]);
        DataTable db = fc.SearchFavorite(UserID);
        this.goodFavorite.DataSource = db;
        this.goodFavorite.DataBind();
    }

    //点击删除按钮
    protected void lnkbtnDelete_Command(object sender, CommandEventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        int id = int.Parse(e.CommandArgument.ToString());
        fc.DeleteFavoriteGoods(id, UserID);
        //刷新页面
        Response.Redirect(Request.Url.ToString());
    }
}