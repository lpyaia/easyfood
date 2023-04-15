using Easyfood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Easyfood.Infrastructure.Persistence.EF
{
    public class EasyfoodDbContext : DbContext
    {
        public EasyfoodDbContext(DbContextOptions<EasyfoodDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyfoodDbContext).Assembly);
        }
    }

    public static class EntityFrameworkExtensions
    {
        public static string ConvertExpressionToEfIncludeString<TEntity>(
            this Expression<Func<TEntity, object>> expression) where TEntity : BaseEntity
        {
            var parameter = expression.Parameters.First();

            return expression.ToString()
                             .Replace($"{parameter.Name}.", "")
                             .Replace($"{parameter.Name} => ", "")
                             .Replace("FirstOrDefault().", "")
                             .Replace("First().", "")
                             .Replace("Single().", "")
                             .Replace("SingleOrDefault().", "")
                             .Trim();
        }
    }
}