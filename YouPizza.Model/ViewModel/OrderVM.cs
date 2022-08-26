using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace YouPizza.Model.ViewModel;

public class OrderVM
{
    public List<OrderSummary> Orders { get; set; }
    [BindProperty]
    public DateTime Min { get; set; }
    [BindProperty]
    public DateTime Max { get; set; }

}