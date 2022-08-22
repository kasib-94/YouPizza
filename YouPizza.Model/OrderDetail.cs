using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class OrderDetail
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }

    public int Count { get; set; } = 1;
    public string Size { get; set; }
    public double Price { get; set; }
    
    [ForeignKey("ProductId")]  
    [ValidateNever] 
    public Product Product { get; set; }
    
    [ForeignKey("OrderId")]
    [ValidateNever]
    public OrderSummary OrderHeader { get; set; }
}