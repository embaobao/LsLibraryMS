using LsLibraryMS.BLL;
using LsLibraryMSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LsLibraryMS.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookInfoManager biManager = new BookInfoManager();
            this.Repeater1.DataSource = biManager.GetIndex(-1);
            this.Repeater1.DataBind();
        }
    }
}