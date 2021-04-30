using Application.Common.Mediator;
using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.ReadAllEmployees
{
    public class Handler : IRequestHandler<Query, IList<DomainModel.Entities.Employee>>
    {
        private readonly EmployeeManagementDbContext _dbContext;

        public Handler(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<DomainModel.Entities.Employee>> HandleAsync(Query request)
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return employees;
        }
    }
}
