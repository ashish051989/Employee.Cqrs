using CQRS.Core;
using System;

namespace CQRS.Queries
{
    public class GetEmployeeQuery : IQuery
    {
        public Guid employeeId { get; private set; }

        public GetEmployeeQuery(Guid id)
        {
            employeeId = id;
        }
    }
}
