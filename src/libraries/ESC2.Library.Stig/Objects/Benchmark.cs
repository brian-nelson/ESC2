using System;

namespace ESC2.Library.Stig.Objects
{
    public class Benchmark
    {
        public string Id { get; set; }
        public DateTime StatusDate { get; set; }
        public string Status { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ReferenceHref { get; set; }
        public string Publisher { get; set; }
        public string Source { get; set; }
        public string ReleaseInfo { get; set; }
        public string Generator { get; set; }
        public string ConventionsVersion { get; set; }
        public string Version { get; set; }

        public string Filename { get; set; }

    }
}
