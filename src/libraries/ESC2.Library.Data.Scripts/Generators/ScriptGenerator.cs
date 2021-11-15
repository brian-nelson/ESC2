using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESC2.Library.Data.Scripts.Helpers;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Data.Scripts.Generators
{
    public static class ScriptGenerator
    {
        public static string GenerateSql(Benchmark benchmark)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GenerateInsertStig(benchmark));
            sb.AppendLine(GenerateInsertVersion(benchmark));

            return sb.ToString();
        }

        private static string GenerateInsertStig(Benchmark benchmark)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @stigId int;");
            sb.AppendLine();

            sb.AppendLine("INSERT INTO dbo.STIG (STIG_NUMBER)");
            sb.AppendLine($"VALUES ({EncodeString(benchmark.Id)});");

            sb.AppendLine();
            sb.AppendLine("SET @stigId = @@IDENTITY");

            return sb.ToString();
        }

        private static string Encode(string text)
        {
            var temp =  text.Replace("'", "''");
            temp = temp.Replace("\r", "\\r");
            temp = temp.Replace("\n", "\\n");
            return temp;
        }

        private static string EncodeString(string text)
        {
            if (text == null)
            {
                return "null";
            }

            return $"'{Encode(text)}'";
        }

        private static string GenerateInsertVersion(Benchmark benchmark)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @versionId bigint;");
            sb.AppendLine();

            sb.Append("INSERT INTO dbo.VERSION (STIG_ID, VERSION_NUMBER, VERSION_STATUS_CODE,");
            sb.Append("VERSION_STATUS_DATE, VERSION_TITLE, VERSION_DESCRIPTION, VERSION_PUBLISHER,");
            sb.AppendLine("VERSION_SOURCE, VERSION_FILENAME)");
            sb.Append($"VALUES (@stigId,");
            sb.Append(EncodeString(benchmark.Version) + ",");
            sb.Append(EncodeString(TranslationHelper.GetVersionStatusCode(benchmark.Status)) + ",");
            sb.Append("CAST(" + EncodeString(benchmark.StatusDate.ToString("O")) + " AS date),");
            sb.Append(EncodeString(benchmark.Title) + ",");
            sb.Append(EncodeString(benchmark.Description) + ",");
            sb.Append(EncodeString(benchmark.Publisher) + ",");
            sb.Append(EncodeString(benchmark.Source) + ",");
            sb.Append(EncodeString(benchmark.Filename));
            sb.AppendLine(");");
            sb.AppendLine();
            sb.AppendLine("SET @versionId = @@IDENTITY");

            return sb.ToString();
        }

        public static string GenerateSql(List<Group> groups)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var group in groups)
            {
                sb.Append(GenerateInsertRule(group));
            }


            return sb.ToString();
        }

        private static string GenerateInsertRule(Group group)
        {
            //Only handles first rule.
            var rule = group.Rules.FirstOrDefault();

            if (rule != null)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO dbo.[RULE](VERSION_ID, RULE_NUMBER, RULE_SEVERITY,");
                sb.AppendLine("RULE_VERSION, RULE_TITLE, RULE_FIX, RULE_CHECK, RULE_CCI) ");
                sb.Append("VALUES(@versionId,");
                sb.Append(EncodeString(rule.Id) + ",");
                sb.Append(EncodeString(TranslationHelper.GetRuleSeverity(rule.Severity)) + ",");
                sb.Append(EncodeString(rule.Version) + ",");
                sb.Append(EncodeString(rule.Title) + ",");
                sb.Append(EncodeString(rule.Fix) + ",");
                sb.Append(EncodeString(rule.Check) + ",");
                sb.Append(EncodeString(rule.CCI));
                sb.AppendLine(");");
                sb.AppendLine();
                
                return sb.ToString();
            }

            return null;
        }
    }
}
