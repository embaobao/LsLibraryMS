using LsLibraryMS.BLL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;

namespace LsLibraryMS.Web.demo1
{
    public partial class Search : System.Web.UI.Page
    {
        BookInfoManager biManager = new BookInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
           
          

            //            $("#cbTest").attr("checked", true);  //复选框  选中，    取消  false
            //$("#sltTest").val(3);  //下拉框 根据 选项的value   选中某一项

            //BookInfo b = new BookInfo();
            //b.BookName = "LOVE 3520";
            //BookType bt = new BookType();
            //bt.typeID = 1;
            //b.Book_Type = bt;
            //BookCase bc = new BookCase();
            //bc.bookcaseID = 1;
            //b.Book_Case = bc;
            //b.BookConcern = "上天入地";
            //b.Price = 3520;
            //b.Author = "草鸡无敌";
            //b.BorrowSum = "1110";
            //b.BookBarCode = "1020071219946";
            //Response.Write(BookInfoManager.UpbookInfo(b).ToString());
            if (!IsPostBack)
            {
                Booktype_input.DataValueField = "typeID";
                Booktype_input.DataTextField = "typeName";
                Booktype_input.DataSource = GetBookType();
                Booktype_input.DataBind();
                this.Booktype_input.Items.Insert(0, new ListItem("--请选择图书类型", "0"));
                try
                {
                    //BookInfo b = new BookInfo();
                    //b.BookName = "LOVE xinxin";
                    //BookType bt = new BookType();
                    //bt.typeID = 1;
                    //b.Book_Type = bt;
                    //BookCase bc = new BookCase();
                    //bc.bookcaseID = 1;
                    //b.Book_Case = bc;
                    //b.BookConcern = "上天入地";
                    //b.Price = 3520;
                    //b.Author = "草鸡无敌";
                    //b.BorrowSum = "1110";
                    //Response.Write(BookInfoManager.AddbookInfo(b).ToString());
                    //AddBookInfo("{jsonStr:'{\"Count:\"1\",\"BookBarCode\":\"1212\",\"BookName\":\"322\",\"Book_Type\":{\"typeID\":1,\"typeName\":\"计算机\",\"borrowDay\":0},\"Book_Case\":{\"bookcaseID\":1,\"bookcaseName\":\"右A - 1\"},\"BookConcern\":\"232\",\"Author\":\"232\",\"Price\":\"232\",\"BorrowSum\":\"232\"}'}");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            this.AspNetPager1.RecordCount = biManager.GetSearchCount(new BookInfo());

        }



        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
            BookType bt = new BookType();
            bt.typeID = Convert.ToInt32(Booktype_input.SelectedValue);
            this.Repeater1.DataSource = biManager.GetPage(new BookInfo() { BookName = bookname_input.Value, BookBarCode = bookcode_input.Value, Book_Type = bt  }, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex);
            this.Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetPager1_PageChanged(null, null);
        }

        [System.Web.Services.WebMethod]
        public static bool UpBookInfo(string jsonStr)
        {
            BookInfo bi = null;
            JavaScriptSerializer js = new JavaScriptSerializer();
            bi = js.Deserialize<BookInfo>(jsonStr);//BookInfo bi = null;
                                                   //bi.Book_Case.bookcaseID.ToString() 
                                                   //
            return bi != null ? BookInfoManager.UpbookInfo(bi) : false;
        }
        [System.Web.Services.WebMethod]
        public static bool AddBookInfo(string jsonStr)
        {
            BookInfo bi = null;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                bi = js.Deserialize<BookInfo>(jsonStr);
                return bi != null ? BookInfoManager.AddbookInfo(bi) : false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [System.Web.Services.WebMethod]
        public static bool DeleteBookInfo(string jsonStr)
        {
            BookInfo bi = null;
            JavaScriptSerializer js = new JavaScriptSerializer();
            bi = js.Deserialize<BookInfo>(jsonStr);//BookInfo bi = null;
                                                   //bi.Book_Case.bookcaseID.ToString() 
                                                   // bi != null ? BookInfoManager.AddbookInfo(bi) : false
            return bi != null ? BookInfoManager.DeletebookInfo(bi) : false;
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



    }
}