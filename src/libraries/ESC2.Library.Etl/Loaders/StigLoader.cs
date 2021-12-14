using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESC2.Library.Data.Interfaces;
using ESC2.Library.Etl.Mapper;
using ESC2.Library.Stig.Readers;

namespace ESC2.Library.Etl.Loaders
{
    public class StigLoader
    {
        private readonly IDataProvider _dataProvider;

        public StigLoader(
            IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void LoadStig(
            string stigFile)
        {
            var reader = new StigReader(stigFile);

            var benchmark = reader.GetBenchmark();
            var groups = reader.GetGroups();

            var stig = BenchmarkMapper.ToImplementationGuide(benchmark);
            




        }
    }
}
