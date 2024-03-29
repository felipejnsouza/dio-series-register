using System.Collections.Generic;

namespace series_register.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T GetById(int id);
         void Insert(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextID();
    }
}