using DataLayer.Context;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PageGroupRepository : IPageGroup
    {
        private MyNewsContext db;
        public PageGroupRepository(MyNewsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Models.PageGroup> GetAllPageGroups()
        {
            return db.PageGroups.ToList();
        }
        public Models.PageGroup GetPageGroupById(int id)
        {
            return db.PageGroups.Find(id);
        }
        public bool InsertPageGroup(Models.PageGroup group)
        {
            try
            {
                db.PageGroups.Add(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePageGroup(Models.PageGroup group)
        {
            try
            {
                db.Entry(group).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePageGroup(Models.PageGroup group)
        {
            try
            {
                db.Entry(group).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePageGroup(int groupId)
        {
            try
            {
                var group = GetPageGroupById(groupId);
                DeletePageGroup(group);
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

        public IEnumerable<ShowGroupViewModel> GetShowGroupViews()
        {
            return db.PageGroups.Select(n => new ShowGroupViewModel()
            {
                GroupId = n.GroupId,
                GroupTitle = n.GroupTitle,
                PageCount = n.Pages.Count()
            });
        }
    }
}
