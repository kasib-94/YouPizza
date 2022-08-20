using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class Product
{
    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [ForeignKey("Category")] public int CategoryId { get; set; }
    [ValidateNever] public Category Category { get; set; }
    public string? ImageUrl { get; set; }
    public int Price { get; set; }
    [Required] public int PriceSmall { get; set; }

    public int? PriceMedium { get; set; }
    public int? PriceLarge { get; set; }
    public string? Size { get; set; }
    public ICollection<IngredientsProduct>? IngredientsProduct { get; set; }
    public ICollection<ProductOrderSummary>? ProductOrderSummaries { get; set; }
}