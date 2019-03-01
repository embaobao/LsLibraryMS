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
    public partial class BookCaseMangerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    
                    //Response.Write(BookCatologManger.DeletebookType(bt,bt.borrowDay).ToString());
                }
                catch (Exception)
                {

                    throw;
                }
            }
            this.AspNetPager1.RecordCount = GetBookCase().Count();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            this.Repeater1.DataSource = GetBookCase();
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
        public static bool UpBookCase(string jsonStr)
        {
            BookCase bc = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bc = js.Deserialize<BookCase>(jsonStr);
                return bc != null ? BookCatologManger.UpbookCase(bc) : false;
               // return bc;
            }
            catch (Exception)
            {
                return false;
               // return bc;
            }
        }
        [System.Web.Services.WebMethod]
        public static bool DeleteBookCase(string jsonStr)
        {
            BookCase bc = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bc = js.Deserialize<BookCase>(jsonStr);
                return bc != null ? BookCatologManger.DeletebookCase(bc) : false;
                //return bc;
            }
            catch (Exception)
            {
                 return false;
               // return bc;
            }
           

        }
        [System.Web.Services.WebMethod]
        public static bool AddBookCase(string jsonStr)
        {
            BookCase bc = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bc = js.Deserialize<BookCase>(jsonStr);
                 return bc != null ? BookCatologManger.AddbookCase(bc) : false;
                //return bc;
            }
            catch (Exception)
            {
                return false;
               // return bc;
            }
        }

    }
}