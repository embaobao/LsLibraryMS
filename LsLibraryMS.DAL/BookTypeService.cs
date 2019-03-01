using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LSLibraryMS.DAL;
using System.Data.SqlClient;
using System.Data;

namespace LsLibraryMS.DAL
{
    public class BookTypeService
    {

        public BookType GetById(int typeId)
        {

            BookType bt = new BookType();
          
            try
            {
                DataRow dr = DBHelper.GetDataRow("SELECT [typeID],[typeName],[borrowDay] FROM [dbo].[tb_bookType] WHERE typeID=@id;", new SqlParameter("@id", typeId));
                bt.typeID = dr["typeID"] == DBNull.Value ? -1 : (int)dr["typeID"];
                bt.typeName = dr["typeName"] == DBNull.Value ? string.Empty : dr["typeName"].ToString().Trim();
                bt.borrowDay = dr["borrowDay"] == DBNull.Value ? -1 : (int)dr["borrowDay"];
            }
            catch
            {
                bt.typeID = -1;
                bt.typeName = "";
                bt.borrowDay = 0;
                return bt;
            }

            return bt;

        }

        public static List<BookType> GetBookTypeList()
        {
            List<BookType> list = new List<BookType>();

            BookType bt = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [typeID]
                                              ,[typeName]
                                              ,[borrowDay]
                                               FROM[dbo].[tb_bookType]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        bt = new BookType();
                        bt.typeID = dr["typeID"] == DBNull.Value ? -1 : (int)dr["typeID"];
                        bt.typeName = dr["typeName"] == DBNull.Value ? string.Empty : dr["typeName"].ToString().Trim();
                        bt.borrowDay = dr["borrowDay"] == DBNull.Value ? -1 : (int)dr["borrowDay"];
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        list.Add(bt);
                    }


                }
            }


            return list;

        }






    }
}
