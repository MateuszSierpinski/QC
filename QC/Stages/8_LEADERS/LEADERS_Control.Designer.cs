namespace QC
{
    partial class LEADERS_Control
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Choice_comboBox = new System.Windows.Forms.ComboBox();
            this.Search_box = new System.Windows.Forms.TextBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridView1.Location = new System.Drawing.Point(45, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1060, 386);
            this.dataGridView1.TabIndex = 0;
            // 
            // Choice_comboBox
            // 
            this.Choice_comboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Title Code",
            "Job Number",
            "Cafe",
            "Processor"});
            this.Choice_comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Choice_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Choice_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice_comboBox.Font = new System.Drawing.Font("Century Gothic", 10.7F, System.Drawing.FontStyle.Bold);
            this.Choice_comboBox.ForeColor = System.Drawing.Color.White;
            this.Choice_comboBox.FormattingEnabled = true;
            this.Choice_comboBox.Items.AddRange(new object[] {
            "Title Code",
            "Job Number",
            "Cafe",
            "Processor"});
            this.Choice_comboBox.Location = new System.Drawing.Point(125, 70);
            this.Choice_comboBox.Name = "Choice_comboBox";
            this.Choice_comboBox.Size = new System.Drawing.Size(161, 25);
            this.Choice_comboBox.TabIndex = 218;
            // 
            // Search_box
            // 
            this.Search_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Search_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Search_box.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.Search_box.ForeColor = System.Drawing.Color.White;
            this.Search_box.Location = new System.Drawing.Point(330, 70);
            this.Search_box.Name = "Search_box";
            this.Search_box.Size = new System.Drawing.Size(250, 25);
            this.Search_box.TabIndex = 219;
            // 
            // Search_Button
            // 
            this.Search_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Search_Button.FlatAppearance.BorderSize = 0;
            this.Search_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search_Button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Button.ForeColor = System.Drawing.Color.White;
            this.Search_Button.Location = new System.Drawing.Point(620, 70);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(90, 25);
            this.Search_Button.TabIndex = 220;
            this.Search_Button.Text = "Search";
            this.Search_Button.UseVisualStyleBackColor = false;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 221;
            this.label3.Text = "Search by:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LEADERS_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Search_box);
            this.Controls.Add(this.Choice_comboBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LEADERS_Control";
            this.Size = new System.Drawing.Size(1163, 660);
            this.Load += new System.EventHandler(this.LEADERS_Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox Choice_comboBox;
        private System.Windows.Forms.TextBox Search_box;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.Label label3;
    }
}
