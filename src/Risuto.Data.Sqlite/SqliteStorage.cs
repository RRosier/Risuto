using Risuto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risuto.Data.Sqlite
{
    public class SqliteStorage : IStorage
    {
        public async Task CreateDatabaseAsync()
        {
            var conn = new SQLiteAsyncConnection("risuto");
            await conn.CreateTableAsync<ShoppingList>().ContinueWith((results) =>
            {
                Debug.WriteLine("Table created!");
            });
        }

        public async Task<int> InsertAsync<T>(T entity)
        {
            var conn = new SQLiteAsyncConnection("risuto");
            return await conn.InsertAsync(entity);
        }

        public Task<List<ShoppingList>> LoadSavedListsAsync()
        {
            var conn = new SQLiteAsyncConnection("risuto");
            var query = conn.Table<ShoppingList>();
            return query.ToListAsync();
        }
    }
}
