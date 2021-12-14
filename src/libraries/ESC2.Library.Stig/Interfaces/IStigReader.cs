using System.Collections.Generic;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Stig.Interfaces
{
    public interface IStigReader
    {
        Benchmark GetBenchmark();
        List<Group> GetGroups();
    }
}
