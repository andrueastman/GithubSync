using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using GithubSync.ClientApp.Models;

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
        public IEnumerable<Job> Get()
        {
            // TODO read from json
            return new List<Job>();
        }
    }
}
