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
// named AuditRepo.cs
namespace ESC2.Module.System.Data.Repos
{
    public partial class AuditRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.Audit>
    {
        public AuditRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "audit";

        public override string InsertSql => @"
            INSERT INTO [dbo].[audit] (
                [dbo].[audit].[audit_id],
                [dbo].[audit].[start_date],
                [dbo].[audit].[end_date],
                [dbo].[audit].[status],
                [dbo].[audit].[summary],
                [dbo].[audit].[employee_id],
                [dbo].[audit].[implementation_id])
            VALUES ( 
                @Id,
                @StartDate,
                @EndDate,
                @Status,
                @Summary,
                @EmployeeId,
                @ImplementationId) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[audit] 
            SET [dbo].[audit].[start_date]=@StartDate,
                [dbo].[audit].[end_date]=@EndDate,
                [dbo].[audit].[status]=@Status,
                [dbo].[audit].[summary]=@Summary,
                [dbo].[audit].[employee_id]=@EmployeeId,
                [dbo].[audit].[implementation_id]=@ImplementationId
            WHERE [dbo].[audit].[audit_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[audit].[audit_id],
                   [dbo].[audit].[start_date],
                   [dbo].[audit].[end_date],
                   [dbo].[audit].[status],
                   [dbo].[audit].[summary],
                   [dbo].[audit].[employee_id],
                   [dbo].[audit].[implementation_id]
            FROM [dbo].[audit] ";

        public override ESC2.Module.System.Data.DataObjects.Audit ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Audit();
            obj.Id = row.GetGuid("audit_id");
            obj.StartDate = row.GetNullableDateTime("start_date");
            obj.EndDate = row.GetNullableDateTime("end_date");
            obj.Status = row.GetString("status");
            obj.Summary = row.GetString("summary");
            obj.EmployeeId = row.GetNullableGuid("employee_id");
            obj.ImplementationId = row.GetNullableGuid("implementation_id");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Audit obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("StartDate", obj.StartDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("EndDate", obj.EndDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("Status", obj.Status, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Summary", obj.Summary, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("EmployeeId", obj.EmployeeId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("ImplementationId", obj.ImplementationId, DbQueryParameterType.Guid));

            return parameters;
        }
    }
}
