using System;

namespace Millennials.Creator.BaseClass
{
    public static class BaseDAOBaseClass
    {
        public const string baseClassTemplate =

        @"using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace {0}
{{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAO
    {{
       protected string connectionString;
       protected SqlConnection conn;
       protected SqlCommand cmd;

       public BaseDAO()
       {{
            connectionString = ConfigurationManager.ConnectionStrings[""conn""].ConnectionString;
       }}
    }}
    
    /// <summary>
    ///  Convert a datareader to a typed list
    /// </summary>
    public class CastDbType<TEntity>
            where TEntity : new()
    {{
        //a dictionary of all properties on the entity
        private IDictionary<string, MemberInfo> _properties = new Dictionary<string, MemberInfo>();
        private Type _type = typeof(TEntity);

        /// <summary>
        /// Convert a datareader to a list
        /// </summary>
        /// <param name=""dataReader""> data reader</param>
        /// <returns>A list of the specified entities</returns>
        public IList<TEntity> Fill(SqlDataReader dataReader)
        {{
            if (dataReader == null) throw new ArgumentNullException(""dataReader"");

            var result = new List<TEntity>();
            if (!dataReader.HasRows) return result;

            //a list of dictionaries for each row
            var rows = new List<IDictionary<string, object>>();
            while (dataReader.Read())
            {{
                rows.Add(ReadRow(dataReader));
            }}

            //close the dataReader
            dataReader.Close();

            //use the list of dictionaries
            foreach (var row in rows)
            {{
                result.Add(BuildEntity(row));
            }}

            return result;
        }}

        private IDictionary<string, object> ReadRow(IDataRecord record)
        {{
            var row = new Dictionary<string, object>();
            for (int i = 0; i < record.FieldCount; i++)
            {{
                row.Add(record.GetName(i), record.GetValue(i));
            }}
            return row;
        }}

        private TEntity BuildEntity(IDictionary<string, object> row)
        {{
            var entity = new TEntity();

            foreach (var item in row)
            {{
                var key = item.Key;
                var value = item.Value;
                if (value == DBNull.Value) value = null; //may be DBNull

                SetProperty(key, entity, value);
            }}

            return entity;
        }}

        #region Reflect into entity
        private void SetProperty(string key, TEntity entity, object value)
        {{
            //first try dictionary
            if (_properties.ContainsKey(key))
            {{
                SetPropertyFromDictionary(_properties[key], entity, value);
                return;
            }}

            //otherwise (should be first time only) reflect it out
            //first look for a writeable public property of any case
            var property = _type.GetProperty(key,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (property != null && property.CanWrite)
            {{
                _properties.Add(key, property);
                property.SetValue(entity, value, null);
                return;
            }}

            //look for a nonpublic field with the standard _ prefix
            var field = _type.GetField(""_"" + key,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            _properties.Add(key, field);
            field.SetValue(entity, value);
        }}

        private void SetPropertyFromDictionary(MemberInfo member, TEntity entity, object value)
        {{
            var property = member as PropertyInfo;
            if (property != null)
                property.SetValue(entity, value, null);
            var field = member as FieldInfo;
            if (field != null)
                field.SetValue(entity, value);
        }}
        #endregion
    }}
}}";

    }
}