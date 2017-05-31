using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ChangePwd : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    AdminClass ac = new AdminClass();
    string adminName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] != null)
        {
            adminName = Session["AdminName"].ToString();
        }
        this.txtName.Attributes.Add("Value", adminName);
        //解决密码textChanged事件导致密码消失问题
        if (IsPostBack)
        {
            this.txtPasswordForget.Attributes.Add("value ", this.txtPasswordForget.Text);
            this.confrimPwd.Attributes.Add("value", this.confrimPwd.Text);
        }
    }
    //密码规范
    protected void pwd_textChanged(object sender, EventArgs e)
    {
        if (!cc.IsPasswLength(this.txtPasswordForget.Text)) //密码6-18位
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
        if (this.pwdNew.Visible == false && this.confrimPwdSpan.Visible == false)
        {
            ac.ChangePwdManager(this.txtName.Text.Trim(), this.txtPasswordForget.Text.Trim());
            //返回登录界面（带参数）
            string s_url;
            //Response.Redirect("~/Login/Login.aspx");
            s_url = "../Login/Login.aspx?AdminName=" + adminName;
            Response.Write(cc.MessageBox("密码修改成功！", s_url));
        }
        else
        {
            Response.Write(cc.MessageBox("密码修改失败，请检查输入是否有误！"));
        }
    }

}