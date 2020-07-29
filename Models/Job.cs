using System;

namespace GithubSync.ClientApp.Models
{
    public class Job
    {
        public TimeSpan SyncFrequency { get; set; }

        public string SourceUrl { get; set; }

        public string DestinationPath { get; set; }

        public string DestinationRepository { get; set; }
    }
}