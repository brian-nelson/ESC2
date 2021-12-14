using System;
using System.Collections.Generic;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Objects;
using ESC2.Module.System.Data.DataObjects;

namespace ESC2.Module.System.Data.Repos
{
    public partial class RuleRepo
    {
        public void Save(List<Rule> rules)
        {
            foreach (var rule in rules)
            {
                Save(rule);
            }
        }

        public ESC2.Module.System.Data.DataObjects.Rule Get(
            Guid versionId,
            string ruleNumber)
        {
            string sql = SelectSql +
                         " WHERE version_id = @versionId" +
                         " AND number = @ruleNumber";

            var parameters = new List<DbQueryParameter>
            {
                new DbQueryParameter("versionId", versionId, DbQueryParameterType.Guid),
                new DbQueryParameter("ruleNumber", ruleNumber, DbQueryParameterType.String)
            };

            var dt = DataProvider.GetData(sql, parameters);
            if (dt != null
                && dt.Rows.Count > 0)
            {
                return ToObject(dt.Rows[0]);
            }

            return default;
        }
    }
}
