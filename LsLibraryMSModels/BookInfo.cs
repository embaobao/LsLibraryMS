using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
 public   class BookInfo
    {
        public BookInfo()
        {

            Book_Type = new BookType();
            Book_Case = new BookCase();
        }


        public int Count { get; set; }
        public string BookBarCode { get; set; }
        public string BookName { get; set; }
        public BookType Book_Type { get; set; }
        public BookCase Book_Case { get; set; }
        public string BookConcern { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string BorrowSum { get; set; }
    }
}
