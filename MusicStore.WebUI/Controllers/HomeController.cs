using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IMusicStoreRepository repository;
        public HomeController(IMusicStoreRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index(string genre=null)
        {
            IEnumerable<Album> albums = repository.Albums.Where(a => genre == null || a.Genre == genre);
            return View(albums);
        }

        public ViewResult Details(string returnUrl,int id=1)
        {
            ViewBag.ReturnUrl = returnUrl;
            Album album = repository.Albums.FirstOrDefault(a => a.AlbumID == id);
            return View(album);
        }
 
    }
}