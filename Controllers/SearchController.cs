using DataLayer.Context;
using DataLayer.Repository;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class SearchController : Controller
    {
        MyNewsContext db=new MyNewsContext();
        IPage pageRepository;
        public SearchController()
        {
            pageRepository=new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.Search(q));
        }
    }
}