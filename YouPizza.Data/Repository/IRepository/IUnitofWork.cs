namespace YouPizza.Data.Repository.IRepository;

public interface IUnitOfWork
{
    
    ISauceRepository Sauce { get; }
    IIngredientsRepository Ingredients { get; }
  

    void Save();
}