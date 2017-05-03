using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Insert(T obj);
        Task  Update(T obj);
        Task Delete(string id);
    }
}
