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
// named AssetGroupRepo.cs
namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class AssetGroupRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Operational.AssetGroup, Guid>
    {
        public AssetGroupRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "operational";
        public override string TableName => "asset_group";

        public override string InsertSql => @"
            INSERT INTO [operational].[asset_group] (
                [operational].[asset_group].[asset_group_id],
                [operational].[asset_group].[name],
                [operational].[asset_group].[created_by_id],
                [operational].[asset_group].[created_on],
                [operational].[asset_group].[last_modified_by_id],
                [operational].[asset_group].[last_modified_on])
            VALUES ( 
                @Id,
                @Name,
                @CreatedById,
                @CreatedOn,
                @LastModifiedById,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [operational].[asset_group] 
            SET [operational].[asset_group].[name]=@Name,
                [operational].[asset_group].[created_by_id]=@CreatedById,
                [operational].[asset_group].[created_on]=@CreatedOn,
                [operational].[asset_group].[last_modified_by_id]=@LastModifiedById,
                [operational].[asset_group].[last_modified_on]=@LastModifiedOn
            WHERE [operational].[asset_group].[asset_group_id]=@Id ";

        public override string SelectSql => @"
            SELECT [operational].[asset_group].[asset_group_id],
                   [operational].[asset_group].[name],
                   [operational].[asset_group].[created_by_id],
                   [operational].[asset_group].[created_on],
                   [operational].[asset_group].[last_modified_by_id],
                   [operational].[asset_group].[last_modified_on]
            FROM [operational].[asset_group] ";

        public override ESC2.Module.System.Data.DataObjects.Operational.AssetGroup ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Operational.AssetGroup();
            obj.Id = row.GetGuid("asset_group_id");
            obj.Name = row.GetString("name");
            obj.CreatedById = row.GetGuid("created_by_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedById = row.GetGuid("last_modified_by_id");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Operational.AssetGroup obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Name", obj.Name, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("CreatedById", obj.CreatedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedById", obj.LastModifiedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}