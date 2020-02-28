using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS
{
    public interface IContactManagementQuery
    {
        Task<Contact> GetContactAsync(int Id);
    }
}
