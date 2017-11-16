namespace ParkSlotMapping
{
    partial class frmSlotMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSlotMapping));
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btNewProject = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCoord = new System.Windows.Forms.Label();
            this.btOpenProject = new System.Windows.Forms.Button();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlMapping = new System.Windows.Forms.Panel();
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.btZoomDown = new System.Windows.Forms.Button();
            this.lblContrast = new System.Windows.Forms.Label();
            this.btZoomUp = new System.Windows.Forms.Button();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.btRevertImg = new System.Windows.Forms.Button();
            this.btToGrayscale = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.barContrast = new System.Windows.Forms.TrackBar();
            this.barBrightness = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlMapButtons = new System.Windows.Forms.Panel();
            this.chkOCV = new System.Windows.Forms.CheckBox();
            this.numYshift = new System.Windows.Forms.NumericUpDown();
            this.btExportBinary = new System.Windows.Forms.Button();
            this.numXshift = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numRotation = new System.Windows.Forms.NumericUpDown();
            this.btShift = new System.Windows.Forms.Button();
            this.btRotation = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btExportXML = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btMapClear = new System.Windows.Forms.Button();
            this.btImportXML = new System.Windows.Forms.Button();
            this.btImportBinary = new System.Windows.Forms.Button();
            this.btCancelDrw = new System.Windows.Forms.Button();
            this.btDraw = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.picZoom = new System.Windows.Forms.PictureBox();
            this.btChangeImg = new System.Windows.Forms.Button();
            this.btSaveProject = new System.Windows.Forms.Button();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaxMove = new System.Windows.Forms.Label();
            this.lblMovPoint = new System.Windows.Forms.Label();
            this.chkXover = new System.Windows.Forms.CheckBox();
            this.chkYover = new System.Windows.Forms.CheckBox();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.checkDebugOpt = new System.Windows.Forms.CheckBox();
            this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBynaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBynaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.btSaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBrightness)).BeginInit();
            this.pnlMapButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYshift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXshift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).BeginInit();
            this.pnlDebug.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picImage.Location = new System.Drawing.Point(8, 31);
            this.picImage.MaximumSize = new System.Drawing.Size(900, 675);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(900, 675);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picSlotMap_Paint);
            this.picImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picSlotMap_MouseDoubleClick);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSlotMap_MouseDown);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSlotMap_MouseMove);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSlotMap_MouseUp);
            // 
            // btNewProject
            // 
            this.btNewProject.Location = new System.Drawing.Point(1081, 31);
            this.btNewProject.Name = "btNewProject";
            this.btNewProject.Size = new System.Drawing.Size(104, 23);
            this.btNewProject.TabIndex = 2;
            this.btNewProject.Text = "New Project";
            this.btNewProject.UseVisualStyleBackColor = true;
            this.btNewProject.Click += new System.EventHandler(this.btNewProject_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.AutoUpgradeEnabled = false;
            this.openImageDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF, *.PNG)|*.BMP; *.JPG; *.GIF; *.PNG;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cursor position:";
            // 
            // lblCoord
            // 
            this.lblCoord.AutoSize = true;
            this.lblCoord.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoord.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCoord.Location = new System.Drawing.Point(91, 47);
            this.lblCoord.Name = "lblCoord";
            this.lblCoord.Size = new System.Drawing.Size(53, 13);
            this.lblCoord.TabIndex = 7;
            this.lblCoord.Text = "{X=0,Y=0}";
            // 
            // btOpenProject
            // 
            this.btOpenProject.Location = new System.Drawing.Point(969, 31);
            this.btOpenProject.Name = "btOpenProject";
            this.btOpenProject.Size = new System.Drawing.Size(104, 23);
            this.btOpenProject.TabIndex = 1;
            this.btOpenProject.Text = "Open Project";
            this.btOpenProject.UseVisualStyleBackColor = true;
            this.btOpenProject.Click += new System.EventHandler(this.btOpenProject_Click);
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.AutoUpgradeEnabled = false;
            this.openProjectDialog.Filter = "Parking Slot Mapping Project(*.smprj)|*.smprj;";
            // 
            // pnlMapping
            // 
            this.pnlMapping.BackColor = System.Drawing.Color.White;
            this.pnlMapping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMapping.Controls.Add(this.lblZoom);
            this.pnlMapping.Controls.Add(this.lblZ);
            this.pnlMapping.Controls.Add(this.btZoomDown);
            this.pnlMapping.Controls.Add(this.lblContrast);
            this.pnlMapping.Controls.Add(this.btZoomUp);
            this.pnlMapping.Controls.Add(this.lblBrightness);
            this.pnlMapping.Controls.Add(this.btRevertImg);
            this.pnlMapping.Controls.Add(this.btToGrayscale);
            this.pnlMapping.Controls.Add(this.label9);
            this.pnlMapping.Controls.Add(this.label8);
            this.pnlMapping.Controls.Add(this.barContrast);
            this.pnlMapping.Controls.Add(this.barBrightness);
            this.pnlMapping.Controls.Add(this.label7);
            this.pnlMapping.Controls.Add(this.pnlMapButtons);
            this.pnlMapping.Controls.Add(this.btCancelDrw);
            this.pnlMapping.Controls.Add(this.btDraw);
            this.pnlMapping.Controls.Add(this.label4);
            this.pnlMapping.Controls.Add(this.picZoom);
            this.pnlMapping.Controls.Add(this.lblCoord);
            this.pnlMapping.Controls.Add(this.label1);
            this.pnlMapping.Enabled = false;
            this.pnlMapping.Location = new System.Drawing.Point(969, 99);
            this.pnlMapping.Name = "pnlMapping";
            this.pnlMapping.Size = new System.Drawing.Size(216, 607);
            this.pnlMapping.TabIndex = 8;
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.BackColor = System.Drawing.Color.Transparent;
            this.lblZoom.Font = new System.Drawing.Font("Lato Black", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoom.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblZoom.Location = new System.Drawing.Point(104, 82);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(0, 15);
            this.lblZoom.TabIndex = 10;
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.BackColor = System.Drawing.Color.Transparent;
            this.lblZ.Font = new System.Drawing.Font("Lato Black", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblZ.Location = new System.Drawing.Point(53, 82);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(56, 15);
            this.lblZ.TabIndex = 10;
            this.lblZ.Text = "ZOOM x";
            // 
            // btZoomDown
            // 
            this.btZoomDown.BackColor = System.Drawing.Color.Transparent;
            this.btZoomDown.Location = new System.Drawing.Point(141, 77);
            this.btZoomDown.Name = "btZoomDown";
            this.btZoomDown.Size = new System.Drawing.Size(20, 22);
            this.btZoomDown.TabIndex = 16;
            this.btZoomDown.Text = "-";
            this.btZoomDown.UseVisualStyleBackColor = false;
            this.btZoomDown.Click += new System.EventHandler(this.btZoomDown_Click);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrast.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblContrast.Location = new System.Drawing.Point(75, 531);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(13, 13);
            this.lblContrast.TabIndex = 17;
            this.lblContrast.Text = "1";
            // 
            // btZoomUp
            // 
            this.btZoomUp.BackColor = System.Drawing.Color.Transparent;
            this.btZoomUp.Location = new System.Drawing.Point(119, 77);
            this.btZoomUp.Name = "btZoomUp";
            this.btZoomUp.Size = new System.Drawing.Size(20, 22);
            this.btZoomUp.TabIndex = 16;
            this.btZoomUp.Text = "+";
            this.btZoomUp.UseVisualStyleBackColor = false;
            this.btZoomUp.Click += new System.EventHandler(this.btZoomUp_Click);
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrightness.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBrightness.Location = new System.Drawing.Point(75, 484);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(13, 13);
            this.lblBrightness.TabIndex = 17;
            this.lblBrightness.Text = "0";
            // 
            // btRevertImg
            // 
            this.btRevertImg.Location = new System.Drawing.Point(13, 578);
            this.btRevertImg.Name = "btRevertImg";
            this.btRevertImg.Size = new System.Drawing.Size(187, 23);
            this.btRevertImg.TabIndex = 13;
            this.btRevertImg.Text = "Reset Adjustments";
            this.btRevertImg.UseVisualStyleBackColor = true;
            this.btRevertImg.Click += new System.EventHandler(this.btRevertImg_Click);
            // 
            // btToGrayscale
            // 
            this.btToGrayscale.Enabled = false;
            this.btToGrayscale.Location = new System.Drawing.Point(140, 478);
            this.btToGrayscale.Name = "btToGrayscale";
            this.btToGrayscale.Size = new System.Drawing.Size(71, 23);
            this.btToGrayscale.TabIndex = 13;
            this.btToGrayscale.Text = "Grayscale";
            this.btToGrayscale.UseVisualStyleBackColor = true;
            this.btToGrayscale.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(10, 531);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Contrast:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(10, 483);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Brightness:";
            // 
            // barContrast
            // 
            this.barContrast.LargeChange = 1;
            this.barContrast.Location = new System.Drawing.Point(5, 543);
            this.barContrast.Maximum = 20;
            this.barContrast.Name = "barContrast";
            this.barContrast.Size = new System.Drawing.Size(206, 45);
            this.barContrast.TabIndex = 15;
            this.barContrast.Value = 5;
            this.barContrast.Scroll += new System.EventHandler(this.bar_Scroll);
            // 
            // barBrightness
            // 
            this.barBrightness.LargeChange = 3;
            this.barBrightness.Location = new System.Drawing.Point(5, 496);
            this.barBrightness.Maximum = 15;
            this.barBrightness.Minimum = -15;
            this.barBrightness.Name = "barBrightness";
            this.barBrightness.Size = new System.Drawing.Size(206, 45);
            this.barBrightness.TabIndex = 15;
            this.barBrightness.TickFrequency = 3;
            this.barBrightness.Scroll += new System.EventHandler(this.bar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lato Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(46, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "IMAGE ADJUSTMENTS:";
            // 
            // pnlMapButtons
            // 
            this.pnlMapButtons.Controls.Add(this.btSaveImage);
            this.pnlMapButtons.Controls.Add(this.label12);
            this.pnlMapButtons.Controls.Add(this.chkOCV);
            this.pnlMapButtons.Controls.Add(this.numYshift);
            this.pnlMapButtons.Controls.Add(this.btExportBinary);
            this.pnlMapButtons.Controls.Add(this.numXshift);
            this.pnlMapButtons.Controls.Add(this.label5);
            this.pnlMapButtons.Controls.Add(this.numRotation);
            this.pnlMapButtons.Controls.Add(this.btShift);
            this.pnlMapButtons.Controls.Add(this.btRotation);
            this.pnlMapButtons.Controls.Add(this.label11);
            this.pnlMapButtons.Controls.Add(this.btExportXML);
            this.pnlMapButtons.Controls.Add(this.label6);
            this.pnlMapButtons.Controls.Add(this.label10);
            this.pnlMapButtons.Controls.Add(this.btMapClear);
            this.pnlMapButtons.Controls.Add(this.btImportXML);
            this.pnlMapButtons.Controls.Add(this.btImportBinary);
            this.pnlMapButtons.Enabled = false;
            this.pnlMapButtons.Location = new System.Drawing.Point(3, 274);
            this.pnlMapButtons.Name = "pnlMapButtons";
            this.pnlMapButtons.Size = new System.Drawing.Size(208, 186);
            this.pnlMapButtons.TabIndex = 13;
            // 
            // chkOCV
            // 
            this.chkOCV.AutoSize = true;
            this.chkOCV.Location = new System.Drawing.Point(109, 164);
            this.chkOCV.Name = "chkOCV";
            this.chkOCV.Size = new System.Drawing.Size(88, 17);
            this.chkOCV.TabIndex = 21;
            this.chkOCV.Text = "OCV storage";
            this.chkOCV.UseVisualStyleBackColor = true;
            // 
            // numYshift
            // 
            this.numYshift.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numYshift.Location = new System.Drawing.Point(88, 53);
            this.numYshift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numYshift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numYshift.Name = "numYshift";
            this.numYshift.Size = new System.Drawing.Size(52, 21);
            this.numYshift.TabIndex = 20;
            // 
            // btExportBinary
            // 
            this.btExportBinary.Location = new System.Drawing.Point(108, 109);
            this.btExportBinary.Name = "btExportBinary";
            this.btExportBinary.Size = new System.Drawing.Size(90, 23);
            this.btExportBinary.TabIndex = 11;
            this.btExportBinary.Text = "Export Binary";
            this.btExportBinary.UseVisualStyleBackColor = true;
            this.btExportBinary.Click += new System.EventHandler(this.btExportBinary_Click);
            // 
            // numXshift
            // 
            this.numXshift.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numXshift.Location = new System.Drawing.Point(21, 53);
            this.numXshift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numXshift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numXshift.Name = "numXshift";
            this.numXshift.Size = new System.Drawing.Size(52, 21);
            this.numXshift.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lato Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(85, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MAP:";
            // 
            // numRotation
            // 
            this.numRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRotation.Location = new System.Drawing.Point(64, 23);
            this.numRotation.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numRotation.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            -2147483648});
            this.numRotation.Name = "numRotation";
            this.numRotation.Size = new System.Drawing.Size(75, 21);
            this.numRotation.TabIndex = 20;
            // 
            // btShift
            // 
            this.btShift.Location = new System.Drawing.Point(150, 52);
            this.btShift.Name = "btShift";
            this.btShift.Size = new System.Drawing.Size(47, 23);
            this.btShift.TabIndex = 19;
            this.btShift.Text = "Shift";
            this.btShift.UseVisualStyleBackColor = true;
            this.btShift.Click += new System.EventHandler(this.btShift_Click);
            // 
            // btRotation
            // 
            this.btRotation.Location = new System.Drawing.Point(150, 22);
            this.btRotation.Name = "btRotation";
            this.btRotation.Size = new System.Drawing.Size(47, 23);
            this.btRotation.TabIndex = 19;
            this.btRotation.Text = "Rotate";
            this.btRotation.UseVisualStyleBackColor = true;
            this.btRotation.Click += new System.EventHandler(this.btRotate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(7, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 26);
            this.label11.TabIndex = 16;
            this.label11.Text = "in tenth \r\nof degree";
            // 
            // btExportXML
            // 
            this.btExportXML.Location = new System.Drawing.Point(108, 138);
            this.btExportXML.Name = "btExportXML";
            this.btExportXML.Size = new System.Drawing.Size(90, 23);
            this.btExportXML.TabIndex = 11;
            this.btExportXML.Text = "Export XML";
            this.btExportXML.UseVisualStyleBackColor = true;
            this.btExportXML.Click += new System.EventHandler(this.btExportXML_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "X:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(74, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Y:";
            // 
            // btMapClear
            // 
            this.btMapClear.Location = new System.Drawing.Point(10, 80);
            this.btMapClear.Name = "btMapClear";
            this.btMapClear.Size = new System.Drawing.Size(90, 23);
            this.btMapClear.TabIndex = 11;
            this.btMapClear.Text = "Clear";
            this.btMapClear.UseVisualStyleBackColor = true;
            this.btMapClear.Click += new System.EventHandler(this.btMapClear_Click);
            // 
            // btImportXML
            // 
            this.btImportXML.Location = new System.Drawing.Point(10, 138);
            this.btImportXML.Name = "btImportXML";
            this.btImportXML.Size = new System.Drawing.Size(90, 23);
            this.btImportXML.TabIndex = 11;
            this.btImportXML.Text = "Import XML";
            this.btImportXML.UseVisualStyleBackColor = true;
            this.btImportXML.Click += new System.EventHandler(this.btImportXML_Click);
            // 
            // btImportBinary
            // 
            this.btImportBinary.Location = new System.Drawing.Point(10, 109);
            this.btImportBinary.Name = "btImportBinary";
            this.btImportBinary.Size = new System.Drawing.Size(90, 23);
            this.btImportBinary.TabIndex = 11;
            this.btImportBinary.Text = "Import Binary";
            this.btImportBinary.UseVisualStyleBackColor = true;
            this.btImportBinary.Click += new System.EventHandler(this.btImportBinary_Click);
            // 
            // btCancelDrw
            // 
            this.btCancelDrw.Enabled = false;
            this.btCancelDrw.Location = new System.Drawing.Point(140, 13);
            this.btCancelDrw.Name = "btCancelDrw";
            this.btCancelDrw.Size = new System.Drawing.Size(60, 21);
            this.btCancelDrw.TabIndex = 12;
            this.btCancelDrw.Text = "Cancel";
            this.btCancelDrw.UseVisualStyleBackColor = true;
            this.btCancelDrw.Click += new System.EventHandler(this.btCancelDrw_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(70, 13);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(60, 21);
            this.btDraw.TabIndex = 11;
            this.btDraw.Text = "Start";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lato Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(10, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DRAW:";
            // 
            // picZoom
            // 
            this.picZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picZoom.Location = new System.Drawing.Point(13, 72);
            this.picZoom.Name = "picZoom";
            this.picZoom.Size = new System.Drawing.Size(187, 191);
            this.picZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZoom.TabIndex = 9;
            this.picZoom.TabStop = false;
            // 
            // btChangeImg
            // 
            this.btChangeImg.Enabled = false;
            this.btChangeImg.Location = new System.Drawing.Point(969, 60);
            this.btChangeImg.Name = "btChangeImg";
            this.btChangeImg.Size = new System.Drawing.Size(104, 23);
            this.btChangeImg.TabIndex = 3;
            this.btChangeImg.Text = "Change Image";
            this.btChangeImg.UseVisualStyleBackColor = true;
            this.btChangeImg.Click += new System.EventHandler(this.btChangeImg_Click);
            // 
            // btSaveProject
            // 
            this.btSaveProject.Enabled = false;
            this.btSaveProject.Location = new System.Drawing.Point(1081, 60);
            this.btSaveProject.Name = "btSaveProject";
            this.btSaveProject.Size = new System.Drawing.Size(104, 23);
            this.btSaveProject.TabIndex = 3;
            this.btSaveProject.Text = "Save Project";
            this.btSaveProject.UseVisualStyleBackColor = true;
            this.btSaveProject.Click += new System.EventHandler(this.btSaveProject_Click);
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.AutoUpgradeEnabled = false;
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.AutoUpgradeEnabled = false;
            this.saveImageDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Im" +
    "age (.png)|*.png";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "maxMove";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "movPoint";
            // 
            // lblMaxMove
            // 
            this.lblMaxMove.AutoSize = true;
            this.lblMaxMove.Location = new System.Drawing.Point(11, 13);
            this.lblMaxMove.Name = "lblMaxMove";
            this.lblMaxMove.Size = new System.Drawing.Size(0, 13);
            this.lblMaxMove.TabIndex = 9;
            // 
            // lblMovPoint
            // 
            this.lblMovPoint.AutoSize = true;
            this.lblMovPoint.Location = new System.Drawing.Point(11, 48);
            this.lblMovPoint.Name = "lblMovPoint";
            this.lblMovPoint.Size = new System.Drawing.Size(0, 13);
            this.lblMovPoint.TabIndex = 9;
            // 
            // chkXover
            // 
            this.chkXover.AutoSize = true;
            this.chkXover.Enabled = false;
            this.chkXover.Location = new System.Drawing.Point(9, 64);
            this.chkXover.Name = "chkXover";
            this.chkXover.Size = new System.Drawing.Size(58, 17);
            this.chkXover.TabIndex = 10;
            this.chkXover.Text = "X over";
            this.chkXover.UseVisualStyleBackColor = true;
            // 
            // chkYover
            // 
            this.chkYover.AutoSize = true;
            this.chkYover.Enabled = false;
            this.chkYover.Location = new System.Drawing.Point(9, 87);
            this.chkYover.Name = "chkYover";
            this.chkYover.Size = new System.Drawing.Size(58, 17);
            this.chkYover.TabIndex = 10;
            this.chkYover.Text = "Y over";
            this.chkYover.UseVisualStyleBackColor = true;
            // 
            // pnlDebug
            // 
            this.pnlDebug.Controls.Add(this.label2);
            this.pnlDebug.Controls.Add(this.label3);
            this.pnlDebug.Controls.Add(this.lblMaxMove);
            this.pnlDebug.Controls.Add(this.lblMovPoint);
            this.pnlDebug.Controls.Add(this.chkYover);
            this.pnlDebug.Controls.Add(this.chkXover);
            this.pnlDebug.Enabled = false;
            this.pnlDebug.Location = new System.Drawing.Point(1191, 54);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(144, 160);
            this.pnlDebug.TabIndex = 12;
            this.pnlDebug.Visible = false;
            // 
            // checkDebugOpt
            // 
            this.checkDebugOpt.AutoSize = true;
            this.checkDebugOpt.Location = new System.Drawing.Point(1191, 31);
            this.checkDebugOpt.Name = "checkDebugOpt";
            this.checkDebugOpt.Size = new System.Drawing.Size(92, 17);
            this.checkDebugOpt.TabIndex = 10;
            this.checkDebugOpt.Text = "Debug option";
            this.checkDebugOpt.UseVisualStyleBackColor = true;
            this.checkDebugOpt.Visible = false;
            this.checkDebugOpt.CheckedChanged += new System.EventHandler(this.checkDebugOpt_CheckedChanged);
            // 
            // openMapDialog
            // 
            this.openMapDialog.AutoUpgradeEnabled = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1335, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.btNewProject_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.btOpenProject_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save project";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btSaveProject_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeImageToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // changeImageToolStripMenuItem
            // 
            this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            this.changeImageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.changeImageToolStripMenuItem.Text = "Change Image";
            this.changeImageToolStripMenuItem.Click += new System.EventHandler(this.btChangeImg_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exportBynaryToolStripMenuItem,
            this.exportXMLToolStripMenuItem,
            this.importBynaryToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.btMapClear_Click);
            // 
            // exportBynaryToolStripMenuItem
            // 
            this.exportBynaryToolStripMenuItem.Name = "exportBynaryToolStripMenuItem";
            this.exportBynaryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportBynaryToolStripMenuItem.Text = "Export Binary";
            this.exportBynaryToolStripMenuItem.Click += new System.EventHandler(this.btExportBinary_Click);
            // 
            // exportXMLToolStripMenuItem
            // 
            this.exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            this.exportXMLToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportXMLToolStripMenuItem.Text = "Export XML";
            this.exportXMLToolStripMenuItem.Click += new System.EventHandler(this.btExportXML_Click);
            // 
            // importBynaryToolStripMenuItem
            // 
            this.importBynaryToolStripMenuItem.Name = "importBynaryToolStripMenuItem";
            this.importBynaryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importBynaryToolStripMenuItem.Text = "Import Bynary";
            this.importBynaryToolStripMenuItem.Click += new System.EventHandler(this.btImportBinary_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.btSaveImage_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "(no ocv_storage)";
            // 
            // btSaveImage
            // 
            this.btSaveImage.Location = new System.Drawing.Point(107, 80);
            this.btSaveImage.Name = "btSaveImage";
            this.btSaveImage.Size = new System.Drawing.Size(90, 23);
            this.btSaveImage.TabIndex = 23;
            this.btSaveImage.Text = "Save Image";
            this.btSaveImage.UseVisualStyleBackColor = true;
            // 
            // frmSlotMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.checkDebugOpt);
            this.Controls.Add(this.pnlDebug);
            this.Controls.Add(this.pnlMapping);
            this.Controls.Add(this.btOpenProject);
            this.Controls.Add(this.btSaveProject);
            this.Controls.Add(this.btChangeImg);
            this.Controls.Add(this.btNewProject);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSlotMapping";
            this.Text = "Park Slot Mapping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.slotMapping_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slotMap_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlMapping.ResumeLayout(false);
            this.pnlMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBrightness)).EndInit();
            this.pnlMapButtons.ResumeLayout(false);
            this.pnlMapButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYshift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXshift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).EndInit();
            this.pnlDebug.ResumeLayout(false);
            this.pnlDebug.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btNewProject;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCoord;
        private System.Windows.Forms.Button btOpenProject;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.Panel pnlMapping;
        private System.Windows.Forms.Button btChangeImg;
        private System.Windows.Forms.PictureBox picZoom;
        private System.Windows.Forms.Button btSaveProject;
        private System.Windows.Forms.Button btExportXML;
        private System.Windows.Forms.Button btExportBinary;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaxMove;
        private System.Windows.Forms.Label lblMovPoint;
        private System.Windows.Forms.CheckBox chkXover;
        private System.Windows.Forms.CheckBox chkYover;
        private System.Windows.Forms.Panel pnlDebug;
        private System.Windows.Forms.Button btCancelDrw;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkDebugOpt;
        private System.Windows.Forms.Button btImportBinary;
        private System.Windows.Forms.OpenFileDialog openMapDialog;
        private System.Windows.Forms.Panel pnlMapButtons;
        private System.Windows.Forms.Button btMapClear;
        private System.Windows.Forms.Button btToGrayscale;
        private System.Windows.Forms.Button btRevertImg;
        private System.Windows.Forms.TrackBar barBrightness;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar barContrast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportBynaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBynaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Button btZoomDown;
        private System.Windows.Forms.Button btZoomUp;
        private System.Windows.Forms.Button btRotation;
        private System.Windows.Forms.NumericUpDown numRotation;
        private System.Windows.Forms.NumericUpDown numYshift;
        private System.Windows.Forms.NumericUpDown numXshift;
        private System.Windows.Forms.Button btShift;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btImportXML;
        private System.Windows.Forms.CheckBox chkOCV;
        private System.Windows.Forms.Button btSaveImage;
        private System.Windows.Forms.Label label12;
    }
}