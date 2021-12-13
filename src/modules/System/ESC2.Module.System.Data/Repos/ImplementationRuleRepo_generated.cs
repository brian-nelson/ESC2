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
// named ImplementationRuleRepo.cs
namespace ESC2.Module.System.Data.Repos
{
    public partial class ImplementationRuleRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.ImplementationRule>
    {
        public ImplementationRuleRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "implementation_rule";

        public override string InsertSql => @"
            INSERT INTO [dbo].[implementation_rule] (
                [dbo].[implementation_rule].[ImplementationRuleId],
                [dbo].[implementation_rule].[Status],
                [dbo].[implementation_rule].[FindingDetails],
                [dbo].[implementation_rule].[Comments],
                [dbo].[implementation_rule].[SeverityOverride],
                [dbo].[implementation_rule].[SeverityJustification],
                [dbo].[implementation_rule].[CreatedOn],
                [dbo].[implementation_rule].[LastModifiedOn],
                [dbo].[implementation_rule].[AdjustmentSetId],
                [dbo].[implementation_rule].[RuleId],
                [dbo].[implementation_rule].[EvidenceSetId],
                [dbo].[implementation_rule].[ImplementationId])
            VALUES ( 
                @Id,
                @Status,
                @FindingDetails,
                @Comments,
                @SeverityOverride,
                @SeverityJustification,
                @CreatedOn,
                @LastModifiedOn,
                @AdjustmentSetId,
                @RuleId,
                @EvidenceSetId,
                @ImplementationId) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[implementation_rule] 
            SET [dbo].[implementation_rule].[status]=@Status,
                [dbo].[implementation_rule].[finding_details]=@FindingDetails,
                [dbo].[implementation_rule].[comments]=@Comments,
                [dbo].[implementation_rule].[severity_override]=@SeverityOverride,
                [dbo].[implementation_rule].[severity_justification]=@SeverityJustification,
                [dbo].[implementation_rule].[created_on]=@CreatedOn,
                [dbo].[implementation_rule].[last_modified_on]=@LastModifiedOn,
                [dbo].[implementation_rule].[adjustment_set_id]=@AdjustmentSetId,
                [dbo].[implementation_rule].[rule_id]=@RuleId,
                [dbo].[implementation_rule].[evidence_set_id]=@EvidenceSetId,
                [dbo].[implementation_rule].[implementation_id]=@ImplementationId
            WHERE [dbo].[implementation_rule].[implementation_rule_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[implementation_rule].[implementation_rule_id],
                   [dbo].[implementation_rule].[status],
                   [dbo].[implementation_rule].[finding_details],
                   [dbo].[implementation_rule].[comments],
                   [dbo].[implementation_rule].[severity_override],
                   [dbo].[implementation_rule].[severity_justification],
                   [dbo].[implementation_rule].[created_on],
                   [dbo].[implementation_rule].[last_modified_on],
                   [dbo].[implementation_rule].[adjustment_set_id],
                   [dbo].[implementation_rule].[rule_id],
                   [dbo].[implementation_rule].[evidence_set_id],
                   [dbo].[implementation_rule].[implementation_id]
            FROM [dbo].[implementation_rule] ";

        public override ESC2.Module.System.Data.DataObjects.ImplementationRule ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.ImplementationRule();
            obj.Id = row.GetGuid("implementation_rule_id");
            obj.Status = row.GetString("status");
            obj.FindingDetails = row.GetString("finding_details");
            obj.Comments = row.GetString("comments");
            obj.SeverityOverride = row.GetString("severity_override");
            obj.SeverityJustification = row.GetString("severity_justification");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            obj.AdjustmentSetId = row.GetNullableGuid("adjustment_set_id");
            obj.RuleId = row.GetGuid("rule_id");
            obj.EvidenceSetId = row.GetNullableGuid("evidence_set_id");
            obj.ImplementationId = row.GetGuid("implementation_id");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.ImplementationRule obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Status", obj.Status, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("FindingDetails", obj.FindingDetails, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Comments", obj.Comments, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("SeverityOverride", obj.SeverityOverride, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("SeverityJustification", obj.SeverityJustification, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("AdjustmentSetId", obj.AdjustmentSetId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("RuleId", obj.RuleId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("EvidenceSetId", obj.EvidenceSetId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("ImplementationId", obj.ImplementationId, DbQueryParameterType.Guid));

            return parameters;
        }
    }
}