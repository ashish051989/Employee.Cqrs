using CQRS.Commands;
using CQRS.Core;
using Domain.DTO.Employee;
using Domain.DTO.ValueObjects;
using Domain.Employee;
using Domain.Extensions;
using Domain.Translators;
using Domain.ValueObjects;
using Employee.Repository.Repositories.PersistentRepository.Implementation;
using System.Threading.Tasks;

namespace CQRS.CommandHandlers
{
    public class SaveEmployeeHandler : ICommandHandler<SaveEmployeeCommand>
    {
        private readonly EmployeeRepository repository;
        private readonly ITranslator<EmployeeAddressDto, EmployeeAddress> employeeAddressDtoTranslator;

        public SaveEmployeeHandler(EmployeeRepository repository,
            ITranslator<EmployeeAddressDto, EmployeeAddress> employeeDtoTranslator)
        {
            this.repository = repository;
            this.employeeAddressDtoTranslator = employeeDtoTranslator;
        }

        public Task Handle(SaveEmployeeCommand message)
        {
            return Task.Factory.StartNew(() =>
            {
                var department = new Department(message.DepartmentId);

                var emp = new Domain.Employee.Employee(message.EmpName);
                emp.AddEmployeeAddressDetails(employeeAddressDtoTranslator.Translate(message.EmployeeAddress));
                emp.AddEmployeeToDepartment(department);                

                repository.Add(emp);
            });
        }
    }
}
