using CommonWebsite.Data;

namespace CommonWebsiteService
{
    public abstract class ServiceBase
    {
        protected SqLiteDataContext SqLiteDataDb()
        {
            return new SqLiteDataContext();
        }
    }
}