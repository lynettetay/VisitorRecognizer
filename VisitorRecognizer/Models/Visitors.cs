using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisitorRecognizer.Models
{
    public class Visitors
    {
        public DbSet<Visitor> Visitorss { get; set; }
    }
}