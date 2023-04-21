using DataLayer.Context;
using DataLayer.Repository;
using DataLayer.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        IPage pageRepository;
        MyNewsContext db = new MyNewsContext();
        public HomeController()
        {
            pageRepository=new PageRepository(db);
        }
        [Route("Home")]
        [Route("")]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SliderAction()
        {
            return PartialView(pageRepository.PagesInSlider());
        }
        public ActionResult LastNews()
        {
            return PartialView(pageRepository.LastNews());
        }

    }
}