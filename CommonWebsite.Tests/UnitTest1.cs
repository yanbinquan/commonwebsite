using System;
using CommonWebsite.Controllers;
using CommonWebsite.Infrastructure.Ioc;
using CommonWebsiteService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonWebsite.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ioc.RegisterInheritedTypes(typeof (IUserService).Assembly, typeof (ServiceBase));

            var service = Ioc.GetService<IUserService>();
            var result = service.IsLogin("123", "abc");
            //var hc=new HomeController();
            //hc.Login();
        }
    }
}