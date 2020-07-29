using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GithubSync.BackgroundJob
{
    public class GithubSyncHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<GithubSyncHostedService> _logger;
        private Timer _timer;

        public GithubSyncHostedService(ILogger<GithubSyncHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(RunJobs, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void RunJobs(object state)
        {
            // read the json for jobs list and execute if needed

            _logger.LogInformation("Period job check completed.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}