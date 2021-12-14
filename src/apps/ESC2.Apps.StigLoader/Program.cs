using System;
using System.IO;
using ESC2.Library.Data.SqlServer.DataProvider;
using ESC2.Library.Etl.Mapper;
using ESC2.Library.Stig.Interfaces;
using ESC2.Library.Stig.Readers;
using ESC2.Module.System.Data.Repos;

namespace ESC2.Apps.StigLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=StigTools;Trusted_Connection=True;";
            var dbProvider = new SqlServerDataProvider(connectionString);

            var implementationGuideRepo = new ImplementationGuideRepo(dbProvider);
            var versionRepo = new VersionRepo(dbProvider);
            var ruleRepo = new RuleRepo(dbProvider);

            var files = Directory.GetFiles("C:\\Data\\Stigs");

            foreach (var file in files)
            {
                if (file.EndsWith(".zip"))
                {
                    IStigReader reader = null;
                    try
                    {
                        reader = new StigZipReader(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unable to read file: {file}");
                        continue;
                    }
                    
                    var benchmark = reader.GetBenchmark();

                    if (benchmark != null)
                    {
                        //Process ImplementationGuid
                        var implementationGuide = BenchmarkMapper.ToImplementationGuide(benchmark);
                        implementationGuide.Type = "Stig";

                        var savedIG = implementationGuideRepo.Get(
                            implementationGuide.Number,
                            implementationGuide.Type);

                        if (savedIG != null)
                        {
                            implementationGuide.Id = savedIG.Id;
                        }

                        implementationGuideRepo.Save(implementationGuide);

                        //Process Version
                        var version = BenchmarkMapper.ToVersion(implementationGuide.Id, benchmark);
                        var savedVersion = versionRepo.Get(implementationGuide.Id, version.Number);
                        if (savedVersion != null)
                        {
                            version.Id = savedVersion.Id;
                        }
                        versionRepo.Save(version);

                        //Process Rules
                        var groups = reader.GetGroups();

                        var rules = GroupMapper.ToListDataRules(groups, version.Id);
                        foreach (var rule in rules)
                        {
                            var savedRule = ruleRepo.Get(rule.VersionId, rule.Number);

                            if (savedRule != null)
                            {
                                rule.Id = savedRule.Id;
                            }
                        }

                        ruleRepo.Save(rules);
                    }
                }
            }
        }
    }
}
