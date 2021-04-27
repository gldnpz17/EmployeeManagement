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
        public Guid EmployeedId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public List<EmployeeHistory> EmployeeHistories { get; set; } = new List<EmployeeHistory>();

        public Employee(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public void RecordHistory(IDateTimeService dateTimeService) 
        {
            EmployeeHistories.Add(new EmployeeHistory()
            {
                TimeStamp = dateTimeService.GetCurrentDateTime(),
                Name = Name,
                Position = Position.Name
            });
        }
    }
}
