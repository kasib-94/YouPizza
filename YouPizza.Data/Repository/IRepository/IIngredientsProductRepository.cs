using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IIngredientsProductRepository
    : IRepository<IngredientsProduct>
{
    void Update(IngredientsProduct obj);
    void Save();
}