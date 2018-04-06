using System;
using System.Windows.Forms;
using Common;
using Docking;

namespace UI
{
    public partial class Home : DockContent
    {

        public static Home Instance = null;
        public static Form_Database form_Database = null;
        public static OpaqueCommand oc = null;
        public static Form_Home form_Home = null;
        public Home()
        {


            InitializeComponent();
            Instance = this;
            this.skinEngine1.SkinFile = "Wave.ssk";
            oc = new OpaqueCommand(125, true); //加载层
        }
        /// <summary>
        /// 显示起始页
        /// </summary>
        public void ShowHome()
        {
            if (form_Home == null)
            {
                form_Home = new Form_Home();
                form_Home.Show(dockPanel1);
            }

            form_Home.Activate();
        }
        private void Home_Load(object sender, EventArgs e)
        {

            form_Database = new Form_Database();
            form_Database.Show(dockPanel1, DockState.DockLeft);
            form_Database.Activate();

            form_Home = new Form_Home();
            form_Home.Show(dockPanel1);
            form_Home.Activate();

        }

        private void Control_Add(Form form, Panel pn)
        {
            pn.Controls.Clear(); //移除所有控件
            form.TopLevel = false;  //设置为非顶级窗体
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
            form.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
            pn.Controls.Add(form);//添加窗体
            form.Show();//窗体运行
        }
        /// <summary>
        /// 显示服务器资源管理器
        /// </summary>
        public void ShowServerList()
        {
            if (form_Database == null)
            {
                form_Database = new Form_Database();
                form_Database.Show(dockPanel1, DockState.DockLeftAutoHide);
            }
            form_Database.Activate();
        }
        public void AutoCreateControls(string pageName, string txtContent)
        {
            TabPage Page = new TabPage();
            Page.Name = pageName;
            Page.Text = pageName;
            TextBox tx = new TextBox();
            tx.Multiline = true;
            tx.Dock = DockStyle.Fill;
            tx.Text = txtContent;
            Page.Controls.Add(tx);
            //  this.tabControl.Controls.Add(Page);  
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowServerList();
        }

        private void 起始页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHome();
        }
        /// <summary>
        /// 生成代码到文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            form_Database.ShowCodeText();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗应用程序吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;  //点击OK
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmNewProject frmNewProject = new FrmNewProject();
            frmNewProject.Name = "frmNewProject";
            frmNewProject.Show(Home.Instance.dockPanel1);
            if (this.exist(frmNewProject))
            {
                frmNewProject.MdiParent = this;
                frmNewProject.StartPosition = FormStartPosition.CenterScreen;
                frmNewProject.Show();
            }
        }
        public bool exist(Form frm)
        {
            foreach (Form frmMDI in this.MdiChildren)
            {
                if (frmMDI.Name == frm.Name)
                {
                    frmMDI.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FrmNewProject frmNewProject = new FrmNewProject();
            frmNewProject.Name = "frmNewProject";
            frmNewProject.Show(Home.Instance.dockPanel1);
            if (this.exist(frmNewProject))
            {
                frmNewProject.MdiParent = this;
                frmNewProject.StartPosition = FormStartPosition.CenterScreen;
                frmNewProject.Show();
            }
        }

        private void 模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplate frmTemplate = new FrmTemplate();
            frmTemplate.Name = "frmTemplate";
            frmTemplate.Show(Home.Instance.dockPanel1);
            if (exist(frmTemplate))
            {
                frmTemplate.MdiParent = this;
                frmTemplate.StartPosition = FormStartPosition.CenterScreen;
                frmTemplate.Show();
            }
        }

        private void 模板编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditTemplate frmEditTemplate = new FrmEditTemplate();
            frmEditTemplate.Name = "frmEditTemplate";
            frmEditTemplate.Show(Home.Instance.dockPanel1);
            if (exist(frmEditTemplate))
            {
                frmEditTemplate.MdiParent = this;
                frmEditTemplate.StartPosition = FormStartPosition.CenterScreen;
                frmEditTemplate.Show();
            }
        }

        private void millennials代码生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewProject frmNewProject = new FrmNewProject();
            frmNewProject.Name = "frmNewProject";
            frmNewProject.Show(Home.Instance.dockPanel1);
            if (this.exist(frmNewProject))
            {
                frmNewProject.MdiParent = this;
                frmNewProject.StartPosition = FormStartPosition.CenterScreen;
                frmNewProject.Show();
            }
        }
    }
}
