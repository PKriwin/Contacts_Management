using System;
using System.Threading.Tasks;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface IContactService
    {
        Task<Employee> GetEmployeeAsync(int Id);
        Task<Freelancer> GetFreelancerAsync(int Id);
        Task<Employee> CreateEmployeeAsync(EmployeeCreation newEmployeeData);
        Task<Freelancer> CreateFreelancerAsync(FreelancerCreation newFreelancerData);
        Task UpdateEmployeeAsync(int Id, EmployeeUpdate EmployeeData);
        Task UpdateFreelancerAsync(int Id, FreelancerUpdate FreelancerData);
        Task DeleteEmployeeAsync(int Id);
        Task DeleteFreelancerAsync(int Id);
    }
}
