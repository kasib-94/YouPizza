using YouPizza.Data.Repository;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class OrderProductSummaryRepository : Repository<ProductOrderSummary> ,IProductOrderSummaryRepository
{
    private ApplicationDbContext _db;
    public OrderProductSummaryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(ProductOrderSummary obj)
    {
        _db.ProductOrderSummaries.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}