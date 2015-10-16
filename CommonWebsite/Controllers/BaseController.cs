using System;
using System.Web;
using System.Web.Mvc;
using CommonWebsite.Infrastructure;
using CommonWebsite.Infrastructure.Mvc;
using CommonWebsite.ViewModels;

namespace CommonWebsite.Controllers
{
    [AuthorizeFilterAttribute]
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string error;
            if (filterContext.Exception is KnownException)
            {
                error = filterContext.Exception.Message;
            }
            else
            {
                error = "服务器未知错误，请重试。如果该问题一直存在，请联系管理员。感谢您的支持。";
            }
#if DEBUG
            error = filterContext.HttpContext.Error.ToString();
#endif
            if (Request.IsAjaxRequest())
            {
                var result = new StandardJsonResult();
                result.Fail(error);
                filterContext.Result = result;
            }
            else
            {
                var model = new LayoutViewModel { Error = error };
                filterContext.Result = View("Error", model);
            }
            filterContext.ExceptionHandled = true;
        }
    }

    /// <summary>
    ///     权限拦截
    /// </summary>
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

#if DEBUG
            return;
#endif

            if (HttpContext.Current.Session["UserAccuont"] != null)
                return;

            filterContext.Result = new ContentResult
            {
                Content = "抱歉,你不具有当前操作的权限！请重新<a href='/Home/Login'>登陆<a>"
            };
        }
    }
}