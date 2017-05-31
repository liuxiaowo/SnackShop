using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manager_ManagerGoods : System.Web.UI.Page
{
    GoodsClass gc = new GoodsClass();
    ManagerGoodsClass mgc = new ManagerGoodsClass();
    DBClass db = new DBClass();
    CommonClass cc = new CommonClass();
    bool isDisplay;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlBind();

        }
    }
    /// <summary>
    /// 说明：dlBind方法用于绑定相关的商品信息
    public void dlBind()
    {
        //绑定订单数据
        DataTable db = mgc.SearchAllGoods();
        this.MsgGoodsList.DataSource = db;
        this.MsgGoodsList.DataBind();
    }
    //点击下架按钮
    protected void lnkbtnDrop_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        string strSql = "select * from tb_GoodsInfo where GoodsID=" + id;
        DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
        bool isShow = bool.Parse(dsTable.Rows[0][15].ToString());
        if (isShow)
        {
           mgc.UpdateGoodIsShow(id, false);
        }
        else
        {
            mgc.UpdateGoodIsShow(id, true);
        }
        //刷新页面
        Response.Redirect(Request.Url.ToString());
    }
    //点击修改按钮
    protected void lnkbtnChange_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        //刷新页面
        Response.Redirect("ManagerChangeGoods.aspx?goodID="+id);
    }
    //添加商品信息按钮
    protected void AddGood_onCLick(object sender, EventArgs e)
    {
        Response.Redirect("ManagerAddGoods.aspx");
    }
    //添加大礼包信息按钮
    protected void AddGift_onCLick(object sender, EventArgs e)
    {
        Response.Redirect("ManagerAddGiftPack.aspx");
    }
    //当绑定DataList1中的每一项时的处理方法 
    protected void MsgGoodsList_onItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int id = int.Parse(DataBinder.Eval(e.Item.DataItem, "GoodsID").ToString());
            //根据状态修改退款和确认收货的按钮显示与否
            LinkButton Drop = e.Item.FindControl("Drop") as LinkButton;
            //LinkButton up = e.Item.FindControl("up") as LinkButton;
            //bool isShow = mgc.SearchGoodsIsDisplayByGoodsID(id);
            string strSql = "select * from tb_GoodsInfo where GoodsID=" + id;
            DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
            bool isShow = bool.Parse(dsTable.Rows[0][15].ToString());
            //Response.Write(cc.MessageBox(isShow+""));
            if (isShow)
            {
                Drop.Text = "下架";
                //up.Visible = false;
            }
            else
            {
                Drop.Text = "上架";
                //up.Visible = true;
            }
           
        }
    }

}