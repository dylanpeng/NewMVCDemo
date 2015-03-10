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
    public class AdminBLL
    {
        /// <summary>
        /// 根据条件查询账号
        /// </summary>
        /// <returns></returns>
        public static List<AdminVM> SearchAdmin()
        {
            List<AdminVM> admins = new List<AdminVM>();
            return admins;
        }

        public static AdminVM GetAdminByID(int id)
        {
            Admin admin = AdminDAL.GetAdminByID(id);
            if (admin != null)
            {
                Mapper.CreateMap<Admin, AdminVM>();
                AdminVM adminVM = Mapper.Map<Admin, AdminVM>(admin);
                if (admin.Hobby != null)
                {
                    adminVM.Hobbys = admin.Hobby.Split(',');
                }
                return adminVM;
            }
            return null;
        }

        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="adminVM"></param>
        public static void AddAdmin(AdminVM adminVM)
        {
            Mapper.CreateMap<AdminVM, Admin>();
            Admin admin = Mapper.Map<AdminVM, Admin>(adminVM);
            if (adminVM.Hobbys != null && adminVM.Hobbys.Length > 0)
            {
                admin.Hobby = string.Join(",", adminVM.Hobbys).Trim();
            }
            admin.CreatedTime = DateTime.Now;
            admin.UpdatedTime = DateTime.Now;
            admin.IsDeleted = false;
            AdminDAL.AddAdmin(admin);
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <param name="adminVM"></param>
        public static AdminVM EditAdmin(AdminVM adminVM)
        {
            Mapper.CreateMap<AdminVM, Admin>();
            Admin admin = Mapper.Map<AdminVM, Admin>(adminVM);
            if (adminVM.Hobbys != null && adminVM.Hobbys.Length > 0)
            {
                admin.Hobby = string.Join(",", adminVM.Hobbys);
            }
            admin.UpdatedTime = DateTime.Now;
            AdminDAL.EditAdmin(admin);
            return adminVM;
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteAdmin(int id)
        {
            return true;
        }
    }
}
