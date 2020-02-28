using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS
{
    public class ContactManagementQuery : IContactManagementQuery
    {
        private readonly ContactManagementDBContext _dbContext;

        public ContactManageQuery(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> GetContactAsync(int Id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
