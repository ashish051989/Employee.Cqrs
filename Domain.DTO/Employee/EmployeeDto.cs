using Domain.DTO.ValueObjects;
using System;

namespace Domain.DTO.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public EmployeeAddressDto EmployeeAddress { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
