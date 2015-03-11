using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.Common
{
    //列表json传值对象
    public class JsonTableParams<TModel>
    {
        public JsonTableParams(int pageIndex, int pageSize, int pageCount, int totalCount, IEnumerable<TModel> records)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.PageCount = pageCount;
            this.TotalCount = totalCount;
            this.Records = records;
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<TModel> Records { get; set; }
    }
}
