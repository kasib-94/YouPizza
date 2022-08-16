using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NuGet.Protocol;
using YouPizza.Model.ViewModel;
using YouPizza.Utility.SD;

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
            obj.TotalPrice = obj.ListCart.Sum(item => item.Price);
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
        OrderSummary summaryVm = new OrderSummary();
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
            var user = _db.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
            summaryVm.City = user.City;
            summaryVm.Name = user.Name;
            summaryVm.StreetAdress = user.StreetAdress;
            summaryVm.State = user.State;
            summaryVm.PostalCode = user.PostalCode;
            summaryVm.PhoneNumber = user.PhoneNumber;
        }

        var value = HttpContext.Session.GetString("list");
        summaryVm.ListCart = JsonConvert.DeserializeObject<List<Product>>(value);
        foreach (Product item in summaryVm.ListCart)
        {
            summaryVm.TotalPrice += item.Price;
        }

        return View(summaryVm);
    }

    [HttpPost]
    [ActionName("Summary")]
    [ValidateAntiForgeryToken]
    public IActionResult SummaryPOST(OrderSummary orderSummary)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
            orderSummary.ApplicationUser = _db.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
        }
        //getting cart from session to order summary.listcart
        orderSummary.ListCart = JsonConvert.DeserializeObject<List<Product>>(HttpContext.Session.GetString("list"));
        orderSummary.OrderStatus = SD.Pending;
        orderSummary.PaymentStatus = SD.Pending;
        orderSummary.TotalPrice = orderSummary.ListCart.Sum(item => item.Price);
        _db.OrderSummary.Add(orderSummary);
        _db.Save();
        
        
        return View();
        
    }
}