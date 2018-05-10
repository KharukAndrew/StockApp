using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.DAL.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
