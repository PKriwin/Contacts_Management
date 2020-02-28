using System;
namespace Contact_Management.Database.Entities
{
    public class WorkingContract
    {
        public int ContactId { get; set; }
        public int CompanyId { get; set; }

        public Contact Contact { get; set; }
        public Company Company { get; set; }
    }
}
