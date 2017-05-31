using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_ForgetPassword : System.Web.UI.Page
{
    //公有类
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login页传值
        if (Request.QueryString["UserName"] != null)
        {
            this.txtName.Text = Request.QueryString["UserName"];
        }
        //解决密码textChanged事件导致密码消失问题
        if (IsPostBack)
        {
            this.txtPasswordForget.Attributes.Add("value ", this.txtPasswordForget.Text);
            this.confrimPwd.Attributes.Add("value", this.confrimPwd.Text);
        }
    }
    //返回登录页点击
    protected void backLogin_Click(object sender, EventArgs e)
    {
        //返回登录界面
        Response.Redirect("Login.aspx");
    }
    //手机号验证
    protected void phone_confirmTextChanged(object sender, EventArgs e)
    {
        DataTable isPhoneConfirm = ucObj.UserForgetPwdIsPhoneConfirm(this.txtName.Text.Trim(), this.phoneText.Text.Trim());
        if (isPhoneConfirm == null)
        {
            this.phoneConfirmSpan.Visible = true;
        }
        else
        {
            this.phoneConfirmSpan.Visible = false;
        }
    }
    //密码规范
    protected void pwd_textChanged(object sender, EventArgs e)
    {
        if (!ccObj.IsPasswLength(this.txtPasswordForget.Text)) //密码6-18位
        {
            this.pwdNew.Visible = true;
        }
        else
        {
            this.pwdNew.Visible = false;
        }
    }
    //密码验证
    protected void pwdAgain_textChanged(object sender, EventArgs e)
    {
        String onePwd = this.txtPasswordForget.Text;
        String twoPwd = this.confrimPwd.Text;
        if (onePwd != twoPwd)
        {
            this.confrimPwdSpan.Visible = true;
        }
        else
        {
            this.confrimPwdSpan.Visible = false;
        }
    }
    //修改密码
    protected void btn_ChangePwdClick(object sender, EventArgs e)
    {
        if (this.phoneConfirmSpan.Visible == false && this.pwdNew.Visible == false && this.confrimPwdSpan.Visible == false)
        {
            ucObj.UserChangePwd(this.txtName.Text.Trim(), this.txtPasswordForget.Text.Trim());
            //返回登录界面（带参数）
            string s_url;
            s_url = "Login.aspx?UserName=" + this.txtName.Text.Trim();
            Response.Write(ccObj.MessageBox("密码修改成功！", s_url));
        }
        else
        {
            Response.Write(ccObj.MessageBox("密码修改失败，请检查输入是否有误！"));
        }
    }

}