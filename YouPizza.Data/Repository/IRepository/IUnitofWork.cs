namespace YouPizza.Data.Repository.IRepository;

public interface IUnitOfWork
{
    
    ISauceRepository Sauce { get; }
    IIngredientsRepository Ingredients { get; }
    IPizzaRepository Pizza { get; }

    void Save();
}