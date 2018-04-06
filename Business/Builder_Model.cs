using System.Collections.Generic;
using System.Text;
using Common;
using IData;

namespace Business
{
    internal class Builder_Model
    {
        private ICreateCode createInstance;
        private IDatabase databaseInstance;
        private Import import;
        public Builder_Model(Model.DatabaseType dbType)
        {
            this.createInstance = Factory.Factory.CreateCreateCodeInstance(dbType);
            this.databaseInstance = Factory.Factory.CreateDatabaseInstance(dbType);
            this.import = new Import(dbType);
        }
        /// <summary>
        /// 得到实体层
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetModelClass(Model.CodeCreate param)
        {
            Model.Servers server = Config.GetServer(param.ServerID);
            if (server == null)
            {
                return string.Empty;
            }
            List<Model.Fields> fields = Database.GetFields(server.ID, param.DbName, param.TableName);
            StringBuilder model = new StringBuilder(import.GetImport_Model());
            //namespace .Model.
            model.Append("namespace " + param.NameSpace + (param.NameSpace == null ? "" : ".") + param.CNSC.Model + (param.NameSpace1 == null ? "" : "." + param.NameSpace1) + "\r\n");
            model.Append("{\r\n");
            model.Append("\t[Serializable]\r\n");
            model.Append("\tpublic class " + param.ClassName + "\r\n");
            model.Append("\t{\r\n");
            foreach (var field in fields)
            {
                model.Append("\t\t/// <summary>\r\n");
                model.Append("\t\t/// " + (field.Note == null ? field.Name : field.Note) + "\r\n");
                model.Append("\t\t/// </summary>\r\n");
                model.Append("\t\t[DisplayName(\"" + (field.Note == null ? field.Name : field.Note) + "\")]\r\n");
                model.Append("\t\tpublic " + field.DotNetType + " " + field.Name + " { get; set; }\r\n\r\n");
            }
            model.Append("\t}\r\n");
            model.Append("}\r\n");
            return model.ToString();
        }
        /// <summary>
        /// 得到实体层
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetModelClass2(Model.CodeCreate param)
        {
            Model.Servers server = Config.GetServer(param.ServerID);
            if (server == null)
            {
                return string.Empty;
            }
            List<Model.Fields> fields = Database.GetFields(server.ID, param.DbName, param.TableName);
            StringBuilder model = new StringBuilder(import.GetImport_Model2());
            model.Append("namespace " + param.NameSpace + (param.NameSpace == null ? "" : ".") + param.CNSC.Model + (param.NameSpace1 == null ? "" : "." + param.NameSpace1) + "\r\n");
            model.Append("{\r\n");
            model.Append("\t[Serializable]\r\n");
            model.Append("\tpublic class " + param.ClassName + "\r\n");
            model.Append("\t{\r\n");
            foreach (var field in fields)
            {
                model.Append("\t\t/// <summary>\r\n");
                model.Append("\t\t/// " + (field.Note == null ? field.Name : field.Note) + "\r\n");
                model.Append("\t\t/// </summary>\r\n");
                model.Append("\t\tpublic " + field.DotNetType + " " + field.Name + " { get; set; }\r\n\r\n");
            }
            model.Append("\t}\r\n");
            model.Append("}\r\n");
            return model.ToString();
        }
    }
}
