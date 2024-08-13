namespace MonitoringApp
{
    partial class Form1
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
            this.dtgMonitoring = new System.Windows.Forms.DataGridView();
            this.btnUploadFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonitoring)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMonitoring
            // 
            this.dtgMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMonitoring.Location = new System.Drawing.Point(0, 3);
            this.dtgMonitoring.Name = "dtgMonitoring";
            this.dtgMonitoring.RowHeadersWidth = 51;
            this.dtgMonitoring.RowTemplate.Height = 24;
            this.dtgMonitoring.Size = new System.Drawing.Size(1128, 343);
            this.dtgMonitoring.TabIndex = 0;
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.BackColor = System.Drawing.Color.Lime;
            this.btnUploadFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUploadFile.Location = new System.Drawing.Point(0, 357);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(147, 45);
            this.btnUploadFile.TabIndex = 1;
            this.btnUploadFile.Text = "Start";
            this.btnUploadFile.UseVisualStyleBackColor = false;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 412);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.dtgMonitoring);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonitoring)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgMonitoring;
        private System.Windows.Forms.Button btnUploadFile;
    }
}

