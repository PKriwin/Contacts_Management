using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Query
{
    public interface ICompanyQuery
    {
        Task<Company> GetCompanyAsync(int Id);
        Task<Company[]> GetAllCompaniesAsync();
    }
}
