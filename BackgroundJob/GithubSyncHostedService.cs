using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GithubSync.Models;
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

            _timer = new Timer(async state => await RunJobsAsync(), null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async Task RunJobsAsync()
        {
            // read the json for jobs list and execute if needed
            await using FileStream fs = File.OpenRead("jobs.json");
            var jobs = await JsonSerializer.DeserializeAsync<IEnumerable<Job>>(fs);
            foreach (var job in jobs)
            {
                _logger.LogInformation($"Reading job : {job.Name}");
                _logger.LogInformation($"Enabled : {job.Enabled}");
                if (job.Enabled)
                {
                    _logger.LogInformation("Job completed");
                }
            }
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