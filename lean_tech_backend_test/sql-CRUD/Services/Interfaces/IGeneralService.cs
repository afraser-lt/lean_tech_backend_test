using sql_CRUD.Models;
using sql_CRUD.MyModels;
using System.Collections.Generic;

namespace sql_CRUD.Services.Interfaces
{
    public interface IGeneralService <T>
    {
        public IList<T> GetAll();
        public T Find(int id);
        public int Add(T model);
        public int Update(T model);
        public int Remove(int id);
    }
}
