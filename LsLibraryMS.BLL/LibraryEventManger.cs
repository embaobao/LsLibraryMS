using LsLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMS.BLL
{
    public class LibraryEventManger
    {
        public LibraryEventManger()
        {
        }
        //获取图书馆信息
        public LibraryInfo GetLibraryInfo()
        {

            return new LibraryService().GetLibraryInfo();

        }
        //更新图书馆信息
        public  bool SetLibraryInfo(LibraryInfo l)
        {
            StringBuilder sql = new StringBuilder();


            Dictionary<string, string> values = new Dictionary<string, string>();




            sql.Append(@"UPDATE [dbo].[tb_library]
                       SET [libraryName] = @libraryName
                          ,[curator]=@curator
                          ,[tel]=@tel
                          ,[address]=@address
                          ,[email]=@email
                          ,[net] =@net
                          ,[upbuildTime]=@upbuildTime
                          ,[remark]=@remark");

            values.Add("@libraryName", l.libraryName);
            values.Add("@curator", l.curator);
            values.Add("@tel", l.tel);
            values.Add("@address", l.address);
            values.Add("@email", l.email);
            values.Add("@net", l.net);
            values.Add("@upbuildTime", l.upbuildTime);
            values.Add("@remark", l.remark);
            return BookInfoService.UpBookInfo(sql.ToString(), values);
        }
        //获取读者
        public List<Reader> GetReaderList()
        {

            return new ReaderService().GetReaderInfoList();
        }
        //获取读者类型
        public List<ReaderType> GetReaderTypeList()
        {

            return new ReaderService().GetReaderTypeList();
        }

        //图书管理员
        public List<Adimistrator> GetAdimistratorList()
        {
            return new AdiministratorService().GetAdimistratorList();
        }
        //图书借还信息

        public List<BorrowBookInfo> GetBookBorrwList()
        {
            return new BookBorrwService().GetBorrowBookInfoList();
        }
    }
}
