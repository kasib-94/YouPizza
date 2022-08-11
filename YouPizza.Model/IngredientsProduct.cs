using System.ComponentModel.DataAnnotations.Schema;

namespace YouPizza.Model;

public class IngredientsProduct
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [ForeignKey("Ingredients")]
    public int IngredientsId { get; set; }

    public Product Product { get; set; }
    public Ingredients Ingredients { get; set; }
}