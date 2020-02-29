using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Command
{
    public interface ICompanyCommand
    {
        Task<Company> CreateCompanyAsync(Company companyData);
        Task UpdateCompanyAsync(int id, Company companyData);
    }
}
