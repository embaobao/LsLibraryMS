using LsLibraryMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LsLibraryMS.Web.demo1
{

    public partial class ReaderTypeMangerPage : System.Web.UI.Page
    {
        LibraryEventManger lim = new LibraryEventManger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            this.Repeater1.DataSource = lim.GetReaderTypeList();
            this.Repeater1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetPager1_PageChanged(null, null);
        }
    }
}