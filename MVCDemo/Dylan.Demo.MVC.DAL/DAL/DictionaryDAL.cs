using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.DAL
{
    public class DictionaryDAL
    {
        /// <summary>
        /// 根据类型查询字典
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Dictionary> GetDictionaryByType(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                using (MVCDemoDBEntities db = new MVCDemoDBEntities())
                {
                    List<Dictionary> dictionarys = db.Dictionary.Where(m => m.Type == type && m.IsDeleted == false).ToList();
                    return dictionarys;
                }
            }
            return null;
        }
    }
}
