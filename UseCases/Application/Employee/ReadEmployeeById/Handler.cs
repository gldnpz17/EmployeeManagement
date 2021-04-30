using Application.Common.Mediator;
using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.ReadEmployeeById
{
    public class Handler : IRequestHandler<Query, DomainModel.Entities.Employee>
    {
        private readonly EmployeeManagementDbContext _dbContext;

        public Handler(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DomainModel.Entities.Employee> HandleAsync(Query request)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);

            if (employee == null)
            {
                throw new ApplicationException("Can't find an employee with the given ID.");
            }

            return employee;
        }
    }
}
