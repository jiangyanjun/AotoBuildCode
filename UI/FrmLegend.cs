using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using System.Configuration;

namespace UI
{
    public partial class FrmLegend : Form
    {
        TextEditorControl txtEditControl;

        public FrmLegend()
        {
            InitializeComponent();

            // source code editor
            txtEditControl = new TextEditorControl();
            txtEditControl.Dock = DockStyle.Fill;
            this.Controls.Add(txtEditControl);
        }

        private void FrmLegend_Load(object sender, EventArgs e)
        {
            txtEditControl.LoadFile(ConfigurationManager.AppSettings["Legend"].ToString());
            txtEditControl.Enabled = false;
        }
    }
}
