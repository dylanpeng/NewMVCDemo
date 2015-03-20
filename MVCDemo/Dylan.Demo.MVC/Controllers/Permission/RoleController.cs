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
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult SearchByConditions(int page = 1, int rows = 10)
        {
            int totalCount = 0, pageIndex = page, pageSize = rows;
            List<RoleVM> list = RoleBLL.Search(pageIndex, pageSize, out totalCount);
            int pageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
            JsonTableParams<RoleVM> result = new JsonTableParams<RoleVM>(pageIndex, pageSize, pageCount, totalCount, list);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                RoleBLL.Create(roleVM);
                return RedirectToAction("Index");
            }
            return View(roleVM);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            RoleVM roleVM = RoleBLL.GetByID(id);
            if (roleVM == null)
            {
                return Content("参数错误！");
            }
            return View(roleVM);
        }

        /// <summary>
        /// 编辑账户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                RoleBLL.Edit(roleVM);
                return RedirectToAction("Index");
            }
            return View(roleVM);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(string ids)
        {
            RoleBLL.DeleteLogical(ids);
            return Content("OK");
        }
	}
}