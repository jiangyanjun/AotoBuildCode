using System.Collections.Generic;
using System.Data.SqlClient;
using Data;
using Model;

namespace Business
{
    public class TableBusiness
    {
        /// <summary>
        /// List the tables of a specific database
        /// </summary>
        /// <param name="conn"> SQL Connection </param>
        /// <returns> tables list </returns>
        public List<Table> ListTables(SqlConnectionStringBuilder conn, string db)
        {
            conn.InitialCatalog = db;
            return new TableData().ListTables(conn);
        }
    }
}
