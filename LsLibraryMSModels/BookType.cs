using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
   public class BookType
    {
        public BookType()
        {
            typeID = -1;
            typeName = "";
            borrowDay = 0;

        }
        public int typeID { get; set; }
        public string typeName { get; set; }
        public int borrowDay { get; set; }
    }
}
