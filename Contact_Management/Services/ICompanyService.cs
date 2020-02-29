using System;
using System.Threading.Tasks;
using Contact_Management.Models;

namespace Contact_Management.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyAsync(int Id);
        Task<Company> CreateCompanyAsync(Company companyData);
        Task UpdateCompanyAsync(int Id, Company companyData);
        Task AddOtherAddressToCompanyAsync(int Id, string newOtherAddress)
    }
}
