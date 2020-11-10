using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Infracstruture.DataAccess.Repositories.Caontract
{
    public interface IBaseRepository
    {
        SqliteConnection OpenDbConnection();
        Task AddAsync<T>(T entity, string query);
        Task<IEnumerable<T>> FindAllAsync<T>(string query);
        Task UpdateAsync<T>(T entity, string query);
        Task DeleteAsync(string query);
    }
}
