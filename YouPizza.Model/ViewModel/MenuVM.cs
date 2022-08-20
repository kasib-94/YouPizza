using Microsoft.AspNetCore.Mvc.Rendering;

namespace YouPizza.Model.ViewModel;

public class MenuVM
{
    public List<Product> Products { get; set; }
    public List<SelectListItem> Sizes { get; set; }
    public List<Category> Categories { get; set; }

}