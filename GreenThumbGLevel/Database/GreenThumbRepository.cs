using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbGLevel.Database
{
    //Generic Repository
    internal class GreenThumbRepository <T> where T : class
    {
        private readonly GreenThumbDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GreenThumbRepository(GreenThumbDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public List<T>GetAll()
        {
            return _dbSet.ToList(); 

        }
        public T? GetbyName(string name)
        {
            return _dbSet.Find(name);
        }

        public void Add(T entity) 
        {
            _dbSet.Add(entity);
        }
        public void Delete(string name)
        {
            T? entityToDelete=GetbyName(name);

            if(entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }


    }
}
