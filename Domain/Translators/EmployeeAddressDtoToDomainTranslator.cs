using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.ValueObjects;

namespace Domain.Translators
{
    public class EmployeeAddressDtoToDomainTranslator : ITranslator<EmployeeAddressDto, EmployeeAddress>
    {
        public EmployeeAddress Translate(EmployeeAddressDto from, EmployeeAddress to)
        {
            var empAddress = new EmployeeAddress(from.AddressLine1, from.AddressLine2,
                from.AddressLine3, from.Pin);

            return empAddress;
        }
    }
}
