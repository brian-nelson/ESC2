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
// named ImplementationRepo.cs
namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class ImplementationRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Operational.Implementation, Guid>
    {
        public ImplementationRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "operational";
        public override string TableName => "implementation";

        public override string InsertSql => @"
            INSERT INTO [operational].[implementation] (
                [operational].[implementation].[implementation_id],
                [operational].[implementation].[start_date],
                [operational].[implementation].[end_date],
                [operational].[implementation].[status],
                [operational].[implementation].[summary],
                [operational].[implementation].[assigned_user_id],
                [operational].[implementation].[asset_id],
                [operational].[implementation].[implementation_guide_id],
                [operational].[implementation].[created_by_id],
                [operational].[implementation].[created_on],
                [operational].[implementation].[last_modified_by_id],
                [operational].[implementation].[last_modified_on])
            VALUES ( 
                @Id,
                @StartDate,
                @EndDate,
                @Status,
                @Summary,
                @AssignedUserId,
                @AssetId,
                @ImplementationGuideId,
                @CreatedById,
                @CreatedOn,
                @LastModifiedById,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [operational].[implementation] 
            SET [operational].[implementation].[start_date]=@StartDate,
                [operational].[implementation].[end_date]=@EndDate,
                [operational].[implementation].[status]=@Status,
                [operational].[implementation].[summary]=@Summary,
                [operational].[implementation].[assigned_user_id]=@AssignedUserId,
                [operational].[implementation].[asset_id]=@AssetId,
                [operational].[implementation].[implementation_guide_id]=@ImplementationGuideId,
                [operational].[implementation].[created_by_id]=@CreatedById,
                [operational].[implementation].[created_on]=@CreatedOn,
                [operational].[implementation].[last_modified_by_id]=@LastModifiedById,
                [operational].[implementation].[last_modified_on]=@LastModifiedOn
            WHERE [operational].[implementation].[implementation_id]=@Id ";

        public override string SelectSql => @"
            SELECT [operational].[implementation].[implementation_id],
                   [operational].[implementation].[start_date],
                   [operational].[implementation].[end_date],
                   [operational].[implementation].[status],
                   [operational].[implementation].[summary],
                   [operational].[implementation].[assigned_user_id],
                   [operational].[implementation].[asset_id],
                   [operational].[implementation].[implementation_guide_id],
                   [operational].[implementation].[created_by_id],
                   [operational].[implementation].[created_on],
                   [operational].[implementation].[last_modified_by_id],
                   [operational].[implementation].[last_modified_on]
            FROM [operational].[implementation] ";

        public override ESC2.Module.System.Data.DataObjects.Operational.Implementation ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Operational.Implementation();
            obj.Id = row.GetGuid("implementation_id");
            obj.StartDate = row.GetNullableDateTime("start_date");
            obj.EndDate = row.GetNullableDateTime("end_date");
            obj.Status = row.GetString("status");
            obj.Summary = row.GetString("summary");
            obj.AssignedUserId = row.GetNullableGuid("assigned_user_id");
            obj.AssetId = row.GetGuid("asset_id");
            obj.ImplementationGuideId = row.GetGuid("implementation_guide_id");
            obj.CreatedById = row.GetGuid("created_by_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedById = row.GetGuid("last_modified_by_id");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Operational.Implementation obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("StartDate", obj.StartDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("EndDate", obj.EndDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("Status", obj.Status, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Summary", obj.Summary, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("AssignedUserId", obj.AssignedUserId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("AssetId", obj.AssetId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("ImplementationGuideId", obj.ImplementationGuideId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedById", obj.CreatedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedById", obj.LastModifiedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}