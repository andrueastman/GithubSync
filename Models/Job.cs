using System;

namespace GithubSync.Models
{
    public class Job
    {
        public int SyncFrequency { get; set; }

        public string SourceUrl { get; set; }

        public string DestinationPath { get; set; }

        public string DestinationRepository { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime LastRun { get; set; }

        public bool Enabled { get; set; }
    }
}