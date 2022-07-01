using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Cargo_WebApi.Models.EFCore
{
    public interface IGenericRepository<T> where T: class 
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(int id, T item);
        Task Delete(int id);
    }
}
