using EFCoreInMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<IList<DomainModel.Entities.Employee>> Handle(Query request, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return employees;
        }
    }
}
