using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private IUserRepository repository;
        public AccountController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData data)
        {
            User user = repository.Users.FirstOrDefault(x => x.Password == data.Password&&x.UserName==data.UserName);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(data.UserName, false);
                return RedirectToAction("Checkout", "ShoppingCart");
            }
            else
            {
                ModelState.AddModelError("", "Username or password are incorrect");
                return View();
            }
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterData data)
        {
            if(data.User.Password!=data.PasswordConfirm)
            {
                ModelState.AddModelError("", "Kujdes!Passwordet nuk perputhen.");
                return View(data);
            }
            else
            {
                bool result=repository.SaveUser(data.User);
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(data.User.UserName, false);
                    return RedirectToAction("Checkout","ShoppingCart");
                }
                else
                {
                    ModelState.AddModelError("", "Nje user me kredenciale te tilla ekziston tashme ");
                    return View(data);
                }


            }
            
        }
        public RedirectToRouteResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}