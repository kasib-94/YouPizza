using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class OrderDetailRepository : Repository<OrderDetail> ,IOrderDetailRepository
{
    private ApplicationDbContext _db;
    public OrderDetailRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(OrderDetail obj)
    {
        _db.OrderDetails.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}