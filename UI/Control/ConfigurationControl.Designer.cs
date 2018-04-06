namespace UI.Control
{
    partial class ConfigurationControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3camadas = new System.Windows.Forms.RadioButton();
            this.rbMVC = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLINQ = new System.Windows.Forms.RadioButton();
            this.rbNHibernate = new System.Windows.Forms.RadioButton();
            this.rbADO = new System.Windows.Forms.RadioButton();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3camadas);
            this.groupBox1.Controls.Add(this.rbMVC);
            this.groupBox1.Location = new System.Drawing.Point(25, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project architecture:";
            // 
            // rb3camadas
            // 
            this.rb3camadas.AutoSize = true;
            this.rb3camadas.Location = new System.Drawing.Point(22, 41);
            this.rb3camadas.Name = "rb3camadas";
            this.rb3camadas.Size = new System.Drawing.Size(47, 16);
            this.rb3camadas.TabIndex = 1;
            this.rb3camadas.Text = "三层";
            this.rb3camadas.UseVisualStyleBackColor = true;
            this.rb3camadas.CheckedChanged += new System.EventHandler(this.rb3camadas_CheckedChanged);
            // 
            // rbMVC
            // 
            this.rbMVC.AutoSize = true;
            this.rbMVC.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rbMVC.Location = new System.Drawing.Point(22, 20);
            this.rbMVC.Name = "rbMVC";
            this.rbMVC.Size = new System.Drawing.Size(41, 16);
            this.rbMVC.TabIndex = 0;
            this.rbMVC.Text = "MVC";
            this.rbMVC.UseVisualStyleBackColor = true;
            this.rbMVC.CheckedChanged += new System.EventHandler(this.rbMVC_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLINQ);
            this.groupBox2.Controls.Add(this.rbNHibernate);
            this.groupBox2.Controls.Add(this.rbADO);
            this.groupBox2.Location = new System.Drawing.Point(25, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Access type";
            // 
            // rbLINQ
            // 
            this.rbLINQ.AutoSize = true;
            this.rbLINQ.Location = new System.Drawing.Point(22, 54);
            this.rbLINQ.Name = "rbLINQ";
            this.rbLINQ.Size = new System.Drawing.Size(47, 16);
            this.rbLINQ.TabIndex = 2;
            this.rbLINQ.Text = "LINQ";
            this.rbLINQ.UseVisualStyleBackColor = true;
            this.rbLINQ.CheckedChanged += new System.EventHandler(this.rbLINQ_CheckedChanged);
            // 
            // rbNHibernate
            // 
            this.rbNHibernate.AutoSize = true;
            this.rbNHibernate.Location = new System.Drawing.Point(22, 78);
            this.rbNHibernate.Name = "rbNHibernate";
            this.rbNHibernate.Size = new System.Drawing.Size(83, 16);
            this.rbNHibernate.TabIndex = 1;
            this.rbNHibernate.Text = "NHibernate";
            this.rbNHibernate.UseVisualStyleBackColor = true;
            this.rbNHibernate.CheckedChanged += new System.EventHandler(this.rbNHibernate_CheckedChanged);
            // 
            // rbADO
            // 
            this.rbADO.AutoSize = true;
            this.rbADO.Location = new System.Drawing.Point(22, 30);
            this.rbADO.Name = "rbADO";
            this.rbADO.Size = new System.Drawing.Size(71, 16);
            this.rbADO.TabIndex = 0;
            this.rbADO.Text = "ADO .NET";
            this.rbADO.UseVisualStyleBackColor = true;
            this.rbADO.CheckedChanged += new System.EventHandler(this.rbADO_CheckedChanged);
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(25, 36);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.Size = new System.Drawing.Size(307, 21);
            this.txtSolutionName.TabIndex = 2;
            this.txtSolutionName.Text = "AutoBuilCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Solution name:";
            // 
            // ConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSolutionName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigurationControl";
            this.Size = new System.Drawing.Size(343, 316);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb3camadas;
        private System.Windows.Forms.RadioButton rbMVC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLINQ;
        private System.Windows.Forms.RadioButton rbNHibernate;
        private System.Windows.Forms.RadioButton rbADO;
        private System.Windows.Forms.TextBox txtSolutionName;
        private System.Windows.Forms.Label label1;
    }
}
