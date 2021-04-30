using Application.Common.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.ReadEmployeeById
{
    public class Query : IRequest<DomainModel.Entities.Employee>
    {
        public Guid EmployeeId { get; set; }
    }
}
