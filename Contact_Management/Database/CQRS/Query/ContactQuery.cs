using System.Threading.Tasks;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Query
{
    public class ContactQuery : IContactQuery
    {
        private readonly ContactManagementDBContext _dbContext;

        public ContactQuery(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> GetContactAsync(int Id, Contact.ContactType type)
        {
            return await _dbContext.Contacts
                .FirstOrDefaultAsync(c => (c.Id == Id) && (c.Type.Equals(type)));
        }
    }
}
