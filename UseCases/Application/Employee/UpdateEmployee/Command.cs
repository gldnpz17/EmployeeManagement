using Application.Common.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.UpdateEmployee
{
    public class Command : IRequest<Unit>
    {
        public Guid EmployeeId { get; set; }
        public DomainModel.Entities.Employee Employee { get; set; }
    }
}
