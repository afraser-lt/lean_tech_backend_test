using System.Collections.Generic;

namespace Demo.Services.Interfaces
{
    public interface IGeneralService<T>
    {
        public IList<T> GetAll();
        public T Find(int id);
        public int Add(T model);
        public int Update(T model);
        public int Remove(int id);
    }
}
