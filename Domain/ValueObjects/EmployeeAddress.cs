namespace Domain.ValueObjects
{
    public class EmployeeAddress
    {
        public string Address1 { get; protected set; }
        public string Address2 { get; protected set; }
        public string Address3 { get; protected set; }

        public string Pin { get; protected set; }

        public EmployeeAddress(string address1, string address2, string address3, string pin) : this()
        {
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            Pin = pin;
        }

        public EmployeeAddress() { }
    }
}
