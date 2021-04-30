using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.CreateEmployee
{
    public class Command : IRequest<DomainModel.Entities.Employee>
    {
        public DomainModel.Entities.Employee Employee { get; set; }
    }
}
