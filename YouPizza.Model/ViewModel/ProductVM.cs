using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YouPizza.Model.ViewModel;

public class ProductVM
{
    
   
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; }




}