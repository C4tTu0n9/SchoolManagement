using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> where T : class
    {
        PRN212_Student_ManagementContext _context;
        DbSet<T> _dbSet;
        
        public GenericRepository() {
            _context = new PRN212_Student_ManagementContext();
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Delete(T entity) { 
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        
        public void Update(T entity) { 
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
