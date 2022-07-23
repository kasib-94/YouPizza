﻿using Microsoft.AspNetCore.Mvc;
using YouPizza.Data;
using YouPizza.Model;

namespace YouPizza.Areas.Admin.Controllers;

public class SauceController : Controller
{
    // GET
    private readonly ApplicationDbContext dbContext;

    public SauceController(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public IActionResult Index()
    {
        IEnumerable<Sauce> objList = ;
        return View(objCategorylist);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.CoverType.Save();
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

        var categoryFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }


        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {


        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
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

        var categoryFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

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
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.CoverType.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
}