using System.Net;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;
using YouPizza.Model.ViewModel;

namespace YouPizza.Areas.Admin.Controllers;

[Controller]
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _db;
    private readonly IWebHostEnvironment _webHost;

    public ProductController(IUnitOfWork db, IWebHostEnvironment webHost)
    {
        _webHost = webHost;
        _db = db;
    }

    public IActionResult Index()
    {
        List<Product> ProductList = _db.Products
            .GetAll(includeProperties: "Category,IngredientsProduct,IngredientsProduct.Ingredients").ToList();
        return View(ProductList);
    }

    public IActionResult Upsert(int? id)
    {
        ProductVM obj = new ProductVM()
        {
            Product = new(),
            CategoryList = _db.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            })
        };
        if (id == null)
        {
            return View(obj);
        }

        //this for edit
        obj.Product = _db.Products.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductVM obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            obj.Product.Price = obj.Product.PriceSmall;
            string wwwRootPath = _webHost.WebRootPath;
            if (file != null)
            {
                // HOW TO COPY FILE IN C###

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"img\Products");
                var extension = Path.GetExtension(file.FileName);

                if (obj.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists((oldImagePath)))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                obj.Product.ImageUrl = @"\img\Products\" + fileName + extension;
            }


            if (obj.Product.Id == 0)
            {
                //this is create
                _db.Products.Add(obj.Product);
            }
            else
            {
                //this is an update
                _db.Products.Update(obj.Product);
            }

            _db.Save();
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    public IActionResult ManageIngredients(int id)
    {
        IngredientsProductVM obj = new IngredientsProductVM()
        {
            IngredientsProductsList = _db.IngredientsProduct.GetAll(includeProperties: "Product,Ingredients")
                .Where(u => u.ProductId == id),
            Product = _db.Products.GetFirstOrDefault(u => u.Id == id),
            IngredientsProduct = new IngredientsProduct()
            {
                ProductId = id,
            }
        };
        List<int> AssignedIngredientsList = obj.IngredientsProductsList.Select(u => u.IngredientsId).ToList();

        var tempList = _db.Ingredients.GetAll(u => !AssignedIngredientsList.Contains(u.Id)).ToList();

        obj.IngredientsList = tempList.Select(i => new SelectListItem
        {
            Text = i.Name,
            Value = i.Id.ToString()
        });
        Cookie cook = new Cookie();
        return View(obj);
    }


    [HttpPost]
    public IActionResult ManageIngredients(IngredientsProductVM obj)
    {
        if (obj.IngredientsProduct.IngredientsId != 0 && obj.IngredientsProduct.ProductId != 0)
        {
            _db.IngredientsProduct.Add(obj.IngredientsProduct);
            _db.Save();
        }

        return RedirectToAction(nameof(ManageIngredients), new { @id = obj.IngredientsProduct.ProductId });
    }

    [HttpPost]
    public IActionResult RemoveIngredients(int id, IngredientsProductVM obj)
    {
        int ProductId = obj.Product.Id;
        IngredientsProduct ingredientsProduct =
            _db.IngredientsProduct.GetFirstOrDefault(u => u.ProductId == ProductId && u.IngredientsId == id);
        _db.IngredientsProduct.Remove(ingredientsProduct);
        _db.Save();

        return RedirectToAction(nameof(ManageIngredients), new { @id = ProductId });
    }

    public IActionResult Delete(int id)
    {
        Product product = _db.Products.GetFirstOrDefault(p => p.Id == id);
        _db.Products.Remove(product);
        _db.Save();
        return RedirectToAction(nameof(Index));
    }
}