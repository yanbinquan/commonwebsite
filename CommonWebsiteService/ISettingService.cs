using System.Collections.Generic;
using CommonWebsite.Data.Entities;

namespace CommonWebsiteService
{
    public interface ISettingService
    {
        void Init(List<Setting> settings);
        List<Setting> GetAll();
    }
}