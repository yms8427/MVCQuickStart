using System;

namespace BilgeAdam.Contracts
{
    public class NewEmployeeInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}