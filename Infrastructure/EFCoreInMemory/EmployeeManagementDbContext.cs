using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreInMemory
{
    public class EmployeeManagementDbContext : DbContext
    {
        private string _databaseName;

        public EmployeeManagementDbContext(string databaseName)
        {
            _databaseName = databaseName;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_databaseName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(b =>
            {
                b.HasKey(e => e.EmployeeId);
                b.Property(e => e.EmployeeId).ValueGeneratedNever();

                b.OwnsMany(e => e.EditHistories);
            });
        }
    }
}
