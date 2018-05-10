using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockApp.WEB.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}