using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repository;
using DataLayer.Services;

namespace News.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private MyNewsContext db = new MyNewsContext();
        IPage pageRepository;
        IPageGroup pageGroupRepository;
        public PagesController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository=new PageRepository(db);
        }
        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepository.GetAllPages());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return PartialView(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllPageGroups(), "GroupId", "GroupTitle");
            return PartialView();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,GroupId,TitlePage,ShortDescription,Text,Visit,SliderShow,CreatDateTime,Tags")] Page page)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreatDateTime=DateTime.Now;
                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllPageGroups(), "GroupId", "GroupTitle", page.GroupId);
            return PartialView(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllPageGroups(), "GroupId", "GroupTitle", page.GroupId);
            return PartialView(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,GroupId,TitlePage,ShortDescription,Text,Visit,SliderShow,CreatDateTime,Tags")] Page page)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreatDateTime = DateTime.Now;
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllPageGroups(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return PartialView(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = pageRepository.GetPageById(id);
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageRepository.Dispose();
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
