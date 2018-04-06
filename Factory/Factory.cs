using System.Reflection;
using Model;

namespace Factory
{
    public class Factory
    {
        public static IData.IDatabase CreateDatabaseInstance(DatabaseType databaseType)
        {
            string dllName = string.Empty;
            if (databaseType == DatabaseType.SqlServer2000
                || databaseType == DatabaseType.SqlServer)
            {
                dllName = "SqlServer";
            }
            else
            {
                dllName = databaseType.ToString();
            }
            return (IData.IDatabase)CreateInstance(dllName, "DataBase");
        }

        public static IData.ICreateCode CreateCreateCodeInstance(DatabaseType databaseType)
        {
            string dllName = string.Empty;
            if (databaseType == DatabaseType.SqlServer2000
                || databaseType == DatabaseType.SqlServer)
            {
                dllName = "SqlServer";
            }
            else
            {
                dllName = databaseType.ToString();
            }
            return (IData.ICreateCode)CreateInstance(dllName, "CreateCode");
        }
        private static object CreateInstance(string dllName, string className)
        {
            string str1 = string.Format("Data.{0}", dllName);
            string str2 = string.Format("Data.{0}.{1}", dllName, className);
            object obj = Assembly.Load(str1).CreateInstance(str2);
            if (obj == null)
            {
                Common.Func.WriteLog(string.Format("Data.{0}.{1} 创建实例为空", dllName, className));
            }
            return obj;
        }
    }
}
