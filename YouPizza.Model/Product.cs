using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("CategoryId")] 
    public int CategoryId { get; set; }
    [ValidateNever] public Category Category { get; set; }
    public string? ImageUrl { get; set; }
    public int Price { get; set; }
}