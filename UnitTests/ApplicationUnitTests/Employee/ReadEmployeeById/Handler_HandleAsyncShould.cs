using EFCoreInMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationUnitTests.Employee.ReadEmployeeById
{
    [TestFixture]
    public class Handler_HandleAsyncShould
    {
        [Test]
        public async Task HandleAsync_InputIsNormalQuery_ShouldReturnProperEmployee()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Name = "TestName1",
                Position = "TestPosition1",
            });
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "TestName2",
                Position = "TestPosition2",
            });
            await database.SaveChangesAsync();
            var handler = new Application.Employee.ReadEmployeeById.Handler(database);
            var query = new Application.Employee.ReadEmployeeById.Query()
            {
                EmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            };

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(Guid.Parse("00000000-0000-0000-0000-000000000001"), result.EmployeeId);
        }
    }
}
