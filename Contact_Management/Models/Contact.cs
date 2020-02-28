using System;

namespace Contact_Management.Models
{
    public abstract class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
