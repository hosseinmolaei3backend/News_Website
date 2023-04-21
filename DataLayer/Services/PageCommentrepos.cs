using DataLayer.Context;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PageCommentrepos : IPageComment
    {
        private MyNewsContext db;
        public PageCommentrepos(MyNewsContext context)
        {
            db = context;
        }
        public IEnumerable<Models.PageComment> GetCommentByPageId(int pageId)
        {
            return db.PageComments.Where(n=>n.PageId == pageId);
        }
        public bool addComment(Models.PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
