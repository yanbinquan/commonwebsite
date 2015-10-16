using CommonWebsite.Data.Entities;
using CommonWebsiteService.Dtos;

namespace CommonWebsiteService
{
    public interface IUserService
    {
        User Get(string username);
        bool IsLogin(string username, string password);
        SessionUser GetSessionUser(string username);
    }
}