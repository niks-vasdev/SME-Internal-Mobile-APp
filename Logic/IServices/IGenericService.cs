using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IServices
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(object id);
        public Task<bool> Insert(T obj);
        public Task<bool> Update(T obj);
        public Task<bool> Delete(object id);
        public ValueTask Dispose();
    }
}
