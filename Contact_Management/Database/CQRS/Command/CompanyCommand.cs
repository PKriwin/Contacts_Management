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

            _mapper.Map(CompanyData, CompanyToUpdate);

            await _dbContext.SaveChangesAsync();
        }
    }
}
