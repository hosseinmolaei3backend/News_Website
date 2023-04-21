using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPageComment:IDisposable
    {
        IEnumerable<PageComment> GetCommentByPageId(int pageId);
        bool addComment(PageComment comment);
    }
}
