using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Database.CQRS.Command;
using Contact_Management.Database.CQRS.Query;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _companyQuery;
        private readonly ICompanyCommand _companyCommand;
        private readonly Mapper _mapper;

        public CompanyService(ICompanyQuery companyQuery, ICompanyCommand companyCommand, Mapper mapper)
        {
            _companyQuery = companyQuery;
            _companyCommand = companyCommand;
            _mapper = mapper;
        }

        public async Task<Company> CreateCompanyAsync(Company companyData)
        {
            return _mapper.Map<Models.Company>(
                await _companyCommand.CreateCompanyAsync(
                    _mapper.Map<Database.Entities.Company>(companyData)));
        }

        public async Task<Company> GetCompanyAsync(int Id)
        {
            return _mapper.Map<Models.Company>(await _companyQuery.GetCompanyAsync(Id));
        }

        public async Task UpdateCompanyAsync(int Id, Company companyData)
        {
            await _companyCommand.UpdateCompanyAsync(Id,
                _mapper.Map<Database.Entities.Company>(companyData));
        }

        public async Task AddOtherAddressToCompanyAsync(int Id, string newOtherAddress)
        {
            var companyToUpdate = _mapper.Map<Models.Company>(await _companyQuery.GetCompanyAsync(Id));

            companyToUpdate.OtherAdresses.Add(newOtherAddress);

            await _companyCommand.UpdateCompanyAsync(Id,
                _mapper.Map<Database.Entities.Company>(companyToUpdate));
        }
    }
}
