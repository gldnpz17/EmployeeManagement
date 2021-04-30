using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCorePostgres
{
    public class PostgresEmployeeManagementDbContext : EmployeeManagementDbContext
    {
        private readonly string _connectionString;

        public PostgresEmployeeManagementDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
