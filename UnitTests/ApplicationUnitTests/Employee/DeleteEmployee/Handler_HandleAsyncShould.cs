using EFCoreInMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests.Employee.DeleteEmployee
{
    [TestFixture]
    public class Handler_HandleAsyncShould
    {
        [Test]
        public async Task HandleAsync_InputIsNormalData_ShouldDeletFromDatabase()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            database.Employees.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.Empty,
                Name = "TestName",
                Position = "TestPosition"
            });
            await database.SaveChangesAsync();
            var handler = new Application.Employee.DeleteEmployee.Handler(database);
            var command = new Application.Employee.DeleteEmployee.Command()
            {
                EmployeeId = Guid.Empty
            };

            await handler.HandleAsync(command);

            Assert.AreEqual(0, database.Employees.Count());
        }
    }
}
