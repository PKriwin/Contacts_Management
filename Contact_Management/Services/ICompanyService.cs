using System.Threading.Tasks;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyAsync(int id);
        Task<Company> CreateCompanyAsync(CompanyCreation companyData);
        Task UpdateCompanyAsync(int id, CompanyUpdate companyData);
        Task<Company[]> GetAllCompaniesAsync();
        Task<Employee[]> GetAllEmployeesOfCompanyAsync(int companyId);
        Task<Freelancer[]> GetAllFreelancersOfCompanyAsync(int companyId);
    }
}
