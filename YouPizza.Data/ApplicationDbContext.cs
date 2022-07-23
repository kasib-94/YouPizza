using Microsoft.EntityFrameworkCore;
using YouPizza.Model;

namespace YouPizza.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Sauce>? Sauces { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}