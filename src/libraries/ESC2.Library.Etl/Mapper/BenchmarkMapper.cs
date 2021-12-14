using System;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Etl.Mapper
{
    public static class BenchmarkMapper
    {
        public static ESC2.Module.System.Data.DataObjects.ImplementationGuide ToImplementationGuide(
            Benchmark benchmark)
        {
            var stig = new ESC2.Module.System.Data.DataObjects.ImplementationGuide
            {
                Number = benchmark.Id
            };

            return stig;
        }

        public static ESC2.Module.System.Data.DataObjects.Version ToVersion(
            Guid implementationGuideId,
            Benchmark benchmark)
        {
            var version = new ESC2.Module.System.Data.DataObjects.Version
            {
                Number = benchmark.Version,
                Status = GetVersionStatusCode(benchmark.Status),
                StatusDate = benchmark.StatusDate,
                Title = benchmark.Title,
                Description = benchmark.Description,
                Publisher = benchmark.Publisher,
                Source = benchmark.Source,
                Filename = benchmark.Filename,
                ImplementationGuideId = implementationGuideId
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

            if (status.Equals(""))
            {
                return "UN";
            }

            throw new Exception("Unknown version status");
        }
    }
}
