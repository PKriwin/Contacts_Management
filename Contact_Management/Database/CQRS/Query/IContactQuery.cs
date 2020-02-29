using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Query
{
    public interface IContactQuery
    {
        Task<Contact> GetContactAsync(int id, Contact.ContactType type);
        Task<Contact[]> GetContactsAsync(Contact.ContactType type);
    }
}
