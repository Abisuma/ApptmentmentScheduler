using ApptmentmentScheduler.DataAccessLayer.Data;
using ApptmentmentScheduler.DataAccessLayer.Repository.IRepository;
using ApptmentmentScheduler.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private AppDbContext _dbContext;
        public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Update(Appointment obj)
        {
           _dbContext.Appointments.Update(obj);
        }

        public IEnumerable<Appointment> GetAllApp(string? userId = null)
        {
            IQueryable<Appointment> query = dbSet.Where(u => u.UserId.Equals(userId));
              return query.ToList();  
        }

        public IEnumerable<Appointment> GetAppointmentsForDeletion()
        {
            DateTime deletionTime = DateTime.UtcNow.AddHours(1) - TimeSpan.FromMinutes(2); // Define your deletion condition here

            IQueryable<Appointment> query = dbSet.Where(appointment => appointment.DateTime < deletionTime);

            return query.ToList();
        }

    }
}
