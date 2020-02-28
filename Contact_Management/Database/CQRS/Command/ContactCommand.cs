using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS
{
    public class ContactCommand : IContactCommand
    {
        private readonly ContactManagementDBContext _dbContext;

        public ContactCommand(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> CreateContactAsync(Contact ContactData)
        {
            await _dbContext.Contacts.AddAsync(ContactData);
            await _dbContext.SaveChangesAsync();

            return ContactData;
        }

        public async Task DeleteContactAsync(int Id)
        {
            var contactToDelete = await _dbContext.Contacts
                .FirstAsync(c => c.Id == Id);

            _dbContext.Contacts.Remove(contactToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(int Id, Contact ContactData)
        {
            var ContactToUpdate = await _dbContext.Contacts
                .FirstAsync(c => c.Id == Id);

            ContactToUpdate.FirstName = ContactData.FirstName;
            ContactToUpdate.LastName = ContactData.LastName;
            ContactToUpdate.Address = ContactData.Address;
            ContactToUpdate.Type = ContactData.Type;
            ContactToUpdate.VATIdNumber = ContactData.VATIdNumber;

            await _dbContext.SaveChangesAsync();
        }
    }
}
