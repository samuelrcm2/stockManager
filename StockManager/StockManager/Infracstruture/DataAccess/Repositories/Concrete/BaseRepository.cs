using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using StockManager.Infracstruture.DataAccess.Repositories.Caontract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Infracstruture.DataAccess.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IConfiguration _configuraition;
        public BaseRepository(IConfiguration configuration)
        {
            _configuraition = configuration;
        }

        public SqliteConnection OpenDbConnection()
        {
            string path = _configuraition["DatabaseConnectionString"];
            return new SqliteConnection(_configuraition["DatabaseConnectionString"]);
        }

        public async Task AddAsync<T>(T entity, string query)
        {
            using (var connection = OpenDbConnection())
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.ExecuteAsync(query, entity);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<IEnumerable<T>> FindAllAsync<T>(string query)
        {
            using (var connection = OpenDbConnection())
            {
                try
                {
                    await connection.OpenAsync();
                    return (await connection.QueryAsync<T>(query)).ToList();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task UpdateAsync<T>(T entity, string query)
        {
            using (var connection = OpenDbConnection())
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.ExecuteAsync(query, entity);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task DeleteAsync(string query)
        {
            using (var connection = OpenDbConnection())
            {
                try
                {
                    await connection.OpenAsync();
                    await connection.ExecuteAsync(query);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
