using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.DAL
{
    public class AdminDAL
    {
        public static List<Admin> SearchByConditions(Expression<Func<Admin, bool>> expression, int pageIndex, int pageSize, out int totalCount)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                totalCount = db.Admin.Count();
                return db.Admin.Where(expression).OrderByDescending(i => i.CreatedTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static Admin GetAdminByID(int id)
        {
            Admin admin;
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                admin = db.Admin.Find(id);
            }
            return admin;
        }

        public static void AddAdmin(Admin admin)
        {
            using(MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                db.Admin.Add(admin);
                db.SaveChanges();
            }
        }

        public static void EditAdmin(Admin admin)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                db.Set<Admin>().Attach(admin);
                db.Entry<Admin>(admin).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
