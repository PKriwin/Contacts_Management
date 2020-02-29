using System;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Management.Database.CQRS.Command;
using Contact_Management.Database.CQRS.Query;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactQuery _contactQuery;
        private readonly IContactCommand _contactCommand;
        private readonly IMapper _mapper;

        public ContactService(IContactQuery contactQuery, IContactCommand contactCommand, IMapper mapper)
        {
            _contactQuery = contactQuery;
            _contactCommand = contactCommand;
            _mapper = mapper;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployeeData)
        {
            return _mapper.Map<Models.Employee>(
               await _contactCommand.CreateContactAsync(
                   _mapper.Map<Database.Entities.Contact>(newEmployeeData)));
        }

        public async Task<Freelancer> CreateFreelancerAsync(Freelancer newFreelancerData)
        {
            return _mapper.Map<Models.Freelancer>(
               await _contactCommand.CreateContactAsync(
                   _mapper.Map<Database.Entities.Contact>(newFreelancerData)));
        }

        public async Task DeleteEmployeeAsync(int Id)
        {
            await _contactCommand.DeleteContactAsync(Id);
        }

        public async Task DeleteFreelancerAsync(int Id)
        {
            await _contactCommand.DeleteContactAsync(Id);
        }

        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            return _mapper.Map<Employee>(await _contactQuery.GetContactAsync(Id));
        }

        public async Task<Freelancer> GetFreelancerAsync(int Id)
        {
            return _mapper.Map<Freelancer>(await _contactQuery.GetContactAsync(Id));
        }

        public async Task UpdateEmployeeAsync(int Id, Employee EmployeeData)
        {
            await _contactCommand.UpdateContactAsync(Id,
                _mapper.Map<Database.Entities.Contact>(EmployeeData));
        }

        public async Task UpdateFreelancerAsync(int Id, Freelancer FreelancerData)
        {
            await _contactCommand.UpdateContactAsync(Id,
                _mapper.Map<Database.Entities.Contact>(FreelancerData));
        }
    }
}
