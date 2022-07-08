using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models.Configuration;

namespace WebHosting.Configure
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configure = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configure.GetConnectionString("ConnectionSQL"));

            return new RepositoryContext(builder.Options);
        }
    }
}
