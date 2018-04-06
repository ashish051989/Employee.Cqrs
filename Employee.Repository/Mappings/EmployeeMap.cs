using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Mappings
{
    public class EmployeeMap : ClassMap<Domain.Employee.Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Name).Not.Nullable();

            Component(x => x.EmployeeAddress, m =>
            {
                m.Map(x => x.Address1).Not.Nullable();
                m.Map(x => x.Address2);
                m.Map(x => x.Address3);
                m.Map(x => x.Pin);
            });


            References(x => x.Department)
                .Column("DepartmentId")
                .Not.LazyLoad();
            
            Table("Employee");
        }
    }
}
