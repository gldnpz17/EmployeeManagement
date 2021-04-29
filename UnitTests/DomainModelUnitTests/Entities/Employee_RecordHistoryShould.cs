using DomainModel.Entities;
using DomainModel.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelUnitTests.Entities
{
    [TestFixture]
    public class Employee_RecordHistoryShould
    {
        [Test]
        public void RecordHistory_InputIsRegularData_ShouldntThrowException()
        {
            var employee = CreateEmployee();

            Assert.DoesNotThrow(() =>
            {
                employee.RecordHistory(CreateDateTimeServiceMock().Object);
            });
        }

        [Test]
        public void RecordHistory_InputIsRegularData_ShouldCreateHistory()
        {
            var employee = CreateEmployee();

            employee.RecordHistory(CreateDateTimeServiceMock().Object);

            Assert.IsTrue(employee.EditHistories.Count == 1);
        }

        [Test]
        public void RecordHistory_InputIsRegularData_ShouldSaveProperData()
        {
            var employee = CreateEmployee();
            var dateTimeService = CreateDateTimeServiceMock().Object;

            employee.RecordHistory(dateTimeService);
            var history = employee.EditHistories[0];

            Assert.IsTrue(history.TimeStamp == dateTimeService.GetCurrentDateTime());
            Assert.IsTrue(history.Name == employee.Name);
            Assert.IsTrue(history.Position == employee.Position);
        }

        private Employee CreateEmployee()
        {
            return new Employee("TestName", "TestPosition");
        }

        private Mock<IDateTimeService> CreateDateTimeServiceMock()
        {
            var mock = new Mock<IDateTimeService>();

            mock.Setup(service => service.GetCurrentDateTime()).Returns(DateTime.MinValue);

            return mock;
        }
    }
}
