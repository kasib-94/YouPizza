using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [ValidateNever]
     public Category Category { get; set; }
    public string? ImageUrl { get; set; }
    [Required]
    public int Price { get; set; }
    
    public  ICollection<IngredientsProduct>? IngredientsProduct { get; set; }
}