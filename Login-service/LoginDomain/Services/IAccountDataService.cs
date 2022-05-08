using LoginDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDomain.Services
{
    public interface IAccountDataService
    {
        Task<int> DeletePersonAsync(Account account);
        Task<IEnumerable<Account>> LoadAccountAsync();
        Task<int> SavePersonAsync(Account account);
        Task<int> UpdatePersonAsync(Account account);

        Task<Account> GetByUserName(string username);
        Task<Account> GetByEmail(string email);

    }
}
