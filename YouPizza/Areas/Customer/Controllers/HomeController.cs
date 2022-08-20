using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;
using YouPizza.Model.ViewModel;

namespace YouPizza.Areas.Customer.Controllers;
[Area("Customer")]
[Controller]

public class HomeController : Controller
{
    public int catId; 
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

    public IActionResult Menu(int? id, MenuVM? menuVmm)
    {
      
            MenuVM obj = new MenuVM();
        
        
        if (id!=null)
        {
            List<string> Sizes = _db.Category.GetFirstOrDefault(u => u.Id == id).Sizes
                .Split(new char[] { ',', ';', ':' }).ToList();
            obj.Sizes = new List<SelectListItem>();
            for (int i = 0; i < Sizes.Count(); i++)
            {
                obj.Sizes.Add(new SelectListItem(Sizes[i], Sizes[i]));
            }
            
            obj.Products = _db.Products.GetAll().Where(u => u.CategoryId == id).ToList();
            obj.Products.ForEach(u=>u.Size=Sizes[0]);
            if (menuVmm.Products!=null)
            {
                Product sized = obj.Products.Find(u => u.Id == menuVmm.Products[0].Id);
                Dictionary<string, System.Nullable<int>> SizePriceDict = new Dictionary<string, System.Nullable<int>>();
                SizePriceDict.Add(Sizes[0], sized.PriceSmall);
                if (Sizes.Count>1)
                {
                    SizePriceDict.Add(Sizes[1], sized.PriceMedium);
                }

                if (Sizes.Count>2)
                {
                    SizePriceDict.Add(Sizes[2], sized.PriceLarge);
                }
                
                sized.Size = menuVmm.Products[0].Size;
                sized.Price = (int)SizePriceDict[sized.Size];

            }
            
        }
        obj.Categories = _db.Category.GetAll().ToList();
        return View(obj);
    }
    [HttpPost]
    public IActionResult ManageSize(MenuVM menuVm)
    {

       
        return RedirectToAction(nameof(Menu),new {@menuVmm = menuVm});
    }
  
}