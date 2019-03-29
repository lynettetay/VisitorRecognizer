using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitorRecognizer.Models
{
    public class Visitor
    {
        public string carplate { get; set; }
        public string reason { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string block { get; set; }
        public string unit { get; set; }
        public string pVisit { get; set; }
        public string rawImageData { get; set; }
    }
}