using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Core.Entities.Products
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int ProductsNumber { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public string UrlImage { get; set; }

        public double Price { get; set; }

        public double Size { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public string Brand { get; set; }

        public double Reviews { get; set; }
    }
}
