using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// AdminClass 的摘要说明
/// </summary>
public class AdminClass
{
    DBClass dbObj = new DBClass();
	public AdminClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************登录界面************************************************************
    /// <summary>
    /// 判断管理员是否能登录
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">用户密码</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable AdminLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AdminLogin");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbAdmin");
        return dsTable;
    }
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向管理员表中插入信息
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="localdate">注册时间</param>
    /// <returns>返回管理员ID代号</returns>
    public int AddAdmin(string strName, string strPassword, DateTime localdate)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddAdmin");
        //添加参数
        SqlParameter name = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);
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
    /// 修改密码
    /// </summary>
    /// <param name="strName">管理员名</param>
    /// <param name="strPwd">密码</param>
    /// <returns>返回数据源的数据表</returns>
    public void ChangePwdManager(string strName, String strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("pro_ChangePwdManager");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@AdminName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(用户名)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
    }
  
}