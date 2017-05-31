using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;

public partial class User_UserMyOrders : System.Web.UI.Page
{
    OrderClass oc = new OrderClass();
    CommonClass cc = new CommonClass();
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
        int UserID = Convert.ToInt32(Session["UserID"]);
        //绑定商品数据
        DataTable db = oc.SearchOrderInfoByUserID(UserID);
        this.myOrderList.DataSource = db;
        this.myOrderList.DataBind();
    }
    //当绑定DataList1中的每一项时的处理方法 
    protected void myOrderGoodList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataList ChildList = null;
            // 填充dataset
            DataSet ds = new DataSet();
            ChildList = (DataList)e.Item.FindControl("myOrderGoodList");
            int id = int.Parse(DataBinder.Eval(e.Item.DataItem, "OrderID").ToString());
            DataTable db = oc.SearchOrderInfoGoods(id);
            ds.Tables.Add(db.Copy());
            if (ChildList != null)
            {
                ChildList.DataSource = ds.Tables;
                ChildList.DataBind();
            }
        }
    }
    //全部订单
    protected void allBtn_onClick(object sender, EventArgs e)
    {
        dlBind();
    }
    //待付款
    protected void payBtn_onClick(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        //绑定商品数据
        DataTable db = oc.SearchOrderByOrderState(0, UserID);
        this.myOrderList.DataSource = db;
        this.myOrderList.DataBind();
    }
    //待发货
    protected void sendBtn_onClick(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        //绑定商品数据
        DataTable db = oc.SearchOrderByOrderState(1, UserID);
        this.myOrderList.DataSource = db;
        this.myOrderList.DataBind();
    }
    //待收货
    protected void takeOverBtn_onClick(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        //绑定商品数据
        DataTable db = oc.SearchOrderByOrderState(2, UserID);
        this.myOrderList.DataSource = db;
        this.myOrderList.DataBind();
    }
    //订单完成
    protected void FinishBtn_onClick(object sender, EventArgs e)
    {
        int UserID = Convert.ToInt32(Session["UserID"]);
        //绑定商品数据
        DataTable db = oc.SearchOrderByOrderState(3, UserID);
        this.myOrderList.DataSource = db;
        this.myOrderList.DataBind();
    }

    //点击详情按钮
    protected void lnkbtnDetails_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("UserOrderDetails.aspx?OrderID=" + id);
    }

}