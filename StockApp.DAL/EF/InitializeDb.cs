using StockApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.DAL.EF
{
    class InitializeDb : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            context.Stocks.AddRange(new List<Stock>
            {
                new Stock{Number = "st01", Name = "Food stock", Address = "118, Picadilly str."},
                new Stock{Number = "st02", Name = "Molniya", Address = "9, Picadilly str."},
                new Stock{Number = "st03", Name = "Industrial goods", Address = "118, Picadilly str."}
            });

            context.Products.AddRange(new List<Product>
            {
                new Product{ Name = "Table" },
                new Product{ Name = "Chair" },
                new Product{ Name = "Bed" },
                new Product{ Name = "Apples" },
                new Product{ Name = "Milk" }
            });

            context.Providers.AddRange(new List<Provider>
            {
                new Provider{Name = "Liad Ltd.", Phone = "+007 23 45 678", Address = "15, New Street"},
                new Provider{Name = "Pack Line Ltd.", Phone = "+002 73 45 128", Address = "15, Old Street"}
            });

            base.Seed(context);
        }
    }
}
