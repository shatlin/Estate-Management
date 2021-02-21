using System;
using System.Collections.Generic;

namespace MM.Helper
{
    public partial class Header
    {
        public string name { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
    }

    public partial class MenuItem
    {
        public string url { get; set; }
        public string abbreviation { get; set; }
        public string linktext { get; set; }
        public string page { get; set; }
        public string icon{ get; set; }
    }

}
