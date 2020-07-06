namespace QC
{
    partial class ARCHIVE_Control
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Drop_Zip = new System.Windows.Forms.Button();
            this.Clear_Folder = new System.Windows.Forms.Button();
            this.Archive_Folder = new System.Windows.Forms.Button();
            this.Info_label = new System.Windows.Forms.Label();
            this.Zip_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Result_Label = new System.Windows.Forms.Label();
            this.Clear_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Drop_backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(381, 18);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(762, 639);
            this.webBrowser1.TabIndex = 203;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Drop_Zip
            // 
            this.Drop_Zip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Drop_Zip.FlatAppearance.BorderSize = 0;
            this.Drop_Zip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Drop_Zip.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drop_Zip.ForeColor = System.Drawing.Color.White;
            this.Drop_Zip.Location = new System.Drawing.Point(50, 200);
            this.Drop_Zip.Name = "Drop_Zip";
            this.Drop_Zip.Size = new System.Drawing.Size(264, 40);
            this.Drop_Zip.TabIndex = 202;
            this.Drop_Zip.Text = "Drop Zip file to cafe";
            this.Drop_Zip.UseVisualStyleBackColor = false;
            this.Drop_Zip.Click += new System.EventHandler(this.Drop_Zip_Click);
            // 
            // Clear_Folder
            // 
            this.Clear_Folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Clear_Folder.FlatAppearance.BorderSize = 0;
            this.Clear_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_Folder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_Folder.ForeColor = System.Drawing.Color.White;
            this.Clear_Folder.Location = new System.Drawing.Point(50, 123);
            this.Clear_Folder.Name = "Clear_Folder";
            this.Clear_Folder.Size = new System.Drawing.Size(264, 40);
            this.Clear_Folder.TabIndex = 201;
            this.Clear_Folder.Text = "Clear Folder";
            this.Clear_Folder.UseVisualStyleBackColor = false;
            this.Clear_Folder.Click += new System.EventHandler(this.Clear_Folder_Click);
            // 
            // Archive_Folder
            // 
            this.Archive_Folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Archive_Folder.FlatAppearance.BorderSize = 0;
            this.Archive_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Archive_Folder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Archive_Folder.ForeColor = System.Drawing.Color.White;
            this.Archive_Folder.Location = new System.Drawing.Point(50, 46);
            this.Archive_Folder.Name = "Archive_Folder";
            this.Archive_Folder.Size = new System.Drawing.Size(264, 40);
            this.Archive_Folder.TabIndex = 200;
            this.Archive_Folder.Text = "Archive MDS Folder";
            this.Archive_Folder.UseVisualStyleBackColor = false;
            this.Archive_Folder.Click += new System.EventHandler(this.Archive_Folder_Click);
            // 
            // Info_label
            // 
            this.Info_label.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.Info_label.ForeColor = System.Drawing.Color.White;
            this.Info_label.Location = new System.Drawing.Point(61, 373);
            this.Info_label.Name = "Info_label";
            this.Info_label.Size = new System.Drawing.Size(169, 27);
            this.Info_label.TabIndex = 205;
            this.Info_label.Text = "Archiving";
            this.Info_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Info_label.Visible = false;
            // 
            // Zip_backgroundWorker
            // 
            this.Zip_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Zip_backgroundWorker_DoWork);
            this.Zip_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Zip_backgroundWorker_RunWorkerCompleted);
            // 
            // Result_Label
            // 
            this.Result_Label.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.Result_Label.ForeColor = System.Drawing.Color.White;
            this.Result_Label.Location = new System.Drawing.Point(0, 476);
            this.Result_Label.Name = "Result_Label";
            this.Result_Label.Size = new System.Drawing.Size(379, 27);
            this.Result_Label.TabIndex = 206;
            this.Result_Label.Text = "Result";
            this.Result_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Result_Label.Visible = false;
            // 
            // Clear_backgroundWorker
            // 
            this.Clear_backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Clear_backgroundWorker_DoWork);
            this.Clear_backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Clear_backgroundWorker_RunWorkerCompleted);
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(236, 361);
            this.circularProgressBar1.MarqueeAnimationSpeed = 3000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
            this.circularProgressBar1.OuterMargin = -35;
            this.circularProgressBar1.OuterWidth = 35;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(233)))));
            this.circularProgressBar1.ProgressWidth = 10;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(50, 50);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = ".23";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "°C";
            this.circularProgressBar1.TabIndex = 207;
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 67;
            this.circularProgressBar1.Visible = false;
            // 
            // ARCHIVE_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.Result_Label);
            this.Controls.Add(this.Info_label);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.Drop_Zip);
            this.Controls.Add(this.Clear_Folder);
            this.Controls.Add(this.Archive_Folder);
            this.Name = "ARCHIVE_Control";
            this.Size = new System.Drawing.Size(1163, 660);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button Drop_Zip;
        private System.Windows.Forms.Button Clear_Folder;
        private System.Windows.Forms.Button Archive_Folder;
        private System.Windows.Forms.Label Info_label;
        private System.ComponentModel.BackgroundWorker Zip_backgroundWorker;
        private System.Windows.Forms.Label Result_Label;
        private System.ComponentModel.BackgroundWorker Clear_backgroundWorker;
        private System.ComponentModel.BackgroundWorker Drop_backgroundWorker;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}
