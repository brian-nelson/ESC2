using System;
using System.Collections.Generic;
using System.Data;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator

namespace ESC2.Library.Data.Helpers
{
    public static class RowHelper
    {

        public static Guid GetGuid(this DataRow row, string columnName)
        {
            return (Guid)row[columnName];
        }

        public static Guid? GetNullableGuid(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (Guid)row[columnName];
        }

        public static int GetInt(this DataRow row, string columnName)
        {
            return (int)row[columnName];
        }

        public static int? GetNullableInt(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (int)row[columnName];
        }

        public static long GetLong(this DataRow row, string columnName)
        {
            return (long)row[columnName];
        }

        public static long? GetNullableLong(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (long)row[columnName];
        }

        public static short GetShort(this DataRow row, string columnName)
        {
            return (short)row[columnName];
        }

        public static short? GetNullableShort(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (short)row[columnName];
        }

        public static string GetString(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return Convert.ToString(row[columnName]);
        }

        public static DateTime GetDateTime(this DataRow row, string columnName)
        {
            return (DateTime)row[columnName];
        }

        public static DateTime? GetNullableDateTime(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (DateTime)row[columnName];
        }

        public static bool GetBool(this DataRow row, string columnName)
        {
            return (bool)row[columnName];
        }

        public static bool? GetNullableBool(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (bool)row[columnName];
        }

        public static double GetDouble(this DataRow row, string columnName)
        {
            return (double)row[columnName];
        }

        public static Double? GetNullableDouble(this DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
            {
                return null;
            }

            return (Double)row[columnName];
        }
    }
}
