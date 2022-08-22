using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IOrderDetailRepository
    : IRepository<OrderDetail>
{
    void Update(OrderDetail obj);
    void Save();
}