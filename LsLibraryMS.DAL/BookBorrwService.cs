using LSLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LsLibraryMS.DAL
{
   public class BookBorrwService
    {
        private bool isTrue(int i)
        {
            return i == 1 ? true : false;
        }

        public  List<BorrowBookInfo> GetBorrowBookInfoList()
        {
            List<BorrowBookInfo> list = new List<BorrowBookInfo>();

            BorrowBookInfo b = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [bookBarcode]
                                                                              ,[bookName]
                                                                              ,[borrowTime]
                                                                              ,[returnTime]
                                                                              ,[readerBarCode]
                                                                              ,[readerName]
                                                                              ,[isReturn]
                                                                          FROM [dbo].[tb_bookBorrow]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        b = new BorrowBookInfo();
                        b.bookBarcode = dr["bookBarcode"] == DBNull.Value ? string.Empty : dr["bookBarcode"].ToString().Trim();
                        b.bookName = dr["bookName"] == DBNull.Value ? string.Empty : dr["bookName"].ToString().Trim();
                        b.borrowTime = dr["borrowTime"] == DBNull.Value ? string.Empty : dr["borrowTime"].ToString().Trim();
                        b.returnTime = dr["returnTime"] == DBNull.Value ? string.Empty : dr["returnTime"].ToString().Trim();
                        b.readerBarCode = dr["readerBarCode"] == DBNull.Value ? string.Empty : dr["readerBarCode"].ToString().Trim();
                        b.readerName = dr["readerName"] == DBNull.Value ? string.Empty : dr["readerName"].ToString().Trim();
                        b.isReturn = dr["isReturn"] == DBNull.Value ? false : isTrue(Convert.ToInt32(dr["isReturn"]));
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        list.Add(b);
                    }


                }
            }


            return list;

        }

    }
}
