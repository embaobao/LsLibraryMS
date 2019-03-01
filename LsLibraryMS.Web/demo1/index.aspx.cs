using LsLibraryMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LsLibraryMS.Web.demo1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BookInfoManager biManager = new BookInfoManager();
            this.Repeater1.DataSource = biManager.GetIndex(10);
            this.Repeater1.DataBind();


        }
    }
}