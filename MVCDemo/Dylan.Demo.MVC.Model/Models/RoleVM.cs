using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dylan.Demo.MVC.Model
{
    class RoleVM
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
