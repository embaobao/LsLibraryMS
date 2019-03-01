using LsLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMS.BLL
{
    public class BookInfoManager
    {
        BookInfoService biService = new BookInfoService();
        public List<BookInfo> GetIndex()
        {
            return biService.GetSearch("", null, 10, "[borrowSum] desc");
        }

        public int GetSearchCount(BookInfo bookInfo)
        {

            StringBuilder sql_condition = new StringBuilder();
            Dictionary<string, string> values = new Dictionary<string, string>();

            //图书类型的  筛选
            if (bookInfo.Book_Type.typeID > 0)
            {
                sql_condition.Append(" and bookType = @bookType ");
                values.Add("@bookType", bookInfo.Book_Type.typeID.ToString());
            }

            //书名 的 筛选（模糊）
            if (!string.IsNullOrEmpty(bookInfo.BookName))
            {
                sql_condition.Append(" and bookName like '%' + @bookName + '%' ");
                values.Add("@bookName", bookInfo.BookName);
            }

            return biService.GetRecordCnt(sql_condition.ToString(), values);
        }

        public List<BookInfo> GetPage(BookInfo bookInfo, int pageSize, int pageIndex)
        {
            StringBuilder sql_condition = new StringBuilder();
            Dictionary<string, string> values = new Dictionary<string, string>();

            //根据图书类别 筛选
            if (bookInfo.Book_Type.typeID > 0)
            {
                sql_condition.Append(" and bookType = @bookType ");
                values.Add("@bookType", bookInfo.Book_Type.typeID.ToString());
            }
            //判断 图书名称 的 筛选, （模糊）
            if (!string.IsNullOrEmpty(bookInfo.BookName))
            {
                sql_condition.Append(" and bookName like '%' + @bookName + '%' ");
                values.Add("@bookName", bookInfo.BookName);
            }
            if (!string.IsNullOrEmpty(bookInfo.BookBarCode))
            {
                sql_condition.Append(" and bookBarCode like  @BookBarCode + '%' ");
                values.Add("@BookBarCode", bookInfo.BookBarCode);
            }

            //集合中的  booktype 与 bookcase 仅有 主键id
            List<BookInfo> list = biService.GetPage(sql_condition.ToString(), values, pageSize, pageIndex);

            return list;

        }

        





        public List<BookInfo> GetIndex(int Top)
        {
            return biService.GetSearch("", null, Top, "[borrowSum] desc");
        }
        public List<BookInfo> GetSearch(BookInfo bookInfo)
        {

            StringBuilder sql_condition = new StringBuilder();
            Dictionary<string, string> values = new Dictionary<string, string>();

            //图书类型的  筛选
            if (bookInfo.Book_Type.typeID > 0)
            {
                sql_condition.Append(" and bookType = @bookType ");
                values.Add("@bookType", bookInfo.Book_Type.typeID.ToString());
            }

            //书名 的 筛选（模糊）
            if (!string.IsNullOrEmpty(bookInfo.BookName))
            {
                sql_condition.Append(" and bookName like '%' + @bookName + '%' ");
                values.Add("@bookName", bookInfo.BookName);
            }

            return biService.GetSearch(sql_condition.ToString(), values, -1, "");
        }


        public static  bool UpbookInfo(BookInfo bookInfo)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();
          

            sql.Append(@"UPDATE [dbo].[tb_bookInfo] SET
            [bookName] = @bookName ,
            [bookType] = @bookType,
            [bookcase] = @bookCase,
            [bookConcern] = @bookConcern,
            [author] = @bookAuthor,
            [price] = @bookPrice,
            [borrowSum] = @readNum
             WHERE[bookBarCode] = @bookBarCode ");

            values.Add("@bookName", bookInfo.BookName);
            values.Add("@bookType",bookInfo.Book_Type.typeID.ToString());
            values.Add("@bookCase", bookInfo.Book_Case.bookcaseID.ToString());
            values.Add("@bookConcern", bookInfo.BookConcern);
            values.Add("@bookAuthor", bookInfo.Author);
            values.Add("@bookPrice", bookInfo.Price.ToString());
            values.Add("@readNum", bookInfo.BorrowSum.ToString());
            values.Add("@bookBarCode", bookInfo.BookBarCode);
            return BookInfoService.UpBookInfo(sql.ToString(),values);
        }
        public static bool AddbookInfo(BookInfo bookInfo)
        {
            StringBuilder sql = new StringBuilder();

            

            Dictionary<string, string> values = new Dictionary<string, string>();


            sql.Append(@"INSERT INTO [dbo].[tb_bookInfo]
           ([bookBarCode]
           ,[bookName]
           ,[bookType]
           ,[bookcase]
           ,[bookConcern]
           ,[author]
           ,[price]
           ,[borrowSum])
     VALUES
           (@bookBarCode
           ,@bookName
           ,@bookType
           ,@bookCase
           ,@bookConcern
           ,@bookAuthor
           ,@bookPrice
           ,@readNum)");

            values.Add("@bookName", bookInfo.BookName);
            values.Add("@bookType", bookInfo.Book_Type.typeID.ToString());
            values.Add("@bookCase", bookInfo.Book_Case.bookcaseID.ToString());
            values.Add("@bookConcern", bookInfo.BookConcern);
            values.Add("@bookAuthor", bookInfo.Author);
            values.Add("@bookPrice", bookInfo.Price.ToString());
            values.Add("@readNum", bookInfo.BorrowSum.ToString());
            values.Add("@bookBarCode", bookInfo.BookBarCode);
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        public static bool DeletebookInfo(BookInfo bookInfo)
        {
            StringBuilder sql = new StringBuilder();

            Dictionary<string, string> values = new Dictionary<string, string>();

            sql.Append(@"DELETE FROM [dbo].[tb_bookInfo]
                         WHERE [bookBarCode]=@bookBarCode");
            values.Add("@bookBarCode", bookInfo.BookBarCode);
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }


    }
}
