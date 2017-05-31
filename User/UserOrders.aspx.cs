using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserOrders : System.Web.UI.Page
{
    UserClass uc = new UserClass();
    OrderClass oc = new OrderClass();
    CommonClass cc = new CommonClass();
    int OrderID = 0;
    int UserID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //商品详情到生成订单页传值（立即购买）
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
            }else
            {
                //重新登录
                Response.Write(cc.MessageBox("请先登录！", "../Login/Login.aspx"));
            }

        }
    }
    /// <summary>
    /// 说明：dlBind方法绑定信息
    public void dlBind()
    {
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
    //提交订单
    protected void submitOrderBtn_onClick(object sender, EventArgs e)
    {
        TextBox lm = PayWayList.Items[0].FindControl("LeavingMsg") as TextBox;
        //更新备注信息
        oc.UpdateLeavingMsg(OrderID, lm.Text);
        Session["BackOrderID"] = null;
        Response.Redirect("UserPay.aspx?OrderID="+OrderID);
    }
    //取消订单
    protected void cancelOrder(object sender, EventArgs e)
    {
        //删除对应订单信息
        oc.DelOrderByOrderID(OrderID);
        Response.Redirect("UserIndex.aspx");
    }
    //修改收货人地址
    protected void ChangedUserInfo_onClick(object sender, EventArgs e)
    {
        Response.Redirect("UserInfoChanged.aspx?OrderID="+OrderID);
    }

}