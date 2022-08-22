using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        ApplicationUsers = new ApplicationUserRepository(_db);
        Sauce = new SauceRepository(_db);
        Ingredients = new IngredientsRepository(_db);
        Category = new CategoryRepository(_db);
        Products = new ProductRepository(_db);
        IngredientsProduct = new IngredientsProductRepository(_db);
        OrderSummary = new OrderSummaryRepository(_db);
        OrderDetail = new OrderDetailRepository(_db);
    }


    public ISauceRepository Sauce { get; }
    public IIngredientsRepository Ingredients { get; }
    public ICategoryRepository Category { get; }
    public IProductRepository Products { get; }
    public IIngredientsProductRepository IngredientsProduct { get; }
    public IApplicationUserRepository ApplicationUsers { get; }
    public IOrderSummaryRepository OrderSummary { get; }
    public IOrderDetailRepository OrderDetail { get; }

    public void Save()
    {
        _db.SaveChanges();
    }
}