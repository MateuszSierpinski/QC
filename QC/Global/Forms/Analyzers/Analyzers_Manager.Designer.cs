namespace QC
{
    partial class Analyzers_Manager
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PRE-JOB");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("JOB");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("OUT");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Analyzers_Hi_Panel = new System.Windows.Forms.Panel();
            this.Compare_Hi_Panel = new System.Windows.Forms.Panel();
            this.Analyzers_Label = new System.Windows.Forms.Label();
            this.Compare_Label = new System.Windows.Forms.Label();
            this.Analyzer_Panel = new System.Windows.Forms.Panel();
            this.Check_Button = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Compare_Panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ListBox_Of_Anlyzers_Output = new System.Windows.Forms.ListBox();
            this.Clear_2 = new System.Windows.Forms.Button();
            this.Clear_1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Compare_Button = new System.Windows.Forms.Button();
            this.ListBox_Of_Anlyzers_Input = new System.Windows.Forms.ListBox();
            this.tabControl1 = new FlatTabControl.FlatTabControl();
            this.Analyzer_Panel.SuspendLayout();
            this.Compare_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.treeView1.Location = new System.Drawing.Point(5, 50);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Pre-Job";
            treeNode1.Text = "PRE-JOB";
            treeNode2.Name = "JOB";
            treeNode2.Text = "JOB";
            treeNode3.Name = "Out";
            treeNode3.Text = "OUT";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(340, 550);
            this.treeView1.TabIndex = 26;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // Analyzers_Hi_Panel
            // 
            this.Analyzers_Hi_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(233)))));
            this.Analyzers_Hi_Panel.Location = new System.Drawing.Point(350, 45);
            this.Analyzers_Hi_Panel.Name = "Analyzers_Hi_Panel";
            this.Analyzers_Hi_Panel.Size = new System.Drawing.Size(100, 3);
            this.Analyzers_Hi_Panel.TabIndex = 212;
            // 
            // Compare_Hi_Panel
            // 
            this.Compare_Hi_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(233)))));
            this.Compare_Hi_Panel.Location = new System.Drawing.Point(450, 45);
            this.Compare_Hi_Panel.Name = "Compare_Hi_Panel";
            this.Compare_Hi_Panel.Size = new System.Drawing.Size(100, 3);
            this.Compare_Hi_Panel.TabIndex = 210;
            this.Compare_Hi_Panel.Visible = false;
            // 
            // Analyzers_Label
            // 
            this.Analyzers_Label.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold);
            this.Analyzers_Label.ForeColor = System.Drawing.Color.White;
            this.Analyzers_Label.Location = new System.Drawing.Point(350, 0);
            this.Analyzers_Label.Name = "Analyzers_Label";
            this.Analyzers_Label.Size = new System.Drawing.Size(100, 50);
            this.Analyzers_Label.TabIndex = 213;
            this.Analyzers_Label.Text = "Analyzers";
            this.Analyzers_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Analyzers_Label.Click += new System.EventHandler(this.Analyzers_Label_Click);
            this.Analyzers_Label.MouseEnter += new System.EventHandler(this.Analyzers_Label_MouseEnter);
            this.Analyzers_Label.MouseLeave += new System.EventHandler(this.Analyzers_Label_MouseLeave);
            // 
            // Compare_Label
            // 
            this.Compare_Label.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compare_Label.ForeColor = System.Drawing.Color.DimGray;
            this.Compare_Label.Location = new System.Drawing.Point(450, 0);
            this.Compare_Label.Name = "Compare_Label";
            this.Compare_Label.Size = new System.Drawing.Size(100, 50);
            this.Compare_Label.TabIndex = 211;
            this.Compare_Label.Text = "Compare";
            this.Compare_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Compare_Label.Click += new System.EventHandler(this.Compare_Label_Click);
            this.Compare_Label.MouseEnter += new System.EventHandler(this.Compare_Label_MouseEnter);
            this.Compare_Label.MouseLeave += new System.EventHandler(this.Compare_Label_MouseLeave);
            // 
            // Analyzer_Panel
            // 
            this.Analyzer_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Analyzer_Panel.Controls.Add(this.Check_Button);
            this.Analyzer_Panel.Controls.Add(this.comboBox2);
            this.Analyzer_Panel.Controls.Add(this.tabControl1);
            this.Analyzer_Panel.Location = new System.Drawing.Point(350, 55);
            this.Analyzer_Panel.Name = "Analyzer_Panel";
            this.Analyzer_Panel.Size = new System.Drawing.Size(900, 655);
            this.Analyzer_Panel.TabIndex = 214;
            // 
            // Check_Button
            // 
            this.Check_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Check_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Check_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Check_Button.ForeColor = System.Drawing.Color.White;
            this.Check_Button.Location = new System.Drawing.Point(229, 622);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(247, 33);
            this.Check_Button.TabIndex = 69;
            this.Check_Button.Text = "Check";
            this.Check_Button.UseVisualStyleBackColor = true;
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Analyzer  *.pre",
            "Analyzer  *.add"});
            this.comboBox2.Location = new System.Drawing.Point(25, 626);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 26);
            this.comboBox2.TabIndex = 68;
            // 
            // Compare_Panel
            // 
            this.Compare_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Compare_Panel.Controls.Add(this.label6);
            this.Compare_Panel.Controls.Add(this.comboBox1);
            this.Compare_Panel.Controls.Add(this.ListBox_Of_Anlyzers_Output);
            this.Compare_Panel.Controls.Add(this.Clear_2);
            this.Compare_Panel.Controls.Add(this.Clear_1);
            this.Compare_Panel.Controls.Add(this.label4);
            this.Compare_Panel.Controls.Add(this.label3);
            this.Compare_Panel.Controls.Add(this.Compare_Button);
            this.Compare_Panel.Controls.Add(this.ListBox_Of_Anlyzers_Input);
            this.Compare_Panel.Location = new System.Drawing.Point(350, 55);
            this.Compare_Panel.Name = "Compare_Panel";
            this.Compare_Panel.Size = new System.Drawing.Size(900, 655);
            this.Compare_Panel.TabIndex = 215;
            this.Compare_Panel.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(214, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 27);
            this.label6.TabIndex = 66;
            this.label6.Text = "Compare otpions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "One to one",
            "Couple to one"});
            this.comboBox1.Location = new System.Drawing.Point(416, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 24);
            this.comboBox1.TabIndex = 65;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ListBox_Of_Anlyzers_Output
            // 
            this.ListBox_Of_Anlyzers_Output.AllowDrop = true;
            this.ListBox_Of_Anlyzers_Output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ListBox_Of_Anlyzers_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Of_Anlyzers_Output.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_Of_Anlyzers_Output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(2)))));
            this.ListBox_Of_Anlyzers_Output.FormattingEnabled = true;
            this.ListBox_Of_Anlyzers_Output.ItemHeight = 19;
            this.ListBox_Of_Anlyzers_Output.Location = new System.Drawing.Point(420, 300);
            this.ListBox_Of_Anlyzers_Output.Name = "ListBox_Of_Anlyzers_Output";
            this.ListBox_Of_Anlyzers_Output.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_Of_Anlyzers_Output.Size = new System.Drawing.Size(265, 19);
            this.ListBox_Of_Anlyzers_Output.TabIndex = 59;
            this.ListBox_Of_Anlyzers_Output.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_Of_Anlyzers_Output_DragDrop);
            this.ListBox_Of_Anlyzers_Output.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_Of_Anlyzers_Output_DragEnter);
            // 
            // Clear_2
            // 
            this.Clear_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Clear_2.ForeColor = System.Drawing.Color.White;
            this.Clear_2.Location = new System.Drawing.Point(494, 355);
            this.Clear_2.Name = "Clear_2";
            this.Clear_2.Size = new System.Drawing.Size(102, 33);
            this.Clear_2.TabIndex = 64;
            this.Clear_2.Text = "Clear";
            this.Clear_2.UseVisualStyleBackColor = true;
            this.Clear_2.Click += new System.EventHandler(this.Clear_2_Click);
            // 
            // Clear_1
            // 
            this.Clear_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Clear_1.ForeColor = System.Drawing.Color.White;
            this.Clear_1.Location = new System.Drawing.Point(175, 407);
            this.Clear_1.Name = "Clear_1";
            this.Clear_1.Size = new System.Drawing.Size(102, 33);
            this.Clear_1.TabIndex = 63;
            this.Clear_1.Text = "Clear";
            this.Clear_1.UseVisualStyleBackColor = true;
            this.Clear_1.Click += new System.EventHandler(this.Clear_1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(420, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 27);
            this.label4.TabIndex = 62;
            this.label4.Text = "To this";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 27);
            this.label3.TabIndex = 61;
            this.label3.Text = "Compare this";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Compare_Button
            // 
            this.Compare_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Compare_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Compare_Button.ForeColor = System.Drawing.Color.White;
            this.Compare_Button.Location = new System.Drawing.Point(279, 574);
            this.Compare_Button.Name = "Compare_Button";
            this.Compare_Button.Size = new System.Drawing.Size(247, 33);
            this.Compare_Button.TabIndex = 60;
            this.Compare_Button.Text = "Compare";
            this.Compare_Button.UseVisualStyleBackColor = true;
            this.Compare_Button.Click += new System.EventHandler(this.Compare_Button_Click);
            // 
            // ListBox_Of_Anlyzers_Input
            // 
            this.ListBox_Of_Anlyzers_Input.AllowDrop = true;
            this.ListBox_Of_Anlyzers_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ListBox_Of_Anlyzers_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Of_Anlyzers_Input.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_Of_Anlyzers_Input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(231)))), ((int)(((byte)(2)))));
            this.ListBox_Of_Anlyzers_Input.FormattingEnabled = true;
            this.ListBox_Of_Anlyzers_Input.ItemHeight = 19;
            this.ListBox_Of_Anlyzers_Input.Location = new System.Drawing.Point(100, 240);
            this.ListBox_Of_Anlyzers_Input.Name = "ListBox_Of_Anlyzers_Input";
            this.ListBox_Of_Anlyzers_Input.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_Of_Anlyzers_Input.Size = new System.Drawing.Size(265, 152);
            this.ListBox_Of_Anlyzers_Input.TabIndex = 58;
            this.ListBox_Of_Anlyzers_Input.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_Of_Anlyzers_Input_DragDrop);
            this.ListBox_Of_Anlyzers_Input.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_Of_Anlyzers_Input_DragEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 616);
            this.tabControl1.TabIndex = 29;
            // 
            // Analyzers_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.Analyzer_Panel);
            this.Controls.Add(this.Analyzers_Hi_Panel);
            this.Controls.Add(this.Compare_Hi_Panel);
            this.Controls.Add(this.Analyzers_Label);
            this.Controls.Add(this.Compare_Label);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Compare_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Analyzers_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analyzers Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Analyzers_Manager_FormClosing);
            this.Shown += new System.EventHandler(this.Analyzers_Manager_Shown);
            this.Analyzer_Panel.ResumeLayout(false);
            this.Compare_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private FlatTabControl.FlatTabControl tabControl1;
        private System.Windows.Forms.Panel Analyzers_Hi_Panel;
        private System.Windows.Forms.Panel Compare_Hi_Panel;
        private System.Windows.Forms.Label Analyzers_Label;
        private System.Windows.Forms.Label Compare_Label;
        private System.Windows.Forms.Panel Analyzer_Panel;
        private System.Windows.Forms.Panel Compare_Panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ListBox ListBox_Of_Anlyzers_Output;
        private System.Windows.Forms.Button Clear_2;
        private System.Windows.Forms.Button Clear_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Compare_Button;
        public System.Windows.Forms.ListBox ListBox_Of_Anlyzers_Input;
        private System.Windows.Forms.Button Check_Button;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}