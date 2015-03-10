using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dylan.Demo.MVC.Model;
using Dylan.Demo.MVC.BLL;

namespace Dylan.Demo.MVC.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/

        /// <summary>
        /// 账号列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 新增账户
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 新增账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(AdminVM adminVM)
        {
            if (ModelState.IsValid)
            {
                AdminBLL.AddAdmin(adminVM);
            }
            return View(adminVM);
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            AdminVM adminVM = AdminBLL.GetAdminByID(id);
            if (adminVM == null)
            {
                return Content("参数错误！");
            }
            return View(adminVM);
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(AdminVM admin)
        {
            if (ModelState.IsValid)
            {
                AdminBLL.EditAdmin(admin);
            }
            return View(admin);
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return View();
        }
	}
}   