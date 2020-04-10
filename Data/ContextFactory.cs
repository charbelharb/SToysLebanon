using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<Context> builder = new DbContextOptionsBuilder<Context>();
            builder.UseLazyLoadingProxies().UseMySql("Server=127.0.0.1;User ID=STLebanon;Password=123;Database=STLebanon",
            optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));
            return new Context(builder.Options);
        }

        public static Context GetContext(string connectionName)
        {
            DbContextOptionsBuilder<Context> builder = new DbContextOptionsBuilder<Context>();
            builder.UseMySql(connectionName,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));
            return new Context(builder.Options);
        }
    }
}
