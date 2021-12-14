using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ESC2.Library.Data.Constants;
using ESC2.Library.Data.Interfaces;
using ESC2.Library.Data.Objects;

namespace ESC2.Library.Data.SqlServer.DataProvider
{
    public class SqlServerDataProvider : IDataProvider
    {
        private readonly string _connectionString;

        public SqlServerDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlCommand CreateCommand(
            string sql, 
            List<DbQueryParameter> parameters, 
            int timeout = 30)
        {
            var output = new SqlCommand(sql);
            output.CommandTimeout = timeout;

            if (parameters != null)
            {
                AppendParameters(output, parameters);
            }

            return output;
        }

        private void AppendParameters(
            SqlCommand command, 
            List<DbQueryParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                SqlParameter dbParameter = new SqlParameter(parameter.Name, (DbType)parameter.ParameterType);

                if (parameter.Value == null)
                {
                    dbParameter.Value = DBNull.Value;
                }
                else
                {
                    dbParameter.Value = parameter.Value;
                }

                command.Parameters.Add(dbParameter);
            }
        }

        // private SqlDbType ToSqlDbType(DbQueryParameterType parameterType)
        // {
        //     switch (parameterType)
        //     {
        //         case DbQueryParameterType.AnsiString:
        //             return SqlDbType.Text;
        //         case DbQueryParameterType.Binary:
        //             return SqlDbType.Binary;
        //         case DbQueryParameterType.Byte:
        //             return SqlDbType.TinyInt;
        //         case DbQueryParameterType.Boolean:
        //             return SqlDbType.Bit;
        //         case DbQueryParameterType.Currency:
        //             return SqlDbType.Money;
        //         case DbQueryParameterType.Date:
        //             return SqlDbType.Date;
        //         case DbQueryParameterType.DateTime:
        //             return SqlDbType.DateTime;
        //         case DbQueryParameterType.Decimal:
        //             return SqlDbType.Decimal;
        //         case DbQueryParameterType.Double:
        //             return SqlDbType.Float;
        //         case DbQueryParameterType.Guid:
        //             return SqlDbType.UniqueIdentifier;
        //         case DbQueryParameterType.Int16:
        //             return SqlDbType.SmallInt;
        //         case DbQueryParameterType.Int32:
        //             return SqlDbType.Int;
        //         case DbQueryParameterType.Int64:
        //             return SqlDbType.BigInt;
        //         case DbQueryParameterType.Object:
        //             throw new Exception("Unsupported");
        //         case DbQueryParameterType.SByte:
        //             throw new Exception("Unsupported");
        //         case DbQueryParameterType.Single:
        //             return SqlDbType.Real;
        //         case DbQueryParameterType.String:
        //             return SqlDbType.Text;
        //         case DbQueryParameterType.Time:
        //             return SqlDbType.Time;
        //         case DbQueryParameterType.UInt16:
        //             return SqlDbType.SmallInt;
        //         case DbQueryParameterType.UInt32:
        //             return SqlDbType.Int;
        //         case DbQueryParameterType.UInt64:
        //             return SqlDbType.BigInt;
        //         case DbQueryParameterType.VarNumeric:
        //             throw new Exception("Unsupported");
        //         case DbQueryParameterType.AnsiStringFixedLength:
        //             return SqlDbType.Char;
        //         case DbQueryParameterType.StringFixedLength:
        //             return SqlDbType.Char;
        //         case DbQueryParameterType.Xml:
        //             return SqlDbType.Xml;
        //         case DbQueryParameterType.DateTime2:
        //             return SqlDbType.DateTime2;
        //         case DbQueryParameterType.DateTimeOffset:
        //             return SqlDbType.DateTimeOffset;
        //     }
        //
        //     throw new Exception("Unsupported");
        // }

        public DataTable GetData(string sql, List<DbQueryParameter> parameters = null, int timeout = 10)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    AppendParameters(command, parameters);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        dataAdapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public int Execute(string sql, List<DbQueryParameter> parameters = null, int timeout = 10)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    AppendParameters(command, parameters);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
