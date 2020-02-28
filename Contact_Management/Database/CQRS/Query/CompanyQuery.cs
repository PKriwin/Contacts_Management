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

        public async Task<Company> GetCompanyAsync(int Id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
