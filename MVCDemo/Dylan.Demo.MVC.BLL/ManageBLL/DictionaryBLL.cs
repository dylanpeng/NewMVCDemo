using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dylan.Demo.MVC.DAL;
using Dylan.Demo.MVC.Model;
using AutoMapper;

namespace Dylan.Demo.MVC.BLL
{
    public class DictionaryBLL
    {
        /// <summary>
        /// 根据类型查询字典
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<DictionaryVM> GetDictionaryByType(string type)
        {
            List<DictionaryVM> Dvms = new List<DictionaryVM>();
            List<Dictionary> dictionary = DictionaryDAL.GetDictionaryByType(type);
            if (dictionary != null && dictionary.Count > 0)
            {
                foreach (var item in dictionary)
                {
                    Mapper.CreateMap<Dictionary, DictionaryVM>();
                    DictionaryVM Dvm = Mapper.Map<Dictionary, DictionaryVM>(item);
                    Dvms.Add(Dvm);
                }
            }
            return Dvms;
        }
    }
}
