using System;
using System.Collections.Generic;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Objects;

namespace ESC2.Module.System.Data.Repos
{
    public partial class VersionRepo
    {
        public ESC2.Module.System.Data.DataObjects.Version Get(
            Guid implementationGuideId,
            string versionNumber)
        {
            string sql = SelectSql +
                         " WHERE implementation_guide_id = @implementationGuideId" +
                         " AND number = @versionNumber";

            var parameters = new List<DbQueryParameter>
            {
                new DbQueryParameter("implementationGuideId", implementationGuideId, DbQueryParameterType.Guid),
                new DbQueryParameter("versionNumber", versionNumber, DbQueryParameterType.String)
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
