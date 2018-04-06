using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.Employee;
using Domain.Employee;

namespace Domain.Translators
{
    public class EmployeeDomainToDtoTranslator : ITranslator<Employee.Employee, DTO.Employee.EmployeeDto>
    {
        public EmployeeDto Translate(Employee.Employee from, EmployeeDto to)
        {
            to.Id = from.Id;
            to.Name = from.Name;
            to.DepartmentId = from.Department.Id;
            to.EmployeeAddress = new DTO.ValueObjects.EmployeeAddressDto
            {
                AddressLine1 = from.EmployeeAddress.Address1,
                AddressLine2 = from.EmployeeAddress.Address2,
                AddressLine3 = from.EmployeeAddress.Address3,
                Pin = from.EmployeeAddress.Pin
            };

            return to;
        }
    }
}
