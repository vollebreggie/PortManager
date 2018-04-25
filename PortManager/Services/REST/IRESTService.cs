using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Services
{
    public interface IRESTService<T> where T : class, new()
    {

        Task<List<T>> GetAll(string queryString);
        Task<List<T>> GetAll(string queryString, int id);
        Task<T> Get(string queryString);
        Task<T> Get(string queryString, int id);
        Task<T> Get(string queryString, int firstId, int secondId);
        Task<T> Post(string queryString, T entity);
        Task<T> Put(string queryString, T entity);
        Task<T> Delete(string queryString, int id);

    }
}
