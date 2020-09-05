using System.Collections.Generic;

namespace API_EIA.Services.Interfaces
{
    public interface IGeneralService<T>
    {
        public IList<T> GetAll();
        public T Find(string id);
        public T Add(T model);
        public int Update(T model);
        public int Remove(string id);
    }
}
