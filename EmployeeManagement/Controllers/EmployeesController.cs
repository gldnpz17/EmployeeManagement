using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Application.Common.Mediator;
using CreateEmployee = Application.Employee.CreateEmployee;
using ReadAllEmployees = Application.Employee.ReadAllEmployees;
using ReadEmployeeById = Application.Employee.ReadEmployeeById;
using UpdateEmployee = Application.Employee.UpdateEmployee;
using DeleteEmployee = Application.Employee.DeleteEmployee;
using AutoMapper;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IApplicationMediator _application;
        private readonly IMapper _mapper;

        public EmployeesController(IApplicationMediator application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to be created.</param>
        /// <returns>A summary of the created resource.</returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeQuerySimplified>> CreateEmployee([FromBody]EmployeeManipulate employee)
        {
            var result = await _application.SendAsync(new CreateEmployee.Command()
            {
                Employee = _mapper.Map<DomainModel.Entities.Employee>(employee)
            });

            return Created($"/employees/{result.EmployeeId}", _mapper.Map<EmployeeCreateResponse>(result));
        }

        /// <summary>
        /// Lists all employees.
        /// </summary>
        /// <returns>A summarized list of all employees.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeQuerySimplified>>> ReadAllEmployees()
        {
            var results = await _application.SendAsync(new ReadAllEmployees.Query());

            var mappedResult = new List<EmployeeQuerySimplified>();
            foreach (var result in results)
            {
                mappedResult.Add(_mapper.Map<EmployeeQuerySimplified>(result));
            }

            return Ok(mappedResult);
        }

        /// <summary>
        /// Fetches a detailed information about a particular employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        /// <returns>A detailed information on the employee.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeQueryDetailed>> ReadEmployeeById([FromRoute]Guid id)
        {
            var result = await _application.SendAsync(new ReadEmployeeById.Query()
            {
                EmployeeId = id
            });

            return Ok(_mapper.Map<EmployeeQueryDetailed>(result));
        }

        /// <summary>
        /// Updates the information about a particular employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        /// <param name="employee">The employee data to be updated.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute]Guid id, [FromBody]EmployeeManipulate employee)
        {
            var newEmployeeData = _mapper.Map<DomainModel.Entities.Employee>(employee);

            await _application.SendAsync(new UpdateEmployee.Command()
            {
                EmployeeId = id,
                Employee = newEmployeeData
            });

            return Ok();
        }

        /// <summary>
        /// Erases the data of an employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _application.SendAsync(new DeleteEmployee.Command()
            {
                EmployeeId = id
            });

            return Ok();
        }
    }
}
