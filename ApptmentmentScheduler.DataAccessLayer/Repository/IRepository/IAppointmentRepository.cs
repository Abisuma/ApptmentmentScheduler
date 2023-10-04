using ApptmentmentScheduler.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository.IRepository
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        void Update(Appointment obj);
        IEnumerable <Appointment> GetAllApp(string? userId = null);
        IEnumerable<Appointment> GetAppointmentsForDeletion();
    }
}
