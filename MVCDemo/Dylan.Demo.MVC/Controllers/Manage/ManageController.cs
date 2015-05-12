using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dylan.Demo.MVC.Model;
using Dylan.Demo.MVC.BLL;
using Dylan.Demo.MVC.Common;

namespace Dylan.Demo.MVC.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        /// <summary>
        /// 起始页
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View(); 
        }


        /// <summary>
        /// 账号列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchByConditions(string account, string name, string phone, string email, string beginTime, string endTime, int page = 1, int rows = 10)
        {
            int totalCount = 0, pageIndex = page, pageSize = rows;
            DateTime bTime, eTime;
            DateTime.TryParse(beginTime, out bTime);
            DateTime.TryParse(endTime, out eTime);
            List<AdminVM> list = AdminBLL.SearchAdmin(account, name, phone, email, bTime, eTime, pageIndex, pageSize, out totalCount);
            int pageCount = (int)Math.Ceiling((double)totalCount/(double)pageSize);
            JsonTableParams<AdminVM> result = new JsonTableParams<AdminVM>(pageIndex, pageSize, pageCount, totalCount, list);
            return Json(result, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            AdminBLL.DeleteAdmin(ids);
            return Content("OK");
        }
	}
}   