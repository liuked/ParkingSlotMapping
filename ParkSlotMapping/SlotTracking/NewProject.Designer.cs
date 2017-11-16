namespace ParkSlotMapping
{
    partial class frmNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewProject));
            this.prjFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectFolder = new System.Windows.Forms.TextBox();
            this.btBrowseFolder = new System.Windows.Forms.Button();
            this.txtPrjName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImageFile = new System.Windows.Forms.TextBox();
            this.btBrowseImage = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.btMake = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project image";
            // 
            // txtProjectFolder
            // 
            this.txtProjectFolder.BackColor = System.Drawing.Color.White;
            this.txtProjectFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectFolder.Location = new System.Drawing.Point(94, 43);
            this.txtProjectFolder.Name = "txtProjectFolder";
            this.txtProjectFolder.ReadOnly = true;
            this.txtProjectFolder.Size = new System.Drawing.Size(282, 21);
            this.txtProjectFolder.TabIndex = 1;
            this.txtProjectFolder.TabStop = false;
            this.txtProjectFolder.TextChanged += new System.EventHandler(this.txtProjectFolder_TextChanged);
            // 
            // btBrowseFolder
            // 
            this.btBrowseFolder.Location = new System.Drawing.Point(487, 42);
            this.btBrowseFolder.Name = "btBrowseFolder";
            this.btBrowseFolder.Size = new System.Drawing.Size(93, 21);
            this.btBrowseFolder.TabIndex = 2;
            this.btBrowseFolder.Text = "Browse Folder";
            this.btBrowseFolder.UseVisualStyleBackColor = true;
            this.btBrowseFolder.Click += new System.EventHandler(this.btBrowseFolder_Click);
            // 
            // txtPrjName
            // 
            this.txtPrjName.AllowDrop = true;
            this.txtPrjName.BackColor = System.Drawing.Color.White;
            this.txtPrjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrjName.Location = new System.Drawing.Point(94, 10);
            this.txtPrjName.Name = "txtPrjName";
            this.txtPrjName.Size = new System.Drawing.Size(342, 21);
            this.txtPrjName.TabIndex = 4;
            this.txtPrjName.TabStop = false;
            this.txtPrjName.TextChanged += new System.EventHandler(this.txtPrjName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Project folder:";
            // 
            // txtImageFile
            // 
            this.txtImageFile.BackColor = System.Drawing.Color.White;
            this.txtImageFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageFile.Location = new System.Drawing.Point(94, 76);
            this.txtImageFile.Name = "txtImageFile";
            this.txtImageFile.ReadOnly = true;
            this.txtImageFile.Size = new System.Drawing.Size(378, 21);
            this.txtImageFile.TabIndex = 1;
            this.txtImageFile.TabStop = false;
            // 
            // btBrowseImage
            // 
            this.btBrowseImage.Enabled = false;
            this.btBrowseImage.Location = new System.Drawing.Point(487, 75);
            this.btBrowseImage.Name = "btBrowseImage";
            this.btBrowseImage.Size = new System.Drawing.Size(93, 21);
            this.btBrowseImage.TabIndex = 2;
            this.btBrowseImage.Text = "Browse Image";
            this.btBrowseImage.UseVisualStyleBackColor = true;
            this.btBrowseImage.Click += new System.EventHandler(this.btBrowseImage_Click);
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(94, 109);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(240, 184);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 5;
            this.picPreview.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Preview:";
            // 
            // openImageDialog
            // 
            this.openImageDialog.AutoUpgradeEnabled = false;
            this.openImageDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF, *.PNG)|*.BMP; *.JPG; *.GIF; *.PNG;";
            this.openImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openImageDialog_FileOk);
            // 
            // btMake
            // 
            this.btMake.Enabled = false;
            this.btMake.Location = new System.Drawing.Point(388, 272);
            this.btMake.Name = "btMake";
            this.btMake.Size = new System.Drawing.Size(93, 21);
            this.btMake.TabIndex = 2;
            this.btMake.Text = "Make";
            this.btMake.UseVisualStyleBackColor = true;
            this.btMake.Click += new System.EventHandler(this.btMake_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(434, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = ".smprj";
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.BackColor = System.Drawing.Color.Transparent;
            this.lblFolderName.ForeColor = System.Drawing.Color.Black;
            this.lblFolderName.Location = new System.Drawing.Point(375, 44);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(12, 13);
            this.lblFolderName.TabIndex = 3;
            this.lblFolderName.Text = "\\";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(487, 272);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(93, 21);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 305);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.txtPrjName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btMake);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btBrowseImage);
            this.Controls.Add(this.btBrowseFolder);
            this.Controls.Add(this.txtImageFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFolderName);
            this.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewProject";
            this.Text = "New Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.newProject_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog prjFolderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectFolder;
        private System.Windows.Forms.Button btBrowseFolder;
        private System.Windows.Forms.TextBox txtPrjName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImageFile;
        private System.Windows.Forms.Button btBrowseImage;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Button btMake;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.Button btCancel;
    }
}