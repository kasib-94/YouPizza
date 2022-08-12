using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YouPizza.Model.ViewModel;

public class IngredientsProductVM
{
    public IngredientsProduct IngredientsProduct { get; set; }
    public Product Product { get; set; }
    public  IEnumerable<IngredientsProduct> IngredientsProductsList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> IngredientsList { get; set; }
}