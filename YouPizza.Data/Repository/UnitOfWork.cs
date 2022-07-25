using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Sauce = new SauceRepository(_db);
        Ingredients = new IngredientsRepository(_db);
        Pizza = new PizzaRepository(_db);
    }


    public ISauceRepository Sauce { get; }
    public IIngredientsRepository Ingredients { get; }
    public IPizzaRepository Pizza { get; }

    public void Save()
    {
        _db.SaveChanges();
    }
}