using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
   public class Adimistrator
    {
        public Adimistrator()
        {
            this.userName = "";
            this.systemSet = false;
            this.readerManage = false;
            this.bookManage = false;
            this.bookBorrow = false;
            this.systemSearch = false;
        }
        public string userName { get; set; }
        public bool systemSet { get; set; }
        public bool readerManage { get; set; }
        public bool bookManage { get; set; }
        public bool bookBorrow { get; set; }
        public bool systemSearch { get; set; }
    }
}
