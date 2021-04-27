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
            var position = new Position()
            {
                Name = "TestPosition"
            };

            var employee = new Employee("TestName", position);

            Assert.AreEqual(employee.Name, "TestName");
            Assert.AreSame(employee.Position, position);
        }
    }
}
