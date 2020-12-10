using MusicStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        IMusicStoreRepository repos;
        public NavigationController(IMusicStoreRepository repository)
        {
            repos = repository;
        }
        public PartialViewResult Menu(string genre=null)
        {
            ViewBag.Genre = genre;
            IEnumerable<string> geners = repos.Albums.Select(a => a.Genre).Distinct();
            return PartialView(geners);
        }
    }
}