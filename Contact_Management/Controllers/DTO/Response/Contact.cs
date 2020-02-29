namespace Contact_Management.Controllers.DTO.Response
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public class ContactType
        {
            public const string Employee = "Employee";
            public const string Freelancer = "Freelancer";
        }
    }
}
