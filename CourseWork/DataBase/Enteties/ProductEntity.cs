using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Enteties
{
    public class ProductEntity
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public string PublicationTime { get; set; }
        public string Addres { get; set; }
        public string State { get; set; }

    }
}
