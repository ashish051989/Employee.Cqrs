using EmployeeApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
    }
}
