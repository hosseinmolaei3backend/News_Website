using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPageGroup:IDisposable
    {
        IEnumerable<PageGroup> GetAllPageGroups();
        PageGroup GetPageGroupById(int id);
        bool InsertPageGroup(PageGroup group);
        bool UpdatePageGroup(PageGroup group);
        bool DeletePageGroup(PageGroup group);
        bool DeletePageGroup(int groupId);
        void Save();
        IEnumerable<ShowGroupViewModel> GetShowGroupViews();
    }
}
