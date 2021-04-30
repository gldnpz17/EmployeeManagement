﻿using Application.Common.Mediator;
using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
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
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);

            if (employee == null)
            {
                throw new ApplicationException("Cannot find an employee with the given ID.");
            }

            _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync();

            return Unit.Void;
        }
    }
}
