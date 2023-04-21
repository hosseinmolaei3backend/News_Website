using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "سرگروه")]
        [Required(ErrorMessage = "نام {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {

        }
    }
}
