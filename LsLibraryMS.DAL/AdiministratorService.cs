using LSLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LsLibraryMS.DAL
{
    public class AdiministratorService
    {


        private bool isTrue(int i)
        {
            return i == 1 ? true : false; 
        }

        public List<Adimistrator> GetAdimistratorList()
        {

            List<Adimistrator> list = new List<Adimistrator>();

            Adimistrator admin = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [userName]
                                                          ,[systemSet]
                                                          ,[readerManage]
                                                          ,[bookManage]
                                                          ,[bookBorrow]
                                                          ,[systemSearch]
                                                      FROM [dbo].[tb_admSet]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        admin = new Adimistrator();
                        admin.userName =  dr["userName"] == DBNull.Value ? string.Empty : dr["userName"].ToString().Trim();
                        admin.systemSet = dr["systemSet"] == DBNull.Value ? false :isTrue( Convert.ToInt32(dr["systemSet"]) );
                        admin.readerManage = dr["readerManage"] == DBNull.Value ? false : isTrue(Convert.ToInt32(dr["readerManage"])) ;
                        admin.bookManage = dr["bookManage"] == DBNull.Value ? false : isTrue(Convert.ToInt32(dr["bookManage"]));
                        admin.bookBorrow= dr["bookBorrow"] == DBNull.Value ? false : isTrue(Convert.ToInt32(dr["bookBorrow"]));
                        admin.systemSearch = dr["systemSearch"] == DBNull.Value ? false : isTrue(Convert.ToInt32(dr["systemSearch"])) ;
                    
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        list.Add(admin);
                    }


                }
            }


            return list;
        }

    }
}
