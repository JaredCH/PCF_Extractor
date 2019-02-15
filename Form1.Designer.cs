namespace PCF_Extractor
{
    partial class MainForm
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
            this.dgv_FileList = new System.Windows.Forms.DataGridView();
            this.btn_SelectFiles = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FileList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_FileList
            // 
            this.dgv_FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filename,
            this.location});
            this.dgv_FileList.Location = new System.Drawing.Point(18, 22);
            this.dgv_FileList.Name = "dgv_FileList";
            this.dgv_FileList.Size = new System.Drawing.Size(253, 415);
            this.dgv_FileList.TabIndex = 0;
            // 
            // btn_SelectFiles
            // 
            this.btn_SelectFiles.Location = new System.Drawing.Point(294, 23);
            this.btn_SelectFiles.Name = "btn_SelectFiles";
            this.btn_SelectFiles.Size = new System.Drawing.Size(107, 26);
            this.btn_SelectFiles.TabIndex = 1;
            this.btn_SelectFiles.Text = "Select Files";
            this.btn_SelectFiles.UseVisualStyleBackColor = true;
            this.btn_SelectFiles.Click += new System.EventHandler(this.btn_SelectFiles_Click);
            // 
            // filename
            // 
            this.filename.HeaderText = "File Name";
            this.filename.Name = "filename";
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_SelectFiles);
            this.Controls.Add(this.dgv_FileList);
            this.Name = "MainForm";
            this.Text = "PCF Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FileList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_FileList;
        private System.Windows.Forms.Button btn_SelectFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
    }
}

