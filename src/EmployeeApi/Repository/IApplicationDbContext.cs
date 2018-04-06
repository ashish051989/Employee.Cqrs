using EmployeeApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employee { get; set; }
        int SaveChanges();
    }
}
