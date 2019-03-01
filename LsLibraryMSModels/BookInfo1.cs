using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
 public   class BookInfo1
    {

        public int Count { get; set; }
        public string BookBarCode { get; set; }
        public string BookName { get; set; }
        public string BookConcern { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string BorrowSum { get; set; }
    }
}
