using ApptmentmentScheduler.DataAccessLayer.Data;
using ApptmentmentScheduler.DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        public IAppointmentRepository Appoint { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
             _appDbContext = db;
            Appoint = new AppointmentRepository(_appDbContext);  
        }
       
         public void Save()
         {
            _appDbContext.SaveChanges();
         }
    }
}
