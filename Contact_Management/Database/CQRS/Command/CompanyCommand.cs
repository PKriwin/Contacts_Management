using System.Threading.Tasks;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Command
{
    public class CompanyCommand : ICompanyCommand
    {
        private readonly ContactManagementDBContext _dbContext;

        public CompanyCommand(ContactManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> CreateCompanyAsync(Company CompanyData)
        {
            await _dbContext.Companies.AddAsync(CompanyData);
            await _dbContext.SaveChangesAsync();

            return CompanyData;
        }

        public async Task UpdateCompanyAsync(int Id, Company CompanyData)
        {
            var CompanyToUpdate = await _dbContext.Companies
                .FirstAsync(c => c.Id == Id);

            CompanyToUpdate.Name = CompanyData.Name;
            CompanyToUpdate.VATIdNumber = CompanyData.VATIdNumber;
            CompanyToUpdate.HeadQuarterAddress = CompanyData.HeadQuarterAddress;
            CompanyToUpdate.OtherAdresses = CompanyData.OtherAdresses;

            await _dbContext.SaveChangesAsync();
        }
    }
}
