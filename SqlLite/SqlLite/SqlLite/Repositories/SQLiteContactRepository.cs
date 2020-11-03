using SQLite;
using SqlLite.Models;
using SqlLite.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlLite.Repositories
{
    public class SQLiteContactRepository : IContactRepository
    {
        private SQLiteAsyncConnection _connection;
        private Object MyCloudAPI;
        public SQLiteContactRepository(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }
        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }
        public async Task DeleteContact(Contact contact)
        {
            try
            {
                //Delete Local
                await _connection.DeleteAsync(contact);
                //Delete na API
                //MyCloudAPI.Delete(contact);
                //if (Nao deletou )
                //{
                //contact.IsSync = false;
                     //rollback
                //}
                
            }
            catch (Exception)
            {
                //reverter tudo
                throw;
            }
           

        }
        public async Task AddContact(Contact contact)
        {
            await _connection.InsertAsync(contact);
        }
        public async Task UpdateContact(Contact contact)
        {
            await _connection.UpdateAsync(contact);
        }
        public async Task<Contact> GetContact(int id)
        {
            return await _connection.FindAsync<Contact>(id);
        }
    }
}
