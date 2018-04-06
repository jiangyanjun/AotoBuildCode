using System.Collections.Generic;

namespace Model
{
    public class CodeCreate
    {
        /// <summary>
        /// 数据库服务器ID
        /// </summary>
        public string ServerID { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        private string nameSpace;
        public string NameSpace
        {
            get
            {
                if (nameSpace != null && nameSpace.Length <= 0)
                    return null;
                else
                    return nameSpace;
            }
            set { nameSpace = value; }
        }
        /// <summary>
        /// 二级命名空间
        /// </summary>
        private string nameSpace1 { get; set; }
        public string NameSpace1
        {
            get
            {
                if (nameSpace1 != null && nameSpace1.Length <= 0)
                    return null;
                else
                    return nameSpace1;
            }
            set { nameSpace1 = value; }
        }
        /// <summary>
        /// 表名
        /// </summary>
        private string tableName { get; set; }
        public string TableName
        {
            get
            {
                if (tableName != null && tableName.Length <= 0)
                    return null;
                else
                    return tableName;
            }
            set { tableName = value; }
        }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 生成类型
        /// </summary>
        public BuilderType BuilderType { get; set; }

        /// <summary>
        /// 生成方法列表
        /// </summary>
        public List<BuilderMethods> MethodList { get; set; }

        /// <summary>
        /// 类命名空间
        /// </summary>
        public Model.ConfigNameSpaceClass CNSC { get; set; }
        /// <summary>
        /// 类命名空间
        /// </summary>
        public DatabaseType dataBaseType { get; set; }
    }
}
