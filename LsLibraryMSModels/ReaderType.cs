using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LsLibraryMSModels
{
    public class ReaderType
    {
        public ReaderType()
        {
            this.id = 0;
            this.num = "";
            this.type = "";
        }
        public int id { get; set; }
        public string type { get; set; }
        public string num { get; set; }
    }
}
