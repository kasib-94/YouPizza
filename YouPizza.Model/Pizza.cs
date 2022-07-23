using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouPizza.Model;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public ICollection<Ingredients> Ingredients { get; set; }
    [Required]
    public string PizzaBase { get; set; }
    
    public int Size { get; set; }
    
}