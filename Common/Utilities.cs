using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace Common
{
    public static class Utilities
    {
        #region convertdatatype

        // TRANSMISSINGCOMMENT: Method CheckDecimal
        public static decimal CheckDecimal(object dbValue, bool bUseZero)
        {
            decimal checkDecimalReturn;
            var dRetVal = Convert.ToDecimal(null);
            if (bUseZero)
            {
                dRetVal = 0;
            }
            if (dbValue == null)
            {
                checkDecimalReturn = dRetVal;
            }
            else if (dbValue == DBNull.Value)
            {
                checkDecimalReturn = dRetVal;
            }
            else
            {
                checkDecimalReturn = Convert.ToDecimal(dbValue);
            }

            return checkDecimalReturn;
        }

        // TRANSWARNING: Automatically generated because of optional parameter(s) 
        // TRANSMISSINGCOMMENT: Method CheckDecimal
        public static decimal CheckDecimal(object dbValue)
        {
            return CheckDecimal(dbValue, false);
        }

        // TRANSMISSINGCOMMENT: Method Utilities.CheckGuid
        public static Guid CheckGuid(object dbValue)
        {
            Guid checkGuidReturn;
            if (dbValue == null)
            {
                checkGuidReturn = Guid.Empty;
            }
            else if (dbValue == DBNull.Value)
            {
                checkGuidReturn = Guid.Empty;
            }
            else
            {
                checkGuidReturn = new Guid(dbValue.ToString());
            }

            return checkGuidReturn;
        }

        // TRANSMISSINGCOMMENT: Method Utilities.CheckString
        public static string CheckString(object dbValue)
        {
            string checkStringReturn;
            if (dbValue == null)
            {
                checkStringReturn = "";
            }
            else if (dbValue == DBNull.Value)
            {
                checkStringReturn = "";
            }
            else
            {
                checkStringReturn = Convert.ToString(dbValue).Trim();
            }

            return string.IsNullOrEmpty(checkStringReturn) ? null : checkStringReturn;
        }

        //
        public static string CheckDefaultString(object dbValue)
        {
            string checkStringReturn;
            if (dbValue == null)
            {
                checkStringReturn = "";
            }
            else if (dbValue == DBNull.Value)
            {
                checkStringReturn = "";
            }
            else
            {
                checkStringReturn = Convert.ToString(dbValue).Trim();
            }

            return checkStringReturn;
        }

        // TRANSMISSINGCOMMENT: Method CheckDateTime
        public static DateTime CheckDateTime(object dbValue)
        {
            DateTime dt;
            if (dbValue == null)
            {
                dt = DateTime.MinValue;
            }
            else if (dbValue == DBNull.Value)
            {
                dt = DateTime.MinValue;
            }
            else if (string.IsNullOrEmpty(dbValue.ToString()))
            {
                dt = DateTime.MinValue;
            }
            else
            {
                dt = Convert.ToDateTime(dbValue);
            }
            return dt;
        }

        // TRANSMISSINGCOMMENT: Method CheckDate
        public static string CheckDate(object dbValue)
        {
            DateTime dt;
            if (dbValue == null)
            {
                dt = DateTime.MinValue;
            }
            else if (dbValue == DBNull.Value)
            {
                dt = DateTime.MinValue;
            }
            else
            {
                dt = Convert.ToDateTime(dbValue);
            }
            return dt.ToString("d");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns>yyyy-MM-dd HH:mm:ss "null"</returns>
        public static string CheckDateTimeToFormatStringNulll(object dbValue)
        {

            if (dbValue == null)
            {
                return null;
            }

            if (dbValue == DBNull.Value)
            {
                return null;
            }

            if (string.IsNullOrEmpty(dbValue.ToString()))
            {
                return null;
            }

            var dt = Convert.ToDateTime(dbValue);
            return dt.ToString(SystemConst.DateTimeFormat);
        }

        // TRANSMISSINGCOMMENT: Method CheckFloat
        public static float CheckFloat(object dbValue)
        {
            float checkFloatReturn;
            var dRetVal = Convert.ToSingle(null);

            if (dbValue == null)
            {
                checkFloatReturn = dRetVal;
            }
            else if (dbValue == DBNull.Value)
            {
                checkFloatReturn = dRetVal;
            }
            else
            {
                checkFloatReturn = Convert.ToSingle(dbValue);
            }

            return checkFloatReturn;
        }

        // TRANSMISSINGCOMMENT: Method CheckDouble
        public static double CheckDouble(object dbValue)
        {
            double checkDoubleReturn;
            var dRetVal = Convert.ToDouble(null);

            if (dbValue == null)
            {
                checkDoubleReturn = dRetVal;
            }
            else if (dbValue == DBNull.Value)
            {
                checkDoubleReturn = dRetVal;
            }
            else
            {
                checkDoubleReturn = Convert.ToDouble(dbValue);
            }

            return checkDoubleReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        public static Int64 CheckInt64(object dbValue)
        {
            Int64 checkReturn;
            var dRetVal = Convert.ToInt64(null);

            if (dbValue == null)
            {
                checkReturn = dRetVal;
            }
            else if (dbValue == DBNull.Value)
            {
                checkReturn = dRetVal;
            }
            else
            {
                checkReturn = Convert.ToInt64(dbValue);
            }
            return checkReturn;
        }

        // TRANSMISSINGCOMMENT: Method Utilities.CheckInt
        public static int CheckInt(object dbValue)
        {
            int checkIntReturn;
            if (dbValue == null)
            {
                checkIntReturn = Convert.ToInt32(null);
            }
            else if (dbValue == DBNull.Value)
            {
                checkIntReturn = Convert.ToInt32(null);
            }
            else
            {
                checkIntReturn = Convert.ToInt32(dbValue);
            }
            return checkIntReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        public static int? CheckIntNull(object dbValue)
        {
            if (dbValue == null)
            {
                return null;
            }
            if (dbValue == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt32(dbValue);
        }


        // TRANSMISSINGCOMMENT: Method Utilities.CheckBool
        public static bool CheckBool(object dbValue)
        {
            bool checkBoolReturn;
            if (dbValue == null)
            {
                checkBoolReturn = false;
            }
            else if (dbValue == DBNull.Value)
            {
                checkBoolReturn = false;
            }
            else
            {
                checkBoolReturn = Convert.ToBoolean(dbValue);
            }
            return checkBoolReturn;
        }

        // TRANSMISSINGCOMMENT: Method Utilities.CheckNvarchar
        public static int CheckNvarchar(object dbValue)
        {
            int checkStringReturn;
            if (dbValue == null)
            {
                checkStringReturn = Convert.ToInt32(null);
            }
            else if (dbValue == DBNull.Value)
            {
                checkStringReturn = Convert.ToInt32(null);
            }
            else
            {
                checkStringReturn = Convert.ToInt32(dbValue);
            }

            return checkStringReturn;
        }

        public static DateTime? CheckDateNull(object value)
        {
            if (IsDate(value))
            {
                return DateTime.Parse(value.ToString());
            }
            return null;
        }

        #endregion

        #region Get Settings

        // Get settings of web.config
        public static string GetSettings(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey] ?? string.Empty;
        }

        #endregion

        #region Check data type
        public static bool IsValidTable(DataTable dt)
        {
            return dt != null && dt.Rows.Count > 0;
        }

        //check dataset has table
        public static bool IsValidDataSet(DataSet ds)
        {
            return ds != null && ds.Tables.Count > 0;
        }

        //
        public static bool IsPercent(string str)
        {
            Regex r;
            Match m;

            r = new Regex(@"^\d{1,3}(\.\d{1,2})?%$");
            m = r.Match(str);
            return m.Success;
        }

        //
        public static bool IsNumeric(string str)
        {
            Regex r;
            Match m;
            r = new Regex(@"^-?\d+(\.\d{1,2})?$");
            m = r.Match(str);
            return m.Success;
        }

        //
        public static bool IsToday(string datetime)
        {
            try
            {
                return !string.IsNullOrEmpty(datetime) && IsToday(Convert.ToDateTime(datetime));
            }
            catch (Exception err)
            {
                return false;
            }
        }

        //
        public static bool IsToday(DateTime datetime)
        {
            var dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var ts = datetime - dt;
            return ts.Days == 0;
            //return datetime.Subtract(DateTime.Now).Days == 0;
        }

        public static bool IsDate(string strDate)
        {
            string pattern = @"\A\d{2}-\d{2}-\d{2}|\A\d{4}-\d{2}-\d{2}";
            string pattern1 = @"\A\d{2}/\d{2}/\d{2}|\A\d{4}/\d{2}/\d{2}|\A\d{4}/\d{1}/\d{1}";
            DateTime outDate = new DateTime();
            if (Regex.IsMatch(strDate, pattern) || Regex.IsMatch(strDate, pattern1))
            {
                return DateTime.TryParse(strDate, out outDate);
            }
            else
            {
                return false;
            }
        }

        public static bool IsDate(object strDate)
        {
            return IsDate(strDate.ToString());
        }

        /// <summary>  
        /// 是否为时间型字符串  
        /// </summary>  
        /// <param name="source">时间字符串(15:00:00)</param>  
        /// <returns></returns>  
        public static bool IsTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        /// <summary>  
        /// 是否为日期+时间型字符串  
        /// </summary>  
        /// <param name="source"></param>  
        /// <returns></returns>  
        public static bool IsDateTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }

        //
        public static string CheckStreamString(Stream stream, Encoding encoding)
        {
            if (stream == null)
                return string.Empty;

            var reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }

        public static string CheckStreamString(Stream stream)
        {
            if (stream == null)
                return string.Empty;

            var reader = new StreamReader(stream, Encoding.UTF8);
            var rtvalue = reader.ReadToEnd();
            reader.Close();
            return rtvalue;
        }
        #endregion

        #region Transform string
        public static byte[] GetUTF8Bytes(Stream stream)
        {
            return Encoding.UTF8.GetBytes(CheckStreamString(stream));
        }

        public static byte[] GetUTF8Bytes(string strvalue)
        {
            return Encoding.UTF8.GetBytes(strvalue);
        }

        public static byte[] GetBytes(Stream stream)
        {
            if (stream.CanSeek)
            {
                var buffer = new byte[stream.Length];
                stream.Write(buffer, 0, buffer.Length);
                return buffer;
            }

            using (var mstream = new MemoryStream())
            {
                var bytes = new byte[0x1000];
                if (stream.CanRead)
                {
                    while (true)
                    {
                        var length = stream.Read(bytes, 0, bytes.Length);
                        if (length <= 0)
                        {
                            break;
                        }
                        mstream.Write(bytes, 0, length);
                    }
                }
                return mstream.ToArray();
            }
        }
        #endregion
              
        private static readonly string[] DataTypes = { "int", "float", "decimal", "numeric", "bigint", "bit", "money", "tinyint", "number" };

        public static string GetUpdateSql(object value, object datatype)
        {
            if (DataTypes.ToList().Contains(datatype.ToString().ToLower()))
            {
                return "=" + value + ",";
            }
            return "=N'" + value + "',";
        }

        public static DataTable ConvertXMLToDataTable(XmlNode xml)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml.InnerXml);
            var xmlReader = new XmlNodeReader(xmldoc);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            if (IsValidDataSet(dataSet))
            {
                return dataSet.Tables[0];
            }
            return new DataTable();
        }

        public static string GetDictionaryValue(string key, Dictionary<string, string> dictionary)
        {
            if (string.IsNullOrWhiteSpace(key) || dictionary == null)
            {
                return string.Empty;
            }

            return dictionary.Keys.Contains(key) ? dictionary[key] : string.Empty;
        }

        public static string GetStoreFieldFormate(string fieldnm)
        {
            return fieldnm.Replace(".", "_");
        }

        public static string GetTableColunmFieldFormate(string colunmnm)
        {
            return colunmnm.Replace("_", ".");
        }

        public static DataTable DataSetMergeToDataTable(DataSet dataSet)
        {
            var mergedtable = new DataTable();
            int rowCount = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn c in table.Columns)
                {
                    mergedtable.Columns.Add(c.ColumnName, c.DataType);
                }
                rowCount = table.Rows.Count > rowCount ? table.Rows.Count : rowCount;
            }

            for (int i = 0; i < rowCount; i++)
            {
                var rowItems = new object[mergedtable.Columns.Count];
                int index = 0;
                foreach (DataTable table in dataSet.Tables)
                {
                    var obj = table.Rows.Count > i ? table.Rows[i].ItemArray : new object[table.Columns.Count];
                    obj.CopyTo(rowItems, index);
                    index += obj.Length;
                }
                mergedtable.Rows.Add(rowItems);
            }
            return mergedtable;
        }

        public static Dictionary<string, List<string>> GetConfigDynamicList(string configkey)
        {
            var rtvalue = new Dictionary<string, List<string>>();
            string strapps = Utilities.GetSettings(configkey);
            if (!string.IsNullOrWhiteSpace(strapps))
            {
                foreach (string strapp in strapps.Split('|'))
                {
                    if (string.IsNullOrWhiteSpace(strapp))
                    {
                        continue;
                    }
                    string key = strapp.Split(':')[0].Replace("\\r\\n", "").ToUpper().Trim();
                    string[] values = strapp.Split(':')[1].Split(',');
                    if (!rtvalue.Keys.ToList().Contains(key))
                    {
                        rtvalue.Add(key, values.ToList());
                    }
                    else
                    {
                        rtvalue[key] = values.ToList();
                    }
                }
            }
            return rtvalue;
        }

        public static string GetTableColunmFieldFormateWithTableNm(string tablenm, string fieldnm)
        {
            if (fieldnm.ToLower().IndexOf("projn_s") > -1)
            {
                return tablenm + "." + fieldnm;
            }
            if (fieldnm.IndexOf('_') > 0)
            {
                return fieldnm.Replace("_", ".");
            }
            return tablenm + "." + fieldnm;
        }

        public static string ReplaceSpecialCharForXML(string value)
        {
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        /// <summary>
        /// 转化一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> list)
        {
            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }

        #region IList function
        public static IEnumerable<T> Distinct<T, TV>(this IEnumerable<T> source, Func<T, TV> keySelector)
        {
            return source.Distinct(new CommonEqualityComparer<T, TV>(keySelector));
        }

        public static IEnumerable<T> Distinct<T, TV>(IEnumerable<T> source, Func<T, TV> keySelector, IEqualityComparer<TV> comparer)
        {
            return source.Distinct(new CommonEqualityComparer<T, TV>(keySelector, comparer));
        }
        #endregion
    }

    public class CommonEqualityComparer<T, TR> : IEqualityComparer<T>
    {
        private readonly Func<T, TR> _keySelector;
        private readonly IEqualityComparer<TR> _comparer;

        public CommonEqualityComparer(Func<T, TR> keySelector, IEqualityComparer<TR> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public CommonEqualityComparer(Func<T, TR> keySelector)
            : this(keySelector, EqualityComparer<TR>.Default)
        { }

        public bool Equals(T x, T y)
        {
            return _comparer.Equals(_keySelector(x), _keySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return _comparer.GetHashCode(_keySelector(obj));
        }
    }
}