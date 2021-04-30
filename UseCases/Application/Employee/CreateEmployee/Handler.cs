using DomainModel.Services;
using EFCoreInMemory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee.CreateEmployee
{
    public class Handler : IRequestHandler<Command, DomainModel.Entities.Employee>
    {
        private readonly EmployeeManagementDbContext _dbContext;
        private readonly IDateTimeService _dateTimeService;

        public Handler(EmployeeManagementDbContext dbContext, IDateTimeService dateTimeService)
        {
            _dbContext = dbContext;
            _dateTimeService = dateTimeService;
        }

        public async Task<DomainModel.Entities.Employee> Handle(Command request, CancellationToken cancellationToken)
        {
            // Validate employee data.
            if (request.Employee.Name == null || request.Employee.Name == "")
            {
                throw new ApplicationException("Employee name can't be empty.");
            }
            if (request.Employee.Position == null || request.Employee.Position == "")
            {
                throw new ApplicationException("Employee position can't be empty.");
            }

            var newEmployeee = new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = request.Employee.Name,
                Position = request.Employee.Position
            };

            newEmployeee.RecordHistory(_dateTimeService);

            await _dbContext.Employees.AddAsync(newEmployeee);

            await _dbContext.SaveChangesAsync();

            return newEmployeee;
        }
    }
}
