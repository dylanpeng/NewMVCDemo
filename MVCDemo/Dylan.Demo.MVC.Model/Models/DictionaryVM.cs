using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.Model
{
    public class DictionaryVM
    {
        public int ID { get; set; }
        //名称
        public string Name { get; set; }
        //值
        public string Value { get; set; }
        //类型
        public string Type { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
