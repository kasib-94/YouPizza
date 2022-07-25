using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;

namespace YouPizza.Areas.Admin.Controllers;
[Controller]
[Area("Admin")]
public class IngredientsController : Controller
{
    
    // GET
    private readonly IUnitOfWork _unitOfWork;

    public IngredientsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Ingredients> objList = _unitOfWork.Ingredients.GetAll();
        return View(objList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create( Ingredients obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork. Ingredients.Add(obj);
            _unitOfWork. Ingredients.Save();
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

        var categoryFromDb = _unitOfWork.Ingredients.GetFirstOrDefault(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }


        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit( Ingredients obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork. Ingredients.Update(obj);
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

        var categoryFromDb = _unitOfWork. Ingredients.GetFirstOrDefault(u => u.Id == id);

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
        var obj = _unitOfWork. Ingredients.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork. Ingredients.Remove(obj);
        _unitOfWork. Ingredients.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}