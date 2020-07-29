using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using GithubSync.Models;

namespace GithubSync.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController: ControllerBase
    {
        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Job>> GetAsync()
        {
            // deserialize JSON directly from a file
            using (FileStream fs = System.IO.File.OpenRead("jobs.json"))
            {
                var jobs = await JsonSerializer.DeserializeAsync<IEnumerable<Job>>(fs);
                return jobs;
            }
        }
    }
}
