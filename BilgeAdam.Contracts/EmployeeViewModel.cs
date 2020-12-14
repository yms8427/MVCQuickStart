using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeAdam.Contracts
{
    public class EmployeeViewModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
