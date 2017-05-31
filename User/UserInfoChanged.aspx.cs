using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserInfoChanged : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    UserClass uc = new UserClass();
    int OrderID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            this.txtName.Text = Session["UserName"].ToString();
        }
        else
        {
            Response.Write(cc.MessageBox("请先登录！", "../Login/Login.aspx"));
        }
        if (Request.QueryString["OrderID"] != null)
        {
            OrderID = int.Parse(Request.QueryString["OrderID"]);
        }

    }
    //修改收货地址
    protected void btn_ChangeAddressClick(object sender, EventArgs e)
    {
        if (this.textPhoneLabel.Visible == false) //电话号码输入正确
        {
           int UserID = Convert.ToInt32(Session["UserID"]);
           string name = this.textRevName.Text;
           string phone = this.textPhone.Text;
           string address = this.Address.Text;
           uc.ChangeUserAddress(UserID, name,phone,address);
           Response.Write(cc.MessageBox("修改成功！"));
        }
        else 
        {
            Response.Write(cc.MessageBox("修改失败，请先检查输入是否有误！"));
        }

    }
    //手机号码文字改变时
    protected void phone_textChanged(object sender, EventArgs e)
    {
        if (!cc.IsHandset(this.textPhone.Text.Trim())) //手机号码
        {
            this.textPhoneLabel.Visible = true;
        }
        else
        {
            this.textPhoneLabel.Visible = false;
        }
    }
    //返回个人中心
    protected void backPersonInfo(object sender, EventArgs e)
    {
        Response.Redirect("UserPersonInfo.aspx");
    }
    //返回提交订单界面
    protected void backUpOrders(object sender, EventArgs e)
    {
        Response.Redirect("UserOrders.aspx?OrderID="+OrderID);
    }
}