using System;
using System.Collections.Generic;
using ESC2.Library.Stig.Objects;

namespace ESC2.Library.Etl.Mapper
{
    public static class GroupMapper
    {
        public static List<ESC2.Module.System.Data.DataObjects.Rule> ToListDataRules(
            List<Group> groups,
            Guid versionId)
        {
            var output = new List<ESC2.Module.System.Data.DataObjects.Rule>();

            foreach (var group in groups)
            {
                foreach (var rule in group.Rules)
                {
                    var outputRule = RuleMapper.ToDataRule(rule);
                    outputRule.VersionId = versionId;
                    output.Add(outputRule);
                }
            }

            return output;
        }
    }
}
