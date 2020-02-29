using System.Threading.Tasks;
using Contact_Management.Controllers.DTO.Request;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyAsync(int Id);
        Task<Company> CreateCompanyAsync(CompanyCreation companyData);
        Task UpdateCompanyAsync(int Id, CompanyUpdate companyData);
        Task<Company[]> GetAllCompaniesAsync();
    }
}
