using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections;
using Model;
using Common;

namespace UI.Control
{
    public partial class SolutionControl : UserControl
    {
        #region 公有属性
        public DataGridView gridSolution { get { return gvSolution; } }
        public string Path { get { return txtPath.Text; } }
        private Hashtable templateName = new Hashtable();
        #endregion

        #region 构造函数

        public SolutionControl()
        {
            InitializeComponent();
        }

        #endregion

         #region 方法

        public void InitControl(DataAccess ad, Architecture arch, string solutionName)
        {
            LoadSolutionGrid(ad, arch, solutionName);
            LoadCmbTemplate();
        }

        private void LoadSolutionGrid(DataAccess ad, Architecture arch, string solutionName)
        {
            DataTable dtSolution = new DataTable();
            dtSolution.Columns.Add("Name");
            dtSolution.Columns.Add("Template");
            dtSolution.Columns.Add("Suffix");
            dtSolution.Columns.Add("Assembly");
            dtSolution.Columns.Add("Namespace");
            dtSolution.Columns.Add("ProjectType");

            DataRow drNew;
            if (arch == Architecture.MVC)
            {
                // Model
                drNew = dtSolution.NewRow();
                Project model = new Project();
                model.Name = "Model";
                drNew["Name"] = model.Name;
                model.NameSpace = solutionName + ".Model";
                drNew["Namespace"] = model.NameSpace;
                model.AssemblyName = solutionName + ".Model";
                drNew["Assembly"] = model.AssemblyName;
                drNew["ProjectType"] = (int)ProjectType.MODEL;
                dtSolution.Rows.Add(drNew);
                // View
                drNew = dtSolution.NewRow();
                Project view = new Project();
                view.Name = "View";
                drNew["Name"] = view.Name;
                view.NameSpace = solutionName + ".View";
                drNew["Namespace"] = view.NameSpace;
                view.AssemblyName = solutionName + ".View";
                drNew["Assembly"] = view.AssemblyName;
                view.Suffix = "View";
                drNew["Suffix"] = view.Suffix;
                drNew["ProjectType"] = (int)ProjectType.VIEW;
                dtSolution.Rows.Add(drNew);
                // Controller
                drNew = dtSolution.NewRow();
                Project ctrl = new Project();
                ctrl.Name = "Controller";
                drNew["Name"] = ctrl.Name;
                ctrl.NameSpace = solutionName + ".Controller";
                drNew["Namespace"] = ctrl.NameSpace;
                ctrl.AssemblyName = solutionName + ".Controller";
                drNew["Assembly"] = ctrl.AssemblyName;
                ctrl.Suffix = "Controller";
                drNew["ProjectType"] = (int)ProjectType.CONTROLLER;
                dtSolution.Rows.Add(drNew);
            }
            else //Arquitetura.THREETIER
            {
                // Model
                drNew = dtSolution.NewRow();
                Project model = new Project();
                model.Name = "Model";
                drNew["Name"] = model.Name;
                model.NameSpace = solutionName + ".Model";
                drNew["Namespace"] = model.NameSpace;
                model.AssemblyName = solutionName + ".Model";
                drNew["Assembly"] = model.AssemblyName;
                drNew["ProjectType"] = (int)ProjectType.MODEL;
                dtSolution.Rows.Add(drNew);
                // Business
                drNew = dtSolution.NewRow();
                Project business = new Project();
                business.Name = "Business";
                drNew["Name"] = business.Name;
                business.NameSpace = solutionName + ".Business";
                drNew["Namespace"] = business.NameSpace;
                business.AssemblyName = solutionName + ".Business";
                drNew["Assembly"] = business.AssemblyName;
                business.Suffix = "Business";
                drNew["Suffix"] = business.Suffix;
                drNew["ProjectType"] = (int)ProjectType.BUSINESS;
                dtSolution.Rows.Add(drNew);
                // DAO
                drNew = dtSolution.NewRow();
                Project data = new Project();
                data.Name = "DAO";
                drNew["Name"] = data.Name;
                data.NameSpace = solutionName + ".DAO";
                drNew["Namespace"] = data.NameSpace;
                data.AssemblyName = solutionName + ".DAO";
                drNew["Assembly"] = data.AssemblyName;
                data.Suffix = "DAO";
                drNew["Suffix"] = "DAO";
                drNew["ProjectType"] = (int)ProjectType.DAO;
                dtSolution.Rows.Add(drNew);
            }

            gvSolution.ReadOnly = true;
            gvSolution.AllowUserToAddRows = false;
            gvSolution.DataSource = dtSolution;
            // set the columns
            gvSolution.Columns["Name"].Width = 294;
            gvSolution.Columns["Name"].HeaderText = "Project Name";
            gvSolution.Columns["Template"].Visible = false;
            gvSolution.Columns["Suffix"].Visible = false;
            gvSolution.Columns["Assembly"].Visible = false;
            gvSolution.Columns["Namespace"].Visible = false;
            gvSolution.Columns["ProjectType"].Visible = false;
            // selection changed event
            gvSolution.SelectionChanged += new EventHandler(gvSolution_SelectionChanged);

            // set the cursor to first item

            #region show the values from the first data grid item
            txtName.Text = gvSolution.Rows[0].Cells["Name"].Value.ToString();
            txtSuffix.Text = gvSolution.Rows[0].Cells["Suffix"].Value.ToString();
            txtAssembly.Text = gvSolution.Rows[0].Cells["Assembly"].Value.ToString();
            txtNamespace.Text = gvSolution.Rows[0].Cells["Namespace"].Value.ToString();
            #endregion
        }

