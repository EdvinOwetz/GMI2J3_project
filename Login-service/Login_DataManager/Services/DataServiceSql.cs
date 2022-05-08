using Dapper;
using LoginDomain.Services;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_DataManager.Services
{
    public class DataServiceSql : IDataServiceSql
    {

        private string LoadConnectionString(string id = "Default")
        {

            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }

        public async Task<int> DeleteDataAsync<T>(T account, string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return await cnn.ExecuteAsync(sql, account);
            }
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryAsync<T>(sql, new DynamicParameters());
                return await output;
            }
        }

        public async Task<int> SaveDataAsync<T>(T account, string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return await cnn.ExecuteAsync(sql, account);
            }
        }

        public async Task<int> UpdateDataAsync<T>(T account, string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return await cnn.ExecuteAsync(sql, account);
            }
        }
    }
}
