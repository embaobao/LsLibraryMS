using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LSLibraryMS.DAL
{
	/// <summary>
	/// 数据库访问基类
	/// </summary>
	public static class DBHelper
	{
		#region 得到SqlConnection
		/// <summary>
		/// 得到SqlConnection
		/// </summary>
		/// <returns>返回SqlConnection对象</returns>
		private static SqlConnection getCon()
		{
			string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
			return new SqlConnection(strCon);
		}
		#endregion

		#region 执行一个SQL语句
		/// <summary>
		/// 执行一个SQL语句
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="values">SQL中的参数</param>
		/// <returns>所影响的行数</returns>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				SqlCommand cmd = new SqlCommand(sql, con);
				if (values != null)
				{
                    cmd.Parameters.AddRange(values);
				}
				con.Open();
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 返回第一行第一列的值
		/// <summary>
		/// 返回第一行第一列的值
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="values">参数</param>
		/// <returns>返回第一行第一列的值</returns>
        public static int GetScalar(string sql, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				SqlCommand cmd = new SqlCommand(sql, con);
				if (values != null)
                {
                    cmd.Parameters.AddRange(values);
				}
				con.Open();
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		#endregion

		#region 执返回第一行第一列的值(String)
		/// <summary>
		/// 返回第一行第一列的值(String)
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="values">参数</param>
		/// <returns>返回第一行第一列的值</returns>
        public static string GetStringScalar(string sql, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				SqlCommand cmd = new SqlCommand(sql, con);
				if (values != null)
                {
                    cmd.Parameters.AddRange(values);
				}
				con.Open();
				return cmd.ExecuteScalar().ToString();
			}
		}
        #endregion


        #region 执返回第一行第一列的值(String)
        /// <summary>
        /// 返回第一行第一列的值(String)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数</param>
        /// <returns>返回第一行第一列的值</returns>
        public static int GetIntChangeRow(string sql, params SqlParameter[] values)
        {
            using (SqlConnection con = getCon())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (values != null)
                {
                    cmd.Parameters.AddRange(values);
                }
                con.Open();
                return Convert.ToInt32(cmd.ExecuteNonQuery());
            }
        }
        #endregion


        #region 返回DataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数</param>
        /// <returns>返回一个DataTable</returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				DataSet ds = new DataSet();
				SqlCommand cmd = new SqlCommand(sql, con);
				if (values != null)
                {
                    cmd.Parameters.AddRange(values);
				}
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				return ds.Tables[0];
			}
		}
		#endregion

		#region 返回DataRow
		/// <summary>
		/// 返回DataRow
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="values">参数</param>
		/// <returns>返回一个DataRow</returns>
        public static DataRow GetDataRow(string sql, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				DataSet ds = new DataSet();
				SqlCommand cmd = new SqlCommand(sql, con);
				if (values != null)
                {
                    cmd.Parameters.AddRange(values);
				}
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				if (ds.Tables[0].Rows.Count > 0)
				{
					return ds.Tables[0].Rows[0];
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

		#region 执行存储过程
		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="procName">存储过程名</param>
		/// <param name="values">存储过程中参数</param>
		/// <returns>执行成功的行数</returns>
        public static int ExecuteProc(string procName, params SqlParameter[] values)
		{
			using (SqlConnection con = getCon())
			{
				SqlCommand cmd = new SqlCommand(procName, con);
				cmd.CommandType = CommandType.StoredProcedure;
				if (values != null)
                {
                    cmd.Parameters.AddRange(values);
				}
				con.Open();
				return cmd.ExecuteNonQuery();
			}
		}
		#endregion

		#region 执行事务
		/// <summary>
		/// 执行事务
		/// </summary>
		/// <param name="sql">一组SQL语句</param>
		/// <param name="values">参数</param>
		/// <returns>执行成功的行数</returns>
        public static bool ExecuteTranscation(string sql, params SqlParameter[] values)
		{
			SqlTransaction tran = null;
			try
			{
				using (SqlConnection con = getCon())
				{
					con.Open();
					tran = con.BeginTransaction();
					SqlCommand cmd = new SqlCommand(sql, con);
					if (values != null)
                    {
                        cmd.Parameters.AddRange(values);
					}
					cmd.Transaction = tran;
					cmd.ExecuteNonQuery();
					tran.Commit();
					return true;
				}
			}
			catch
			{
				tran.Rollback();
				return false;
			}
		}
		#endregion
	}
}
