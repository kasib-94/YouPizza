using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouPizza.Model;

namespace YouPizza.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Sauce>? Sauces { get; set; }
    public DbSet<Ingredients> Ingriedients { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}