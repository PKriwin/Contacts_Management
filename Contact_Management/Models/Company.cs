using System;
using System.Collections.Generic;

namespace Contact_Management.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string VATIdNumber { get; set; }
        public string HeadQuarterAddress { get; set; }
        public List<string> OtherAdresses { get; set; }
    }
}
