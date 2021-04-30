using EFCoreInMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<DomainModel.Entities.Employee> Handle(Query request, CancellationToken cancellationToken)
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
