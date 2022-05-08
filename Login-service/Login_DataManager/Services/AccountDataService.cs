using LoginDomain.Models;
using LoginDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_DataManager.Services
{
    public class AccountDataService : IAccountDataService
    {
        private readonly IDataServiceSql _database;

        public AccountDataService(IDataServiceSql database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Account>> LoadAccountAsync()
        {
            string sql = "select * from Account";
            var output = await _database.LoadDataAsync<Account>(sql);
            return output;
        }

        public async Task<int> SavePersonAsync(Account account)
        {
            string sql = "insert into Account (UserName, PasswordHash, Email, DateJoined) " +
                "values (@UserName, @PasswordHash, @Email, @DateJoined)";

            sql = sql.Replace("@UserName", $"'{ account.UserName }'");
            sql = sql.Replace("@PasswordHash", $"'{ account.PasswordHash }'");
            sql = sql.Replace("@Email", $"'{ account.Email }'");
            sql = sql.Replace("@DateJoined", $"'{ account.DateJoined }'");

            return await _database.SaveDataAsync(account, sql);
        }

        public async Task<int> UpdatePersonAsync(Account account)
        {
            string sql = "update Account set UserName = @UserName, PasswordHash = @PasswordHash, Email = @Email" +
                ", DateJoined = @DateJoined where Id = @Id";

            var output = await _database.UpdateDataAsync(account, sql);
            return output;
        }

        public async Task<int> DeletePersonAsync(Account account)
        {
            string sql = "DELETE FROM Account WHERE Id = @Id";

            var output = await _database.DeleteDataAsync(account, sql);
            return output;
        }

        public async Task<Account> GetByUserName(string username)
        {
            string sql = "select * from Account";
            var accounts = await _database.LoadDataAsync<Account>(sql);
            accounts.Any(accounts => accounts.UserName == username);
            return accounts.FirstOrDefault(u => u.UserName == username);
        }

        public async Task<Account> GetByEmail(string email)
        {
            string sql = "select * from Account";
            var accounts = await _database.LoadDataAsync<Account>(sql);
            accounts.Any(accounts => accounts.Email == email);
            return accounts.FirstOrDefault(e => e.Email == email);
        }
    }
}
