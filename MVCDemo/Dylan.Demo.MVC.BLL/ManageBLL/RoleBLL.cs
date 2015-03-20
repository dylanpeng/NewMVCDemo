using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dylan.Demo.MVC.DAL;
using Dylan.Demo.MVC.Model;
using AutoMapper;
using Dylan.Demo.MVC.Common;

namespace Dylan.Demo.MVC.BLL
{
    public class RoleBLL
    {
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RoleVM GetByID(int id)
        {
            Role role = RoleDAL.Find(id);
            Mapper.CreateMap<Role, RoleVM>();
            RoleVM roleVM = Mapper.Map<Role, RoleVM>(role);
            return roleVM;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="roleVM"></param>
        public static void Create(RoleVM roleVM) 
        {
            Mapper.CreateMap<RoleVM, Role>();
            Role role = Mapper.Map<RoleVM, Role>(roleVM);
            role.CreateTime = DateTime.Now;
            role.IsDeleted = false;
            RoleDAL.Add(role);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roleVM"></param>
        public static void Edit(RoleVM roleVM)
        {
            Mapper.CreateMap<RoleVM, Role>();
            Role role = Mapper.Map<RoleVM, Role>(roleVM);
            RoleDAL.Update(role);
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            RoleDAL.Delete(id);
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void Delete(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                string[] strIDS = ids.Split(',');
                foreach (var item in strIDS)
                {
                    int id = int.Parse(item);
                    Delete(id);
                }
            }
        }

        /// <summary>
        /// 逻辑删除账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteLogical(int id)
        {
            RoleDAL.DeleteLogical(id);
        }

        /// <summary>
        /// 逻辑删除多账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteLogical(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                string[] strIDS = ids.Split(',');
                foreach (var item in strIDS)
                {
                    int id = int.Parse(item);
                    DeleteLogical(id);
                }
            }
        }

        /// <summary>
        /// 根据条件查询账号
        /// </summary>
        /// <returns></returns>
        public static List<RoleVM> Search(int pageIndex, int pageSize, out int totalCount)
        {
            var expression = PredicateBuilder.True<Role>();
            expression = expression.And(m => m.IsDeleted == false);
            List<Role> roleList = RoleDAL.Search(expression, m => m.CreateTime,  pageIndex, pageSize, out totalCount);
            if (roleList != null && roleList.Count > 0)
            {
                List<RoleVM> roleVMList = new List<RoleVM>();
                foreach (var item in roleList)
                {
                    Mapper.CreateMap<Role, RoleVM>();
                    RoleVM roleVM = Mapper.Map<Role, RoleVM>(item);
                    roleVMList.Add(roleVM);
                }
                return roleVMList;
            }
            return null;
        }
    }
}
