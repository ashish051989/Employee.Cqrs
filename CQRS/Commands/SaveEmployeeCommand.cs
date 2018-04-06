using Domain.DTO.Employee;
using Domain.DTO.ValueObjects;
using Memento;
using System;

namespace CQRS.Commands
{
    public class SaveEmployeeCommand : Command
    {
        public string EmpName { get; private set; }

        public EmployeeAddressDto EmployeeAddress { get; private set; }

        public Guid DepartmentId { get; private set; }

        public SaveEmployeeCommand(string empName, 
            EmployeeAddressDto employeeAddress,
            Guid departmentId)
        {
            EmpName = empName;
            EmployeeAddress = employeeAddress;
            DepartmentId = departmentId;
        }
    }
}
