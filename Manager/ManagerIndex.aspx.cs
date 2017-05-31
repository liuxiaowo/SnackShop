using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manager_ManagerIndex : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    GoodsClass gcObj = new GoodsClass();
    ManagerOrderClass moc = new ManagerOrderClass();
    OrderClass oc = new OrderClass();
    LinkButton sendOrder;
    LinkButton exitOrder;
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
        DataTable db = moc.SearchAllOrders();
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //当绑定DataList1中的每一项时的处理方法 
    protected void myOrderGoodList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int id = int.Parse(DataBinder.Eval(e.Item.DataItem, "OrderID").ToString());
            sendOrder = e.Item.FindControl("sendOrder") as LinkButton;
            exitOrder = e.Item.FindControl("exitOrder") as LinkButton;
            int state = moc.SearchOrderStateByOrderID(id);
            if (state == 1)
            {
                sendOrder.Visible = true;
                exitOrder.Visible = false;
            }
            else if (state == 4)
            {
                sendOrder.Visible = false;
                exitOrder.Visible = true;
            }
            else
            {
                sendOrder.Visible = false;
                exitOrder.Visible = false;
            }
            DataList ChildList = null;
            // 填充dataset
            DataSet ds = new DataSet();
            ChildList = (DataList)e.Item.FindControl("myOrderGoodList");
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
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(0);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //待发货
    protected void sendBtn_onClick(object sender, EventArgs e)
    {
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(1);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //待收货
    protected void takeOverBtn_onClick(object sender, EventArgs e)
    {
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(2);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //已接收
    protected void FinishBtn_onClick(object sender, EventArgs e)
    {
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(3);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //退单
    protected void ExitBtn_onClick(object sender, EventArgs e)
    {
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(4);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //退单完成
    protected void ExitFinishBtn_onClick(object sender, EventArgs e)
    {
        //绑定商品数据
        DataTable db = moc.SearchAllOrderByOrderState(5);
        this.myOrderListMag.DataSource = db;
        this.myOrderListMag.DataBind();
    }
    //点击发货按钮
    protected void lnkbtnsend_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        oc.UpdateOrderState(id, 2);
        //刷新页面
        Response.Redirect(Request.Url.ToString()); 
    }
    //点击退单按钮
    protected void lnkbtnexit_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        oc.UpdateOrderState(id, 5);
        //刷新页面
        Response.Redirect(Request.Url.ToString()); 
    }

    //点击详情按钮
    protected void lnkbtnDetails_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("MangerOrderDetails.aspx?OrderID=" + id);
    }
    //点击营业额统计按钮
    protected void allMoney_onClick(object sender, EventArgs e)
    {
        float price = 0;
        price = moc.SearchOrdersAllMoneyByOrderState();
        this.AllMoneyLabel.Text = price + "";

    }
}