using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millennials.Creator.BaseClass
{
    public static class DBMLBaseClass
    {
        // 0 - name, 1 - connectionString, 2-tables
        public const string baseClassTemplate =

@"<?xml version=""1.0"" encoding=""utf-8""?>
<Database Name=""{0}"" Class=""DataClassesDataContext"" xmlns=""http://schemas.microsoft.com/linqtosql/dbml/2007"">
  <Connection Mode=""WebSettings"" ConnectionString=""{1}"" SettingsObjectName=""System.Configuration.ConfigurationManager.ConnectionStrings"" SettingsPropertyName=""db"" Provider=""System.Data.SqlClient"" />
  {2}
</Database>";

        // 0- name, 1 - tables, 2 - fields
        public const string baseTableTemplate =
        @"
      <Table Name=""{0}.{1}"" Member=""{1}"">
        <Type Name=""{1}"">
          {2}
        </Type>
      </Table>
";

        public const string baseColumnTemplate =
        @"  
            <Column Name=""{0}"" Type=""{1}"" DbType=""{2}"" CanBeNull=""{3}"" />";

        public const string baseColumnIdTemplate =
        @"
            <Column Name=""{0}"" Type=""{1}"" DbType=""{2}"" IsPrimaryKey=""true"" IsDbGenerated=""true"" CanBeNull=""false"" />";
    }
}