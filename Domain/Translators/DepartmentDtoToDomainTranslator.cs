using Domain.DTO.Employee;
using Domain.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Translators
{
    public class DepartmentDtoToDomainTranslator : ITranslator<DepartmentDto, Department>
    {
        public Department Translate(DepartmentDto from, Department to)
        {
            var department = new Department(from.Name);
            return department;
        }
    }
}
