using DomainModel.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelUnitTests.Entities
{
    [TestFixture]
    public class Employee_EmployeeShould
    {
        [Test]
        public void Employee_InputIsConstructorArgs_ShouldProperlyInitialize()
        {
            var employee = new Employee(Guid.Empty, "TestName", "TestPosition");

            Assert.AreEqual(employee.EmployeeId, Guid.Empty);
            Assert.AreEqual(employee.Name, "TestName");
            Assert.AreEqual(employee.Position, "TestPosition");
        }
    }
}
