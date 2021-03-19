using HDS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Migrations
{
    public class HDSDesignContext : IDesignTimeDbContextFactory<HDSContext>
    {
        public HDSContext CreateDbContext(string[] args)
        {
            var connString = args.FirstOrDefault() ?? Environment.GetEnvironmentVariable("HDS_ConnectionString");
            return CreateDbContext(connString);
        }

        public HDSContext CreateDbContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"HDS connection string cannot be null or empty");
            }

            var optionsBuilder = new DbContextOptionsBuilder<HDSContext>();

            optionsBuilder
                .UseSqlServer(
                    connectionString,
                    b => {
                        b.MigrationsHistoryTable("__HDSMigrationsHistory");
                        b.CommandTimeout(60);
                        b.MigrationsAssembly(typeof(HDSDesignContext).Assembly.FullName);
                    })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new HDSContext(optionsBuilder.Options);
        }
    }
}
