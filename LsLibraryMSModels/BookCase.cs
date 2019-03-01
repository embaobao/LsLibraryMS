using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
    public class BookCase
    {
       public BookCase()
        {
            bookcaseID = -1;
            bookcaseName = "";
        }
        public int bookcaseID { get; set; }
        public string bookcaseName { get; set; }

    }
}
