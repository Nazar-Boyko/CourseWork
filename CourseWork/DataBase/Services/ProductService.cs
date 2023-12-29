using CourseWork.DataBase.Enteties;
using CourseWork.DataBase.Repositories;
using CourseWork.DataBase.Repositories.Base;
using CourseWork.DataBase.Services.Base;
using CourseWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.DataBase.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService(DbContext dbContext)
        {
            productRepository = new ProductRepository(dbContext);
        }
        public List<Product> ReadProduct()
        {

            var products = productRepository.Read().Select(product => Map(product)).ToList();
            return products;
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product.Name);
        }

        Product Map(ProductEntity productEntity)
        {
            Product product = new()
            {
                Quantity = productEntity.Quantity,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Type = productEntity.Type,
                PublicationTime = productEntity.PublicationTime,
                Addres = productEntity.Addres,
                State = productEntity.State,
            };

            return product;
        }

        public void UpdateProductQuantity(Product product)
        {
            var productEntity = productRepository.Update(product.Name);
            productEntity.Quantity = product.Quantity;
        }
    }
}
