using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Model;

namespace UI
{
    public static class StaticTool
    {
        /// <summary>
        /// 当前连接服务唯一ID
        /// </summary>
        public static string ServerID { get; set; }
        /// <summary>
        /// 根据父节点表获取选择的字段
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static TreeView TreeChind(TreeNode n)
        {
            TreeView tree = new TreeView();
            AdvancedTreeNode node;
            string ParentName = ((Model.TreeNodeTag)n.Parent.Tag).Tag.ToString();
            if (n.Nodes.Count > 0)
            {
                foreach (TreeNode item in n.Nodes)
                {
                    if (!item.Checked) continue;
                    node = new AdvancedTreeNode();
                    node.Text = item.Text;
                    node.Name = item.Name;
                    node.Value = item;
                    node.SelectedImageIndex = (int)DBImage.TABLE;
                    node.ImageIndex = (int)DBImage.TABLE;
                    node.Checked = item.Checked;
                    tree.Nodes.Add(node);
                }
            }
            else
            {
                var fields = Database.GetFields(StaticTool.ServerID, ParentName, n.Name);
                foreach (var field in fields)
                {
                    node = new AdvancedTreeNode();
                    node.Name = field.Name;
                    node.Text = string.Format("{0}({1}{2},{3})", field.Name, field.Type, field.Length != -1 ? "(" + field.Length.ToString() + ")" : "", field.IsNull ? "null" : "not null");
                    node.ImageIndex = field.IsPrimaryKey ? 5 : 3;
                    node.SelectedImageIndex = field.IsPrimaryKey ? 5 : 3;
                    node.Tag = new Model.TreeNodeTag() { Type = TreeNodeType.Field, Tag = field };
                    node.Checked = true;
                    tree.Nodes.Add(node);
                }
            }
            return tree;
        }
        /// <summary>
        /// 当前选择的所有表
        /// </summary>
        public static TreeView Get_TreeView
        {
            get
            {
                TreeView tree = new TreeView();
                AdvancedTreeNode node;
                var data =Home.form_Database.GetTreeView1Selected();
                foreach (TreeNode n in data)
                {
                    if (!n.Checked) continue;
                    node = new AdvancedTreeNode();
                    node.Text = n.Name;
                    node.Value = n;
                    node.SelectedImageIndex = (int)DBImage.TABLE;
                    node.ImageIndex = (int)DBImage.TABLE;
                    node.Checked = n.Checked;
                    tree.Nodes.Add(node);
                }
                return tree;
            }
        }
        //public Hashtable conversionBDCSTable;
        public static string GetColumnsType(string key)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("tinyint", "short");
            dict.Add("smallint", "short");
            dict.Add("int", "int");
            dict.Add("bigint", "long");
            dict.Add("bit", "bool");
            dict.Add("decimal", "decimal");
            dict.Add("numeric", "decimal");
            dict.Add("smallmoney", "decimal");
            dict.Add("money", "decimal");
            dict.Add("real", "decimal");
            dict.Add("float", "float");
            dict.Add("smalldatetime", "DateTime");
            dict.Add("date", "DateTime");
            dict.Add("datetime", "DateTime");
            dict.Add("char", "char");
            dict.Add("varchar", "string");
            dict.Add("text", "string");
            dict.Add("nchar", "char");
            dict.Add("nvarchar", "string");
            dict.Add("ntext", "string");
            dict.Add("uniqueidentifier", "Guid");
            dict.Add("xml", "object");
            dict.Add("varbinary", "bool");
            foreach (var item in dict)
            {
                if (item.Key.ToString().Trim().ToUpper() == key.ToString().Trim().ToUpper())
                    return item.Value;
            }
            return "Undefined";
        }
 

    }
}
