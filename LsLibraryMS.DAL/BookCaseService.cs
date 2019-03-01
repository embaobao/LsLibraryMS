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
   public class BookCaseService
    {

        public BookCaseService()
        {
          
         


        }

        public  BookCase GetById(int caseId)
        {

            BookCase bc = new BookCase();
          
            try
            {
                DataRow dr = DBHelper.GetDataRow("SELECT [bookcaseID] ,[bookcaseName] FROM [dbo].[tb_bookcase] where [bookcaseID]=@id;", new SqlParameter("@id", caseId));
                bc.bookcaseID = dr["bookcaseID"] == DBNull.Value ? -1 : (int)dr["bookcaseID"];
                bc.bookcaseName = dr["bookcaseName"] == DBNull.Value ? string.Empty : dr["bookcaseName"].ToString().Trim();
            }
            catch (Exception)
            {

                bc.bookcaseID = -1;
                bc.bookcaseName = "";

            }

            return bc;

        }



        public static List<BookCase> GetBookCaseList()
        {
            List<BookCase> list = new List<BookCase>();

            BookCase bc = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [bookcaseID]
                                                         ,[bookcaseName]
                                                  FROM [dbo].[tb_bookcase]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        bc = new BookCase();
                        bc.bookcaseID = dr["bookcaseID"] == DBNull.Value ? -1 : (int)dr["bookcaseID"];
                        bc.bookcaseName = dr["bookcaseName"] == DBNull.Value ? string.Empty : dr["bookcaseName"].ToString().Trim();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        list.Add(bc);
                    }


                }
            }


            return list;

        }
    }
}
