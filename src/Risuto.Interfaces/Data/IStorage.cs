using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risuto.Models;

namespace Risuto.Data
{
    public interface IStorage
    {
        Task CreateDatabaseAsync();
        Task<int> InsertAsync<T>(T entity);
        Task<List<ShoppingList>> LoadSavedListsAsync();
    }
}
