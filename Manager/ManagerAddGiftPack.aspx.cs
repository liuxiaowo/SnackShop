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
    ManagerGoodsClass mgc = new ManagerGoodsClass();
    static List<int> Id = new List<int>();
    static List<int> Num = new List<int>();
    GiftPacksClass gpc = new GiftPacksClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlUrlBind();
        }
        else
        {
            this.goodClass.SelectedValue = this.goodClass.SelectedValue;
        }

    }
    protected void btn_OnClickAddGoods(object sender, EventArgs e)
    {
        string GoodName = this.goodName.Text;
        string GoodInfo = this.goodInfo.Text;
        string GoodUrl = this.ImageMapPhoto.ImageUrl;
        string GoodClass = this.goodClass.SelectedValue.ToString();
        string GoodBrand = this.goodBrand.Text;
        bool GoodIsTuijian = Boolean.Parse(this.isDropDownList.SelectedValue.ToString());
        float marketPrice = float.Parse(this.marketPrice.Text);
        float DisPrice = float.Parse(this.DisPrice.Text);
        float InPrice = float.Parse(this.RPrice.Text);
        int InNum = int.Parse(this.RNum.Text);
        int spareNum = InNum;
        float ShipFee = float.Parse(this.Fee.Text);
        //将用户输入的信息插入到用户表tb_User中
        int IntReturnValue = gc.AddGoodsInfo(GoodClass, GoodName, GoodInfo, GoodUrl, marketPrice, DisPrice, InPrice, GoodIsTuijian, 0, InNum, spareNum, DateTime.Now, GoodBrand, ShipFee,true);
            if (IntReturnValue != -1)
            {
                //Response.Write(cc.MessageBox(IntReturnValue + ":" + Id.Count));
                for (int i = 0; i < Id.Count; i++)
                {
                    //Response.Write(cc.MessageBox(IntReturnValue + ":" + IntReturnValue + ":" + Num[i]));
                    gpc.AddGiftPacks(IntReturnValue, Id[i], Num[i]);
                }
               Response.Write(cc.MessageBox("插入大礼包信息成功！","ManagerGoods.aspx"));
               for (int i = 0; i < Id.Count; i++)
               {
                   //Response.Write(cc.MessageBox(IntReturnValue + ":" + IntReturnValue + ":" + Num[i]))
                       Id.Remove(i);
                       Num.Remove(i);
               }
               
            }
            else
            {
                Response.Write(cc.MessageBox("插入大礼包信息失败！"));
            }
        }

    public void ddlUrlBind()
    {
        //绑定图片
        string strSql = "select * from tb_Img";
        DataTable dsTable = db.GetDataSetStr(strSql, "tbImg");
        //将供选图像绑定到DropDownList控件中
        this.ddlUrl.DataSource = dsTable.DefaultView;
        this.ddlUrl.DataTextField = dsTable.Columns[1].ToString();//绑定图像名
        this.ddlUrl.DataValueField = dsTable.Columns[2].ToString();//绑定图像路径
        this.ddlUrl.DataBind();
        //绑定商品列表
        string className = this.goodClass.SelectedValue.ToString().Substring(0, 2);
        DataTable dbtable = gc.SearchAllGoodsInfoByClass(className+"类");
        this.GoodsChooseList.DataSource = dbtable;
        this.GoodsChooseList.DataBind();
    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
    protected void goodClass_SelectedChanged(object sender, EventArgs e)
    {
        //绑定商品列表
        string className = this.goodClass.SelectedValue.ToString().Substring(0, 2);
        DataTable dbtable = gc.SearchAllGoodsInfoByClass(className + "类");
        this.GoodsChooseList.DataSource = dbtable;
        this.GoodsChooseList.DataBind();
        //刷新页面
        //Response.Redirect(Request.Url.ToString());
    }
    //选择商品
    protected void goodChecked_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = sender as CheckBox;
        bool IsChecked = cb.Checked;
        TextBox tb = cb.Parent.FindControl("num") as TextBox;
        //Response.Write(cc.MessageBox(tb.Text));
        if (IsChecked)
        {
            string strSql = "select * from tb_GoodsInfo where GoodsID=" + int.Parse(cb.Text);
            DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
            float marketPriceF = float.Parse(dsTable.Rows[0][5].ToString());
            float DisPriceF = float.Parse(dsTable.Rows[0][6].ToString());
            float RPriceF = float.Parse(dsTable.Rows[0][7].ToString());
            float FeeF = float.Parse(dsTable.Rows[0][14].ToString());
            int RNumF = int.Parse(dsTable.Rows[0][10].ToString());
            //Response.Write(cc.MessageBox(float.Parse(this.Discount.Text)+""));
            float sales = float.Parse(this.Discount.Text);
            int num = int.Parse(tb.Text);
            this.marketPrice.Text = (float.Parse(this.marketPrice.Text) + marketPriceF * num * sales) + "";
            this.DisPrice.Text = (float.Parse(this.DisPrice.Text) + DisPriceF * num * sales) + "";
            this.RPrice.Text = (float.Parse(this.RPrice.Text) + RPriceF * num * sales) + "";
            this.Fee.Text = (float.Parse(this.Fee.Text) + FeeF * num * sales) + "";
            if (int.Parse(this.RNum.Text)!=0)
            {
               this.RNum.Text = (Math.Min(int.Parse(this.RNum.Text),RNumF)) + "";  
            }else{
                this.RNum.Text = RNumF + ""; 
            }
            Id.Add(int.Parse(cb.Text));
            Num.Add(int.Parse(tb.Text));
        }
        else
        {
            string strSql = "select * from tb_GoodsInfo where GoodsID=" + int.Parse(cb.Text);
            DataTable dsTable = db.GetDataSetStr(strSql, "tbGoodsInfo");
            float marketPriceF = float.Parse(dsTable.Rows[0][5].ToString());
            float DisPriceF = float.Parse(dsTable.Rows[0][6].ToString());
            float RPriceF = float.Parse(dsTable.Rows[0][7].ToString());
            float FeeF = float.Parse(dsTable.Rows[0][14].ToString());
            int RNumF = int.Parse(dsTable.Rows[0][10].ToString());
            float sales = float.Parse(this.Discount.Text);
            int num = int.Parse(tb.Text);
            if ((float.Parse(this.RPrice.Text) - RPriceF * sales) >= 0)
            {
                this.marketPrice.Text = (float.Parse(this.marketPrice.Text) - marketPriceF * num * sales) + "";
                this.DisPrice.Text = (float.Parse(this.DisPrice.Text) - DisPriceF * num * sales) + "";
                this.RPrice.Text = (float.Parse(this.RPrice.Text) - RPriceF * num * sales) + "";
                this.Fee.Text = (float.Parse(this.Fee.Text) - FeeF * num * sales) + "";
            }
            else
            {
                this.marketPrice.Text = 0.00 + "";
                this.DisPrice.Text = 0.00 + "";
                this.RPrice.Text = 0.00 + "";
                this.Fee.Text = 0.00 + "";
            }
            if (int.Parse(this.RNum.Text) != 0)
            {
                this.RNum.Text = (Math.Min(int.Parse(this.RNum.Text), RNumF)) + "";
            }
            else
            {
                this.RNum.Text = RNumF + ""; 
            }
            Id.Remove(int.Parse(cb.Text));
            Num.Remove(int.Parse(tb.Text));
        }
           
    }
}