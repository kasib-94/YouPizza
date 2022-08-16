using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Data.Repository;

public class ApplicationUserRepository : Repository<ApplicationUser> ,IApplicationUserRepository
{
    private ApplicationDbContext _db;
    public ApplicationUserRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(ApplicationUser obj)
    {
        _db.ApplicationUsers.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}