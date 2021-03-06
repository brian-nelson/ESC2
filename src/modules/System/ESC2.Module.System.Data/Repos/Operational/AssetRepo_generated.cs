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
// named AssetRepo.cs
namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class AssetRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Operational.Asset, Guid>
    {
        public AssetRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "operational";
        public override string TableName => "asset";

        public override string InsertSql => @"
            INSERT INTO [operational].[asset] (
                [operational].[asset].[asset_id],
                [operational].[asset].[name],
                [operational].[asset].[description],
                [operational].[asset].[status],
                [operational].[asset].[host_name],
                [operational].[asset].[contact_employee_id],
                [operational].[asset].[owning_department_id],
                [operational].[asset].[parent_asset_id],
                [operational].[asset].[asset_type_id],
                [operational].[asset].[created_by_id],
                [operational].[asset].[created_on],
                [operational].[asset].[last_modified_by_id],
                [operational].[asset].[last_modified_on])
            VALUES ( 
                @Id,
                @Name,
                @Description,
                @Status,
                @HostName,
                @ContactEmployeeId,
                @OwningDepartmentId,
                @ParentAssetId,
                @AssetTypeId,
                @CreatedById,
                @CreatedOn,
                @LastModifiedById,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [operational].[asset] 
            SET [operational].[asset].[name]=@Name,
                [operational].[asset].[description]=@Description,
                [operational].[asset].[status]=@Status,
                [operational].[asset].[host_name]=@HostName,
                [operational].[asset].[contact_employee_id]=@ContactEmployeeId,
                [operational].[asset].[owning_department_id]=@OwningDepartmentId,
                [operational].[asset].[parent_asset_id]=@ParentAssetId,
                [operational].[asset].[asset_type_id]=@AssetTypeId,
                [operational].[asset].[created_by_id]=@CreatedById,
                [operational].[asset].[created_on]=@CreatedOn,
                [operational].[asset].[last_modified_by_id]=@LastModifiedById,
                [operational].[asset].[last_modified_on]=@LastModifiedOn
            WHERE [operational].[asset].[asset_id]=@Id ";

        public override string SelectSql => @"
            SELECT [operational].[asset].[asset_id],
                   [operational].[asset].[name],
                   [operational].[asset].[description],
                   [operational].[asset].[status],
                   [operational].[asset].[host_name],
                   [operational].[asset].[contact_employee_id],
                   [operational].[asset].[owning_department_id],
                   [operational].[asset].[parent_asset_id],
                   [operational].[asset].[asset_type_id],
                   [operational].[asset].[created_by_id],
                   [operational].[asset].[created_on],
                   [operational].[asset].[last_modified_by_id],
                   [operational].[asset].[last_modified_on]
            FROM [operational].[asset] ";

        public override string DeleteSql => @"DELETE FROM [operational].[asset] WHERE [operational].[asset].[asset_id] = @Id";

        public override string GetByIdSql => $@"{SelectSql} WHERE [operational].[asset].[asset_id = @Id";
        public override ESC2.Module.System.Data.DataObjects.Operational.Asset ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Operational.Asset();
            obj.Id = row.GetGuid("asset_id");
            obj.Name = row.GetString("name");
            obj.Description = row.GetString("description");
            obj.Status = row.GetString("status");
            obj.HostName = row.GetString("host_name");
            obj.ContactEmployeeId = row.GetNullableGuid("contact_employee_id");
            obj.OwningDepartmentId = row.GetNullableGuid("owning_department_id");
            obj.ParentAssetId = row.GetNullableGuid("parent_asset_id");
            obj.AssetTypeId = row.GetGuid("asset_type_id");
            obj.CreatedById = row.GetGuid("created_by_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedById = row.GetGuid("last_modified_by_id");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Operational.Asset obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Name", obj.Name, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Description", obj.Description, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Status", obj.Status, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("HostName", obj.HostName, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("ContactEmployeeId", obj.ContactEmployeeId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("OwningDepartmentId", obj.OwningDepartmentId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("ParentAssetId", obj.ParentAssetId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("AssetTypeId", obj.AssetTypeId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedById", obj.CreatedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedById", obj.LastModifiedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}
