using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class PizzaRepository : Repository<Pizza> ,IPizzaRepository
{
    private ApplicationDbContext _db;
    public PizzaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Pizza obj)
    {
        _db.Pizzas.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}