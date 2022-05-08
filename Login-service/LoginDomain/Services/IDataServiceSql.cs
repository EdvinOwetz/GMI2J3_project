using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDomain.Services
{
    public interface IDataServiceSql
    {   
        Task<IEnumerable<T>> LoadDataAsync<T>(string sql);
        Task<int> SaveDataAsync<T>(T account, string sql);
        Task<int> UpdateDataAsync<T>(T account, string sql);
        Task<int> DeleteDataAsync<T>(T account, string sql);
    }
}
