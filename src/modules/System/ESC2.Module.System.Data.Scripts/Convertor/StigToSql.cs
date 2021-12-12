using System.IO;
using System.Text;
using ESC2.Library.Data.Scripts.Generators;
using ESC2.Library.Stig.Readers;

namespace ESC2.Library.Data.Scripts.Convertor
{
    public static class StigToSql
    {
        public static void Convert(string inputXmlFilename, string outputFilename)
        {
            var reader = new StigReader(inputXmlFilename);

            StringBuilder outputScript = new StringBuilder();

            var benchMark = reader.GetBenchmark();
            outputScript.Append(ScriptGenerator.GenerateSql(benchMark));

            var groups = reader.GetGroups();
            outputScript.Append(ScriptGenerator.GenerateSql(groups));

            string sql = outputScript.ToString();

            File.WriteAllText(outputFilename, sql);
        }
    }
}
