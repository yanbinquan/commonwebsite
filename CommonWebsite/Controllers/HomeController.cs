using System.Web.Mvc;
using CommonWebsite.Infrastructure.Ioc;
using CommonWebsiteService;

namespace CommonWebsite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Login()
        {
            var userService = Ioc.GetService<IUserService>();
            var result = userService.IsLogin("123", "abc");
            return View();
        }
    }
}