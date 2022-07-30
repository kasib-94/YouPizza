using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IIngredientsRepository : IRepository<Ingredients>
{
    void Update(Ingredients obj);
    void Save();
}