using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manager_MangerGoodsDetails : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    UserClass uc = new UserClass();
    OrderClass oc = new OrderClass();
    int OrderID = 0;
    int AdminID = -1;
    ManagerOrderClass moc = new ManagerOrderClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //商品到商品详情页传值
        if (Request.QueryString["OrderID"] != null)
        {
            OrderID = int.Parse(Request.QueryString["OrderID"]);
        }
        AdminID = Convert.ToInt32(Session["AdminID"]);
        if (!IsPostBack)
        {
            if (AdminID != -1)
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
        DataTable db = moc.SearchOrderUserInfoByOrderID(OrderID);
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
}