using CourseWork.DataBase.Enteties;
using CourseWork.DataBase.Repositories.Base;

namespace CourseWork.DataBase.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private DbContext dbContext;

        public ProductRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(ProductEntity product)
        {
            dbContext.Products.Add(product);
        }

        public void Delete(string Name)
        {
            var product = Read().FirstOrDefault(prod => prod.Name == Name);
            dbContext.Products.Remove(product);
        }

        public List<ProductEntity> Read()
        {
            return dbContext.Products;
        }

        public ProductEntity Update(string Name)
        {
            return Read().FirstOrDefault(prod => prod.Name == Name);

        }
    }
}
