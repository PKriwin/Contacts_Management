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
        private readonly IContactQuery _contactQuery;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyQuery companyQuery, ICompanyCommand companyCommand,
            IContactQuery contactQuery, IMapper mapper)
        {
            _companyQuery = companyQuery;
            _companyCommand = companyCommand;
            _contactQuery = contactQuery;
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

        public async Task<Employee[]> GetAllEmployeesOfCompanyAsync(int companyId)
        {
            return (await _contactQuery.GetContactsAsync(companyId, Database.Entities.Contact.ContactType.Employee))
                .Select(e => _mapper.Map<Employee>(e))
                .ToArray();
        }

        public async Task<Freelancer[]> GetAllFreelancersOfCompanyAsync(int companyId)
        {
            return (await _contactQuery.GetContactsAsync(companyId, Database.Entities.Contact.ContactType.Freelancer))
                .Select(e => _mapper.Map<Freelancer>(e))
                .ToArray();
        }

        public Task AddContactToCompanyAsync(int id, CompanyAddContact contactData)
        {
            return _companyCommand.AddContactToCompanyAsync(id, contactData.ContactId);
        }
    }
}
