using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Areas.Customer.Controllers;
[Area("Customer")]
[Controller]

public class HomeController : Controller
{
    private readonly IUnitOfWork _db;
    public HomeController(IUnitOfWork db)
    {
        _db = db;

    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Menu(int? id)
    {
        if (id==0 || id ==null)
        {
            id = 1;
        }

        IEnumerable<Product> prodList = _db.Products.GetAll().Where(u => u.CategoryId == id);
        ViewBag.categories = _db.Category.GetAll().ToList();
        return View(prodList);
    }

  
}