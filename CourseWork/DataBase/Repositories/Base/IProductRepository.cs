using CourseWork.DataBase.Enteties;
using System.Globalization;

namespace CourseWork.DataBase.Repositories.Base
{
    public interface IProductRepository
    {
        void Create(ProductEntity product);
        List<ProductEntity> Read();

        ProductEntity Update(string Name);

        void Delete(string Name);
    }
}
