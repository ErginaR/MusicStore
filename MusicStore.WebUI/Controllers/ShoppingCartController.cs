using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        IMusicStoreRepository repository;
        public ShoppingCartController(IMusicStoreRepository repos)
        {
            repository = repos;
        }
        public RedirectToRouteResult Add(int albumId,string returnUrl)
        {
            Album album = repository.Albums.FirstOrDefault(a => a.AlbumID == albumId);
            if(album!=null)
            {
                GetCart().AddToCart(album, 1);
            }
            return RedirectToAction("Order",new {returnUrl });
        }
        public RedirectToRouteResult Remove(int albumId,string returnUrl)
        {
            Album album = repository.Albums.FirstOrDefault(a => a.AlbumID == albumId);
            if (album != null)
            {
                GetCart().RemoveFromCart(album);
            }
            return RedirectToAction("Order", new { returnUrl });
        }
        public RedirectToRouteResult RemoveAll(string returnUrl)
        {
            GetCart().Clear();
            return RedirectToAction("Order", new { returnUrl });
        }
        public ViewResult Order(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(GetCart());
        }
        public PartialViewResult CartInfo()
        {

            ViewData["Number"] = GetCart().LineCollection().Sum(x=>x.Quantity);
            return PartialView();
        }
        [Authorize]
        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingInformation());
        }
        [HttpPost]
        public ViewResult Checkout(ShippingInformation info)
        {
            if (GetCart().LineCollection().Count() == 0)
                ModelState.AddModelError("", "Nuk ka produkte ne shporte");
            if (ModelState.IsValid)
            {
                ViewBag.Name = info.FirstName + " " + info.LastName;
                return View("Message");
            }
            else
            {
                return View(info);
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
    }
}