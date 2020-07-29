﻿using System;

namespace GithubSync.ClientApp.Models
{
    public class Job
    {
        public TimeSpan SyncFrequecy { get; set; }

        public string SourceUrl { get; set; }

        public string DestinationPath { get; set; }

        public string DestinationRepository { get; set; }
    }
}