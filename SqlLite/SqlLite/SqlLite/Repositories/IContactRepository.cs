using SqlLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Repositories
{
    /// <summary>
    /// No App real crie um Genético: IRepository<T> where T : class
    /// </summary>
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContact(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(Contact contact);
    }
}
