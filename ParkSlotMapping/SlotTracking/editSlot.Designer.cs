namespace ParkSlotMapping
{
    partial class frmEditSlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSlot));
            this.picSlot = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt0 = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radEmpty = new System.Windows.Forms.RadioButton();
            this.radFull = new System.Windows.Forms.RadioButton();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btDeleteSlot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // picSlot
            // 
            this.picSlot.Location = new System.Drawing.Point(12, 12);
            this.picSlot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picSlot.Name = "picSlot";
            this.picSlot.Size = new System.Drawing.Size(256, 256);
            this.picSlot.TabIndex = 0;
            this.picSlot.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coordinates";
            // 
            // txt0
            // 
            this.txt0.Location = new System.Drawing.Point(292, 95);
            this.txt0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt0.Name = "txt0";
            this.txt0.ReadOnly = true;
            this.txt0.Size = new System.Drawing.Size(81, 21);
            this.txt0.TabIndex = 4;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(278, 28);
            this.txtLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(95, 21);
            this.txtLabel.TabIndex = 1;
            this.txtLabel.TextChanged += new System.EventHandler(this.txtLabel_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "State";
            // 
            // radEmpty
            // 
            this.radEmpty.AutoSize = true;
            this.radEmpty.Checked = true;
            this.radEmpty.Location = new System.Drawing.Point(398, 28);
            this.radEmpty.Name = "radEmpty";
            this.radEmpty.Size = new System.Drawing.Size(56, 17);
            this.radEmpty.TabIndex = 2;
            this.radEmpty.TabStop = true;
            this.radEmpty.Text = "Empty";
            this.radEmpty.UseVisualStyleBackColor = true;
            // 
            // radFull
            // 
            this.radFull.AutoSize = true;
            this.radFull.Location = new System.Drawing.Point(398, 45);
            this.radFull.Name = "radFull";
            this.radFull.Size = new System.Drawing.Size(43, 17);
            this.radFull.TabIndex = 3;
            this.radFull.Text = "Full";
            this.radFull.UseVisualStyleBackColor = true;
            // 
            // btConfirm
            // 
            this.btConfirm.Enabled = false;
            this.btConfirm.Location = new System.Drawing.Point(278, 242);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(95, 23);
            this.btConfirm.TabIndex = 4;
            this.btConfirm.Text = "Confirm";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(385, 242);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(95, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(275, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "0:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(275, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(382, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(382, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "3:";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(399, 121);
            this.txt3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(81, 21);
            this.txt3.TabIndex = 4;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(292, 121);
            this.txt2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(81, 21);
            this.txt2.TabIndex = 4;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(399, 95);
            this.txt1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(81, 21);
            this.txt1.TabIndex = 4;
            // 
            // btDeleteSlot
            // 
            this.btDeleteSlot.Enabled = false;
            this.btDeleteSlot.Location = new System.Drawing.Point(278, 187);
            this.btDeleteSlot.Name = "btDeleteSlot";
            this.btDeleteSlot.Size = new System.Drawing.Size(202, 23);
            this.btDeleteSlot.TabIndex = 4;
            this.btDeleteSlot.Text = "Delete Slot";
            this.btDeleteSlot.UseVisualStyleBackColor = true;
            this.btDeleteSlot.Click += new System.EventHandler(this.btDeleteSlot_Click);
            // 
            // frmEditSlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 277);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btDeleteSlot);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.radFull);
            this.Controls.Add(this.radEmpty);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picSlot);
            this.Font = new System.Drawing.Font("Lato", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmEditSlot";
            this.Load += new System.EventHandler(this.frmNameSlot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editSlot_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt0;
        private System.Windows.Forms.PictureBox picSlot;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radEmpty;
        private System.Windows.Forms.RadioButton radFull;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btDeleteSlot;
    }
}