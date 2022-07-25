using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IPizzaRepository : IRepository<Pizza>
{
    void Update(Pizza obj);
    void Save();
}