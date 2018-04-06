using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI.Control
{
    public partial class ConnectionControl : UserControl
    {
           #region 私有属性

        private bool sucess = false;
        private SqlConnectionStringBuilder connBuilder;

        #endregion

        #region 公有属性

        public string Database
        {
            get { return cmbDatabase.Text; }
        }

        public string ConnectionString
        {
            get { return connBuilder.ConnectionString; }
        }
        #endregion

        #region 构造函数

        public ConnectionControl()
        {
            InitializeComponent();
            connBuilder = new SqlConnectionStringBuilder();
            cmbDatabase.Enabled = false;
        }
       
        #endregion

         #region 方法

        private void SetEnableAuthentication(bool enable)
        {
            txtUsername.Enabled = enable;
            txtPassword.Enabled = enable;
        }

        #endregion

        #region Events

        private void radWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            SetEnableAuthentication(!radWindows.Checked);
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtServer.Text))
            {
                connBuilder.DataSource = txtServer.Text;
                connBuilder.PersistSecurityInfo = true;
                if (!radWindows.Checked)
                {
                    connBuilder.UserID = txtUsername.Text;
                    connBuilder.Password = txtPassword.Text;
                }
                else
                    connBuilder.IntegratedSecurity = true;
                try
                {
                    using (SqlConnection dbConnection = new SqlConnection(connBuilder.ConnectionString))
                    {
                        dbConnection.Open();
                        DataTable tempDataTable = dbConnection.GetSchema(SqlClientMetaDataCollectionNames.Databases);
                        cmbDatabase.DataSource = tempDataTable;
                        cmbDatabase.DisplayMember = tempDataTable.Columns["database_name"].ColumnName;
                        cmbDatabase.ValueMember = tempDataTable.Columns["database_name"].ColumnName;
                        // set the connection string to FrmNewProject's DataBase object
                        ((FrmNewProject)this.ParentForm).ConnBuilder = connBuilder;
                       // MessageBox.Show("Connected successfully!", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dbConnection.Close();
                    }
                    sucess = true;
                    cmbDatabase.Enabled = sucess;
                }
                catch (SqlException)
                {
                    txtPassword.Text = String.Empty;
                    connBuilder.Clear();
                    MessageBox.Show("Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                connBuilder.Clear();
                MessageBox.Show("Please select a server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddConnectionSqlServerProvider_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!sucess)
                connBuilder.Clear();
        }


        #endregion

        #region Validation
        public bool Valid()
        {
            return cmbDatabase.SelectedIndex > -1 ;
        }
        #endregion

        private void ConnectionControl_Load(object sender, EventArgs e)
        {
            btnTestConnection_Click(null, null);
        }
    }
}
