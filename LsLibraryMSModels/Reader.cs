using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
    public class Reader
    {
        public Reader()
        {
            this.readerBarCode = "";
            this.readerName = "";
            this.sex = "";
            this.readerType = "";
            this.certificateType = "";
            this.certificate = "";
            this.tel = "";
            this.email = "";
            this.remark = "";
        }

        public string readerBarCode {get;set;}
        public string readerName {get;set;}
        public string sex { get; set; }
        public string readerType { get; set; }
        public string certificateType { get; set; }
        public string certificate { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string remark { get; set; }

    }
}
