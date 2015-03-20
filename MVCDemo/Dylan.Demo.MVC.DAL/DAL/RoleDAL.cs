using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.DAL
{
    public class RoleDAL : BaseDAL<Role>
    {
        public static void DeleteLogical(int id)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                Role role = db.Role.Find(id);
                if (role != null)
                {
                    role.IsDeleted = true;
                    db.SaveChanges();
                }
            }
        }
    }
}
