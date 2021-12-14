using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Objects;
using ESC2.Module.System.Data.DataObjects;

namespace ESC2.Module.System.Data.Repos
{
    public partial class ImplementationGuideRepo
    {
        public ImplementationGuide Get(
            string number, 
            string type)
        {
            string sql = SelectSql +
                         " WHERE number = @number AND type = @type";

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
