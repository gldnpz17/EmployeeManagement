using EFCoreInMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests.Employee.ReadAllEmployees
{
    [TestFixture]
    public class Handler_HandlerAsyncShould
    {
        [Test]
        public async Task HandleAsync_InputIsNormalQuery_ShouldReturnAllEmployees()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = "TestName1",
                Position = "TestPosition1",
            });
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = "TestName2",
                Position = "TestPosition2",
            });
            await database.SaveChangesAsync();
            var handler = new Application.Employee.ReadAllEmployees.Handler(database);
            var query = new Application.Employee.ReadAllEmployees.Query();

            var results = await handler.HandleAsync(query);

            Assert.AreEqual(2, results.Count);
        }
    }
}
