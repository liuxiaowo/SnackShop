using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    //公有类
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    AdminClass adObj = new AdminClass();
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //返回Login页传值
        if (Request.QueryString["UserName"] != null)
        {
            this.txtName.Text = Request.QueryString["UserName"];
        }
        if (Request.QueryString["AdminName"] != null)
        {
            this.txtName.Text = Request.QueryString["AdminName"];
            this.identity.SelectedIndex = 1;
            this.goRegister.Visible = false;
            this.forgetPwd.Visible = false;
        }
        this.txtPasswordLogin.Attributes.Add("value", this.txtPasswordLogin.Text.Trim());
    }
    //验证码换一张点击
    protected void codeAgain_Click(object sender, EventArgs e)
    {
        //产生随机验证码
        this.labValid.Text = ccObj.RandomNum(4);
    }
    //用户名TextBox
    protected void txtName_leave(object sender, EventArgs e)
    {
        this.txtName.Text = "";
    }
    //前往注册点击
    protected void goRegister_Click(object sender, EventArgs e)
    {
        //跳转到注册界面
        Response.Redirect("Register.aspx");
    }
    //登录点击
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //选择用户（登录跳转用户界面）
        if (this.identity.SelectedIndex == 0)
        {
            //清空Session对象
            Session["UserID"] = null;
            Session["Username"] = null;
            Session["UserIsLogin"] = 0;
            if (this.txtName.Text.Trim() == "" || this.txtPasswordLogin.Text.Trim() == "")
            {
                Response.Write(ccObj.MessageBoxPage("登录名和密码不能为空！"));
            }
            else
            {
                if (this.txtValid.Text.Trim() == this.labValid.Text.Trim())
                {
                    //调用UserClass类的UserLogin方法判断用户是否为合法用户
                    DataTable dsTable = ucObj.UserLogin(this.txtName.Text.Trim(), this.txtPasswordLogin.Text.Trim());
                    if (dsTable != null) //判断用户是否存在
                    {
                        Session["UserID"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存用户ID
                        Session["Username"] = dsTable.Rows[0][1].ToString(); //保存用户登录名
                        Session["UserIsLogin"] = 1;
                        //Response.Redirect(Request.CurrentExecutionFilePath); //跳转到当前请求的虚拟路径
                        Response.Write(ccObj.MessageBox("登录成功！","../User/UserIndex.aspx"));
                        //Response.Redirect("Default.aspx"); //跳转到当前请求的虚拟路径
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBoxPage("您的登录有误，请核对后再重新登录！"));
                    }
                }
                else
                {
                    Response.Write(ccObj.MessageBoxPage("请正确输入验证码！"));
                }
            }
        }
        else   //选择管理员（登录跳转管理中心界面）
        {
            //将默认的管理员帐号插入到tb_Admin数据库中，便于登录查找
            //adObj.AddAdmin("admin", "123456", DateTime.Now);
            //清空Session对象
            Session["AdminID"] = null;
            Session["AdminName"] = null;
            if (this.txtName.Text.Trim() == "" || this.txtPasswordLogin.Text.Trim() == "")
            {
                Response.Write(ccObj.MessageBoxPage("登录名和密码不能为空！"));
            }
            else
            {
                if (this.txtValid.Text.Trim() == this.labValid.Text.Trim())
                {
                    //调用UserClass类的UserLogin方法判断用户是否为合法用户
                    DataTable dsTable = adObj.AdminLogin(this.txtName.Text.Trim(), this.txtPasswordLogin.Text.Trim());
                    if (dsTable != null) //判断用户是否存在
                    {
                        Session["AdminID"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存管理员ID
                        Session["AdminName"] = dsTable.Rows[0][1].ToString(); //保存管理员登录名
                        //Response.Redirect(Request.CurrentExecutionFilePath); //跳转到当前请求的虚拟路径
                        Response.Write(ccObj.MessageBox("登录成功！","../Manager/ManagerIndex.aspx"));
                        //Response.Redirect("Default.aspx"); //跳转到当前请求的虚拟路径
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBoxPage("您的登录有误，请核对后再重新登录！"));
                    }
                }
                else
                {
                    Response.Write(ccObj.MessageBoxPage("请正确输入验证码！"));
                }
            }
            
        }
        
    }
    //忘记密码点击
    protected void forgetPwd_Click(object sender, EventArgs e)
    {
        //调用UserClass类的UserForgetPwd方法判断用户是否存在
        DataTable dsTable = ucObj.UserForgetPwd(this.txtName.Text.Trim());
        if (dsTable != null) //存在
        {
            //跳转到忘记密码界面（带参数）
            string s_url;
            s_url = "ForgetPassword.aspx?UserName=" + this.txtName.Text.Trim();  
            Response.Redirect(s_url);
        }
        else //不存在
        {
            Response.Write(ccObj.MessageBoxPage("用户名不存在！"));
        }
    }
    //用户或管理员选中效果
    protected void identity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.identity.SelectedIndex == 0)
        {
            this.goRegister.Visible = true;
            this.forgetPwd.Visible = true;
        }
        else
        {
            this.goRegister.Visible = false;
            this.forgetPwd.Visible = false;
        }
    }

}