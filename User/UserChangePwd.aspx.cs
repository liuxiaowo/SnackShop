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
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Login页传值
        if (Session["UserName"] != null)
        {
            this.txtName.Text = Session["UserName"].ToString();
        }
        //解决密码textChanged事件导致密码消失问题
        if (IsPostBack)
        {
            this.pwdOld.Attributes.Add("Value", this.pwdOld.Text);
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
    //旧密码规范
    protected void pwdOld_textChanged(object sender, EventArgs e)
    {
        int UserID = int.Parse(Session["UserID"].ToString());
        //总金额
        string strSql = "select * from tb_User where UserID=" + UserID;
        DataTable dsTable = db.GetDataSetStr(strSql, "tbUser");
        string pwd = dsTable.Rows[0]["Password"].ToString();
        if (!pwd.Equals(this.pwdOld.Text)) //旧密码是否一致
        {
            this.pwdOldText.Visible = true;
        }
        else
        {
            this.pwdOldText.Visible = false;
        }
    }
    //新密码规范
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
        if (this.pwdOldText.Visible == false && this.pwdNew.Visible == false && this.confrimPwdSpan.Visible == false)
        {
            ucObj.UserChangePwd(this.txtName.Text.Trim(), this.txtPasswordForget.Text.Trim());
            //返回登录界面（带参数）
            string s_url;
            s_url = "../Login/Login.aspx?UserName=" + this.txtName.Text.Trim();
            Response.Write(ccObj.MessageBox("密码修改成功！", s_url));
        }
        else
        {
            Response.Write(ccObj.MessageBox("密码修改失败，请检查输入是否有误！"));
        }
    }
    //返回个人中心
    protected void backPersonInfo(object sender, EventArgs e)
    {
        Response.Redirect("UserPersonInfo.aspx");
    }

}