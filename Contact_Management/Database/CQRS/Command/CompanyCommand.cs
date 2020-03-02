using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Database.CQRS.Command
{
    public class CompanyCommand : ICompanyCommand
    {
        private readonly ContactManagementDBContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyCommand(ContactManagementDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Company> CreateCompanyAsync(Company companyData)
        {
            await _dbContext.Companies.AddAsync(companyData);
            await _dbContext.SaveChangesAsync();

            return companyData;
        }

        public async Task UpdateCompanyAsync(int id, Company companyData)
        {
            var companyToUpdate = await _dbContext.Companies
                .FirstAsync(c => c.Id == id);

            _mapper.Map(companyData, companyToUpdate);

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddContactToCompanyAsync(int id, int contactId)
        {
            await _dbContext.WorkingContracts.AddAsync(new WorkingContract
            {
                ContactId = contactId,
                CompanyId = id
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
