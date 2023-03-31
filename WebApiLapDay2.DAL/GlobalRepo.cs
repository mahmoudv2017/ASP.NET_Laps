using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLapDay2.DAL.Context;

namespace WebApiLapDay2.DAL
{
    public class GlobalRepo<T> : GlobalInterface<T> where T : class
    {
        private readonly MyDbContext _conetxt;

        public GlobalRepo(MyDbContext myDbContext)
        {
            _conetxt= myDbContext;
        }
        
        public List<T> GetAll()
        {
            return _conetxt.Set<T>().ToList();
        }

        public T? GetByID(int id)
        {
            return _conetxt.Set<T>().Find(id);
        }

        public void Save()
        {
            _conetxt.SaveChanges();
        }

        public void add(T asd)
        {
            _conetxt.Set<T>().Add(asd);
            Save();
        }

        public void Remove(T asd)
        {
  
            _conetxt.Set<T>().Remove(asd);
            Save();
        }

        public void Update()
        {
            
        }
    }
}
