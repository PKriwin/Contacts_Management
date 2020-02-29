using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Database.CQRS.Command;
using Contact_Management.Database.CQRS.Query;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _companyQuery;
        private readonly ICompanyCommand _companyCommand;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyQuery companyQuery, ICompanyCommand companyCommand, IMapper mapper)
        {
            _companyQuery = companyQuery;
            _companyCommand = companyCommand;
            _mapper = mapper;
        }

        public async Task<Company> CreateCompanyAsync(CompanyCreation companyData)
        {
            return _mapper.Map<Company>(
                await _companyCommand.CreateCompanyAsync(
                    _mapper.Map<Database.Entities.Company>(companyData)));
        }

        public async Task<Company[]> GetAllCompaniesAsync()
        {
            return (await _companyQuery.GetAllCompaniesAsync())
                .Select(c => _mapper.Map<Company>(c))
                .ToArray();
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return _mapper.Map<Company>(await _companyQuery.GetCompanyAsync(id));
        }

        public async Task UpdateCompanyAsync(int id, CompanyUpdate companyData)
        {
            await _companyCommand.UpdateCompanyAsync(id,
                _mapper.Map<Database.Entities.Company>(companyData));
        }
    }
}
