using System.Collections.Generic;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Objects;
using ESC2.Module.System.Data.DataObjects.Operational;

namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class ImplementationGuideRepo
    {
        public ImplementationGuide Get(
            string number,
            string type)
        {
            string sql = SelectSql +
                         $" WHERE [{SchemaName}].[{TableName}].[number] = @number" +
                         $" AND [{SchemaName}].[{TableName}].[type] = @type";

            var parameters = new List<DbQueryParameter>
            {
                new DbQueryParameter("number", number, DbQueryParameterType.String),
                new DbQueryParameter("type", type, DbQueryParameterType.String)
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
