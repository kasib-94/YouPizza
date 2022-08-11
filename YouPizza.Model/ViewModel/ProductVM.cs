using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YouPizza.Model.ViewModel;

public class ProductVM
{
    
   
    public Product Product { get; set; }

    public IEnumerable<SelectListItem> CategoryList { get; set; }




}