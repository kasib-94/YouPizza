using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouPizza.Model;

namespace YouPizza.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<Ingredients> Ingriedients { get; set; }

    public DbSet<OrderSummary> OrderSummaries { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<IngredientsProduct> IngredientsProduct { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IngredientsProduct>().HasKey(ip => new { ip.IngredientsId, ip.ProductId });
        
    
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}