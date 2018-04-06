using EmployeeApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext dbContext;

        public EmployeeRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Employee employee)
        {
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
        }
    }
}
