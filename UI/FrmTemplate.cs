using System;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using System.Configuration;
using System.IO;
using Docking;

namespace UI
{
    public partial class FrmTemplate : DockContent
    {
        private string editTemplate = String.Empty;
        TextEditorControl txtEditControl;

        public FrmTemplate()
        {
            InitializeComponent();
            // source code editor
            txtEditControl = new TextEditorControl();
            txtEditControl.Dock = DockStyle.Fill;
            pnlTemplate.Controls.Add(txtEditControl);
        }

        public FrmTemplate(string templateName)
        {
            InitializeComponent();

            // source code editor
            txtEditControl = new TextEditorControl();
            txtEditControl.Dock = DockStyle.Fill;
            pnlTemplate.Controls.Add(txtEditControl);

            // fill for edition
            editTemplate = templateName;
            var values = templateName.Split('_');
            txtTemplateName.Text = values[0];
            if (values[1] == "CC")
            {
                rbCC.Checked = true;
            }
            else
            {
                rbPC.Checked = true;
            }

            txtTemplateName.Enabled = false;
            cmbType.Enabled = false;
            btnSave.Text = "Update";
        }

        private void FrmTemplate_Load(object sender, EventArgs e)
        {
            txtEditControl.LoadFile(ConfigurationManager.AppSettings["TempCS"].ToString());
            LoadCmbTipo();
        }

        private void LoadCmbTipo()
        {
            cmbType.Items.Add(new ComboBoxItem { Value = 1, Description = "Model" });
            cmbType.Items.Add(new ComboBoxItem { Value = 3, Description = "Controller" });
            cmbType.Items.Add(new ComboBoxItem { Value = 4, Description = "Business" });
            cmbType.Items.Add(new ComboBoxItem { Value = 5, Description = "DAO" });
            cmbType.ValueMember = "Value";
            cmbType.DisplayMember = "Description";

            if (!string.IsNullOrEmpty(editTemplate))
            {
                cmbType.SelectedIndex = Convert.ToInt32(editTemplate.Split('_')[2].Split('.')[0]) - 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTemplateName.Text) && cmbType.SelectedIndex > -1
                && (rbCC.Checked || rbPC.Checked))
            {
                string valor = (rbCC.Checked) ? "CC_" : "PC_";
                try
                {
                    string fileName = ConfigurationManager.AppSettings["TemplatesPath"]
                        + "\\" + txtTemplateName.Text + "_" + valor + (cmbType.SelectedIndex + 1) + ".tpl";
                    // Creates the file
                    if (!File.Exists(fileName) || btnSave.Text == "Update")
                    {
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            sw.WriteLine(((TextEditorControl)pnlTemplate.Controls[0]).Text);
                            sw.Close();
                            if (btnSave.Text == "Update")
                            {
                                MessageBox.Show("Template updated successfully!", "Updated", MessageBoxButtons.OK);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Template created successfully!", "Created", MessageBoxButtons.OK);
                                Clean();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("A file with the same name already exist in the template folder. Please, rename this template before save.",
                            "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred in the application. Detail: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields.", "Alert",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clean()
        {
            rbCC.Checked = false;
            rbPC.Checked = false;
            txtTemplateName.Text = "";
            cmbType.SelectedIndex = 0;
            txtEditControl.LoadFile(ConfigurationManager.AppSettings["TempCS"].ToString());
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editTemplate))
            {
                var tipo = ((ComboBoxItem)cmbType.SelectedItem).Description;
                ((TextEditorControl)pnlTemplate.Controls[0]).Text =
                    System.IO.File.ReadAllText(ConfigurationManager.AppSettings["TemplatesPath"] + "\\Default\\" + tipo + ".tpl");
            }
            else
            {
                ((TextEditorControl)pnlTemplate.Controls[0]).Text =
                System.IO.File.ReadAllText(ConfigurationManager.AppSettings["TemplatesPath"] + "\\" + editTemplate);
            }
        }

        private void btnLegend_Click(object sender, EventArgs e)
        {
            FrmLegend frmLegend = new FrmLegend();
            frmLegend.Name = "frmLegend";
            if (((Main)this.MdiParent).exist(frmLegend))
            {
                frmLegend.StartPosition = FormStartPosition.CenterScreen;
                frmLegend.MdiParent = this.MdiParent;
                frmLegend.Show();
            }
        }
    }
}

public class ComboBoxItem
{
    public int Value { get; set; }
    public string Description { get; set; }
}