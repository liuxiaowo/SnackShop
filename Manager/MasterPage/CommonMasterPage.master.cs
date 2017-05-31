using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MasterPage_CommonMasterPage : System.Web.UI.MasterPage
{
    int adminID = -1;
    string adminName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        adminID = Convert.ToInt32(Session["AdminID"]);
        if (Session["AdminName"] != null)
        {
            adminName = Session["AdminName"].ToString();
            this.AdminName.Text = adminName;
        }
        this.time.Text = Convert.ToString(DateTime.Now.ToShortDateString());
    }
    //退出登录
    protected void exit_onClick(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Session["AdminName"] = null;
        //跳转到登录界面
        Response.Redirect("~/Login/Login.aspx");
    }
    //修改密码
    protected void changePwd_onClick(object sender, EventArgs e)
    {
        
        //跳转到修改界面
        Response.Redirect("ChangePwd.aspx");
    }
    //订单管理
    protected void orderMag_onClick(object sender, EventArgs e)
    {
        //跳转到订单管理界面
        Response.Redirect("ManagerIndex.aspx");
    }
    //商品管理
    protected void goodsMag_onCLick(object sender, EventArgs e)
    {
        //跳转到商品管理界面
        Response.Redirect("ManagerGoods.aspx");
    }
}
