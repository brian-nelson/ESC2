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
namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class UserRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Operational.User, Guid>
    {
        public UserRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "operational";
        public override string TableName => "user";

        public override string InsertSql => @"
            INSERT INTO [operational].[user] (
                [operational].[user].[user_id],
                [operational].[user].[user_role_id],
                [operational].[user].[is_enabled],
                [operational].[user].[password_hash],
                [operational].[user].[password_salt],
                [operational].[user].[employee_id],
                [operational].[user].[created_by_id],
                [operational].[user].[created_on],
                [operational].[user].[last_modified_by_id],
                [operational].[user].[last_modified_on])
            VALUES ( 
                @Id,
                @UserRoleId,
                @IsEnabled,
                @PasswordHash,
                @PasswordSalt,
                @EmployeeId,
                @CreatedById,
                @CreatedOn,
                @LastModifiedById,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [operational].[user] 
            SET [operational].[user].[user_role_id]=@UserRoleId,
                [operational].[user].[is_enabled]=@IsEnabled,
                [operational].[user].[password_hash]=@PasswordHash,
                [operational].[user].[password_salt]=@PasswordSalt,
                [operational].[user].[employee_id]=@EmployeeId,
                [operational].[user].[created_by_id]=@CreatedById,
                [operational].[user].[created_on]=@CreatedOn,
                [operational].[user].[last_modified_by_id]=@LastModifiedById,
                [operational].[user].[last_modified_on]=@LastModifiedOn
            WHERE [operational].[user].[user_id]=@Id ";

        public override string SelectSql => @"
            SELECT [operational].[user].[user_id],
                   [operational].[user].[user_role_id],
                   [operational].[user].[is_enabled],
                   [operational].[user].[password_hash],
                   [operational].[user].[password_salt],
                   [operational].[user].[employee_id],
                   [operational].[user].[created_by_id],
                   [operational].[user].[created_on],
                   [operational].[user].[last_modified_by_id],
                   [operational].[user].[last_modified_on]
            FROM [operational].[user] ";

        public override string DeleteSql => @"DELETE FROM [operational].[user] WHERE [operational].[user].[user_id] = @Id";

        public override string GetByIdSql => $@"{SelectSql} WHERE [operational].[user].[user_id = @Id";
        public override ESC2.Module.System.Data.DataObjects.Operational.User ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Operational.User();
            obj.Id = row.GetGuid("user_id");
            obj.UserRoleId = row.GetGuid("user_role_id");
            obj.IsEnabled = row.GetBool("is_enabled");
            obj.PasswordHash = row.GetString("password_hash");
            obj.PasswordSalt = row.GetString("password_salt");
            obj.EmployeeId = row.GetGuid("employee_id");
            obj.CreatedById = row.GetGuid("created_by_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedById = row.GetGuid("last_modified_by_id");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Operational.User obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("UserRoleId", obj.UserRoleId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("IsEnabled", obj.IsEnabled, DbQueryParameterType.Boolean));
            parameters.Add(new DbQueryParameter("PasswordHash", obj.PasswordHash, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("PasswordSalt", obj.PasswordSalt, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("EmployeeId", obj.EmployeeId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedById", obj.CreatedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedById", obj.LastModifiedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}
