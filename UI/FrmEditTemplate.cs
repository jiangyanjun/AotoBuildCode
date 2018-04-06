using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Docking;

namespace UI
{
    public partial class FrmEditTemplate : DockContent
    {
        public FrmEditTemplate()
        {
            InitializeComponent();
        }

        private void FrmEditarTemplate_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            DataTable dtSolution = new DataTable();
            dtSolution.Columns.Add("Name");
            dtSolution.Columns.Add("RealName");

            DataRow drNew;

            // list directory's files
            foreach (var item in Directory.GetFiles(ConfigurationManager.AppSettings["TemplatesPath"], "*.tpl"))
            {
                drNew = dtSolution.NewRow();
                drNew["Name"] = item.Split('\\').Last().Split('_')[0];
                drNew["RealName"] = item.Split('\\').Last();

                dtSolution.Rows.Add(drNew);
            }
            gvTemplates.ReadOnly = true;
            gvTemplates.AllowUserToAddRows = false;
            gvTemplates.DataSource = dtSolution;
            gvTemplates.Columns["Name"].Width = 477;
            gvTemplates.Columns["Name"].HeaderText = "Template name";
            gvTemplates.Columns["RealName"].Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvTemplates.SelectedRows.Count > 0)
            {
                FrmTemplate frmTemplate = new FrmTemplate(gvTemplates.SelectedRows[0].Cells["RealName"].Value.ToString());
                frmTemplate.StartPosition = FormStartPosition.CenterScreen;
                frmTemplate.MdiParent = this.MdiParent;
                frmTemplate.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a template.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
