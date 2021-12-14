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
namespace ESC2.Module.System.Data.Repos
{
    public partial class ImplementationRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.Implementation>
    {
        public ImplementationRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "implementation";

        public override string InsertSql => @"
            INSERT INTO [dbo].[implementation] (
                [dbo].[implementation].[implementation_id],
                [dbo].[implementation].[start_date],
                [dbo].[implementation].[end_date],
                [dbo].[implementation].[status],
                [dbo].[implementation].[summary],
                [dbo].[implementation].[assigned_user_id],
                [dbo].[implementation].[asset_id],
                [dbo].[implementation].[implementation_guide_id],
                [dbo].[implementation].[created_on],
                [dbo].[implementation].[last_modified_on])
            VALUES ( 
                @Id,
                @StartDate,
                @EndDate,
                @Status,
                @Summary,
                @AssignedUserId,
                @AssetId,
                @ImplementationGuideId,
                @CreatedOn,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[implementation] 
            SET [dbo].[implementation].[start_date]=@StartDate,
                [dbo].[implementation].[end_date]=@EndDate,
                [dbo].[implementation].[status]=@Status,
                [dbo].[implementation].[summary]=@Summary,
                [dbo].[implementation].[assigned_user_id]=@AssignedUserId,
                [dbo].[implementation].[asset_id]=@AssetId,
                [dbo].[implementation].[implementation_guide_id]=@ImplementationGuideId,
                [dbo].[implementation].[created_on]=@CreatedOn,
                [dbo].[implementation].[last_modified_on]=@LastModifiedOn
            WHERE [dbo].[implementation].[implementation_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[implementation].[implementation_id],
                   [dbo].[implementation].[start_date],
                   [dbo].[implementation].[end_date],
                   [dbo].[implementation].[status],
                   [dbo].[implementation].[summary],
                   [dbo].[implementation].[assigned_user_id],
                   [dbo].[implementation].[asset_id],
                   [dbo].[implementation].[implementation_guide_id],
                   [dbo].[implementation].[created_on],
                   [dbo].[implementation].[last_modified_on]
            FROM [dbo].[implementation] ";

        public override ESC2.Module.System.Data.DataObjects.Implementation ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Implementation();
            obj.Id = row.GetGuid("implementation_id");
            obj.StartDate = row.GetNullableDateTime("start_date");
            obj.EndDate = row.GetNullableDateTime("end_date");
            obj.Status = row.GetString("status");
            obj.Summary = row.GetString("summary");
            obj.AssignedUserId = row.GetNullableGuid("assigned_user_id");
            obj.AssetId = row.GetGuid("asset_id");
            obj.ImplementationGuideId = row.GetGuid("implementation_guide_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Implementation obj)
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
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}
