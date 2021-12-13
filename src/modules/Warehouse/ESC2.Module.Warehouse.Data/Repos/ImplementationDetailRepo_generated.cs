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
// named ImplementationDetailRepo.cs
namespace ESC2.Module.System.Data.Repos
{
    public partial class ImplementationDetailRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.ImplementationDetail>
    {
        public ImplementationDetailRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "implementation_detail";

        public override string InsertSql => @"
            INSERT INTO [dbo].[implementation_detail] (
                [dbo].[implementation_detail].[ImplementationDetailId],
                [dbo].[implementation_detail].[ImplementationId],
                [dbo].[implementation_detail].[RuleId],
                [dbo].[implementation_detail].[Status],
                [dbo].[implementation_detail].[FindingDetails],
                [dbo].[implementation_detail].[Comments],
                [dbo].[implementation_detail].[SeverityOverride],
                [dbo].[implementation_detail].[SeverityJustification])
            VALUES ( 
                @Id,
                @ImplementationId,
                @RuleId,
                @Status,
                @FindingDetails,
                @Comments,
                @SeverityOverride,
                @SeverityJustification) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[implementation_detail] 
            SET [dbo].[implementation_detail].[implementation_id]=@ImplementationId,
                [dbo].[implementation_detail].[rule_id]=@RuleId,
                [dbo].[implementation_detail].[status]=@Status,
                [dbo].[implementation_detail].[finding_details]=@FindingDetails,
                [dbo].[implementation_detail].[comments]=@Comments,
                [dbo].[implementation_detail].[severity_override]=@SeverityOverride,
                [dbo].[implementation_detail].[severity_justification]=@SeverityJustification
            WHERE [dbo].[implementation_detail].[implementation_detail_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[implementation_detail].[implementation_detail_id],
                   [dbo].[implementation_detail].[implementation_id],
                   [dbo].[implementation_detail].[rule_id],
                   [dbo].[implementation_detail].[status],
                   [dbo].[implementation_detail].[finding_details],
                   [dbo].[implementation_detail].[comments],
                   [dbo].[implementation_detail].[severity_override],
                   [dbo].[implementation_detail].[severity_justification]
            FROM [dbo].[implementation_detail] ";

        public override ESC2.Module.System.Data.DataObjects.ImplementationDetail ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.ImplementationDetail();
            obj.Id = row.GetGuid("implementation_detail_id");
            obj.ImplementationId = row.GetGuid("implementation_id");
            obj.RuleId = row.GetGuid("rule_id");
            obj.Status = row.GetString("status");
            obj.FindingDetails = row.GetString("finding_details");
            obj.Comments = row.GetString("comments");
            obj.SeverityOverride = row.GetString("severity_override");
            obj.SeverityJustification = row.GetString("severity_justification");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.ImplementationDetail obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("ImplementationId", obj.ImplementationId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("RuleId", obj.RuleId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Status", obj.Status, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("FindingDetails", obj.FindingDetails, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Comments", obj.Comments, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("SeverityOverride", obj.SeverityOverride, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("SeverityJustification", obj.SeverityJustification, DbQueryParameterType.String));

            return parameters;
        }
    }
}