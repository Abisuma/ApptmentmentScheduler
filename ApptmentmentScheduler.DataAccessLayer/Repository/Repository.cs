using ApptmentmentScheduler.DataAccessLayer.Data;
using ApptmentmentScheduler.DataAccessLayer.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext dbContext)
        {
            db = dbContext;
            this.dbSet = db.Set<T>();
        }
        public void CreateApp(T entity)
        {
            dbSet.Add(entity);
        }

        public void DeleteApp(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetAApp(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        //public IEnumerable<T> GetAllApp(string userId) 
        //{
        //    IQueryable<T> query = dbSet.Where(u=>u.UserId.Equals(userId));  
        //    return query.ToList();  
        //}

        
    }

}
