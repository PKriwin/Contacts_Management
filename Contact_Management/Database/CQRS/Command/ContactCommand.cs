using System;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Command
{
    public class ContactCommand : IContactCommand
    {
        private readonly ContactManagementDBContext _dbContext;
        private readonly Mapper _mapper;

        public ContactCommand(ContactManagementDBContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

            _mapper.Map(ContactData, ContactToUpdate);

            await _dbContext.SaveChangesAsync();
        }
    }
}
