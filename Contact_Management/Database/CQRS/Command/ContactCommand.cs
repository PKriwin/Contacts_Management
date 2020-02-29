using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Command
{
    public class ContactCommand : IContactCommand
    {
        private readonly ContactManagementDBContext _dbContext;
        private readonly IMapper _mapper;

        public ContactCommand(ContactManagementDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Contact> CreateContactAsync(Contact contactData)
        {
            await _dbContext.Contacts.AddAsync(contactData);
            await _dbContext.SaveChangesAsync();

            return contactData;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contactToDelete = await _dbContext.Contacts
                .FirstAsync(c => c.Id == id);

            _dbContext.Contacts.Remove(contactToDelete);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(int id, Contact contactData)
        {
            var contactToUpdate = await _dbContext.Contacts
                .FirstAsync(c => c.Id == id);

            _mapper.Map(contactData, contactToUpdate);

            await _dbContext.SaveChangesAsync();
        }
    }
}
