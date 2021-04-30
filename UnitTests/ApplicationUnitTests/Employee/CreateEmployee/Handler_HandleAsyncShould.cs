using EFCoreInMemory;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests.Employee.CreateEmployee
{
    [TestFixture]
    public class Handler_HandleAsyncShould
    {
        [Test]
        public async Task HandleAsync_InputIsCreateCommand_ShouldSaveToDatabase()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            var handler = new Application.Employee.CreateEmployee.Handler(database);
            var command = new Application.Employee.CreateEmployee.Command()
            {
                Employee = new DomainModel.Entities.Employee()
                {
                    Name = "TestName",
                    Position = "TestPosition"
                }
            };

            await handler.HandleAsync(command);

            var result = await database.Employees.FirstOrDefaultAsync(
                employee => employee.Name == "TestName" && employee.Position == "TestPosition");

            Assert.NotNull(result);
        }
    }
}
