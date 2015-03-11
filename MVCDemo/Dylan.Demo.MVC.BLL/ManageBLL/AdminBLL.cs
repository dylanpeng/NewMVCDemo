﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dylan.Demo.MVC.DAL;
using Dylan.Demo.MVC.Model;
using AutoMapper;
using Dylan.Demo.MVC.Common;
using System.Linq.Expressions;

namespace Dylan.Demo.MVC.BLL
{
    public class AdminBLL
    {
        /// <summary>
        /// 根据条件查询账号
        /// </summary>
        /// <returns></returns>
        public static List<AdminVM> SearchAdmin(string account, string name, string phone, string email, int pageIndex, int pageSize, out int totalCount)
        {
            Expression<Func<Admin, bool>> expression = PredicateBuilder.True<Admin>();
            if (!string.IsNullOrEmpty(account))
                expression.And(m => m.Account.Contains(account));
            if (!string.IsNullOrEmpty(name))
                expression.And(m => m.Name.Contains(name));
            if (!string.IsNullOrEmpty(phone))
                expression.And(m => m.Name.Contains(phone));
            if (!string.IsNullOrEmpty(email))
                expression.And(m => m.Name.Contains(email));
            List<Admin> adminsList = AdminDAL.SearchByConditions(expression, pageIndex, pageSize, out totalCount);
            if (adminsList != null && adminsList.Count > 0)
            {
                List<AdminVM> adminVMList = new List<AdminVM>();
                foreach (var item in adminsList)
                {
                    AdminVM adminVM = TransferToAdminVM(item);
                    adminVMList.Add(adminVM);
                }
                return adminVMList;
            }
            return null;
        }

        /// <summary>
        /// 根据ID查询账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AdminVM GetAdminByID(int id)
        {
            Admin admin = AdminDAL.GetAdminByID(id);
            if (admin != null)
            {
                Mapper.CreateMap<Admin, AdminVM>();
                AdminVM adminVM = TransferToAdminVM(admin);
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
            Admin admin = admin = TransferToAdmin(adminVM);
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
            Admin admin = TransferToAdmin(adminVM);
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

        /// <summary>
        /// AdminVM 向 Admin赋值
        /// </summary>
        /// <param name="adminVM"></param>
        /// <returns></returns>
        public static Admin TransferToAdmin(AdminVM adminVM)
        {
            Mapper.CreateMap<AdminVM, Admin>();
            Admin admin = Mapper.Map<AdminVM, Admin>(adminVM);
            if (adminVM.Hobbys != null && adminVM.Hobbys.Length > 0)
            {
                admin.Hobby = string.Join(",", adminVM.Hobbys);
            }
            return admin;
        }

        /// <summary>
        /// Admin 向 AdminVM赋值
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static AdminVM TransferToAdminVM(Admin admin)
        {
            Mapper.CreateMap<Admin, AdminVM>();
            AdminVM adminVM = Mapper.Map<Admin, AdminVM>(admin);
            if (admin.Hobby != null)
            {
                adminVM.Hobbys = admin.Hobby.Split(',');
            }
            return adminVM;
        }
    }
}
    