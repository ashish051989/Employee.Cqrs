using Domain.DTO.Employee;
using Employee.Host.Api.WorkerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee.Host.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeController : ApiController
    {
        private readonly EmployeeControllerWorkerService workerService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EmployeeController()
        {
            this.workerService = new EmployeeControllerWorkerService();
        }

        /// <summary>
        /// Get Employee for specific employee Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Employee Data</returns>
        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            var result = workerService.GetEmployee(Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Add employee to database.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Http Response</returns>
        [HttpPost]
        public IHttpActionResult Post(EmployeeDto employee)
        {
            try
            {
                workerService.AddEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
