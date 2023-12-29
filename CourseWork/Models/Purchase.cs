using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Purchase
    {
        public Product Product { get; }

        public int Quantity { get; set; }

        public int FullPrice { get; set; }

        public string Date { get; set; }

        public Purchase(Product product, int quantity, int fullPrice, string date)
        {
            Product = product;
            Quantity = quantity;
            FullPrice = fullPrice;
            Date = date;
        }
    }
}
