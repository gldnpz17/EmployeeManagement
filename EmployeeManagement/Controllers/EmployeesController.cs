using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to be created.</param>
        /// <returns>A summary of the created resource.</returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeQuerySimplified>> CreateEmployee([FromBody]EmployeeManipulate employee)
        {
            return Created($"/employees/{Guid.Empty}", new EmployeeQuerySimplified() 
            {
                Id = Guid.Empty,
                Name = "Lorem Ipsum"
            });
        }

        /// <summary>
        /// Lists all employees.
        /// </summary>
        /// <returns>A summarized list of all employees.</returns>
        [HttpGet]
        public async Task<ActionResult> ReadAllEmployees()
        {
            return Ok(new List<EmployeeQuerySimplified>()
            {
                new EmployeeQuerySimplified()
                {
                    Id = Guid.Empty,
                    Name = "Lorem Ipsum"
                },
                new EmployeeQuerySimplified()
                {
                    Id = Guid.Empty,
                    Name = "Dolor Sit Amet"
                }
            });
        }

        /// <summary>
        /// Fetches a detailed information about a particular employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        /// <returns>A detailed information on the employee.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> ReadEmployeeById([FromRoute]Guid id)
        {
            return Ok(new EmployeeQueryDetailed()
            {
                Id = id,
                Name = "Lorem Ipsum",
                Position = "Consectetur",
                EditHistories = new List<EditHistory>()
                {
                    new EditHistory()
                    {
                        Timestamp = DateTime.MinValue,
                        Name = "Wrong Name",
                        Position = "Wrong Position"
                    },
                    new EditHistory()
                    {
                        Timestamp = DateTime.MinValue.AddDays(1),
                        Name = "Wrong Name Again",
                        Position = "Wrong Position Again"
                    }
                }
            });
        }

        /// <summary>
        /// Updates the information about a particular employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        /// <param name="employee">The employee data to be updated.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute]Guid id, [FromBody]EmployeeManipulate employee)
        {
            return Ok();
        }

        /// <summary>
        /// Erases the data of an employee.
        /// </summary>
        /// <param name="id">The ID of the employee (GUID or UUID).</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
