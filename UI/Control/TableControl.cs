using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using Model;
using Business;

namespace UI.Control
{
    public partial class TableControl : UserControl
    {
        #region 公有属性
        public TreeView tvTables { get { return (TreeView)groupBox1.Controls["tvTables"]; } }
        #endregion

        #region Validation
        public bool Valid()
        {
            return true;
        }
        #endregion

        #region 构造函数

        public TableControl()
        {
            InitializeComponent();
        }

        #endregion

         #region 方法

        public void InitControl(SqlConnectionStringBuilder conn, string schema)
        {
            groupBox1.Controls.Clear();

            TableBusiness tableBusiness = new TableBusiness();
            try
            {
                List<Table> lstTable = tableBusiness.ListTables(conn, schema);

                TreeView tree = new TreeView();
                tree.ImageList = lstImage;
                tree.Name = "tvTables";
                tree.CheckBoxes = true;
                tree.AfterCheck += new TreeViewEventHandler(tree_AfterCheck);
                tree.Dock = DockStyle.Fill;
                AdvancedTreeNode node;
                AdvancedTreeNode nodeSon;

                foreach (Table table in lstTable)
                {
                    node = new AdvancedTreeNode();
                    node.Checked = true;
                    node.Text = table.Name;
                    node.Value = table;
                    node.SelectedImageIndex = (int)DBImage.TABLE;
                    node.ImageIndex = (int)DBImage.TABLE;
                    tree.Nodes.Add(node);
                    foreach (Column column in table.Columns)
                    {
                        nodeSon = new AdvancedTreeNode();
                        nodeSon.Checked = true;
                        nodeSon.Text = column.Name + " (" + ListarAtributos(column) + ")";
                        nodeSon.Value = column;
                        nodeSon.SelectedImageIndex = GetImageIndex(column);
                        nodeSon.ImageIndex = GetImageIndex(column);
                        node.Nodes.Add(nodeSon);
                    }
                }

                groupBox1.Controls.Add(tree);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetImageIndex(Column column)
        {
            if (column.PrimaryKey)
            {
                return (int)DBImage.PRIMARY_KEY;
            }
            else if (column.ForeignKey)
            {
                return (int)DBImage.FOREIGN_KEY;
            }
            else
            {
                return (int)DBImage.FIELD;
            }
        }
        private string ListarAtributos(Column column)
        {
            string attributes = String.Empty;

            if (column.PrimaryKey)
            {
                attributes += "PK, ";
            }

            if (column.ForeignKey)
            {
                attributes += "FK, ";
            }

            if (column.CharacterMaximumLength != null)
            {
                attributes += column.Type + "(" + column.CharacterMaximumLength + "), ";
            }
            else
            {
                attributes += column.Type + ", ";
            }

            attributes += (column.Nullable) ? "null" : "not null";

            return attributes;
        }

        #endregion

        #region Events

        void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
	        {
                item.Checked = e.Node.Checked;		 
	        }
        }

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox1.Controls["tvTables"] != null && ((TreeView)groupBox1.Controls["tvTables"]).Nodes.Count > 0)
            {
                foreach (TreeNode node in ((TreeView)groupBox1.Controls["tvTables"]).Nodes)
                {
                    node.Checked = cbCheckAll.Checked;
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode nodeSon in node.Nodes)
                        {
                            nodeSon.Checked = cbCheckAll.Checked;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
