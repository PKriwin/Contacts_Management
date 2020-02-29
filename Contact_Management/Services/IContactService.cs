using System;
using System.Threading.Tasks;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface IContactService
    {
        Task<Employee> GetEmployeeAsync(int Id);
        Task<Freelancer> GetFreelancerAsync(int Id);
        Task<Employee> CreateEmployeeAsync(Employee newEmployeeData);
        Task<Freelancer> CreateFreelancerAsync(Freelancer newFreelancerData);
        Task UpdateEmployeeAsync(int Id, Employee EmployeeData);
        Task UpdateFreelancerAsync(int Id, Freelancer FreelancerData);
        Task DeleteEmployeeAsync(int Id);
        Task DeleteFreelancerAsync(int Id);
    }
}
