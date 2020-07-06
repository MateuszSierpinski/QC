namespace QC
{
    partial class Compare_View
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
            this.Input_Data_Grid_View = new System.Windows.Forms.DataGridView();
            this.Output_Data_Grid_View = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Input_Data_Grid_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Output_Data_Grid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Input_Data_Grid_View
            // 
            this.Input_Data_Grid_View.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Input_Data_Grid_View.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Input_Data_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Input_Data_Grid_View.Location = new System.Drawing.Point(10, 10);
            this.Input_Data_Grid_View.Name = "Input_Data_Grid_View";
            this.Input_Data_Grid_View.Size = new System.Drawing.Size(650, 730);
            this.Input_Data_Grid_View.TabIndex = 0;
            // 
            // Output_Data_Grid_View
            // 
            this.Output_Data_Grid_View.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output_Data_Grid_View.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Output_Data_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Output_Data_Grid_View.Location = new System.Drawing.Point(750, 10);
            this.Output_Data_Grid_View.Name = "Output_Data_Grid_View";
            this.Output_Data_Grid_View.Size = new System.Drawing.Size(650, 730);
            this.Output_Data_Grid_View.TabIndex = 1;
            // 
            // Compare_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1434, 761);
            this.Controls.Add(this.Output_Data_Grid_View);
            this.Controls.Add(this.Input_Data_Grid_View);
            this.Name = "Compare_View";
            this.Text = "Compare_View";
            this.Load += new System.EventHandler(this.Compare_View_Load);
            this.SizeChanged += new System.EventHandler(this.Compare_View_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Input_Data_Grid_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Output_Data_Grid_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Input_Data_Grid_View;
        private System.Windows.Forms.DataGridView Output_Data_Grid_View;
    }
}