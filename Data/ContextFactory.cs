using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<Context> builder = new DbContextOptionsBuilder<Context>();
            builder.UseLazyLoadingProxies().UseSqlite("Data Source=D:\\STLeb.db",
            optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));
            return new Context(builder.Options);
        }

        public static Context GetContext(string connectionName)
        {
            DbContextOptionsBuilder<Context> builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlite(connectionName,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(Context).GetTypeInfo().Assembly.GetName().Name));
            return new Context(builder.Options);
        }
    }
}
