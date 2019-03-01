using LSLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LsLibraryMS.DAL
{
    public class LibraryService
    {


        public LibraryService()
        {
        }
        //图书馆信息操作
        public LibraryInfo GetLibraryInfo()
        {

            LibraryInfo L = new LibraryInfo();

            try
            {
                DataRow dr = DBHelper.GetDataRow(@"SELECT [libraryName]
                                                  ,[curator]
                                                  ,[tel]
                                                  ,[address]
                                                  ,[email]
                                                  ,[net]
                                                  ,[upbuildTime]
                                                  ,[remark]
                                              FROM[dbo].[tb_library]");

                L.libraryName = dr["libraryName"] == DBNull.Value ? string.Empty : dr["libraryName"].ToString().Trim();
                L.curator = dr["curator"] == DBNull.Value ? string.Empty : dr["curator"].ToString().Trim();
                L.tel = dr["tel"] == DBNull.Value ? string.Empty : dr["tel"].ToString().Trim();
                L.address = dr["address"] == DBNull.Value ? string.Empty : dr["address"].ToString().Trim();
                L.email = dr["email"] == DBNull.Value ? string.Empty : dr["email"].ToString().Trim();
                L.net = dr["net"] == DBNull.Value ? string.Empty : dr["net"].ToString().Trim();
                L.upbuildTime = dr["upbuildTime"] == DBNull.Value ? string.Empty : dr["upbuildTime"].ToString().Trim();
                L.remark = dr["remark"] == DBNull.Value ? string.Empty : dr["remark"].ToString().Trim();
            }
            catch (Exception)
            {



            }

            return L;

        }




    }
}
