using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LsLibraryMS.BLL;
using LsLibraryMSModels;

namespace LsLibraryMS.Web.demo1
{
    public partial class LibraryInfoSet : System.Web.UI.Page
    {
        LibraryEventManger lm = new LibraryEventManger();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                LibraryInfo l = lm.GetLibraryInfo();
                library_name.InnerText = l.libraryName;
                library_time.InnerText = l.upbuildTime;
                library_txt.InnerText = l.remark;
                library_address.InnerText = l.address;
                library_emil.InnerText = l.email;
                library_phone.InnerText = l.tel;
                library_website.InnerText = l.net;
                library_man.InnerText = l.curator;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LibraryInfo l = new LibraryInfo();
            l.libraryName = l_name.Value;
            l.upbuildTime = l_time.Value;
            l.remark = l_txt.Value;
            l.address =l_address.Value;
            l.email= l_emil.Value;
            l.tel = l_phonenum.Value;
            l.net = l_web.Value;
            l.curator= l_admin.Value;
            if (lm.SetLibraryInfo(l))
            {
                Response.Write("<script>alert('保存成功')</script>");
                Response.Redirect("/demo1/LibraryInfoSet.aspx");
            }
            else
            {
                Response.Write("<script>alert('保存失败')</script>");
            }
            
        }
    }
}