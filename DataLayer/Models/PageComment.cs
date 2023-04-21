using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PageComment
    {
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "سربرگ")]
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        public int PageId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "عنوان پیام")]
        [MaxLength(100)]
        public string CommentTitle { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ  نظر")]
        public DateTime DateAddComment { get; set; }

        public virtual Page Page { get; set; }
        public PageComment()
        {

        }
    }
}
