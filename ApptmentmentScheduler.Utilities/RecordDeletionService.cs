using ApptmentmentScheduler.DataAccessLayer.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ApptmentmentScheduler.Utilities
{
    public class RecordDeletionService : BackgroundService
    {
        // private readonly IUnitOfWork _unitOfWork;

        private readonly IServiceProvider _serviceProvider;
        private readonly RecordDeletionSettings _deletionSettings;
        private readonly ILogger<RecordDeletionService> _logger;

        public RecordDeletionService( IOptions<RecordDeletionSettings> options, IServiceProvider serviceProvider, ILogger<RecordDeletionService> logger)
        {
           
            _deletionSettings = options.Value;
            _serviceProvider = serviceProvider;
            _logger = logger;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        // Resolve the IUnitOfWork service within the scope
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                        // Find records that meet the deletion condition
                        var recordsToDelete = unitOfWork.Appoint.GetAppointmentsForDeletion()
                            .ToList();

                        foreach (var record in recordsToDelete)
                        {
                            unitOfWork.Appoint.DeleteApp(record);
                        }

                        unitOfWork.Save();
                    }
                    // Sleep for a certain interval before checking again
                    await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during record deletion.");
                }
            }
        }


    }

}
