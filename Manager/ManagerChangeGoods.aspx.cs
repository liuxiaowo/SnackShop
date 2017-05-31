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
    int goodID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["goodID"] != null)
        {
            goodID = int.Parse(Request.QueryString["goodID"]);
        }
        if (!IsPostBack)
        {
            bindGoodsInfo();
            ddlUrlBind();
        }

    }
    //绑定数据信息
    public void bindGoodsInfo()
    {
        string strSql = "select * from tb_GoodsInfo where GoodsID="+goodID;
        DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
        this.goodName.Text = dsTable.Rows[0][2].ToString();
        this.goodInfo.Text = dsTable.Rows[0][3].ToString();
        this.ImageMapPhoto.ImageUrl = dsTable.Rows[0][4].ToString();
        this.goodClass.Text = dsTable.Rows[0][1].ToString();
        this.goodBrand.Text = dsTable.Rows[0][13].ToString();
        this.isDropDownList.SelectedValue = dsTable.Rows[0][8].ToString();
        this.marketPrice.Text = Math.Round(Double.Parse(dsTable.Rows[0][5].ToString()),2)+"";
        this.DisPrice.Text = Math.Round(Double.Parse(dsTable.Rows[0][6].ToString()), 2) + "";
        this.inPrice.Text = Math.Round(Double.Parse(dsTable.Rows[0][7].ToString()), 2) + "";
        this.salesnum.Text = dsTable.Rows[0][9].ToString();
        this.inNum.Text = dsTable.Rows[0][10].ToString();
        this.Fee.Text = Math.Round(Double.Parse(dsTable.Rows[0][14].ToString()), 2) + "";
    }
    protected void btn_OnClickChangeGoods(object sender, EventArgs e)
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
        int SalesNum = int.Parse(this.salesnum.Text);
        int InNum = int.Parse(this.inNum.Text);
        int spareNum = InNum - SalesNum;
        float ShipFee = float.Parse(this.Fee.Text);
            //将用户输入的信息插入到用户表tb_User中
        int IntReturnValue = gc.ChangeGoodsInfo(goodID,GoodClass, GoodName, GoodInfo, GoodUrl, marketPrice, DisPrice, InPrice, GoodIsTuijian, SalesNum, InNum, spareNum, DateTime.Now, GoodBrand, ShipFee);
            if (IntReturnValue == 100)
            {

                Response.Write(cc.MessageBox("修改商品信息成功！","ManagerGoods.aspx"));
            }
            else
            {
                Response.Write(cc.MessageBox("修改商品信息失败！"));

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