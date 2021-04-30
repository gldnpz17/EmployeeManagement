using Application.Common.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.ReadAllEmployees
{
    public class Query : IRequest<IList<DomainModel.Entities.Employee>>
    {

    }
}
