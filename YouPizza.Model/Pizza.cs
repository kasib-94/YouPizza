using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouPizza.Model;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public ICollection<Ingredients> Ingredients { get; set; }
    
    public string? PizzaBase { get; set; }
    
    public int Size { get; set; }
    [Required]
    public int Price30 { get; set; }
    [Required]
    public int Price40 { get; set; }
    [Required]
    public int Price50 { get; set; }
    public string? Alergens { get; set; }
    
    public string?  ImageUrl { get; set; }
    
    
}