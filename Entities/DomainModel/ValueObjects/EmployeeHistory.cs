using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ValueObjects
{
    public class EmployeeHistory : ValueObject
    {
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TimeStamp;
            yield return Name;
            yield return Position;
        }
    }
}
