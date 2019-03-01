using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LsLibraryMS.DAL;
using LsLibraryMSModels;

namespace LsLibraryMS.BLL
{
    public class BookCatologManger
    {
        /// <summary>
        /// 获取图书类型对象的列表
        /// </summary>
        /// <returns> List<BookType> </returns>
        public static List<BookType> GetBTlist()
        {

            return BookTypeService.GetBookTypeList();
        }
        /// <summary>
        /// 获取图书书架位置信息 类列表
        /// </summary>
        /// <returns>List<BookCase></returns>
        public static List<BookCase> GetBClist()
        {

            return BookCaseService.GetBookCaseList();
        }



        //图书类型管理操作

        /// <summary>
        /// 修改图书类型对象
        /// </summary>
        /// <param name="bookType">修改类型对象</param>
        /// <returns>修改结果 bool</returns>
        public static bool UpbookType(BookType bookType)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();


            sql.Append(@"UPDATE [dbo].[tb_bookType]
                           SET [typeName] = @booktypeName
                              ,[borrowDay] =@readday
                               WHERE [typeID]=@typeid");
            values.Add("@booktypeName", bookType.typeName);
            values.Add("@readday", bookType.borrowDay.ToString());
            values.Add("@typeid", bookType.typeID.ToString());

            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }

        /// <summary>
        /// 删除的图书类型对象
        /// </summary>
        /// <param name="bookType">所修改的图书对象</param>
        /// <param name="ExchangebookType">修改图书要转换的类型对象</param>
        /// <returns></returns>
        public static bool DeletebookType(BookType bookType)
        {
            StringBuilder sql = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {
                
                    sql.Append(@"DELETE FROM [dbo].[tb_bookType]
                         WHERE [typeID]=@typeid");
                    values.Add("@typeid", bookType.typeID.ToString());
           
            }
            catch (Exception)
            {

                throw;
            }

            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        public static bool DeletebookType(BookType bookType,int ExtypeID)
        {
            StringBuilder sql = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {

                ExcbookType(bookType.typeID,ExtypeID);
                sql.Append(@"DELETE FROM [dbo].[tb_bookType]
                         WHERE [typeID]=@typeid");
                values.Add("@typeid", bookType.typeID.ToString());

            }
            catch (Exception)
            {

                throw;
            }

            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        /// <summary>
        /// 修改某种类图书的种类
        /// </summary>
        /// <param name="ObookType">要修改的种类</param>
        /// <param name="NType">修改成的种类</param>
        /// <returns>= 修改的结果bool</returns>
        public static bool ExcbookType(int OTypeid, int NTypeid)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();


            sql.Append(@"UPDATE [dbo].[tb_bookInfo]
   SET  [bookType] =@ntypeid
 WHERE  [bookType] =@otypeid");
            values.Add("@otypeid", OTypeid.ToString());
            values.Add("@ntypeid", NTypeid.ToString());
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }


        public static bool AddbookType(BookType bookType)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();


            sql.Append(@"INSERT INTO [dbo].[tb_bookType]
                           ([typeName]
                           ,[borrowDay])
                            VALUES
                           (@booktypeName ,@readday)");
            values.Add("@booktypeName", bookType.typeName);
            values.Add("@readday", bookType.borrowDay.ToString());

            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }


        //图书的位置对象操作



        /// <summary>
        /// 修改图书位置对象
        /// </summary>
        /// <param name="bookType">修改位置对象</param>
        /// <returns>修改结果 bool</returns>
        public static bool UpbookCase(BookCase bookCase)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();
            sql.Append(@"UPDATE [dbo].[tb_bookcase]
                           SET [bookcaseName] =@name
                         WHERE [bookcaseID]=@id");
            values.Add("@name", bookCase.bookcaseName);
            values.Add("@id", bookCase.bookcaseID.ToString());
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        /// <summary>
        /// 增加图书位置对象
        /// </summary>
        /// <param name="bookType">位置对象</param>
        /// <returns>修改结果 bool</returns>
        public static bool AddbookCase(BookCase bookCase)
        {
            StringBuilder sql = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();
            sql.Append(@"INSERT INTO [dbo].[tb_bookcase]
                               ([bookcaseName])
                                VALUES
                               (@name)");
            values.Add("@name", bookCase.bookcaseName);
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        /// <summary>
        /// 删除图书位置对象
        /// </summary>
        /// <param name="bookType">位置对象</param>
        /// <returns>修改结果 bool</returns>
        public static bool DeletebookCase(BookCase bookCase)
        {
            StringBuilder sql = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();
            sql.Append(@"DELETE FROM [dbo].[tb_bookcase]
                                WHERE [bookcaseID]=@id");
            values.Add("@id", bookCase.bookcaseID.ToString());
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }


     


    }
}
