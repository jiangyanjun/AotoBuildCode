using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace Data
{
    public class TableData
    {

        /// <summary>
        /// List the tables of an especific database
        /// </summary>
        /// <param name="conn"> SQL Connection </param>
        /// <returns> tables list </returns>
        public List<Table> ListTables(SqlConnectionStringBuilder conn)
        {
            List<Table> lstTables = new List<Table>();
            ColumnData columnDataLayer = new ColumnData();

            using (SqlConnection dbConnection = new SqlConnection(conn.ConnectionString))
            {
                dbConnection.Open();
                StringBuilder strBuilder = new StringBuilder();
                SqlCommand cmd = new SqlCommand();

                strBuilder.Append("select ");
                strBuilder.Append("a.table_catalog, ");
                strBuilder.Append("a.table_schema, ");
                strBuilder.Append("a.table_name ");
                strBuilder.Append("from information_schema.tables a");
                
                cmd.CommandType = CommandType.Text;
                cmd.Connection = dbConnection;
                cmd.CommandText = strBuilder.ToString();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Table table = new Table();
                    table.Catalog = reader["table_catalog"].ToString();
                    table.Schema = reader["table_schema"].ToString();
                    table.Name = reader["table_name"].ToString();
                    // Fill the table columns
                    foreach (Column column in columnDataLayer.ListColumnsByTable(table,conn))
                    {
                        table.AddColumn(column);
                    }
                    lstTables.Add(table);
                }
                dbConnection.Close();
            }
            return lstTables;
        }
    }
}
