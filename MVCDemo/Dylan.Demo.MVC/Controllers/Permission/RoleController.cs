using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return View();
        }
	}
}