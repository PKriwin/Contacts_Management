﻿using System.ComponentModel.DataAnnotations;

namespace Contact_Management.Controllers.DTO.Request
{
    public class ContactUpdate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
