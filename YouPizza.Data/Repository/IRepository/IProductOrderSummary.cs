using YouPizza.Model;

namespace YouPizza.Data.Repository.IRepository;

public interface IProductOrderSummaryRepository : IRepository<ProductOrderSummary>
{
    void Update(ProductOrderSummary obj);
    void Save();
}