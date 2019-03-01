using LsLibraryMS.BLL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LsLibraryMS.Web.demo1
{
    public partial class BookTypeMangerPage : System.Web.UI.Page
    {
        BookInfoManager biManager = new BookInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                try
                {
                    //BookType bt = new BookType();
                    //bt.borrowDay = 12;
                    //bt.typeID = 18;
                    //bt.typeName = "电子机械";
                    //Response.Write(BookCatologManger.DeletebookType(bt,bt.borrowDay).ToString());
                }
                catch (Exception)
                {

                    throw;
                }
            }
            this.AspNetPager1.RecordCount = GetBookType().Count();
        }



        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            this.Repeater1.DataSource = GetBookType();
            this.Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetPager1_PageChanged(null, null);
        }

       
       
      
        [System.Web.Services.WebMethod]
        public static List<BookCase> GetBookCase()
        {

            return BookCatologManger.GetBClist();
        }

        [System.Web.Services.WebMethod]
        public static List<BookType> GetBookType()
        {

            return BookCatologManger.GetBTlist();
        }

        [System.Web.Services.WebMethod]
        public static bool UpBookType(string jsonStr)
        {
            BookType bt = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bt = js.Deserialize<BookType>(jsonStr);
                return bt != null ? BookCatologManger.UpbookType(bt) : false;
                //return bt;
            }
            catch (Exception)
            {
                return false;
                //return bt;
            }
        }



        [System.Web.Services.WebMethod]
        public static bool AddBookType(string jsonStr)
        {
            BookType bt = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bt = js.Deserialize<BookType>(jsonStr);
                return bt != null ? BookCatologManger.AddbookType(bt) : false;
                //return bt;
            }
            catch (Exception)
            {
               
                return false;
             
            }
          
        }

        [System.Web.Services.WebMethod]
        public static bool DeleteBookType(string jsonStr)
        {
            BookType bt = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bt = js.Deserialize<BookType>(jsonStr);
                if (bt.borrowDay > 0)
                {
                    return bt != null ? BookCatologManger.DeletebookType(bt,bt.borrowDay) : false; 
                }
                return bt != null ? BookCatologManger.DeletebookType(bt) : false;
                //return bt;
            }
            catch (Exception)
            {

                return false;

            }

        }



    }
}