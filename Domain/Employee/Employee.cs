using Domain.ValueObjects;

namespace Domain.Employee
{
    public class Employee : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual EmployeeAddress EmployeeAddress { get; protected set; }

        public virtual Department Department { get; protected set; }

        public Employee(string name)
        {
            Name = name;
        }

        protected Employee() { }

        public virtual void SetName(string name)
        {
            Name = name;
        } 

        public virtual void AddEmployeeAddressDetails(EmployeeAddress employeeAddress)
        {
            EmployeeAddress = employeeAddress;
        }


        public virtual void AddEmployeeToDepartment(Department department)
        {
            Department = department;
        }

    }
}
