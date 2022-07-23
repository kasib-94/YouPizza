using System.ComponentModel.DataAnnotations;

namespace YouPizza.Model;

public class Ingredients
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
}