        #endregion

        #region Events

        void gvSolution_SelectionChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridView gv = (System.Windows.Forms.DataGridView)sender;
            if (gv.SelectedRows.Count > 0)
            {
                // Refresh the values
                txtName.Text = gv.SelectedRows[0].Cells["Name"].Value.ToString();
                if (!string.IsNullOrEmpty(gv.SelectedRows[0].Cells["Template"].Value.ToString()))
                {
                    cmbTemplate.SelectedItem = templateName[gv.SelectedRows[0].Cells["Template"].Value.ToString().Split('\\').Last().Split('_')[0]].ToString().Split('\\').Last().Split('_')[0];
                }
                else
                {
                    cmbTemplate.SelectedIndex = 0;
                }
                txtSuffix.Text = gv.SelectedRows[0].Cells["Suffix"].Value.ToString();
                txtAssembly.Text = gv.SelectedRows[0].Cells["Assembly"].Value.ToString();
                txtNamespace.Text = gv.SelectedRows[0].Cells["Namespace"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog.ShowNewFolderButton = true;
            //DialogResult result = folderBrowserDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            txtPath.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);// folderBrowserDialog.SelectedPath;
            //}
        }

        private void LoadCmbTemplate()
        {
            cmbTemplate.Items.Clear();
            templateName.Clear();

            // list the directory files
            foreach (var item in Directory.GetFiles(ConfigurationManager.AppSettings["TemplatesPath"], "*.tpl"))
            {
                templateName.Add(item.Split('\\').Last().Split('_')[0], item);
                cmbTemplate.Items.Add(item.Split('\\').Last().Split('_')[0]);
            }

            cmbTemplate.Items.Insert(0, "Default");
            cmbTemplate.SelectedIndex = 0;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (gvSolution.SelectedRows.Count > 0)
            {
                gvSolution.SelectedRows[0].Cells["Name"].Value = txtName.Text;
                // Usually, it is the same ... but it is possible to change
                gvSolution.SelectedRows[0].Cells["Assembly"].Value = txtName.Text;
                txtAssembly.Text = txtName.Text;
                gvSolution.SelectedRows[0].Cells["Namespace"].Value = txtName.Text;
                txtNamespace.Text = txtName.Text;
            }
        }

        private void txtPreffix_Leave(object sender, EventArgs e)
        {
            if (gvSolution.SelectedRows.Count > 0)
            {
                gvSolution.SelectedRows[0].Cells["Suffix"].Value = txtSuffix.Text;
            }
        }

        private void txtAssembly_Leave(object sender, EventArgs e)
        {
            if (gvSolution.SelectedRows.Count > 0)
            {
                gvSolution.SelectedRows[0].Cells["Assembly"].Value = txtAssembly.Text;
            }
        }

        private void txtNamespace_Leave(object sender, EventArgs e)
        {
            if (gvSolution.SelectedRows.Count > 0)
            {
                gvSolution.SelectedRows[0].Cells["Namespace"].Value = txtNamespace.Text;
            }
        }

        private void cmbTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (gvSolution.SelectedRows.Count > 0)
            {
                if (cmbTemplate.SelectedItem != null)
                {
                    gvSolution.SelectedRows[0].Cells["Template"].Value = templateName[cmbTemplate.SelectedItem.ToString()];
                }                
            }
        }

        #endregion

        #region Validation
        public bool Valid()
        {
            return (!string.IsNullOrEmpty(txtPath.Text));  
        }
        #endregion

        private void SolutionControl_Load(object sender, EventArgs e)
        {
            txtPath.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        }
    }
}
