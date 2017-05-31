using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class User_UserOrderDetails : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    UserClass uc = new UserClass();
    OrderClass oc = new OrderClass();
    int OrderID = 0,UserID = -1;
    ManagerOrderClass moc = new ManagerOrderClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //商品到商品详情页传值
        if (Request.QueryString["OrderID"] != null)
        {
            OrderID = int.Parse(Request.QueryString["OrderID"]);
        }
        UserID = Convert.ToInt32(Session["UserID"]);
        if (!IsPostBack)
        {
            if (UserID != -1)
            {
                dlBind();       //绑定信息
            }
            else
            {
                //重新登录
                Response.Write(cc.MessageBox("请先登录！", "../Login/Login.aspx"));
            }

        }
    }
    /// 说明：dlBind方法绑定信息
    public void dlBind()
    {
        //绑定订单信息
        DataTable oLD = oc.SearchOrderLessInfo(OrderID);
        this.orderList.DataSource = oLD;
        this.orderList.DataBind();
        //绑定用户信息
        DataTable db = uc.SearchUserInfo(UserID);
        this.OrderAddressList.DataSource = db;
        this.OrderAddressList.DataBind();
        //绑定商品信息
        DataTable oDB = oc.SearchOrderInfo(OrderID);
        this.goodOrderList.DataSource = oDB;
        this.goodOrderList.DataBind();
        //绑定运费信息
        DataTable oLDB = oc.SearchOrderLessInfo(OrderID);
        this.PayWayList.DataSource = oLDB;
        this.PayWayList.DataBind();
    }
    //当绑定DataList1中的每一项时的处理方法 
    protected void PayWayList_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //根据状态修改退款和确认收货的按钮显示与否
            LinkButton exitMoney = e.Item.FindControl("exitMoney") as LinkButton;
            LinkButton confrimRev = e.Item.FindControl("confrimRev") as LinkButton;
            LinkButton deleteOrder = e.Item.FindControl("deleteOrder") as LinkButton;
            int state = moc.SearchOrderStateByOrderID(OrderID);
            if (state == 1)
            {
                exitMoney.Visible = true;
                confrimRev.Visible = false;
                deleteOrder.Visible = false;
            }
            else if (state == 2)
            {
                exitMoney.Visible = true;
                confrimRev.Visible = true;
                deleteOrder.Visible = false;
            }
            else if (state == 3 || state == 5 || state == 0)
            {
                exitMoney.Visible = false;
                confrimRev.Visible = false;
                deleteOrder.Visible = true;
            }
            else
            {
                exitMoney.Visible = false;
                confrimRev.Visible = false;
                deleteOrder.Visible = false;
            }
        }
    }
    //点击退款按钮
    protected void lnkbtnBackMoney_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        //bc.DeleteCartGoods(id);
        oc.UpdateOrderState(id, 4);
        //刷新页面
        Response.Write(cc.MessageBox("退款成功，金钱会在24小时内转回您的账户！", "UserMyOrders.aspx"));
        //Response.Redirect("UserIndex.aspx");
    }
    //点击确认收货按钮
    protected void lnkbtnConfrimRev_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        //bc.DeleteCartGoods(id);
        oc.UpdateOrderState(id, 3);
        //刷新页面
        Response.Write(cc.MessageBox("订单完成！", "UserMyOrders.aspx"));
        //Response.Redirect("UserIndex.aspx");
    }
    //点击删除订单按钮
    protected void lnkbtnDeleteOrder_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        //bc.DeleteCartGoods(id);
        oc.DelOrderByOrderID(id);
        //刷新页面
        Response.Redirect("UserMyOrders.aspx"); 
    }
}