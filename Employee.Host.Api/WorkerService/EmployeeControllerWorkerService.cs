using CQRS.Commands;
using CQRS.Queries;
using Domain.DTO.Employee;
using Employee.Configuration;
using Employee.Host.Api.Messaging;
using Rebus.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Host.Api.WorkerService
{
    public class EmployeeControllerWorkerService
    {
        private readonly IBus bus;
        private readonly QueryBus queryBus;

        public EmployeeControllerWorkerService()
        {
            this.bus = ServiceLocator.Bus;
            queryBus = new QueryBus();
        }

        public void AddEmployee(EmployeeDto employee)
        {
            var command = new SaveEmployeeCommand(employee.Name, 
                employee.EmployeeAddress, employee.DepartmentId);

            bus.Send(command);
        }

        public EmployeeDto GetEmployee(Guid empId)
        {
            var query = new GetEmployeeQuery(empId);
            return queryBus.Execute<GetEmployeeQuery, EmployeeDto>(query);
        }
    }
}