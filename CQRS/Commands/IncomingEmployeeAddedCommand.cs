using Memento;
using System;

namespace CQRS.Commands
{
    public class IncomingEmployeeAddedCommand : Command
    {
        public Guid EmployeeId { get; set; }

        public IncomingEmployeeAddedCommand(Guid empId)
        {
            EmployeeId = empId;
        }
    }
}
