using SQLite;
using SqlLite.Models;
using SqlLite.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.Repositories
{
    public class SQLiteContactRepository : IContactRepository
    {
        private SQLiteAsyncConnection _connection;

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
            await _connection.DeleteAsync(contact);
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
