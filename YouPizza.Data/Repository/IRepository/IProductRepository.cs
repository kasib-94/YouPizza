using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
    void Save();
}