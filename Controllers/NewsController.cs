using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repository;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        MyNewsContext db = new MyNewsContext();
        IPageGroup pageGroupRepository;
        IPage pageRepository;
        IPageComment pageCommentRepository;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentrepos(db);
        }
        // GET: News
        public ActionResult ShowGroupNews()
        {
            return PartialView(pageGroupRepository.GetShowGroupViews());
        }

        public ActionResult ShowGroupNewsInMenu()
        {
            return PartialView(pageGroupRepository.GetAllPageGroups());
        }
        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }
        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPages());
        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }
        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComments(int id, string name, string email, string titr, string comment)
        {
            PageComment pageComment = new PageComment()
            {
                DateAddComment = DateTime.Now,
                PageId = id,
                Name = name,
                Email = email,
                CommentTitle = titr,
                CommentText = comment
            };
            pageCommentRepository.addComment(pageComment);
            return PartialView("ShowComment",pageCommentRepository.GetCommentByPageId(id));
        }
        public ActionResult ShowComment(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByPageId(id));
        }
    
    }
}