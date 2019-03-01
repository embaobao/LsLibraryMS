using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
   public class BorrowBookInfo
    {
        public BorrowBookInfo()
        { }
        public string bookBarcode { get; set; }
        public string bookName { get; set; }
        public string borrowTime { get; set; }
        public string returnTime { get; set; }
        public string readerBarCode { get; set; }
        public string readerName { get; set; }
        public bool isReturn { get; set; }



    }
}
