using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IOrderSummaryRepository : IRepository<OrderSummary>
{
    void Update(OrderSummary obj);
    void Save();
}