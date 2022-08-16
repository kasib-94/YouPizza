using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NuGet.Protocol;
using YouPizza.Model.ViewModel;

namespace YouPizza.Areas.Customer.Controllers;

[Area("Customer")]
[Controller]
public class CartController : Controller
{
    // GET

    private readonly IUnitOfWork _db;


    public CartController(IUnitOfWork db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        ShoppingCartVM obj = new ShoppingCartVM();
        var value = HttpContext.Session.GetString("list");
        if (value != null)
        {
            obj.ListCart = JsonConvert.DeserializeObject<List<Product>>(value);
            foreach (Product item in obj.ListCart)
            {
                obj.TotalPrice += item.Price;
            }
        }


        return View(obj);
    }

    public IActionResult Add(int id)
    {
        Product product = _db.Products.GetFirstOrDefault(u => u.Id == id);

        if (HttpContext.Session.GetString("list") == null)
        {
            List<Product> ProductList = new List<Product>();
            ProductList.Add(product);
            HttpContext.Session.SetString("list", JsonConvert.SerializeObject(ProductList));
        }
        else
        {
            var value = HttpContext.Session.GetString("list");
            List<Product> ProductList = JsonConvert.DeserializeObject<List<Product>>(value);
            ProductList.Add(product);
            HttpContext.Session.SetString("list", JsonConvert.SerializeObject(ProductList));
        }


        return RedirectToAction("Menu", "Home");
    }

    public IActionResult Remove(int id)
    {
      


        var value = HttpContext.Session.GetString("list");
        List<Product> ProductList = JsonConvert.DeserializeObject<List<Product>>(value);
        ProductList.Remove(ProductList.Find(x => x.Id == id));

        HttpContext.Session.SetString("list", JsonConvert.SerializeObject(ProductList));

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Summary()
    {
        return View();
    }
}