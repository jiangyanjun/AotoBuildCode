using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Business;
using Common;
using Model;

namespace UI
{
    public partial class Form_Code_SetText : Form
    {
        private TreeNode node = null;
        private Form fm = null;
        public Form_Code_SetText()
        {
            InitializeComponent();
            fm = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Code_SetText_Load(object sender, EventArgs e)
        {
            var selNode = Home.form_Database.treeView1.SelectedNode;
            if (selNode == null || (((TreeNodeTag)selNode.Tag).Type != TreeNodeType.Table && ((TreeNodeTag)selNode.Tag).Type != TreeNodeType.View))
            {
                var nodes = Home.form_Database.GetTreeView1Selected();
                if (nodes.Count > 0)
                {
                    node = nodes.First();
                }
            }
            else
            {
                node = selNode;
            }

            if (node == null)
            {
                this.Close();
            }
            else
            {
                this.textBox2.Text = ((TreeNodeTag)node.Tag).Tag.ToString();
                this.Text = string.Format("生成代码至文本框--表:{0}", this.textBox2.Text);
            }
            this.label7.Text = "";
            Form.CheckForIllegalCrossThreadCalls = false;

            //加载默认命名空间
            ConfigNameSpace cnsDefault = new Config_NameSpace().GetDefault();
            if (cnsDefault != null)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "正在执行中";
            //OpaqueCommand oc = new OpaqueCommand(125,true);
            //oc.ShowOpaqueLayer(fm);
            //oc.HideOpaqueLayer();
            this.button1.Enabled = false;
            new Thread(delegate()
            {
                this.Invoke(new Action(delegate
                {
                    AddNameSpace();
                    CreateCode();
                }));
            }).Start();
        }
        private void AddNameSpace()
        {
            new Config_NameSpace().Add(new ConfigNameSpace()
            {
                Name1 = "",
                Name2 = ""
            });
        }
        /// <summary>
        /// 生成代码条件
        /// </summary>
        /// <returns></returns>
        public CodeCreate GetCodeCreateSources()
        {
            TreeNode dbNode = node.Parent.Parent;
            TreeNode serverNode = Home.form_Database.GetRoot(node);
            if (dbNode == null || serverNode == null)
            {
                return null;
            }
            List<BuilderMethods> methods = new List<BuilderMethods>();
            if (checkBox_add.Checked) methods.Add(BuilderMethods.Add);
            if (checkBox_count.Checked) methods.Add(BuilderMethods.Count);
            if (checkBox_delete.Checked) methods.Add(BuilderMethods.Delete);
            if (checkBox_exists.Checked) methods.Add(BuilderMethods.Exists);
            if (checkBox_getall.Checked) methods.Add(BuilderMethods.SelectAll);
            if (checkBox_getbykey.Checked) methods.Add(BuilderMethods.SelectByKey);
            if (checkBox_update.Checked) methods.Add(BuilderMethods.Update);
            Servers server = (Servers)((TreeNodeTag)serverNode.Tag).Tag;      
            CodeCreate param = new CodeCreate();
            param.ClassName = this.textBox2.Text == null ? ((TreeNodeTag)node.Tag).Tag.ToString() : this.textBox2.Text.Trim();
            param.DbName = ((TreeNodeTag)dbNode.Tag).Tag.ToString();
            param.NameSpace = "";
            param.NameSpace1 = "";
            param.ServerID = server.ID;
            param.TableName = ((TreeNodeTag)node.Tag).Tag.ToString();
            param.BuilderType = this.radioButton1.Checked ? BuilderType.Default : BuilderType.Factory;
            param.MethodList = methods;
            param.CNSC = new Config_NameSpaceClass().GetDefault();
            param.dataBaseType = server.Type;
            return param;
        }
        private void CreateCode()
        {
            var param = GetCodeCreateSources();
            Business.CreateCode CreateCode = new Business.CreateCode(param.dataBaseType);
            Form_Code_Area fca_model = new Form_Code_Area(CreateCode.GetModelClass(param,2), string.Format("实体类({0})", param.TableName));
            fca_model.Show(Home.Instance.dockPanel1);
            Form_Code_Area fca_data = new Form_Code_Area(CreateCode.GetDataClass(param), string.Format("数据类({0})", param.TableName));
            fca_data.Show(Home.Instance.dockPanel1);
            Form_Code_Area fca_business = new Form_Code_Area(CreateCode.GetBusinessClass(param), string.Format("业务类({0})", param.TableName));
            fca_business.Show(Home.Instance.dockPanel1);
            if (param.BuilderType == BuilderType.Factory)
            {
                Form_Code_Area fca_interface = new Form_Code_Area(CreateCode.GetInterfaceClass(param), string.Format("接口类({0})", param.TableName));
                fca_interface.Show(Home.Instance.dockPanel1);
                Form_Code_Area fca_factory = new Form_Code_Area(CreateCode.GetFactoryClass(param), string.Format("工厂类({0})", param.TableName));
                fca_factory.Show(Home.Instance.dockPanel1);
            }
            this.Close();
            button1.Text = "确定生成";
        }
        private void btAutoCreateCode2_Click(object sender, EventArgs e)
        {
            this.btAutoCreateCode2.Enabled = false;
            AutoCode();
        }
        public void AutoCode()
        {
            try
            {
                #region 代码自动生成
                string t = "\t";
                string tt = t + t;
                string ttt = t + t + t;
                StringBuilder sw = new StringBuilder();
                StringBuilder db = new StringBuilder();
                TreeNode dbNode = node.Parent.Parent;
                TreeNode serverNode = Home.form_Database.GetRoot(node);
                if (dbNode == null || serverNode == null)
                {
                    return;
                }
                Servers server = (Servers)((TreeNodeTag)serverNode.Tag).Tag;
                CodeCreate param = new CodeCreate();
                param.ClassName = ((TreeNodeTag)node.Tag).Tag.ToString();
                param.DbName = ((TreeNodeTag)dbNode.Tag).Tag.ToString();
                param.ServerID = server.ID;
                param.TableName = ((TreeNodeTag)node.Tag).Tag.ToString();
                string sql = " use " + param.DbName + "; select name,type_name(user_type_id)as typeid from sys.columns where  "
                  + " object_id=(select object_id from sys.tables where name='" + param.TableName + "') ";
                DataTable dt1 = Database.GetDataTable(sql, param.ServerID, param.DbName);
                #region 实体类
                #region 实体类头部
                sw.Append("using System;" + Environment.NewLine);
                sw.Append("using System.Collections.Generic;" + Environment.NewLine);
                sw.Append("using System.Linq;" + Environment.NewLine);
                sw.Append("using System.Text;" + Environment.NewLine);
                sw.Append("namespace " + getdaxie(param.DbName + Environment.NewLine));
                sw.Append(t + "{" + Environment.NewLine);
                sw.Append(tt + "public class " + param.TableName + Environment.NewLine);
                sw.Append(ttt + "{" + Environment.NewLine);
                #endregion
                #region 实体类主体生成
                foreach (DataRow line1 in dt1.Rows)
                {
                    sw.Append(ttt + "private " + Database.GetFieldSqlType(line1["typeid"].ToString()) + "  _" + getdaxie(line1["name"].ToString()) + ";" + Environment.NewLine);
                    sw.Append(ttt + "public " + Database.GetFieldSqlType(line1["typeid"].ToString()) + " " + getdaxie(line1["name"].ToString()) + Environment.NewLine);
                    sw.Append(ttt + "{" + Environment.NewLine);
                    sw.Append(ttt + t + "get { return _" + getdaxie(line1["name"].ToString()) + "; }" + Environment.NewLine);
                    sw.Append(ttt + t + " set { _" + getdaxie(line1["name"].ToString()) + " = value; }" + Environment.NewLine);
                    sw.Append(ttt + "}" + Environment.NewLine);
                }
                sw.Append(tt + "}" + Environment.NewLine);
                sw.Append(t + "}" + Environment.NewLine);
                #endregion 
                #endregion
                #region DBHelp
                db.Append("using System;" + Environment.NewLine);
                db.Append("using System.Collections.Generic;" + Environment.NewLine);
                db.Append("using System.Linq;" + Environment.NewLine);
                db.Append("using System.Text;" + Environment.NewLine);
                db.Append("using System.Data;" + Environment.NewLine);
                db.Append("using System.Data.SqlClient;" + Environment.NewLine);
                db.Append("using System.Configuration;" + Environment.NewLine);
                db.Append("namespace " + getdaxie(param.TableName) + Environment.NewLine);
                db.Append(t + "{" + Environment.NewLine);
                db.Append(tt + "public class " + getdaxie("DBHelpe") + Environment.NewLine);
                db.Append(tt + "{" + Environment.NewLine);
                db.Append(ttt + "private static SqlConnection con;" + Environment.NewLine);
                db.Append(ttt + "/// <summary>" + Environment.NewLine);
                db.Append(ttt + " ///获得connection " + Environment.NewLine);
                db.Append(ttt + "/// </summary>" + Environment.NewLine);
                db.Append(ttt + "public static SqlConnection GetCon()" + Environment.NewLine);
                db.Append(ttt + "{" + Environment.NewLine);
                db.Append(ttt + t + "string connectionString = ConfigurationManager.ConnectionStrings[\"url\"].ConnectionString;" + Environment.NewLine);
                db.Append(ttt + t + "if (con == null)" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + t + "con = new SqlConnection(connectionString);" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "return con;" + Environment.NewLine);
                db.Append(ttt + "}" + Environment.NewLine);
                db.Append(ttt + "/// <summary>" + Environment.NewLine);
                db.Append(ttt + "/// 执行增、删、改操作" + Environment.NewLine);
                db.Append(ttt + "/// </summary>" + Environment.NewLine);
                db.Append(ttt + "/// <param name=sql>SQL语句</param>" + Environment.NewLine);
                db.Append(ttt + "/// <returns>受影响行数</returns>" + Environment.NewLine);
                db.Append(ttt + "public static int ExecuteSql(string sql)" + Environment.NewLine);
                db.Append(ttt + "{" + Environment.NewLine);
                db.Append(ttt + t + "int i = -1;" + Environment.NewLine);
                db.Append(ttt + t + "SqlConnection con = DBHelpe.GetCon();" + Environment.NewLine);
                db.Append(ttt + t + "SqlCommand cmd = new SqlCommand(sql, con);" + Environment.NewLine);
                db.Append(ttt + t + "try" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "con.Open();" + Environment.NewLine);
                db.Append(ttt + tt + "i = cmd.ExecuteNonQuery();" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "catch (Exception err)" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "throw err;" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "finally" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "if (con.State == ConnectionState.Open)" + Environment.NewLine);
                db.Append(ttt + tt + "{" + Environment.NewLine);
                db.Append(ttt + tt + "con.Close();" + Environment.NewLine);
                db.Append(ttt + tt + "}" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "return i;" + Environment.NewLine);
                db.Append(ttt + "}" + Environment.NewLine);
                db.Append(ttt + "/// <summary>" + Environment.NewLine);
                db.Append(ttt + "/// 根据SQL返回DataTable" + Environment.NewLine);
                db.Append(ttt + "/// </summary>" + Environment.NewLine);
                db.Append(ttt + "/// <param name=sql>执行的SQL</param>" + Environment.NewLine);
                db.Append(ttt + "/// <returns>DataTable</returns>" + Environment.NewLine);
                db.Append(ttt + "public static DataTable GetTable(string sql)" + Environment.NewLine);
                db.Append(ttt + "{" + Environment.NewLine);
                db.Append(ttt + t + "DataTable dt =new DataTable();" + Environment.NewLine);
                db.Append(ttt + t + "SqlConnection con = DBHelpe.GetCon();" + Environment.NewLine);
                db.Append(ttt + t + "try" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "con.Open();" + Environment.NewLine);
                db.Append(ttt + tt + "SqlCommand cmd = new SqlCommand(sql, con);" + Environment.NewLine);
                db.Append(ttt + tt + "SqlDataAdapter da = new SqlDataAdapter(cmd);" + Environment.NewLine);
                db.Append(ttt + tt + "da.Fill(dt);" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "catch (Exception err)" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "throw err;" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "finally" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "if (con.State == ConnectionState.Open)" + Environment.NewLine);
                db.Append(ttt + tt + "{" + Environment.NewLine);
                db.Append(ttt + ttt + "con.Close();" + Environment.NewLine);
                db.Append(ttt + tt + "}" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "return dt;" + Environment.NewLine);
                db.Append(ttt + "}" + Environment.NewLine);
                db.Append(ttt + "/// <summary>" + Environment.NewLine);
                db.Append(ttt + "/// 执行SQL返回SqlDataReader" + Environment.NewLine);
                db.Append(ttt + "/// </summary>" + Environment.NewLine);
                db.Append(ttt + "/// <param name=sql>执行的SQL</param>" + Environment.NewLine);
                db.Append(ttt + "/// <returns>SqlDataReader</returns>" + Environment.NewLine);
                db.Append(ttt + "public static SqlDataReader ExReader(string sql)" + Environment.NewLine);
                db.Append(ttt + "{" + Environment.NewLine);
                db.Append(ttt + t + "SqlConnection con = DBHelpe.GetCon();" + Environment.NewLine);
                db.Append(ttt + t + "try" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "con.Open();" + Environment.NewLine);
                db.Append(ttt + tt + "SqlCommand cmd = new SqlCommand(sql, con);" + Environment.NewLine);
                db.Append(ttt + tt + "SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);" + Environment.NewLine);
                db.Append(ttt + tt + "return dr;" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + t + "catch(Exception err)" + Environment.NewLine);
                db.Append(ttt + t + "{" + Environment.NewLine);
                db.Append(ttt + tt + "throw err;" + Environment.NewLine);
                db.Append(ttt + t + "}" + Environment.NewLine);
                db.Append(ttt + "}" + Environment.NewLine);
                //****************************************************************
                db.Append(t + "}" + Environment.NewLine);
                db.Append("}" + Environment.NewLine);
                #endregion

                Form_Code_Area fca_model = new Form_Code_Area(sw.ToString(), string.Format("实体类({0})", param.TableName));
                fca_model.Show(Home.Instance.dockPanel1);
                Form_Code_Area fca_data = new Form_Code_Area(db.ToString(), string.Format("数据类({0})", param.TableName));
                fca_data.Show(Home.Instance.dockPanel1);
                #endregion
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            this.Close();
        }
        string getdaxie(string daxie)
        {
            return daxie.Substring(0, 1).ToUpper() + daxie.Substring(1);
        }
    }
}
