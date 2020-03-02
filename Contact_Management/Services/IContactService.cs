using System.Threading.Tasks;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface IContactService
    {
        Task<Employee> GetEmployeeAsync(int id);
        Task<Freelancer> GetFreelancerAsync(int id);
        Task<Employee[]> GetAllEmployeesAsync();
        Task<Freelancer[]> GetAllFreelancersAsync();
        Task<Company[]> GetEmployeeEmployersAsync(int employeeId);
        Task<Company[]> GetFreelancerClientsAsync(int freelancerId);
        Task<Employee> CreateEmployeeAsync(EmployeeCreation newEmployeeData);
        Task<Freelancer> CreateFreelancerAsync(FreelancerCreation newFreelancerData);
        Task UpdateEmployeeAsync(int id, EmployeeUpdate employeeData);
        Task UpdateFreelancerAsync(int id, FreelancerUpdate freelancerData);
        Task DeleteEmployeeAsync(int id);
        Task DeleteFreelancerAsync(int id);
    }
}
