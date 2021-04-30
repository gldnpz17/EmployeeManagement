using DomainModel.Services;
using EFCoreInMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee.UpdateEmployee
{
    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly EmployeeManagementDbContext _dbContext;
        private readonly IDateTimeService _dateTimeService;

        public Handler(EmployeeManagementDbContext dbContext, IDateTimeService dateTimeService)
        {
            _dbContext = dbContext;
            _dateTimeService = dateTimeService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);

            // Validate employee data.
            if (request.Employee.Name == null || request.Employee.Name == "")
            {
                throw new ApplicationException("Employee name can't be empty.");
            }
            if (request.Employee.Position == null || request.Employee.Position == "")
            {
                throw new ApplicationException("Employee position can't be empty.");
            }

            employee.Name = request.Employee.Name;
            employee.Position = request.Employee.Position;

            employee.RecordHistory(_dateTimeService);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
