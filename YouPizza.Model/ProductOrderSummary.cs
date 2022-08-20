using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class ProductOrderSummary
{
    [ForeignKey("Product")] public int ProductId { get; set; }
    [ForeignKey("OrderSummary")] public int OrderSummaryId { get; set; }
    public OrderSummary OrderSummary { get; set; }
    public Product Product { get; set; }
}