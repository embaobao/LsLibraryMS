using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LsLibraryMSModels;
using LSLibraryMS.DAL;
using System.Data;

namespace LsLibraryMS.DAL
{
    public class BookInfoService
    {





        /// <summary>
        /// 根据条件返回总记录数
        /// </summary>
        /// <param name="sql_condition"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int GetRecordCnt(string sql_condition, Dictionary<string, string> values)
        {
            string sql = "select count(1) from [tb_bookInfo] where 1=1 " + sql_condition;

            List<SqlParameter> valuesParam = new List<SqlParameter>();
            if (values != null)
            {
                foreach (var item in values)
                {
                    valuesParam.Add(new SqlParameter(item.Key, item.Value));
                }
            }
            return DBHelper.GetScalar(sql, valuesParam.ToArray());
        }


        public List<BookInfo> GetPage(string sql_condition, Dictionary<string, string> values, int pageSize, int pageIndex)
        {
            string sql = string.Format(@" select b.* from(
                                        SELECT ROW_NUMBER() OVER(ORDER BY[bookBarCode]) r
                                                ,[bookBarCode]
                                              ,[bookName]
                                              ,[bookType]
                                              ,[bookcase]
                                              ,[bookConcern]
                                              ,[author]
                                              ,[price]
                                              ,[borrowSum]
                                          FROM[dbo].[tb_bookInfo] where 1=1 {0} ) b
                                     where b.r between @pageSize * (@pageIndex - 1) + 1  and @pageSize *@pageIndex ", sql_condition);

            List<SqlParameter> valuesParam = new List<SqlParameter>();
            if (values != null)
            {
                foreach (var item in values)
                {
                    valuesParam.Add(new SqlParameter(item.Key, item.Value));
                }
            }
            valuesParam.Add(new SqlParameter("@pageSize", pageSize));
            valuesParam.Add(new SqlParameter("@pageIndex", pageIndex));

            return GetListBySql(sql, valuesParam.ToArray());
        }



        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <param name="sql_condition">sql语句，主要写条件</param>
        /// <param name="values">sql语句里所用到参数，在底层以SqlParameter封装</param>
        /// <param name="topNum">返回前几行数据，-1为返回所有数据</param>
        /// <param name="order">排序字段，已经写好order by关键字了</param>
        /// <returns>S_City数据集合</returns>
        public List<BookInfo> GetSearch(string sql_condition, Dictionary<string, string> values, int topNum, string order)
        {
            string sql = "select";
            if (topNum > 0)
            {
                sql += " top " + topNum;
            }
            sql += " * from [tb_bookInfo] where 1=1 " + sql_condition;
            if (!string.IsNullOrEmpty(order))
            {
                sql += " order by " + order;
            }
            List<SqlParameter> valuesParam = new List<SqlParameter>();
            if (values != null)
            {
                foreach (var item in values)
                {
                    valuesParam.Add(new SqlParameter(item.Key, item.Value));
                }
            }


            return GetListBySql(sql, valuesParam.ToArray());
        }


        /// <summary>
        /// 私有方法，查询多条数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="values">参数值(key,value)</param>
        /// <returns>S_City数据集合</returns>
        private List<BookInfo> GetListBySql(string sql, params SqlParameter[] values)
        {
            DataTable dt = DBHelper.GetDataTable(sql, values);
            List<BookInfo> list = new List<BookInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetModel(dr));
                }
            }


            list = Tra_BokLAllId_ToClass(list);

            return list;
        }

        private BookInfo GetModel(DataRow dr)
        {
            BookInfo book = new BookInfo();
            book.BookBarCode = dr["bookBarCode"] == DBNull.Value ? string.Empty : dr["bookBarCode"].ToString().Trim();
            book.BookName = dr["bookName"] == DBNull.Value ? string.Empty : dr["bookName"].ToString().Trim();
            book.Book_Type.typeID = dr["bookType"] == DBNull.Value ? -1 : (int)dr["bookType"];
            book.Book_Case.bookcaseID = dr["bookcase"] == DBNull.Value ? -1 : (int)dr["bookcase"];
            book.BookConcern = dr["bookConcern"] == DBNull.Value ? string.Empty : dr["bookConcern"].ToString().Trim();
            book.Author = dr["author"] == DBNull.Value ? string.Empty : dr["author"].ToString().Trim();
            book.Price = dr["price"] == DBNull.Value ? -1 : (decimal)dr["price"];
            book.BorrowSum = dr["borrowSum"] == DBNull.Value ? string.Empty : dr["borrowSum"].ToString().Trim();
            return book;
        }
        private List<BookInfo> Tra_BokLCaseId_ToClass(List<BookInfo> list)
        {

            BookCaseService bcService = new BookCaseService();
            //遍历集合，根据 booktype 与 bookcase 的 主键id 去 获取 他们的对象
            foreach (BookInfo b in list)
            {
                b.Book_Case = bcService.GetById(b.Book_Case.bookcaseID);
            }

            return list;
        }
        private List<BookInfo> Tra_BokLTypeId_ToClass(List<BookInfo> list)
        {
            BookTypeService btService = new BookTypeService();

            //遍历集合，根据 booktype 与 bookcase 的 主键id 去 获取 他们的对象
            foreach (BookInfo b in list)
            {
                b.Book_Type = btService.GetById(b.Book_Type.typeID);

            }

            return list;
        }
        private List<BookInfo> Tra_BokLAllId_ToClass(List<BookInfo> list)
        {
            BookTypeService btService = new BookTypeService();
            BookCaseService bcService = new BookCaseService();
            //遍历集合，根据 booktype 与 bookcase 的 主键id 去 获取 他们的对象
            foreach (BookInfo b in list)
            {
                b.Book_Type = btService.GetById(b.Book_Type.typeID);
                b.Book_Case = bcService.GetById(b.Book_Case.bookcaseID);
            }

            return list;
        }

        public static bool UpBookInfo(string sql, Dictionary<string, string> values)
        {
            int a = -1;
            List<SqlParameter> valuesParam = new List<SqlParameter>();
            if (values != null)
            {
                foreach (var item in values)
                {
                    valuesParam.Add(new SqlParameter(item.Key, item.Value));
                }
            }


            try
            {
                a = DBHelper.GetIntChangeRow(sql, valuesParam.ToArray());
            }
            catch (Exception)
            {
                throw;
             //   return false;
                
            }

            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        








    }

}
