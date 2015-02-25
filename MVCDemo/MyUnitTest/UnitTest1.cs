using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dylan.Demo.MVC.BLL;
using Dylan.Demo.MVC.Model;

namespace MyUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AdminVM adminVM = new AdminVM();
            adminVM.name = "admin";
            adminVM.password = "123456";
            AdminBLL.AddAdmin(adminVM);
        }
    }
}
