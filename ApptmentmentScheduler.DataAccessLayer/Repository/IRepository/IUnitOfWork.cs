using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAppointmentRepository Appoint { get; }
        void Save();
    }
}
