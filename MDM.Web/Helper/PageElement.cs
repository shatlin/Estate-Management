using System;
using System.Collections.Generic;

namespace MDM.Helper
{
    public partial class PageElement
    {
        public string fieldname { get; set; }
        public string labelname { get; set; }
        public string fieldtype { get; set; }
        public bool idfield { get; set; }
        public bool show { get; set; }
        public string placeholder { get; set; }
        public string lookuplist { get; set; }
    }
}
