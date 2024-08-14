using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC9_MVC_SOLUTION2.Repository
{
    public interface IMovieRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);  //a particular movie
        void Insert(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Save();
    }

}
