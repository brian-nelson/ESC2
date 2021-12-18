using System;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Etl.Mapper
{
    public static class RuleMapper
    {
        public static Module.System.Data.DataObjects.Operational.Rule ToDataRule(Rule rule)
        {
            var output = new Module.System.Data.DataObjects.Operational.Rule
            {
                Number = rule.Id,
                Severity = GetRuleSeverity(rule.Severity),
                Version = rule.Version,
                Title = rule.Title,
                Discussion = rule.Discussion,
                Fix = rule.Fix,
                Check = rule.Check,
                Cci = rule.CCI
            };

            return output;
        }

        public static string GetRuleSeverity(string severity)
        {
            if (severity.Equals("high", StringComparison.InvariantCultureIgnoreCase))
            {
                return "H";
            }

            if (severity.Equals("medium", StringComparison.InvariantCultureIgnoreCase))
            {
                return "M";
            }

            if (severity.Equals("low", StringComparison.InvariantCultureIgnoreCase))
            {
                return "L";
            }

            throw new Exception("Unknown version status");
        }
    }
}
