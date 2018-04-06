using System.Threading.Tasks;
using CQRS.Core;
using CQRS.Queries;
using Domain.DTO.Employee;
using Employee.Repository.Repositories.NonPersistentRepository;
using Employee.Repository.Repositories.PersistentRepository.Implementation;
using Domain.Extensions;
using Domain.Translators;

namespace CQRS.QueryHandlers
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, EmployeeDto>
    {
        private readonly EmployeeReadOnlyRepository repository;
        private readonly ITranslator<Domain.Employee.Employee, EmployeeDto> employeeDtoTranslator;

        public GetEmployeeQueryHandler(EmployeeReadOnlyRepository repository,
            ITranslator<Domain.Employee.Employee, EmployeeDto> employeeDtoTranslator)
        {
            this.repository = repository;
            this.employeeDtoTranslator = employeeDtoTranslator;
        }

        public EmployeeDto Execute(GetEmployeeQuery query)
        {
            var employee = repository.GetById<Domain.Employee.Employee>(query.employeeId);
            return employeeDtoTranslator.Translate(employee);
        }
    }
}
