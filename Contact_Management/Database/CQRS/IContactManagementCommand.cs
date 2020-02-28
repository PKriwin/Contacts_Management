using System;
using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS
{
    public interface IContactManagementCommand
    {
        Task<Contact> CreateContactAsync(Contact ContactData);

        Task UpdateContactAsync(int Id, Contact ContactData);

        Task DeleteContactAsync(int Id);

        Task<Company> CreateCompanyAsync(Company CompanyData);

        Task UpdateCompanyAsync(int Id, Company CompanyData);
    }
}
