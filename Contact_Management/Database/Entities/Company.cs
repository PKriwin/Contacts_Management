using System;
using System.Collections.Generic;

namespace Contact_Management.Database.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VATIdNumber { get; set; }
        public string HeadQuarterAddress { get; set; }
        public string OtherAdresses { get; set; } // Semi colon delimited

        public ICollection<WorkingContract> WorkingContracts { get; set; }
    }
}
