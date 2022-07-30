using Microsoft.AspNetCore.Mvc;
using YouPizza.Data;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Areas.Admin.Controllers;


[Area("Admin")]
[Controller]
public class SauceController : Controller
{
    // GET
    private readonly IUnitOfWork _unitOfWork;

    public SauceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Sauce> objList = _unitOfWork.Sauce.GetAll();
        return View(objList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Sauce obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.Sauce.Add(obj);
            _unitOfWork.Sauce.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    public IActionResult Edit(int? id)
    {

        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _unitOfWork.Sauce.GetFirstOrDefault(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }


        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Sauce obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.Sauce.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _unitOfWork.Sauce.GetFirstOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Sauce.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Sauce.Remove(obj);
        _unitOfWork.Sauce.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}