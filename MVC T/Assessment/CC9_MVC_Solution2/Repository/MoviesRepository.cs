using CC9_MVC_SOLUTION2.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CC9_MVC_SOLUTION2.Repository
{
    public class MovieRepository<T> :IMovieRepository<T> where T : class
    {
        MoviesContext db;
        DbSet<T> dbset;

        public MovieRepository()
        {
            db = new MoviesContext();
            dbset = db.Set<T>();
        }

        public void Delete(object Id)
        {
            T getmodel = dbset.Find(Id);
            if (getmodel != null)
                dbset.Remove(getmodel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}