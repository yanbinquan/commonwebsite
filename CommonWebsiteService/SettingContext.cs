using System.Collections.Generic;
using CommonWebsite.Data.Entities;
using CommonWebsite.Infrastructure.Ioc;

namespace CommonWebsiteService
{
    public class SettingContext
    {
        private static readonly SettingContext _instance;

        public static SettingContext Instance
        {
            get { return _instance; }
        }

        public void Init()
        {
            var items = new List<Setting>();
            var service = Ioc.GetService<ISettingService>();
            service.Init(items);
        }
    }
}