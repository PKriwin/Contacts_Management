using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Database.CQRS.Command;
using Contact_Management.Database.CQRS.Query;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactQuery _contactQuery;
        private readonly IContactCommand _contactCommand;
        private readonly ICompanyQuery _companyQuery;
        private readonly IMapper _mapper;

        public ContactService(IContactQuery contactQuery, IContactCommand contactCommand,
            ICompanyQuery companyQuery, IMapper mapper)
        {
            _contactQuery = contactQuery;
            _contactCommand = contactCommand;
            _companyQuery = companyQuery;
            _mapper = mapper;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeCreation newEmployeeData)
        {
            return _mapper.Map<Models.Employee>(
               await _contactCommand.CreateContactAsync(
                   _mapper.Map<Database.Entities.Contact>(newEmployeeData)));
        }

        public async Task<Freelancer> CreateFreelancerAsync(FreelancerCreation newFreelancerData)
        {
            return _mapper.Map<Models.Freelancer>(
               await _contactCommand.CreateContactAsync(
                   _mapper.Map<Database.Entities.Contact>(newFreelancerData)));
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _contactCommand.DeleteContactAsync(id);
        }

        public async Task DeleteFreelancerAsync(int id)
        {
            await _contactCommand.DeleteContactAsync(id);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return _mapper.Map<Employee>(await _contactQuery.GetContactAsync(id,
                Database.Entities.Contact.ContactType.Employee));
        }

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            return (await _contactQuery.GetContactsAsync(Database.Entities.Contact.ContactType.Employee))
                .Select(e => _mapper.Map<Employee>(e))
                .ToArray();
        }

        public async Task<Freelancer[]> GetAllFreelancersAsync()
        {
            return (await _contactQuery.GetContactsAsync(Database.Entities.Contact.ContactType.Freelancer))
                .Select(f => _mapper.Map<Freelancer>(f))
                .ToArray();
        }

        public async Task<Freelancer> GetFreelancerAsync(int id)
        {
            return _mapper.Map<Freelancer>(await _contactQuery.GetContactAsync(id,
                Database.Entities.Contact.ContactType.Freelancer));
        }

        public async Task<Company[]> GetEmployeeEmployersAsync(int employeeId)
        {
            return (await _companyQuery.GetCompaniesInContractWithAsync(employeeId))
                .Select(c => _mapper.Map<Company>(c))
                .ToArray();
        }

        public async Task<Company[]> GetFreelancerClientsAsync(int freelancerId)
        {
            return (await _companyQuery.GetCompaniesInContractWithAsync(freelancerId))
                .Select(c => _mapper.Map<Company>(c))
                .ToArray();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeUpdate EmployeeData)
        {
            await _contactCommand.UpdateContactAsync(id,
                _mapper.Map<Database.Entities.Contact>(EmployeeData));
        }

        public async Task UpdateFreelancerAsync(int id, FreelancerUpdate FreelancerData)
        {
            await _contactCommand.UpdateContactAsync(id,
                _mapper.Map<Database.Entities.Contact>(FreelancerData));
        }
    }
}
