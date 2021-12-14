using System;
using System.Collections.Generic;
using System.IO.Compression;
using ESC2.Library.Stig.Interfaces;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Stig.Readers
{
    public class StigZipReader : IStigReader
    {
        private readonly StigReader _stigReader = null;

        public StigZipReader(string zipFile)
        {
            bool success = false;
            using (ZipArchive archive = ZipFile.OpenRead(zipFile))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".xml"))
                    {
                        try
                        {
                            _stigReader = new StigReader(entry.Open(), entry.FullName);
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }

            if (!success)
            {
                throw new Exception("Unable to find stig xml file");
            }
        }

        public Benchmark GetBenchmark()
        {
            return _stigReader?.GetBenchmark();
        }

        public List<Group> GetGroups()
        {
            return _stigReader?.GetGroups();
        }
    }
}
