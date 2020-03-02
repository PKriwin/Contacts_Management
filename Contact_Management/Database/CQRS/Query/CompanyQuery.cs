using System.Linq;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Query
{
    public class CompanyQuery : ICompanyQuery
    {
        private readonly ContactManagementDBContext _dbContext;

        public CompanyQuery(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Company[]> GetAllCompaniesAsync()
        {
            return await _dbContext.Companies.ToArrayAsync();
        }

        public async Task<Company[]> GetCompaniesInContractWithAsync(int contactId)
        {
            return (await _dbContext.Contacts
                .Where(c => c.Id == contactId)
                    .Include(c => c.WorkingContracts)
                    .ThenInclude(wc => wc.Company)
                .FirstAsync())
                .WorkingContracts
                .Select(wc => wc.Company)
                .ToArray();
        }
    }
}
