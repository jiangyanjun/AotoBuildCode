using System;
using System.Windows.Forms;
using UI.Control;
using System.Data.SqlClient;
using Millennials.Creator;
using System.IO;
using Model;
using Docking;
using Common;

namespace UI
{
    public partial class FrmNewProject : DockContent
    {
           #region 私有属性

        //private volatile ConnectionControl connectionControl;
        //private volatile TableControl tableControl;
        private volatile SolutionControl solutionControl;
        private volatile ConfigurationControl configControl;
        private SqlConnectionStringBuilder connBuilder;

        #endregion

        #region 公有属性

        public SqlConnectionStringBuilder ConnBuilder
        {
            get { return connBuilder; }
            set { connBuilder = value; }
        }

        #endregion

        public FrmNewProject()
        {
            InitializeComponent();
        }

        #region Events

        private void FrmNewProject_Load(object sender, EventArgs e)
        {
            toolStripButton1_Click(null, null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (connectionControl.Visible)
            //{
            //    if (connectionControl.Valid())
            //    {
            //        showControl(NewProjectStep.TABLE);
            //        tableControl.InitControl(connBuilder, connectionControl.Database);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please fill all required fields.",
            //        "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else if (tableControl.Visible)
            //{
            //    if (tableControl.Valid())
            //    {
            //        showControl(NewProjectStep.CONFIG);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please fill all required fields.",
            //        "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            if (configControl.Visible)
            {
                if (configControl.Valid())
                {
                    showControl(NewProjectStep.SOLUTION);
                    solutionControl.InitControl(configControl.dataAccessType, configControl.architectureType, configControl.SolutionName);

                }
                else
                {
                    MessageBox.Show("Please fill all required fields.",
                    "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //if (tableControl.Visible)
            //{
            //    showControl(NewProjectStep.CONNECTION);
            //}
            //else 
            if (configControl.Visible)
            {
                showControl(NewProjectStep.TABLE);
            }
            else if (solutionControl.Visible)
            {
                showControl(NewProjectStep.CONFIG);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
           
            btnFinish.Enabled = false;
            btnFinish.Text = "执行中……";
            if (solutionControl.Valid())
            {
                try
                {
                    SolutionCreator creator = new SolutionCreator();
                    if (Home.form_Database.GetTreeView1Selected().Count <= 0)
                    {
                        MessageBox.Show("没有找到你选择的Table，请双击展开Selected Table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnFinish.Enabled = true;
                        btnFinish.Text = "&Finish";
                        return;
                    }
                    string db = ((Model.TreeNodeTag)Home.form_Database.GetTreeView1Selected()[0].Parent.Tag).Tag.ToString();
                    var tvTables = Home.form_Database.InitTreeView(db);
                    string dtime = DateTime.Now.ToString("yyMMddHHmmss");
                    string date = dtime;// DateTime.Now.ToString("yyMMddHH24mmsszzz").Substring(0, DateTime.Now.ToString("yyMMddHH24mmsszzz").Length - 8);
                    string path = solutionControl.Path + "\\" + date;
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    creator.CreateSolution(db+"_" + configControl.SolutionName, path, tvTables, configControl.dataAccessType, configControl.architectureType, solutionControl.gridSolution, Config.GetConnectionString(StaticTool.ServerID));
                    //creator.CreateSolution(configControl.SolutionName,@"C:\Users\JiangYanJun\Desktop\新建文件夹", tableControl.tvTables,
                    //    configControl.dataAccessType, configControl.architectureType, solutionControl.gridSolution, connectionControl.ConnectionString);

                    MessageBox.Show("项目成功生成目录在：" + Environment.NewLine +Environment.NewLine + path, "\t\t成功生成", MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("该项目创建过程中发生了错误。 详情: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DeleteUselessFiles();
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields.",
                "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnFinish.Enabled = true;
            btnFinish.Text = "&Finish";
        }

        #endregion

         #region 方法

        private void DeleteUselessFiles()
        {
            //DirectoryInfo di = new DirectoryInfo(solutionControl.Path);
            //di.Delete(true);  
        }

        private void showControl(NewProjectStep step)
        {

            if (step == NewProjectStep.CONNECTION)
            {
                //connectionControl.Visible = true;
                //tableControl.Visible = false;
                configControl.Visible = true;
                solutionControl.Visible = false;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
                btnBack.Enabled = false;
            }
            else if (step == NewProjectStep.TABLE)
            {
                //connectionControl.Visible = false;
                //tableControl.Visible = true;
                configControl.Visible = true;
                solutionControl.Visible = false;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
                btnBack.Enabled = true;
            }
            else if (step == NewProjectStep.CONFIG)
            {
                //connectionControl.Visible = false;
                //tableControl.Visible = false;
                configControl.Visible = true;
                solutionControl.Visible = false;
                btnNext.Enabled = true;
                btnFinish.Enabled = false;
                btnBack.Enabled = true;
            }
            else //NovoProjetoStep.SOLUTION
            {
                //connectionControl.Visible = false;
                //tableControl.Visible = false;
                solutionControl.Visible = true;
                configControl.Visible = false;
                btnNext.Enabled = false;
                btnFinish.Enabled = true;
                btnBack.Enabled = true;
            }

            if (btnFinish.Visible)
                this.AcceptButton = btnFinish;
            else
                this.AcceptButton = btnNext;
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            #region 构造函数
            //connectionControl = new ConnectionControl();
            //connectionControl.Visible = true;
            //pnlControles.Controls.Add(connectionControl);

            //tableControl = new TableControl();
            //tableControl.Visible = false;
            //pnlControles.Controls.Add(tableControl);

            configControl = new ConfigurationControl();
            configControl.Visible = false;
            pnlControles.Controls.Add(configControl);

            solutionControl = new SolutionControl();
            solutionControl.Visible = false;
            pnlControles.Controls.Add(solutionControl);

            showControl(NewProjectStep.CONNECTION);
            #endregion
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
