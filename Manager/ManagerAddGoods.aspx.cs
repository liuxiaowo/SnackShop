using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manager_ManagerAddGoods : System.Web.UI.Page
{
    GoodsClass gc = new GoodsClass();
    CommonClass cc = new CommonClass();
    DBClass db = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlUrlBind();
        }

    }
    protected void btn_OnClickAddGoods(object sender, EventArgs e)
    {
        string GoodName = this.goodName.Text;
        string GoodInfo = this.goodInfo.Text;
        string GoodUrl = this.ImageMapPhoto.ImageUrl;
        string GoodClass = this.goodClass.Text;
        string GoodBrand = this.goodBrand.Text;
        bool GoodIsTuijian = Boolean.Parse(this.isDropDownList.SelectedValue.ToString());
        float marketPrice = float.Parse(this.marketPrice.Text);
        float DisPrice = float.Parse(this.DisPrice.Text);
        float InPrice = float.Parse(this.inPrice.Text);
        int InNum = int.Parse(this.inNum.Text);
        int spareNum = InNum;
        float ShipFee = float.Parse(this.Fee.Text);
            //将用户输入的信息插入到用户表tb_User中
        int IntReturnValue = gc.AddGoodsInfo(GoodClass, GoodName, GoodInfo, GoodUrl, marketPrice, DisPrice, InPrice, GoodIsTuijian, 0, InNum, spareNum, DateTime.Now, GoodBrand, ShipFee,true);
            if (IntReturnValue!=-1)
            {

                Response.Write(cc.MessageBox("插入商品信息成功！","ManagerGoods.aspx"));
            }
            else
            {
                Response.Write(cc.MessageBox("插入商品信息失败！"));

            }
        }

    public void ddlUrlBind()
    {
        string strSql = "select * from tb_Img";
        DataTable dsTable = db.GetDataSetStr(strSql, "tbImg");
        //将供选图像绑定到DropDownList控件中
        this.ddlUrl.DataSource = dsTable.DefaultView;
        this.ddlUrl.DataTextField = dsTable.Columns[1].ToString();//绑定图像名
        this.ddlUrl.DataValueField = dsTable.Columns[2].ToString();//绑定图像路径
        this.ddlUrl.DataBind();
    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
}