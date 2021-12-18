using System;
using System.Collections.Generic;
using System.Data;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Repos;
using ESC2.Library.Data.Helpers;
using ESC2.Library.Data.Interfaces;
using ESC2.Library.Data.Objects;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator
// To extend the class beyond a POCO, create a additional partial class
// named SystemEventPropertyRepo.cs
namespace ESC2.Module.System.Data.Repos.Logging
{
    public partial class SystemEventPropertyRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Logging.SystemEventProperty, Int64>
    {
        public SystemEventPropertyRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "logging";
        public override string TableName => "system_event_property";

        public override string InsertSql => @"
            INSERT INTO [logging].[system_event_property] (
                [logging].[system_event_property].[system_event_id],
                [logging].[system_event_property].[parameter_name],
                [logging].[system_event_property].[parameter_value])
            VALUES ( 
                @SystemEventId,
                @ParameterName,
                @ParameterValue) ";

        public override string UpdateSql => @"
            UPDATE [logging].[system_event_property] 
            SET [logging].[system_event_property].[system_event_id]=@SystemEventId,
                [logging].[system_event_property].[parameter_name]=@ParameterName,
                [logging].[system_event_property].[parameter_value]=@ParameterValue
            WHERE [logging].[system_event_property].[system_event_property_id]=@Id ";

        public override string SelectSql => @"
            SELECT [logging].[system_event_property].[system_event_property_id],
                   [logging].[system_event_property].[system_event_id],
                   [logging].[system_event_property].[parameter_name],
                   [logging].[system_event_property].[parameter_value]
            FROM [logging].[system_event_property] ";

        public override ESC2.Module.System.Data.DataObjects.Logging.SystemEventProperty ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Logging.SystemEventProperty();
            obj.Id = row.GetLong("system_event_property_id");
            obj.SystemEventId = row.GetNullableLong("system_event_id");
            obj.ParameterName = row.GetString("parameter_name");
            obj.ParameterValue = row.GetString("parameter_value");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Logging.SystemEventProperty obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("SystemEventId", obj.SystemEventId, DbQueryParameterType.Int64));
            parameters.Add(new DbQueryParameter("ParameterName", obj.ParameterName, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("ParameterValue", obj.ParameterValue, DbQueryParameterType.String));

            return parameters;
        }
    }
}