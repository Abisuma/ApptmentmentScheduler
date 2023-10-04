using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
       // IEnumerable<T> GetAllApp(string userId);
        T GetAApp(Expression<Func<T, bool>> filter);
        void CreateApp(T entity);
        //void UpdateApp(T entity);   
        void DeleteApp(T entity);   
    }
    
    
}
