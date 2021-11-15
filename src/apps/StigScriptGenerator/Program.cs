using System;
using System.IO;
using System.Text;
using ESC2.Library.Data.Scripts.Convertor;
using ESC2.Library.Data.Scripts.Generators;
using ESC2.Library.Stig.Readers;

namespace StigScriptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Apache server
            StigToSql.Convert(
                "../../../../../../Samples/U_Apache_Server_2-4_UNIX_Server_STIG_V2R4_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\apache_server_2_4.sql");

            //Apache site
            StigToSql.Convert(
                "../../../../../../Samples/U_Apache_Server_2-4_UNIX_Site_STIG_V2R1_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\apache_site_2_4.sql");

            //Apple Mac Os 11
            StigToSql.Convert(
                "../../../../../../Samples/U_Apple_macOS_11_STIG_V1R4_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\macOS_11.sql");

            //Ubuntu 20.04
            StigToSql.Convert(
                "../../../../../../Samples/U_CAN_Ubuntu_20-04_LTS_STIG_V1R2_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\ubuntu_20-04.sql");

            //IIS Server
            StigToSql.Convert(
                "../../../../../../Samples/U_MS_IIS_10-0_Server_STIG_V2R4_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\iis_10_server.sql");

            //IIS Site
            StigToSql.Convert(
                "../../../../../../Samples/U_MS_IIS_10-0_Site_STIG_V2R4_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\iis_10_site.sql");

            //Windows Server 10
            StigToSql.Convert(
                "../../../../../../Samples/U_MS_Windows_10_STIG_V2R2_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\windows_10.sql");

            //Windows Server 2019
            StigToSql.Convert(
                "../../../../../../Samples/U_MS_Windows_Server_2019_STIG_V2R2_Manual-xccdf.xml",
                @"C:\Data\Stigs\Sql\windows_server_2019.sql");

        }
    }
}
