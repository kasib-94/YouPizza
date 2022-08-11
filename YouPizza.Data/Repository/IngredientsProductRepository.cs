using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class IngredientsProductRepository : Repository<IngredientsProduct> ,IIngredientsProductRepository
{
    private ApplicationDbContext _db;
    public IngredientsProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(IngredientsProduct obj)
    {
        _db.IngredientsProduct.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}