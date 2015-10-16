using System.Web;
using CommonWebsite.Infrastructure.Ioc;
using CommonWebsiteService;
using CommonWebsiteService.Dtos;

namespace CommonWebsite.Security
{
    public class MvcSolutionSession
    {
        private SessionUser _user;

        public SessionUser User
        {
            get { return _user; }
        }

        public void Logout()
        {
            _user = null;
        }

        public void Login(string username)
        {
            ReloadAll(username);
        }

        public void Init()
        {
            if (!IsAuthenticated)
            {
                Logout();
                return;
            }
            ReloadAll(HttpContext.Current.User.Identity.Name);
        }

        private void ReloadAll(string username)
        {
            _user = Ioc.GetService<IUserService>().GetSessionUser(username);
        }

        public bool IsAuthenticated
        {
            get { return HttpContext.Current.Request.IsAuthenticated; }
        }
    }
}