using CommonWebsite.Data.Entities;

namespace CommonWebsiteService.Dtos
{
    public class SessionUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; set; }

        public SessionUser(User user, string[] roles)
        {
            Id = user.Id;
            Name = user.Name;
            Roles = roles;
        }

        public bool IsSuperAdmin()
        {
            return true;
        }

        public bool IsManager()
        {
            return true;
        }

    }
}
