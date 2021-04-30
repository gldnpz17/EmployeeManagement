using Application.Common.Mediator;
using EFCoreInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.CreateEmployee
{
    public class Handler : IRequestHandler<Command, DomainModel.Entities.Employee>
    {
        private readonly EmployeeManagementDbContext _dbContext;

        public Handler(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DomainModel.Entities.Employee> HandleAsync(Command request)
        {
            throw new NotImplementedException();
        }
    }
}
