using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewProject frmNewProject = new FrmNewProject();
            frmNewProject.Name = "frmNewProject";
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

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmTemplate frmTemplate = new FrmTemplate();
            frmTemplate.Name = "frmTemplate";
            if (exist(frmTemplate))
            {
                frmTemplate.MdiParent = this;
                frmTemplate.StartPosition = FormStartPosition.CenterScreen;
                frmTemplate.Show();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditTemplate frmEditTemplate = new FrmEditTemplate();
            frmEditTemplate.Name = "frmEditTemplate";
            if (exist(frmEditTemplate))
            {
                frmEditTemplate.MdiParent = this;
                frmEditTemplate.StartPosition = FormStartPosition.CenterScreen;
                frmEditTemplate.Show();
            }

        }
    }
}
