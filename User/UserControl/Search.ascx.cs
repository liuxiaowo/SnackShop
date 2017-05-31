using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserControl_Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //用户输入
        this.searchBox.Attributes.Add("Value", "请输入关键词");
        this.searchBox.Attributes.Add("OnFocus", "if(this.value=='请输入关键词'){this.value=''}");
        this.searchBox.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入关键词'}");
    }
    //搜索框点击
    protected void searchbtn_onClick(object sender, EventArgs e)
    {
        //选择“商品名称”
        if (this.type.SelectedIndex == 0)
        {
            String className = this.searchBox.Text.Trim();
            Response.Redirect("./UserIndex.aspx?name=" + className);
        }
        else if (this.type.SelectedIndex == 1) //选择“品牌”
        {
            String className = this.searchBox.Text.Trim();
            Response.Redirect("./UserIndex.aspx?brand=" + className);
        }
        else //选择“类别”
        {
            String className = this.searchBox.Text.Trim();
            //跳转到该类别界面
            Response.Redirect("./UserIndex.aspx?class=" + className);
        }
    }
}