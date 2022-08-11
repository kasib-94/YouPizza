using Microsoft.AspNetCore.Mvc.Rendering;

namespace YouPizza.Model.ViewModel;

public class IngredientsProductVM
{
    public IngredientsProduct IngredientsProduct { get; set; }
    public Product Product { get; set; }
    public  IEnumerable<IngredientsProduct> IngredientsProductsList { get; set; }
    public IEnumerable<SelectListItem> IngredientsList { get; set; }
}