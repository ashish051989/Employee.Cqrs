using Domain.ValueObjects;
using System;

namespace Domain.Employee
{
    public class Department : AggregateRoot
    {
        public virtual string Name { get; protected set; }

        public virtual EmployeeAddress EmployeeAddress { get; protected set; }

        public virtual Employee Employee { get; protected set; }

        public Department(string name) : this()
        {
            Name = name;
        }

        public Department(Guid id) : this()
        {
            Id = id;
        }

        public Department(string name, Employee employee,
            EmployeeAddress employeeAddress) : this()
        {
            Name = name;
            Employee = employee;
            EmployeeAddress = employeeAddress;
        }

        public Department() { }
    }
}
