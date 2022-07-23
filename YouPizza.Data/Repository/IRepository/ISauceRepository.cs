using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface ISauceRepository : IRepository<Sauce>
{
    void Update(Sauce obj);
    void Save();
}