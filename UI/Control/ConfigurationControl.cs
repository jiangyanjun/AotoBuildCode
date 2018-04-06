using System;
using System.Windows.Forms;
using Model;

namespace UI.Control
{
    public partial class ConfigurationControl : UserControl
    {
           #region 私有属性

        public Architecture architectureType;
        public DataAccess dataAccessType;

        #endregion

        #region 公有属性
        public string SolutionName { get { return txtSolutionName.Text; } }
        #endregion

        #region 构造函数

        public ConfigurationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void rbMVC_CheckedChanged(object sender, EventArgs e)
        {
            architectureType = Architecture.MVC;
        }

        private void rb3camadas_CheckedChanged(object sender, EventArgs e)
        {
            architectureType = Architecture.THREETIER;
        }

        private void rbADO_CheckedChanged(object sender, EventArgs e)
        {
            dataAccessType = DataAccess.ADONET;
        }

        private void rbLINQ_CheckedChanged(object sender, EventArgs e)
        {
            dataAccessType = DataAccess.LINQ;
        }

        private void rbNHibernate_CheckedChanged(object sender, EventArgs e)
        {
            dataAccessType = DataAccess.NHIBERNATE;
        }

        #endregion

        #region Validation
        public bool Valid()
        {
            return (!string.IsNullOrEmpty(txtSolutionName.Text)
                && (rb3camadas.Checked || rbMVC.Checked)
                && (rbADO.Checked || rbLINQ.Checked || rbNHibernate.Checked));
        }
        #endregion
    }
}
