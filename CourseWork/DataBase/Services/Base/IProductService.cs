using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Services.Base
{
    public interface IProductService
    {
        List<Product> ReadProduct();
        void DeleteProduct(Product product);

        void UpdateProductQuantity(Product product);
    }
}
