using DomainModel.Services;
using DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<EditHistory> EditHistories { get; set; } = new List<EditHistory>();

        public Employee() { }

        public Employee(Guid employeeId, string name, string position)
        {
            EmployeeId = employeeId;
            Name = name;
            Position = position;
        }

        public void RecordHistory(IDateTimeService dateTimeService) 
        {
            EditHistories.Add(new EditHistory()
            {
                TimeStamp = dateTimeService.GetCurrentDateTime(),
                Name = Name,
                Position = Position
            });
        }
    }
}
