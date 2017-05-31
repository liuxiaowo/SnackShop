using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControl_Menu : System.Web.UI.UserControl
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    BuyCart bc = new BuyCart();
    OrderClass oc = new OrderClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 1)
        {
            this.Loginbtn.Visible = false;
            this.Registerbtn.Visible = false;

            this.welcome.Visible = true;
            this.LoginedUserName.Visible = true;
            this.exit.Visible = true;
            this.LoginedUserName.Text = Convert.ToString(Session["UserName"]);
            //获取购物车中的数量
            int UserID = Convert.ToInt32(Session["UserID"]);
            int count = bc.SearchGoodsIDNumByUserID(UserID);
            this.cartGoodsNum.Text = count + "";
        }
        else
        {
            this.Loginbtn.Visible = true;
            this.Registerbtn.Visible = true;

            this.welcome.Visible = false;
            this.LoginedUserName.Visible = false;
            this.exit.Visible = false;
            this.cartGoodsNum.Text = 0 + "";
        }

    }
    //去登录点击
    protected void goLogin_Click(object sender, EventArgs e)
    {
        //返回登录界面
        Response.Redirect("../Login/Login.aspx");
    }
    //去注册点击
    protected void goRegister_Click(object sender, EventArgs e)
    {
        //返回登录界面
        Response.Redirect("../Login/Register.aspx");
    }
    //退出登录点击
    protected void Exit_Click(object sender, EventArgs e)
    {
        //清空Session对象
        Session["UserID"] = null;
        Session["Username"] = null;
        Session["UserIsLogin"] = 0;
        //返回登录界面
        Response.Redirect("../Login/Login.aspx");
    }
    //返回首页点击
    protected void BackToIndex_Click(object sender, EventArgs e)
    {
        if (Session["BackOrderID"] != null)
        {
            int OrderID = int.Parse(Session["BackOrderID"].ToString());
            oc.DelOrderByOrderID(OrderID);
        }
        Response.Redirect("UserIndex.aspx");

    }
    //个人中心点击
    protected void Minebtn_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            Response.Redirect("./UserPersonInfo.aspx");
        }
    }
    //我的订单点击
    protected void MineOrderbtn_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            //跳转我的订单页面
            Response.Redirect("./UserMyOrders.aspx");
        }
        
    }
    //购物车点击
    protected void ShoppingCartbtn_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            //跳转购物车页面
            Response.Redirect("./UserCart.aspx");
        }
    }
    //收藏夹点击
    protected void Favoritebtn_onClick(object sender, EventArgs e)
    {
        //调用UserClass类的UserIsLogin方法判断用户是否登录
        int UserIsLogin = Convert.ToInt32(Session["UserIsLogin"]);
        if (UserIsLogin == 0)
        {
            Response.Write(ccObj.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        else //用户已登录逻辑
        {
            //跳转收藏夹页面
            Response.Redirect("./UserFavorite.aspx");
        }
    }
}