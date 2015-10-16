using System;
using System.Linq;
using System.Linq.Expressions;

namespace CommonWebsite.Data.EntityExtensions
{
    public class EntityBaseExtensions
    {
        public static T Get<T>(IQueryable<T> query, Expression<Func<T, bool>> filter)
        {
            return query.FirstOrDefault(filter);
        }
    }
}