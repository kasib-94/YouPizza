using Microsoft.AspNetCore.Mvc;

namespace YouPizza.Areas.Admin.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}