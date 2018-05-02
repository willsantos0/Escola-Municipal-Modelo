using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaMunicipalAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);
        void InsertList(List<T> entitys);
        T Update(T entity);
        void Delete(long id);
        T GetById(long id);
        IEnumerable<T> GetAll();
        T GetByCPF(string cpf);
    }
}
