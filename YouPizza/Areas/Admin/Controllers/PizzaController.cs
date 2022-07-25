using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Areas.Admin.Controllers;
[Area("Admin")]
[Controller]
public class PizzaController : Controller
{
    // GET
    private readonly IUnitOfWork _unitOfWork;


    public PizzaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Upsert(int? id)
    {
        Pizza Pizza = new();



        if (id == null || id == 0)
        {
            return View(Pizza);
        }
        else
        {
            Pizza = _unitOfWork.Pizza.GetFirstOrDefault(x => x.Id == id);
            return View(Pizza);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Pizza obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {



            if (obj.Id == 0)
            {
                _unitOfWork.Pizza.Add(obj);
            }
            else
            {
                _unitOfWork.Pizza.Update(obj);
            }

            _unitOfWork.Save();
            TempData["success"] = "Product added successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }
}