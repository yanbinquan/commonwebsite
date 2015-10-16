using System.Data.Entity;
using CommonWebsite.Data.Entities;

namespace CommonWebsite.Data
{
    public class SqLiteDataContext : DbContext
    {
        public SqLiteDataContext()
        {
            Database.SetInitializer<SqLiteDataContext>(null);
        }

        public DbSet<User> Users { get; set; }
    }
}