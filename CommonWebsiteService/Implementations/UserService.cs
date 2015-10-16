using CommonWebsite.Data.Entities;
using CommonWebsite.Data.EntityExtensions;
using CommonWebsiteService.Dtos;

namespace CommonWebsiteService.Implementations
{
    internal class UserService : ServiceBase, IUserService
    {
        public User Get(string username)
        {
            using (var db = SqLiteDataDb())
            {
                return db.Users.Get(username);
            }
        }

        public bool IsLogin(string username, string password)
        {
            using (var db = SqLiteDataDb())
            {
                var user = db.Users.Get(username);
                return true;
            }
        }

        public SessionUser GetSessionUser(string username)
        {
            using (var db = SqLiteDataDb())
            {
                var user = db.Users.Get(username);
                if (user == null)
                {
                    return null;
                }
                var roleNames = new string[]{};
                return new SessionUser(user, roleNames);
            }
        }
    }
}