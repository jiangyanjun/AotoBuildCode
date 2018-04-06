using System.Collections.Generic;
using System.Text;
using Common;
using IData;
using Model;

namespace Business
{
    internal class Builder_Factory
    {
        private ICreateCode createInstance;
        private IDatabase databaseInstance;
        private Import import;
        public Builder_Factory(Model.DatabaseType dbType)
        {
            this.createInstance = Factory.Factory.CreateCreateCodeInstance(dbType);
            this.databaseInstance = Factory.Factory.CreateDatabaseInstance(dbType);
            this.import = new Import(dbType);
        }

        /// <summary>
        /// 得到工厂层代码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetFactoryClass(Model.CodeCreate param)
        {
            Model.Servers server = Config.GetServer(param.ServerID);
            if (server == null)
            {
                return string.Empty;
            }
            List<Model.Fields> fields = databaseInstance.GetFields(server.ID, param.DbName, param.TableName);

            StringBuilder factory = new StringBuilder(import.GetImport_Factory());
            factory.Append("namespace " + param.NameSpace + (param.NameSpace == null ? "" : ".") + param.CNSC.Factory + (param.NameSpace1 == null ? "" : "." + param.NameSpace1) + "\r\n");
            factory.Append("{\r\n");
            factory.Append("\tpublic class " + param.ClassName + "\r\n");
            factory.Append("\t{\r\n");
            factory.Append("\t\t/// <summary>\r\n");
            factory.Append("\t\t/// 创建实例对象\r\n");
            factory.Append("\t\t/// </summary>\r\n");
            factory.Append("\t\tpublic static " + param.NameSpace + (param.NameSpace == null ? "" : ".") + param.CNSC.Interface + (param.NameSpace1 == null ? "" : "." + param.NameSpace1) + ".I" + param.ClassName + " CreateInstance()\r\n"); 
            factory.Append("\t\t{\r\n");
            factory.Append("\t\t\treturn CreateInstance(\"" + param.ClassName + "\") as " + param.CNSC.Interface + ".I" + param.ClassName + ";\r\n");
            factory.Append("\t\t}\r\n");
            factory.Append("\t\tpublic static object CreateInstance(string dllName)\r\n"); 
            factory.Append("\t\t{\r\n");
            factory.Append("\t\t\treturn Assembly.Load(\"" + param.CNSC.Data + "\").CreateInstance(string.Format(\"" + param.CNSC.Data + ".{1}" + "\"" + ",dllName));\r\n");
            factory.Append("\t\t}\r\n");
            factory.Append("\t}\r\n");

            factory.Append("}\r\n");

            return factory.ToString();
        }
    }
}
