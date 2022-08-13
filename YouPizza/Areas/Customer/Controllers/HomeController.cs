using Microsoft.AspNetCore.Mvc;

namespace YouPizza.Areas.Customer.Controllers;
[Area("Customer")]
[Controller]

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Menu()
    {
        return View();
    }
}