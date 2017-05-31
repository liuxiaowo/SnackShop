using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// UserClass 的摘要说明
/// </summary>
public class UserClass
{
    DBClass dbObj = new DBClass();
	public UserClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************登录界面************************************************************
    /// <summary>
    /// 判断用户是否能登录
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">用户密码</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable UserLogin(string strName,string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_UserLogin");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName",SqlDbType.VarChar,50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password",SqlDbType.VarChar,50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向用户表中插入信息
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strAddress">详细地址</param>
    /// <param name="localdate">注册时间</param>
    /// <returns>返回用户ID代号</returns>
    public int AddUser(string strName, string strPassword, string strRealName, string blSex, string strPhonecode, string strAddress,DateTime localdate)
    {
        SqlCommand myCmd =dbObj.GetCommandProc("proc_AddUser");
        //添加参数
        SqlParameter name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);
        //添加参数
        SqlParameter realName = new SqlParameter("@RealName", SqlDbType.VarChar, 50);
        realName.Value = strRealName;
        myCmd.Parameters.Add(realName);
        //添加参数
        SqlParameter sex = new SqlParameter("@Sex", SqlDbType.VarChar, 50);
        sex.Value = blSex;
        myCmd.Parameters.Add(sex);
        //添加参数
        SqlParameter phonecode = new SqlParameter("@Phonecode", SqlDbType.VarChar, 20);
        phonecode.Value = strPhonecode;
        myCmd.Parameters.Add(phonecode);
        //添加参数
        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
        //添加参数
        SqlParameter date = new SqlParameter("@LocalDate", SqlDbType.DateTime, 8);
        date.Value = localdate;
        myCmd.Parameters.Add(date);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }
    //***************************************忘记密码界面************************************************************
    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable UserForgetPwd(string strName)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetUserNameIsExist");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    //***************************************忘记密码界面************************************************************
    /// <summary>
    /// 验证手机号正确与否
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPhone">手机号</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable UserForgetPwdIsPhoneConfirm(string strName, string strPhone)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ChangePwdPhoneConfirm");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(用户名)
        SqlParameter Phone = new SqlParameter("@Phonecode", SqlDbType.VarChar, 11);
        Phone.Value = strPhone;
        myCmd.Parameters.Add(Phone);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    //***************************************忘记密码界面************************************************************
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">密码</param>
    /// <returns>返回数据源的数据表</returns>
    public void UserChangePwd(string strName,String strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_ChangePwd");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(用户名)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
    }
    //***************************************修改收货地址界面************************************************************
    /// <summary>
    /// 修改收货地址
    /// <returns>返回数据源的数据表</returns>
    public void ChangeUserAddress(int id, string name, string phone, string address)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ChangeUserAddress");
        //添加参数(用户ID)
        SqlParameter ID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        ID.Value = id;
        myCmd.Parameters.Add(ID);
        //添加参数(收货人)
        SqlParameter Name = new SqlParameter("@RealName", SqlDbType.VarChar, 50);
        Name.Value = name;
        myCmd.Parameters.Add(Name);
        //添加参数(电话)
        SqlParameter Phone = new SqlParameter("@Phonecode", SqlDbType.VarChar, 11);
        Phone.Value = phone;
        myCmd.Parameters.Add(Phone);
        //添加参数(地址)
        SqlParameter Address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        Address.Value = address;
        myCmd.Parameters.Add(Address);
        dbObj.ExecNonQuery(myCmd);
    }
    //***************************************生成订单界面************************************************************
    /// <summary>
    /// 订单中的用户信息
    /// <returns>返回数据源的数据表</returns>
    public DataTable SearchUserInfo(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_SearchUserInfo");
        //添加参数(用户名)
        SqlParameter id = new SqlParameter("@UserID", SqlDbType.Int, 4);
        id.Value = UserID;
        myCmd.Parameters.Add(id);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
}
