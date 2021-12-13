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
// named UserRepo.cs
namespace ESC2.Module.System.Data.Repos
{
    public partial class UserRepo : AbstractGuidRepo<ESC2.Module.System.Data.DataObjects.User>
    {
        public UserRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "dbo";
        public override string TableName => "user";

        public override string InsertSql => @"
            INSERT INTO [dbo].[user] (
                [dbo].[user].[UserId],
                [dbo].[user].[Role],
                [dbo].[user].[IsEnabled],
                [dbo].[user].[PasswordHash],
                [dbo].[user].[PasswordSalt],
                [dbo].[user].[EmployeeId])
            VALUES ( 
                @Id,
                @Role,
                @IsEnabled,
                @PasswordHash,
                @PasswordSalt,
                @EmployeeId) ";

        public override string UpdateSql => @"
            UPDATE [dbo].[user] 
            SET [dbo].[user].[role]=@Role,
                [dbo].[user].[is_enabled]=@IsEnabled,
                [dbo].[user].[password_hash]=@PasswordHash,
                [dbo].[user].[password_salt]=@PasswordSalt,
                [dbo].[user].[employee_id]=@EmployeeId
            WHERE [dbo].[user].[user_id]=@Id ";

        public override string SelectSql => @"
            SELECT [dbo].[user].[user_id],
                   [dbo].[user].[role],
                   [dbo].[user].[is_enabled],
                   [dbo].[user].[password_hash],
                   [dbo].[user].[password_salt],
                   [dbo].[user].[employee_id]
            FROM [dbo].[user] ";

        public override ESC2.Module.System.Data.DataObjects.User ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.User();
            obj.Id = row.GetGuid("user_id");
            obj.Role = row.GetString("role");
            obj.IsEnabled = row.GetBool("is_enabled");
            obj.PasswordHash = row.GetString("password_hash");
            obj.PasswordSalt = row.GetString("password_salt");
            obj.EmployeeId = row.GetGuid("employee_id");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.User obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("Role", obj.Role, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("IsEnabled", obj.IsEnabled, DbQueryParameterType.Boolean));
            parameters.Add(new DbQueryParameter("PasswordHash", obj.PasswordHash, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("PasswordSalt", obj.PasswordSalt, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("EmployeeId", obj.EmployeeId, DbQueryParameterType.Guid));

            return parameters;
        }
    }
}