using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.DAL
{
    public class AdminDAL
    {
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
