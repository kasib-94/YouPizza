namespace YouPizza.Data.Repository.IRepository;

public interface IUnitOfWork
{
    
    ISauceRepository Sauce { get; }

    void Save();
}