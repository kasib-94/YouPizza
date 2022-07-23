using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class SauceRepository : Repository<Sauce> ,ISauceRepository
{
    private ApplicationDbContext _db;
    public SauceRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Sauce obj)
    {
        _db.Sauces.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}