using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ValueObjects
{
    public class EditHistory : ValueObject
    {
        public virtual DateTime TimeStamp { get; set; }
        public virtual string Name { get; set; }
        public virtual string Position { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TimeStamp;
            yield return Name;
            yield return Position;
        }
    }
}
