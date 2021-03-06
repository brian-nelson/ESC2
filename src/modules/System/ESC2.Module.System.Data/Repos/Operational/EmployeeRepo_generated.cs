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
// named EmployeeRepo.cs
namespace ESC2.Module.System.Data.Repos.Operational
{
    public partial class EmployeeRepo : AbstractDataRepo<ESC2.Module.System.Data.DataObjects.Operational.Employee, Guid>
    {
        public EmployeeRepo(IDataProvider dataProvider)
             : base(dataProvider)
        {
        }

        public override string SchemaName => "operational";
        public override string TableName => "employee";

        public override string InsertSql => @"
            INSERT INTO [operational].[employee] (
                [operational].[employee].[employee_id],
                [operational].[employee].[given_name],
                [operational].[employee].[family_name],
                [operational].[employee].[email],
                [operational].[employee].[job_title],
                [operational].[employee].[start_date],
                [operational].[employee].[end_date],
                [operational].[employee].[department_id],
                [operational].[employee].[created_by_id],
                [operational].[employee].[created_on],
                [operational].[employee].[last_modified_by_id],
                [operational].[employee].[last_modified_on])
            VALUES ( 
                @Id,
                @GivenName,
                @FamilyName,
                @Email,
                @JobTitle,
                @StartDate,
                @EndDate,
                @DepartmentId,
                @CreatedById,
                @CreatedOn,
                @LastModifiedById,
                @LastModifiedOn) ";

        public override string UpdateSql => @"
            UPDATE [operational].[employee] 
            SET [operational].[employee].[given_name]=@GivenName,
                [operational].[employee].[family_name]=@FamilyName,
                [operational].[employee].[email]=@Email,
                [operational].[employee].[job_title]=@JobTitle,
                [operational].[employee].[start_date]=@StartDate,
                [operational].[employee].[end_date]=@EndDate,
                [operational].[employee].[department_id]=@DepartmentId,
                [operational].[employee].[created_by_id]=@CreatedById,
                [operational].[employee].[created_on]=@CreatedOn,
                [operational].[employee].[last_modified_by_id]=@LastModifiedById,
                [operational].[employee].[last_modified_on]=@LastModifiedOn
            WHERE [operational].[employee].[employee_id]=@Id ";

        public override string SelectSql => @"
            SELECT [operational].[employee].[employee_id],
                   [operational].[employee].[given_name],
                   [operational].[employee].[family_name],
                   [operational].[employee].[email],
                   [operational].[employee].[job_title],
                   [operational].[employee].[start_date],
                   [operational].[employee].[end_date],
                   [operational].[employee].[department_id],
                   [operational].[employee].[created_by_id],
                   [operational].[employee].[created_on],
                   [operational].[employee].[last_modified_by_id],
                   [operational].[employee].[last_modified_on]
            FROM [operational].[employee] ";

        public override string DeleteSql => @"DELETE FROM [operational].[employee] WHERE [operational].[employee].[employee_id] = @Id";

        public override string GetByIdSql => $@"{SelectSql} WHERE [operational].[employee].[employee_id = @Id";
        public override ESC2.Module.System.Data.DataObjects.Operational.Employee ToObject(DataRow row)
        {
            var obj = new ESC2.Module.System.Data.DataObjects.Operational.Employee();
            obj.Id = row.GetGuid("employee_id");
            obj.GivenName = row.GetString("given_name");
            obj.FamilyName = row.GetString("family_name");
            obj.Email = row.GetString("email");
            obj.JobTitle = row.GetString("job_title");
            obj.StartDate = row.GetDateTime("start_date");
            obj.EndDate = row.GetNullableDateTime("end_date");
            obj.DepartmentId = row.GetGuid("department_id");
            obj.CreatedById = row.GetGuid("created_by_id");
            obj.CreatedOn = row.GetDateTime("created_on");
            obj.LastModifiedById = row.GetGuid("last_modified_by_id");
            obj.LastModifiedOn = row.GetDateTime("last_modified_on");
            return obj;
        }

        public override List<DbQueryParameter> ToParameters(ESC2.Module.System.Data.DataObjects.Operational.Employee obj)
        {
            List<DbQueryParameter> parameters = new List<DbQueryParameter>();
            parameters.Add(new DbQueryParameter("Id", obj.Id, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("GivenName", obj.GivenName, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("FamilyName", obj.FamilyName, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("Email", obj.Email, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("JobTitle", obj.JobTitle, DbQueryParameterType.String));
            parameters.Add(new DbQueryParameter("StartDate", obj.StartDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("EndDate", obj.EndDate, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("DepartmentId", obj.DepartmentId, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedById", obj.CreatedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("CreatedOn", obj.CreatedOn, DbQueryParameterType.DateTime));
            parameters.Add(new DbQueryParameter("LastModifiedById", obj.LastModifiedById, DbQueryParameterType.Guid));
            parameters.Add(new DbQueryParameter("LastModifiedOn", obj.LastModifiedOn, DbQueryParameterType.DateTime));

            return parameters;
        }
    }
}
