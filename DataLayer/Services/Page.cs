using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PageRepository : IPage
    {
        private MyNewsContext db;
        public PageRepository(MyNewsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Models.Page> GetAllPages()
        {
            return db.Pages;
        }

        public Models.Page GetPageById(int id)
        {
            return db.Pages.Find(id);
        }

        public bool InsertPage(Models.Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePage(Models.Page page)
        {
            try
            {
                db.Entry(page).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePage(Models.Page page)
        {
            try
            {
                db.Entry(page).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int pageId)
        {
            try
            {
                var page = GetPageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int Take = 4)
        {
            return db.Pages.OrderByDescending(n => n.Visit).Take(Take).ToList();
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(n => n.SliderShow == true);
        }

        public IEnumerable<Page> LastNews(int take)
        {
            return db.Pages.OrderByDescending(n => n.CreatDateTime).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupid)
        {
            return db.Pages.Where(n => n.GroupId == groupid);
        }

        public IEnumerable<Page> Search(string search)
        {
            return db.Pages.Where(n => n.TitlePage.Contains(search) ||
            n.ShortDescription.Contains(search) ||
            n.Tags.Contains(search) || 
            n.Text.Contains(search)).Distinct();
        }
    }
}
