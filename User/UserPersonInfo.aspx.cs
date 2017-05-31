using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_UserPersonInfo : System.Web.UI.Page
{
    int UserID = -1;
    CommonClass cc = new CommonClass();
    UserClass uc = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {
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
    //绑定用户信息
    public void dlBind()
    {
        //绑定用户信息
        DataTable db = uc.SearchUserInfo(UserID);
        this.userList.DataSource = db;
        this.userList.DataBind();
    }
    //用户信息按钮
    protected void userInfo(object sender, EventArgs e)
    {
        Response.Redirect("UserPersonInfo.aspx");
    }
    //我的订单按钮
    protected void MyOrderList(object sender, EventArgs e)
    {
        Response.Redirect("UserMyOrders.aspx");
    }
    //收藏夹按钮
    protected void Favoirite(object sender, EventArgs e)
    {
        Response.Redirect("UserFavorite.aspx");
    }
    //修改用户密码按钮
    protected void changePwd(object sender, EventArgs e)
    {
        Response.Redirect("UserChangePwd.aspx");
    }
    //修改收货地址按钮
    protected void changeAddress(object sender, EventArgs e)
    {
        Response.Redirect("UserInfoChanged.aspx");
    }

}