using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Command
{
    public interface ICompanyCommand
    {
        Task<Company> CreateCompanyAsync(Company CompanyData);

        Task UpdateCompanyAsync(int Id, Company CompanyData);
    }
}
