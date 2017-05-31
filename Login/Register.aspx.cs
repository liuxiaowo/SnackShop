using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Register : System.Web.UI.Page
{
    CommonClass ccObj = new CommonClass();
    UserClass ucObj = new UserClass();
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //解决密码textChanged事件导致密码消失问题
        if (IsPostBack)
        {
            this.txtPassword.Attributes.Add("value ", this.txtPassword.Text);
            this.confrimPwd.Attributes.Add("value", this.confrimPwd.Text);
        }
    }

    //用户名文字改变时
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
         //调用UserClass类的UserForgetPwd方法判断用户是否存在
        DataTable dsTable = ucObj.UserForgetPwd(this.txtName.Text.Trim());
        if (dsTable != null) //用户名存在
        {
            this.UserNameIsExist.Visible = true;
        }
        else
        {
            this.UserNameIsExist.Visible = false;
        }
    }
    //密码文字改变时
    protected void txtPwd_TextChanged(object sender, EventArgs e)
    {
        if (!ccObj.IsPasswLength(this.txtPassword.Text)) //密码6-18位
        {
            this.PwdIsExist.Visible = true;
        }
        else
        {
            this.PwdIsExist.Visible = false;
        }
    }
    //验证密码文字改变时
    protected void txtPwdAgain_TextChanged(object sender, EventArgs e)
    {
        if (this.txtPassword.Text != this.confrimPwd.Text)
        {
            this.confrimPwdSpan.Visible = true;
        }
        else
        {
            this.confrimPwdSpan.Visible = false;
        }
    }
    //手机号码文字改变时
    protected void txtPhone_textChanged(object sender, EventArgs e)
    {
        if (!ccObj.IsHandset(this.txtPhone.Text.Trim())) //手机号码
        {
            this.txtPhoneLabel.Visible = true;
        }
        else
        {
            this.txtPhoneLabel.Visible = false;
        }
    }
    //收货人文字改变时
    protected void txtTrueName_onTextChanged(object sender, EventArgs e)
    {
        if (this.txtTrueName.Text.Trim() == null) //收货人
        {
            this.txtTrueNameLabel.Visible = true;
        }
        else
        {
            this.txtTrueNameLabel.Visible = false;
        }
    }
    //详细地址文字改变时
    protected void address_textChanged(object sender, EventArgs e)
    {
        if (this.txtAddress.Text.Trim()==null) //地址
        {
            this.txtPhoneLabel.Visible = true;
        }
        else
        {
            this.txtPhoneLabel.Visible = false;
        }
    }
    //返回登录页点击
    protected void backLogin_Click(object sender, EventArgs e)
    {
        //返回登录界面
        Response.Redirect("Login.aspx");
    }
    //立即注册点击
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (this.UserNameIsExist.Visible == false && this.PwdIsExist.Visible == false && this.confrimPwdSpan.Visible == false && this.txtPhoneLabel.Visible == false && this.textAddressLabel.Visible == false) //用户名不存在
        {
  
                //将用户输入的信息插入到用户表tb_User中
                int IntReturnValue = ucObj.AddUser(txtName.Text.Trim(), txtPassword.Text.Trim(), txtTrueName.Text.Trim(), this.ddlSex.SelectedValue.ToString(), txtPhone.Text.Trim(), txtAddress.Text.Trim(), DateTime.Now);
                if (IntReturnValue == 100)
                {
                    //返回登录界面（带参数）
                    string s_url;
                    s_url = "Login.aspx?UserName=" + this.txtName.Text.Trim();
                    Response.Write(ccObj.MessageBox("恭喜您，注册成功！", s_url));
                }
                else
                {
                    Response.Write(ccObj.MessageBox("插入失败，该名字已存在！"));

                }
        }
        else //用户名存在
        {
            Response.Write(ccObj.MessageBox("注册失败，请先检查输入是否有误！"));
        }

    }
    /// <summary>
    ///  将性别转化为Bool值
    /// </summary>
    /// <param name="strValue">需要转化的性别值</param>
    /// <returns>返回转化后的性别值</returns>
    protected bool transfer(string strValue)
    {
        if (strValue == "男")
        {
            return true;
        }
        else
        {
            return false;

        }
    }
    //重置点击
    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.txtName.Text = "";     //用户名
        this.txtPassword.Text = ""; //用户密码
        this.confrimPwd.Text = ""; //确认密码
        this.txtTrueName.Text = ""; //用户真实姓名
        this.txtPhone.Text = "";    //用户电话号码
        this.txtAddress.Text = "";  //详细地址
    }
}