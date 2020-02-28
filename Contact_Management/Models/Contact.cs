using System;
using System.Collections.Generic;

namespace Contact_Management.Models
{
    public abstract class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
