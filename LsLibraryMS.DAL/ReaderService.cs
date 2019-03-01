using LSLibraryMS.DAL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LsLibraryMS.DAL
{
    public class ReaderService
    {

        public List<Reader> GetReaderInfoList()
        {
            List<Reader> readerList = new List<Reader>();



            Reader reader = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [readerBarCode]
                                                          ,[readerName]
                                                          ,[sex]
                                                          ,[readerType]
                                                          ,[certificateType]
                                                          ,[certificate]
                                                          ,[tel]
                                                          ,[email]
                                                          ,[remark]
                                                      FROM [dbo].[tb_readerInfo]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        reader = new Reader();
                        reader.readerBarCode = dr["readerBarCode"] == DBNull.Value ? string.Empty : dr["readerBarCode"].ToString().Trim();
                        reader.readerName = dr["readerName"] == DBNull.Value ? string.Empty : dr["readerName"].ToString().Trim();
                        reader.sex = dr["sex"] == DBNull.Value ? string.Empty : dr["sex"].ToString().Trim();
                        reader.readerType = dr["readerType"] == DBNull.Value ? string.Empty : dr["readerType"].ToString().Trim();
                        reader.certificateType = dr["certificateType"] == DBNull.Value ? string.Empty : dr["certificateType"].ToString().Trim();
                        reader.certificate = dr["certificate"] == DBNull.Value ? string.Empty : dr["certificate"].ToString().Trim();
                        reader.tel = dr["tel"] == DBNull.Value ? string.Empty : dr["tel"].ToString().Trim();
                        reader.email = dr["email"] == DBNull.Value ? string.Empty : dr["email"].ToString().Trim();
                        reader.remark = dr["remark"] == DBNull.Value ? string.Empty : dr["remark"].ToString().Trim();
                      
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        readerList.Add(reader);
                    }


                }
            }


            return readerList;


        }

        public List<ReaderType> GetReaderTypeList()
        {
            List<ReaderType> readerList = new List<ReaderType>();



            ReaderType reader = null;
            DataTable dt = DBHelper.GetDataTable(@"SELECT [id]
                                                          ,[type]
                                                          ,[num]
                                                      FROM [dbo].[tb_readerType]");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        reader = new ReaderType();
                        reader.id = dr["id"] == DBNull.Value ? -1 : (int)dr["id"];
                        reader.type =dr["type"] == DBNull.Value ? string.Empty : dr["type"].ToString().Trim();
                        reader.num = dr["num"] == DBNull.Value ? string.Empty : dr["num"].ToString().Trim();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        readerList.Add(reader);
                    }


                }
            }


            return readerList;


        }

    }
}
