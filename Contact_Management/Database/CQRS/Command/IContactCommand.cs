using System.Threading.Tasks;
using Contact_Management.Database.Entities;

namespace Contact_Management.Database.CQRS.Command
{
    public interface IContactCommand
    {
        Task<Contact> CreateContactAsync(Contact contactData);
        Task UpdateContactAsync(int id, Contact contactData);
        Task DeleteContactAsync(int id);
    }
}
