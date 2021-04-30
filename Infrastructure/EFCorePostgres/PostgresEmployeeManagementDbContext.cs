using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCorePostgres
{
    public class PostgresEmployeeManagementDbContext : EmployeeManagementDbContext
    {
        private readonly string _connectionString;

        public PostgresEmployeeManagementDbContext()
        {

        }

        public PostgresEmployeeManagementDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            if (_connectionString == "" || _connectionString == null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PGDB_CONNECTION_STRING"));
            }
            else
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }
    }
}
