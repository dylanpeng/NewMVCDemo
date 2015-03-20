using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dylan.Demo.MVC.DAL
{
    public class BaseDAL<T> where T : class
    {
        public static List<T> Search<TKey>(Expression<Func<T, bool>> expression, Expression<Func<T, TKey>> orderBy, int pageIndex, int pageSize, out int totalCount)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                totalCount = db.Set<T>().Where(expression).Count();
                return db.Set<T>().Where(expression).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public static T Add(T model) 
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                db.Set<T>().Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static T Update(T model)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                if (db.Entry<T>(model).State == EntityState.Modified)
                {
                    db.SaveChanges();
                }
                else if (db.Entry<T>(model).State == EntityState.Detached)
                {
                    db.Set<T>().Attach(model);
                    db.Entry<T>(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return model;
        }

        public static void Delete(T model)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                db.Set<T>().Remove(model);
                db.SaveChanges();
            }
        }
        public static void Delete(params object[] keyValues)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                T model = db.Set<T>().Find(keyValues);
                if (model != null)
                {
                    db.Set<T>().Remove(model);
                    db.SaveChanges();
                }
            }
        }
        public static T Find(params object[] keyValues)
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                return db.Set<T>().Find(keyValues);
            }
        }
        public List<T> FindAll()
        {
            using (MVCDemoDBEntities db = new MVCDemoDBEntities())
            {
                return db.Set<T>().ToList();
            }
        }  
    }
}
