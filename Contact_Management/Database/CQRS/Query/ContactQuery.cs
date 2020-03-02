using System.Linq;
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

        public async Task<Contact> GetContactAsync(int id, Contact.ContactType type)
        {
            return await _dbContext.Contacts
                .FirstOrDefaultAsync(c => (c.Id == id) && (c.Type.Equals(type)));
        }

        public async Task<Contact[]> GetContactsAsync(Contact.ContactType type)
        {
            return await _dbContext.Contacts
                .Where(c => c.Type.Equals(type))
                .ToArrayAsync();
        }

        public async Task<Contact[]> GetContactsAsync(int companyId, Contact.ContactType type)
        {
            return await _dbContext.Contacts
                .Where(c => c.Type.Equals(type))
                .Include(c => c.WorkingContracts)
                .Where(c => c.WorkingContracts.Any(wc => wc.CompanyId == companyId))
                .ToArrayAsync();
        }
    }
}
