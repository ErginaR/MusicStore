using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IMusicStoreRepository repository;
        public AdminController(IMusicStoreRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult List()
        {
            return View(repository.Albums);
        }
        public ViewResult Edit(int albumId)
        {
            Album album = repository.Albums.FirstOrDefault(a=>a.AlbumID==albumId);
            return View(album);
        }
        public ViewResult Create()
        {
            return View("Edit",new Album());
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if(ModelState.IsValid)
            {
               TempData["confirmation"] = "Te dhenat u rregjistruan me sukses";
               repository.SaveAlbum(album);
               return RedirectToAction("List","Admin");
            }
            else
            {
                return View(album);
            }
        }
        [HttpPost]
        public RedirectToRouteResult Delete(int albumId)
        {
            Album album=repository.DeleteAlbum(albumId);
            if(album!=null)
            {
                TempData["confirmation"] = "Albumi: "+album.Title+" u fshi me sukses";
            }
            return RedirectToAction("List");
        }
    }
}