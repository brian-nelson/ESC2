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
namespace ESC2.Module.System.Data.Repos
{
    public partial class AssetRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.Asset>
    {
        public AssetRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "asset";

        public override string InsertSql => @"
            INSERT INTO [dbo].[asset] (
                [dbo].[asset].[asset_id],
                [dbo].[asset].[asset_type_id],
                [dbo].[asset].[name])
            VALUES ( 
                @Id,
                @AssetTypeId,
                @Name) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[asset] 
            SET [dbo].[asset].[asset_type_id]=@AssetTypeId,
                [dbo].[asset].[name]=@Name
            WHERE [dbo].[asset].[asset_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[asset].[asset_id],
                   [dbo].[asset].[asset_type_id],
                   [dbo].[asset].[name]
            FROM [dbo].[asset] ";

        public override ESC2.Module.System.Data.DataObjects.Asset ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Asset();
            obj.Id = row.GetGuid("asset_id");
            obj.AssetTypeId = row.GetGuid("asset_type_id");
            obj.Name = row.GetString("name");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Asset obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("AssetTypeId", obj.AssetTypeId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Name", obj.Name, DbQueryParameterType.String));

            return parameters;
        }
    }
}
