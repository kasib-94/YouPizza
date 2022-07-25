using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class IngredientsRepository : Repository<Ingredients> ,IIngredientsRepository
{
    private ApplicationDbContext _db;
    public IngredientsRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Ingredients obj)
    {
        _db.Ingriedients.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}