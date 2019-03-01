using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
    public class LibraryInfo
    {

        public LibraryInfo()
        {
            this.id = 1;
            this.libraryName = "";
            this.curator = "";
            this.tel = "";
            this.address = "";
            this.email = "";
            this.net = "";
            this.upbuildTime = "";
            this.remark = "";
        }
        public int id { get; set; }
        public string libraryName { get; set; }
        public string curator { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string net { get; set; }
        public string upbuildTime { get; set; }
        public string remark { get; set; }



    }
}
