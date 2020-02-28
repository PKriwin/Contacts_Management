using System;

namespace Contact_Management.Models
{
    public class Company
    {
        public string Name {get; set;}
        public string VATIdNumber { get; set; }
        public string HeadQuarterAddress { get; set; }
        public string[] OtherAdresses { get; set; }
    }
}
