using DomainModel.Services;
using EFCoreInMemory;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUnitTests.Employee.UpdateEmployee
{
    [TestFixture]
    public class Handler_HandleAsyncShould
    {
        [Test]
        public async Task HandleAsync_InputIsNormalCommand_ShouldUpdateEmployee()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.Empty,
                Name = "TestName",
                Position = "TestPosition"
            });
            await database.SaveChangesAsync();
            var handler = new Application.Employee.UpdateEmployee.Handler(database, GetDateTimeServiceMock());
            var command = new Application.Employee.UpdateEmployee.Command()
            {
                EmployeeId = Guid.Empty,
                Employee = new DomainModel.Entities.Employee()
                {
                    Name = "NewTestName",
                    Position = "NewTestPosition"
                }
            };

            await handler.HandleAsync(command);

            var result = database.Employees.FirstOrDefault(e => e.EmployeeId == Guid.Empty);
            Assert.AreEqual("NewTestName", result.Name);
            Assert.AreEqual("NewTestPosition", result.Position);
        }

        [Test]
        public async Task HandleAsync_InputIsNormalCommand_ShouldRecordHistory()
        {
            var database = new EmployeeManagementDbContext(Guid.NewGuid().ToString());
            var oldName = "TestName";
            var oldPosition = "TestPosition";
            database.Add(new DomainModel.Entities.Employee()
            {
                EmployeeId = Guid.Empty,
                Name = "TestName",
                Position = "TestPosition"
            });
            await database.SaveChangesAsync();
            var handler = new Application.Employee.UpdateEmployee.Handler(database, GetDateTimeServiceMock());
            var command = new Application.Employee.UpdateEmployee.Command()
            {
                EmployeeId = Guid.Empty,
                Employee = new DomainModel.Entities.Employee()
                {
                    Name = "NewTestName",
                    Position = "NewTestPosition"
                }
            };

            await handler.HandleAsync(command);

            var result = database.Employees.FirstOrDefault(e => e.EmployeeId == Guid.Empty);
            var history = result.EditHistories[0];

            Assert.AreEqual(DateTime.MinValue, history.TimeStamp);
            Assert.AreEqual(oldName, history.Name);
            Assert.AreEqual(oldPosition, history.Position);
        }

        private IDateTimeService GetDateTimeServiceMock()
        {
            var mock = new Mock<IDateTimeService>();

            mock.Setup(mock => mock.GetCurrentDateTime()).Returns(DateTime.MinValue);

            return mock.Object;
        }
    }
}
