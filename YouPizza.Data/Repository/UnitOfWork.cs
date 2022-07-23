using YouPizza.Data.Repository.IRepository;

namespace YouPizza.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Sauce = new SauceRepository(_db);
    }


    public ISauceRepository Sauce { get; }

    public void Save()
    {
        _db.SaveChanges();
    }
}