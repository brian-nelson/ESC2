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
// named AssetTypeRepo.cs
namespace ESC2.Module.System.Data.Repos
{
    public partial class AssetTypeRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.AssetType>
    {
        public AssetTypeRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "asset_type";

        public override string InsertSql => @"
            INSERT INTO [dbo].[asset_type] (
                [dbo].[asset_type].[AssetTypeId],
                [dbo].[asset_type].[Name],
                [dbo].[asset_type].[Description],
                [dbo].[asset_type].[Manufacturer],
                [dbo].[asset_type].[Model],
                [dbo].[asset_type].[Version],
                [dbo].[asset_type].[ImplementationGuideId],
                [dbo].[asset_type].[AssetGroupId])
            VALUES ( 
                @Id,
                @Name,
                @Description,
                @Manufacturer,
                @Model,
                @Version,
                @ImplementationGuideId,
                @AssetGroupId) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[asset_type] 
            SET [dbo].[asset_type].[name]=@Name,
                [dbo].[asset_type].[description]=@Description,
                [dbo].[asset_type].[manufacturer]=@Manufacturer,
                [dbo].[asset_type].[model]=@Model,
                [dbo].[asset_type].[version]=@Version,
                [dbo].[asset_type].[implementation_guide_id]=@ImplementationGuideId,
                [dbo].[asset_type].[asset_group_id]=@AssetGroupId
            WHERE [dbo].[asset_type].[asset_type_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[asset_type].[asset_type_id],
                   [dbo].[asset_type].[name],
                   [dbo].[asset_type].[description],
                   [dbo].[asset_type].[manufacturer],
                   [dbo].[asset_type].[model],
                   [dbo].[asset_type].[version],
                   [dbo].[asset_type].[implementation_guide_id],
                   [dbo].[asset_type].[asset_group_id]
            FROM [dbo].[asset_type] ";

        public override ESC2.Module.System.Data.DataObjects.AssetType ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.AssetType();
            obj.Id = row.GetGuid("asset_type_id");
            obj.Name = row.GetString("name");
            obj.Description = row.GetString("description");
            obj.Manufacturer = row.GetString("manufacturer");
            obj.Model = row.GetString("model");
            obj.Version = row.GetString("version");
            obj.ImplementationGuideId = row.GetNullableGuid("implementation_guide_id");
            obj.AssetGroupId = row.GetGuid("asset_group_id");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.AssetType obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Name", obj.Name, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Description", obj.Description, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Manufacturer", obj.Manufacturer, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Model", obj.Model, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Version", obj.Version, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("ImplementationGuideId", obj.ImplementationGuideId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("AssetGroupId", obj.AssetGroupId, DbQueryParameterType.Guid));

            return parameters;
        }
    }
}