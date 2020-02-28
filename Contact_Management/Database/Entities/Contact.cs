using System;
using System.Collections.Generic;

namespace Contact_Management.Database.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ContactType Type { get; set; }

        // Freelance Contacts fields
        public string VATIdNumber { get; set; }

        public ICollection<WorkingContract> WorkingContracts { get; set; }

        public enum ContactType
        {
            Employee,
            Freelancer
        }
    }
}
