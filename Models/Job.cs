namespace GithubSync.Models
{
    public class Job
    {
        public int SyncFrequency { get; set; }

        public string SourceUrl { get; set; }

        public string DestinationPath { get; set; }

        public string DestinationRepository { get; set; }
    }
}