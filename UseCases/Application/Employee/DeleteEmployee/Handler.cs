using Application.Common.Mediator;
using EFCoreInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.DeleteEmployee
{
    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly EmployeeManagementDbContext _dbContext;

        public Handler(EmployeeManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> HandleAsync(Command request)
        {
            throw new NotImplementedException();
        }
    }
}
