using Domain.Employee;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Mappings
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id)
                .Column("DepartmentId");

            Map(x => x.Name);
        }
    }
}
