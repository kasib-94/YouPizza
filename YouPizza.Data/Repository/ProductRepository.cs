using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class ProductRepository : Repository<Product> ,IProductRepository
{
    private ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Product obj)
    {
        _db.Products.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}