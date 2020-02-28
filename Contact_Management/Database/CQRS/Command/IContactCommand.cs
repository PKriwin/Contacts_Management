using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Command
{
    public interface IContactCommand
    {
        Task<Contact> CreateContactAsync(Contact ContactData);
        Task UpdateContactAsync(int Id, Contact ContactData);
        Task DeleteContactAsync(int Id);
    }
}
