using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPage : IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageById(int id);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();
        IEnumerable<Page> TopNews(int Take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupId(int groupid);
        IEnumerable<Page> Search(string search);

    }
}
