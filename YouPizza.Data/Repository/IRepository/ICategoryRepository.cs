using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();
}