namespace YouPizza.Model.ViewModel;

public class ShoppingCartVM
{
    public IEnumerable<Product> ListCart { get; set; }
    public int TotalPrice { get; set; }
    public ApplicationUser user { get; set; }
}