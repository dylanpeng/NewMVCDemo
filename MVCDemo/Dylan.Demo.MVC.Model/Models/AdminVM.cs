using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dylan.Demo.MVC.Model
{
    public class AdminVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage="账号不能为空")]
        [Display(Name = "账号：")]
        public string Account { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码：")]
        public string Password { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [Display(Name = "姓名：")]
        public string Name { get; set; }

        [Display(Name = "电话：")]
        [RegularExpression(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)", ErrorMessage = "电话号码格式不正确")]
        public string Phone { get; set; }

        [Display(Name = "Email：")]
        [RegularExpression(@"^[a-zA-Z0-9_\.]+@[a-zA-Z0-9-]+[\.a-zA-Z]+$", ErrorMessage = "Email格式不正确")]
        public string Email { get; set; }

        [Display(Name = "备注：")]
        public string Remark { get; set; }

        [Display(Name = "性别：")]
        [Required(ErrorMessage = "性别不能为空")]
        public Nullable<short> Gender { get; set; }

        [Display(Name = "爱好：")]
        public string Hobby { get; set; }

        [Display(Name = "爱好：")]
        [Required(ErrorMessage = "爱好不能为空")]
        public string[] Hobbys { get; set; }

        [Display(Name = "创建时间")]
        public Nullable<System.DateTime> CreatedTime { get; set; }

        [Display(Name = "更新时间")]
        public Nullable<System.DateTime> UpdatedTime { get; set; }

        [Display(Name = "是否已删除")]
        public Nullable<bool> IsDeleted { get; set; }
    }
}
