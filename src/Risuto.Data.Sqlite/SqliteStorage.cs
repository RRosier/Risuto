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
        private const string DatabaseName = "risuto";

        public async Task CreateDatabaseAsync()
        {
            var conn = new SQLiteAsyncConnection(DatabaseName);
            await conn.CreateTableAsync<ShoppingList>();
            await conn.CreateTableAsync<Item>();
        }

        public async Task<int> InsertAsync<T>(T entity)
        {
            var conn = new SQLiteAsyncConnection(DatabaseName);
            return await conn.InsertAsync(entity);
        }

        public Task<List<T>> QueryAllAsync<T>()
            where T : new()
        {
            var conn = new SQLiteAsyncConnection(DatabaseName);
            var query = conn.Table<T>();
            return query.ToListAsync();
        }
    }
}
