using System;

namespace Contact_Management.Database.Entities
{
    public class CompanyEntity
    {
        public string Name { get; set; }
        public string VATIdNumber { get; set; }
        public string HeadQuarterAddress { get; set; }
        public string OtherAdresses { get; set; } // Semi colon delimited
    }
}
