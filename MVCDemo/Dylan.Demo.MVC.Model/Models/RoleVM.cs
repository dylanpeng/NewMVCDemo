using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dylan.Demo.MVC.Model
{
    public class RoleVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "角色不能为空")]
        [Display(Name = "角色：")]
        public string RoleName { get; set; }

        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
