using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YouPizza.Model;

public class OrderSummary
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }
    [Required] public string StreetAdress { get; set; }
    [Required] public string City { get; set; }
    [Required] public string State { get; set; }
    [Required] public string PostalCode { get; set; }
    [Required] public string PhoneNumber { get; set; }
    public int TotalPrice { get; set; }
    public string? SessionId { get; set; }
    public string? PaymentIntentId { get; set; }
    public int? DeliveryEmployeeId { get; set; }
    public string? OrderStatus { get; set; }
    public string? PaymentStatus { get; set; }
    
    public Dictionary<int,List<string>>? ProductSizes { get; set; }
    public string? ApplicationUserId { get; set; }
   
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }

}