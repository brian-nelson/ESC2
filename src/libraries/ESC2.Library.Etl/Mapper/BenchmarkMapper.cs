using System;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Etl.Mapper
{
    public static class BenchmarkMapper
    {
        public static Data.DataObjects.Stig ToStig(
            Benchmark benchmark)
        {
            var stig = new Data.DataObjects.Stig
            {
                Number = benchmark.Id
            };

            return stig;
        }

        public static Data.DataObjects.Version ToVersion(
            Guid stigId,
            Benchmark benchmark)
        {
            var version = new Data.DataObjects.Version
            {
                Number = benchmark.Version,
                Status = GetVersionStatusCode(benchmark.Status),
                StatusDate = benchmark.StatusDate,
                Title = benchmark.Title,
                Description = benchmark.Description,
                Publisher = benchmark.Publisher,
                Source = benchmark.Source,
                Filename = benchmark.Filename,
                StigId = stigId
            };

            return version;
        }

        private static string GetVersionStatusCode(string status)
        {
            if (status.Equals("accepted", StringComparison.InvariantCultureIgnoreCase))
            {
                return "A";
            }

            if (status.Equals("deprecated", StringComparison.InvariantCultureIgnoreCase))
            {
                return "DP";
            }

            if (status.Equals("draft", StringComparison.InvariantCultureIgnoreCase))
            {
                return "DR";
            }

            if (status.Equals("incomplete", StringComparison.InvariantCultureIgnoreCase))
            {
                return "IC";
            }

            if (status.Equals("interim", StringComparison.InvariantCultureIgnoreCase))
            {
                return "IN";
            }

            throw new Exception("Unknown version status");
        }
    }
}
