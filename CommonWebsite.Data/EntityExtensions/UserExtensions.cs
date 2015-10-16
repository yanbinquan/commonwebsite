using System.Linq;
using CommonWebsite.Data.Entities;

namespace CommonWebsite.Data.EntityExtensions
{
    public static class UserExtensions
    {
        public static User Get(this IQueryable<User> query, string username)
        {
            return query.FirstOrDefault(x => x.Id > 0);
        }
    }
}