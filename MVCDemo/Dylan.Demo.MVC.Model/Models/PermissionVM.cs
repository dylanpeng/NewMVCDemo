using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dylan.Demo.MVC.Model
{
    public class PermissionVM
    {
        public int ID { get; set; }
        public string PermissionName { get; set; }
        public string Descript { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
