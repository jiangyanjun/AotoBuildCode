namespace UI
{
    partial class Form_Code_SetText
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Code_SetText));
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_add = new System.Windows.Forms.CheckBox();
            this.checkBox_delete = new System.Windows.Forms.CheckBox();
            this.checkBox_update = new System.Windows.Forms.CheckBox();
            this.checkBox_getall = new System.Windows.Forms.CheckBox();
            this.checkBox_getbykey = new System.Windows.Forms.CheckBox();
            this.checkBox_exists = new System.Windows.Forms.CheckBox();
            this.checkBox_count = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbp1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbp2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btAutoCreateCode2 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.DBHelper = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Model = new System.Windows.Forms.RadioButton();
            this.All = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tbp3 = new System.Windows.Forms.TabPage();
            this.tbp4 = new System.Windows.Forms.TabPage();
            this.tbp5 = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tbp1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbp2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生成模式：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(70, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "普通三层架构";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(202, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "工厂模式三层架构";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "生成方法：";
            // 
            // checkBox_add
            // 
            this.checkBox_add.AutoSize = true;
            this.checkBox_add.Checked = true;
            this.checkBox_add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_add.Location = new System.Drawing.Point(70, 128);
            this.checkBox_add.Name = "checkBox_add";
            this.checkBox_add.Size = new System.Drawing.Size(48, 16);
            this.checkBox_add.TabIndex = 4;
            this.checkBox_add.Text = "新增";
            this.checkBox_add.UseVisualStyleBackColor = true;
            // 
            // checkBox_delete
            // 
            this.checkBox_delete.AutoSize = true;
            this.checkBox_delete.Checked = true;
            this.checkBox_delete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_delete.Location = new System.Drawing.Point(134, 128);
            this.checkBox_delete.Name = "checkBox_delete";
            this.checkBox_delete.Size = new System.Drawing.Size(48, 16);
            this.checkBox_delete.TabIndex = 5;
            this.checkBox_delete.Text = "删除";
            this.checkBox_delete.UseVisualStyleBackColor = true;
            // 
            // checkBox_update
            // 
            this.checkBox_update.AutoSize = true;
            this.checkBox_update.Checked = true;
            this.checkBox_update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_update.Location = new System.Drawing.Point(202, 128);
            this.checkBox_update.Name = "checkBox_update";
            this.checkBox_update.Size = new System.Drawing.Size(48, 16);
            this.checkBox_update.TabIndex = 6;
            this.checkBox_update.Text = "修改";
            this.checkBox_update.UseVisualStyleBackColor = true;
            // 
            // checkBox_getall
            // 
            this.checkBox_getall.AutoSize = true;
            this.checkBox_getall.Checked = true;
            this.checkBox_getall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_getall.Location = new System.Drawing.Point(70, 161);
            this.checkBox_getall.Name = "checkBox_getall";
            this.checkBox_getall.Size = new System.Drawing.Size(96, 16);
            this.checkBox_getall.TabIndex = 7;
            this.checkBox_getall.Text = "查询所有记录";
            this.checkBox_getall.UseVisualStyleBackColor = true;
            // 
            // checkBox_getbykey
            // 
            this.checkBox_getbykey.AutoSize = true;
            this.checkBox_getbykey.Checked = true;
            this.checkBox_getbykey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_getbykey.Location = new System.Drawing.Point(183, 161);
            this.checkBox_getbykey.Name = "checkBox_getbykey";
            this.checkBox_getbykey.Size = new System.Drawing.Size(96, 16);
            this.checkBox_getbykey.TabIndex = 8;
            this.checkBox_getbykey.Text = "查询主键记录";
            this.checkBox_getbykey.UseVisualStyleBackColor = true;
            // 
            // checkBox_exists
            // 
            this.checkBox_exists.AutoSize = true;
            this.checkBox_exists.Checked = true;
            this.checkBox_exists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_exists.Location = new System.Drawing.Point(273, 128);
            this.checkBox_exists.Name = "checkBox_exists";
            this.checkBox_exists.Size = new System.Drawing.Size(120, 16);
            this.checkBox_exists.TabIndex = 9;
            this.checkBox_exists.Text = "判断记录是否存在";
            this.checkBox_exists.UseVisualStyleBackColor = true;
            // 
            // checkBox_count
            // 
            this.checkBox_count.AutoSize = true;
            this.checkBox_count.Checked = true;
            this.checkBox_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_count.Location = new System.Drawing.Point(297, 161);
            this.checkBox_count.Name = "checkBox_count";
            this.checkBox_count.Size = new System.Drawing.Size(96, 16);
            this.checkBox_count.TabIndex = 10;
            this.checkBox_count.Text = "查询记录条数";
            this.checkBox_count.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "确定生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "取消关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(46, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "生成类名：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(221, 21);
            this.textBox2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "类名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(109, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "label7";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbp1);
            this.tabControl1.Controls.Add(this.tbp2);
            this.tabControl1.Controls.Add(this.tbp3);
            this.tabControl1.Controls.Add(this.tbp4);
            this.tabControl1.Controls.Add(this.tbp5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(873, 430);
            this.tabControl1.TabIndex = 21;
            // 
            // tbp1
            // 
            this.tbp1.Controls.Add(this.panel1);
            this.tbp1.Location = new System.Drawing.Point(4, 22);
            this.tbp1.Name = "tbp1";
            this.tbp1.Padding = new System.Windows.Forms.Padding(3);
            this.tbp1.Size = new System.Drawing.Size(865, 404);
            this.tbp1.TabIndex = 0;
            this.tbp1.Text = "Owe";
            this.tbp1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox_add);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.checkBox_delete);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.checkBox_update);
            this.panel1.Controls.Add(this.checkBox_count);
            this.panel1.Controls.Add(this.checkBox_getall);
            this.panel1.Controls.Add(this.checkBox_exists);
            this.panel1.Controls.Add(this.checkBox_getbykey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 398);
            this.panel1.TabIndex = 0;
            // 
            // tbp2
            // 
            this.tbp2.Controls.Add(this.panel2);
            this.tbp2.Location = new System.Drawing.Point(4, 22);
            this.tbp2.Name = "tbp2";
            this.tbp2.Padding = new System.Windows.Forms.Padding(3);
            this.tbp2.Size = new System.Drawing.Size(865, 404);
            this.tbp2.TabIndex = 1;
            this.tbp2.Text = "Two";
            this.tbp2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btAutoCreateCode2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 398);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Location = new System.Drawing.Point(260, 239);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 80);
            this.panel3.TabIndex = 16;
            this.panel3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "DB类名称：";
            this.label6.Visible = false;
            // 
            // btAutoCreateCode2
            // 
            this.btAutoCreateCode2.Location = new System.Drawing.Point(182, 65);
            this.btAutoCreateCode2.Name = "btAutoCreateCode2";
            this.btAutoCreateCode2.Size = new System.Drawing.Size(72, 26);
            this.btAutoCreateCode2.TabIndex = 0;
            this.btAutoCreateCode2.Text = "点击生成";
            this.btAutoCreateCode2.UseVisualStyleBackColor = true;
            this.btAutoCreateCode2.Click += new System.EventHandler(this.btAutoCreateCode2_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(75, 12);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 0;
            this.textBox7.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.DBHelper);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.Model);
            this.panel4.Controls.Add(this.All);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(45, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 97);
            this.panel4.TabIndex = 15;
            this.panel4.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "数据库实例名称：";
            this.label4.Visible = false;
            // 
            // DBHelper
            // 
            this.DBHelper.AutoSize = true;
            this.DBHelper.Location = new System.Drawing.Point(265, 69);
            this.DBHelper.Name = "DBHelper";
            this.DBHelper.Size = new System.Drawing.Size(71, 16);
            this.DBHelper.TabIndex = 10;
            this.DBHelper.Text = "生成DB类";
            this.DBHelper.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(107, 13);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(116, 21);
            this.textBox5.TabIndex = 4;
            this.textBox5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(107, 40);
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '*';
            this.textBox6.Size = new System.Drawing.Size(116, 21);
            this.textBox6.TabIndex = 4;
            this.textBox6.Visible = false;
            // 
            // Model
            // 
            this.Model.AutoSize = true;
            this.Model.Location = new System.Drawing.Point(265, 41);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(89, 16);
            this.Model.TabIndex = 10;
            this.Model.Text = "生成Model类";
            this.Model.UseVisualStyleBackColor = true;
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Checked = true;
            this.All.Location = new System.Drawing.Point(265, 11);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(71, 16);
            this.All.TabIndex = 10;
            this.All.TabStop = true;
            this.All.Text = "全部生成";
            this.All.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(106, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(117, 21);
            this.textBox4.TabIndex = 4;
            this.textBox4.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "数据库登录名：";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "数据库登录密码：";
            this.label9.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(45, 240);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 79);
            this.panel5.TabIndex = 14;
            this.panel5.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "数据库名称：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(83, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 21);
            this.textBox3.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "实体类名称：";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(130, 206);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(305, 21);
            this.textBox8.TabIndex = 13;
            this.textBox8.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(45, 205);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "保存路径";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // tbp3
            // 
            this.tbp3.Location = new System.Drawing.Point(4, 22);
            this.tbp3.Name = "tbp3";
            this.tbp3.Size = new System.Drawing.Size(865, 404);
            this.tbp3.TabIndex = 2;
            this.tbp3.Text = "Three";
            this.tbp3.UseVisualStyleBackColor = true;
            // 
            // tbp4
            // 
            this.tbp4.Location = new System.Drawing.Point(4, 22);
            this.tbp4.Name = "tbp4";
            this.tbp4.Size = new System.Drawing.Size(865, 404);
            this.tbp4.TabIndex = 3;
            this.tbp4.Text = "Four";
            this.tbp4.UseVisualStyleBackColor = true;
            // 
            // tbp5
            // 
            this.tbp5.Location = new System.Drawing.Point(4, 22);
            this.tbp5.Name = "tbp5";
            this.tbp5.Size = new System.Drawing.Size(865, 404);
            this.tbp5.TabIndex = 4;
            this.tbp5.Text = "Five";
            this.tbp5.UseVisualStyleBackColor = true;
            // 
            // Form_Code_SetText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 430);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form_Code_SetText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成代码至文本";
            this.Load += new System.EventHandler(this.Form_Code_SetText_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbp1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbp2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_add;
        private System.Windows.Forms.CheckBox checkBox_delete;
        private System.Windows.Forms.CheckBox checkBox_update;
        private System.Windows.Forms.CheckBox checkBox_getall;
        private System.Windows.Forms.CheckBox checkBox_getbykey;
        private System.Windows.Forms.CheckBox checkBox_exists;
        private System.Windows.Forms.CheckBox checkBox_count;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbp1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tbp2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tbp3;
        private System.Windows.Forms.TabPage tbp4;
        private System.Windows.Forms.TabPage tbp5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAutoCreateCode2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton DBHelper;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RadioButton Model;
        private System.Windows.Forms.RadioButton All;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}