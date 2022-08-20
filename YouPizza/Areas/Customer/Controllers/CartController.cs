using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using YouPizza.Data.Repository.IRepository;
using YouPizza.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NuGet.Protocol;
using YouPizza.Model.ViewModel;
using YouPizza.Utility.SD;
using Stripe.Checkout;

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


        return RedirectToAction("Menu", "Home",new {id=product.CategoryId});
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
        ShoppingCartVM summaryVm = new ShoppingCartVM();
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
            var user = _db.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
            summaryVm.user.City = user.City;
            summaryVm.user.Name = user.Name;
            summaryVm.user.StreetAdress = user.StreetAdress;
            summaryVm.user.State = user.State;
            summaryVm.user.PostalCode = user.PostalCode;
            summaryVm.user.PhoneNumber = user.PhoneNumber;
        }
        else
        {
            summaryVm.user = new ApplicationUser();
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
    public IActionResult SummaryPOST(ShoppingCartVM orderSummary)
    {
        OrderSummary obj = new OrderSummary();
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        
            obj.Name = orderSummary.user.Name;
            obj.PhoneNumber = orderSummary.user.PhoneNumber;
            obj.StreetAdress = orderSummary.user.StreetAdress;
            obj.City = orderSummary.user.City;
            obj.State = orderSummary.user.State;
            obj.PostalCode = orderSummary.user.PostalCode;
            if (claim!=null)
            {
                var user = _db.ApplicationUsers.GetFirstOrDefault(u => u.Id == claim.Value);
                      obj.ApplicationUserId = user.Id;
            }
            var value = HttpContext.Session.GetString("list");
            IEnumerable<Product> productsList = JsonConvert.DeserializeObject<List<Product>>(value);
            obj.TotalPrice = productsList.Sum(u => u.Price);
        _db.OrderSummary.Add(obj);
        _db.Save();
   
            foreach (var item in productsList )
            {
                ProductOrderSummary productOrder = new ProductOrderSummary();
                productOrder.ProductId = item.Id;
                productOrder.OrderSummaryId = obj.Id;
                
                _db.ProductOrder.Add(productOrder);
            }
            _db.Save();

        
    
    
        obj.OrderStatus = SD.Pending;
        obj.PaymentStatus = SD.Pending;
       // orderSummary.TotalPrice = orderSummary.ListCart.Sum(item => item.Price);

        _db.Save();
        
        //STRIPE PAYMENT
        
        
            var domain = "https://localhost:7010/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"customer/cart/OderConfirmation?id={obj.Id}",
                CancelUrl = domain + $"customer/cart/index",
            };

            // foreach (var item in ShoppingCartVm.ListCart)
            // {
            //     var sessionLineItem = new SessionLineItemOptions
            //     {
            //         PriceData = new SessionLineItemPriceDataOptions()
            //         {
            //             UnitAmount = (long)(item.Price * 100),
            //             Currency = "usd",
            //             ProductData = new SessionLineItemPriceDataProductDataOptions
            //             {
            //                 Name = item.Product.title,
            //                 Description = item.Product.Description
            //             }
            //         },
            //         Quantity = item.Count
            //     };
            //     options.LineItems.Add(sessionLineItem);
            // }
            //
            // var service = new SessionService();
            // Session session = service.Create(options);
            // _unitOfWork.OrderHeader.UpdateStripePaymentId(ShoppingCartVm.OrderHeader.Id, session.Id,
            //     session.PaymentIntentId);
            // _unitOfWork.Save();
            //
            // Response.Headers.Add("Location", session.Url);
            // return new StatusCodeResult(303);
            return RedirectToAction(nameof(OderConfirmation),new { id = obj.Id});

    }

    public IActionResult OderConfirmation(int id)
    {
        return View();
    }
}