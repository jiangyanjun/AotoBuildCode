using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Table
    {
           #region 私有属性

        private string catalog;
        private string schema;
        private string name;
        private List<Column> columns;

        #endregion

        #region 构造函数

        public Table()
        {
            columns = new List<Column>();
        }

        #endregion

        #region 公有属性

        public string Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        public string Schema
        {
            get { return schema; }
            set { schema = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Column> Columns
        {
            get { return columns; }

        }

        public void AddColumn(Column column)
        {
            columns.Add(column);
        }

        #endregion
    }
    /// <summary>
    /// 数据库所包含的表
    /// </summary>
    public class Tables
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }


    }
    public class Views
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// 字段类
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 是否可为空
        /// </summary>
        public bool IsNull { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 是否是自增列
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 对应的.net类型
        /// </summary>
        public string DotNetType { get; set; }
        /// <summary>
        /// 对应的.net SQL类型
        /// </summary>
        public string DotNetSqlType { get; set; }
        /// <summary>
        /// 默认值 
        /// </summary>
        public string Default { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Note { get; set; }

    }
}
