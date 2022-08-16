using YouPizza.Data.Repository;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class OrderSummaryRepository : Repository<OrderSummary> ,IOrderSummaryRepository
{
    private ApplicationDbContext _db;
    public OrderSummaryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(OrderSummary obj)
    {
        _db.OrderSummaries.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}