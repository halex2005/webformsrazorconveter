namespace AspxToRazorForms
{
    partial class RazorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RazorForm));
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSaveLocation = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.dirErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.fileErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerateRazor = new System.Windows.Forms.Button();
            this.rdoOriginalSave = new System.Windows.Forms.RadioButton();
            this.rdoAlternativeSave = new System.Windows.Forms.RadioButton();
            this.rdoOriginalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rdoAltLocationTip = new System.Windows.Forms.ToolTip(this.components);
            this.successPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dirErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.successPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select \r\nWeb Forms View(s)";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(558, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(36, 26);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSaveLocation
            // 
            this.lblSaveLocation.AutoSize = true;
            this.lblSaveLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveLocation.Location = new System.Drawing.Point(36, 299);
            this.lblSaveLocation.Name = "lblSaveLocation";
            this.lblSaveLocation.Size = new System.Drawing.Size(102, 18);
            this.lblSaveLocation.TabIndex = 4;
            this.lblSaveLocation.Text = "Save Location";
            // 
            // txtDir
            // 
            this.txtDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDir.Location = new System.Drawing.Point(145, 297);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(406, 24);
            this.txtDir.TabIndex = 5;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDir.Location = new System.Drawing.Point(558, 297);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(36, 26);
            this.btnBrowseDir.TabIndex = 10;
            this.btnBrowseDir.Text = "...";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // dirErrorProvider
            // 
            this.dirErrorProvider.ContainerControl = this;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(145, 15);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(406, 199);
            this.checkedListBox1.Sorted = true;
            this.checkedListBox1.TabIndex = 13;
            // 
            // fileErrorProvider
            // 
            this.fileErrorProvider.ContainerControl = this;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::AspxToRazorForms.Properties.Resources.refreshi_256;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(145, 344);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(188, 52);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerateRazor
            // 
            this.btnGenerateRazor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateRazor.Image = global::AspxToRazorForms.Properties.Resources.icon_processi;
            this.btnGenerateRazor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateRazor.Location = new System.Drawing.Point(360, 344);
            this.btnGenerateRazor.Name = "btnGenerateRazor";
            this.btnGenerateRazor.Size = new System.Drawing.Size(191, 52);
            this.btnGenerateRazor.TabIndex = 9;
            this.btnGenerateRazor.Text = "Convert";
            this.btnGenerateRazor.UseVisualStyleBackColor = true;
            this.btnGenerateRazor.Click += new System.EventHandler(this.btnGenerateRazor_Click);
            // 
            // rdoOriginalSave
            // 
            this.rdoOriginalSave.AutoSize = true;
            this.rdoOriginalSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rdoOriginalSave.Location = new System.Drawing.Point(145, 230);
            this.rdoOriginalSave.Name = "rdoOriginalSave";
            this.rdoOriginalSave.Size = new System.Drawing.Size(283, 22);
            this.rdoOriginalSave.TabIndex = 15;
            this.rdoOriginalSave.TabStop = true;
            this.rdoOriginalSave.Text = "Save to the original location(s) [Default]";
            this.rdoOriginalToolTip.SetToolTip(this.rdoOriginalSave, "This option will allow you to save CSHTML files to their corresponding WebForms f" +
        "ile(s) location(s).");
            this.rdoOriginalSave.UseVisualStyleBackColor = true;
            // 
            // rdoAlternativeSave
            // 
            this.rdoAlternativeSave.AutoSize = true;
            this.rdoAlternativeSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.rdoAlternativeSave.Location = new System.Drawing.Point(145, 265);
            this.rdoAlternativeSave.Name = "rdoAlternativeSave";
            this.rdoAlternativeSave.Size = new System.Drawing.Size(217, 22);
            this.rdoAlternativeSave.TabIndex = 16;
            this.rdoAlternativeSave.TabStop = true;
            this.rdoAlternativeSave.Text = "Save to an altenative location";
            this.rdoAltLocationTip.SetToolTip(this.rdoAlternativeSave, "This option will allow you to save CSHTML file to a specified location.");
            this.rdoAlternativeSave.UseVisualStyleBackColor = true;
            this.rdoAlternativeSave.CheckedChanged += new System.EventHandler(this.rdoAlternativeSave_CheckedChanged);
            // 
            // successPictureBox
            // 
            this.successPictureBox.Image = global::AspxToRazorForms.Properties.Resources.iconi_go;
            this.successPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("successPictureBox.InitialImage")));
            this.successPictureBox.Location = new System.Drawing.Point(558, 344);
            this.successPictureBox.Name = "successPictureBox";
            this.successPictureBox.Size = new System.Drawing.Size(48, 50);
            this.successPictureBox.TabIndex = 18;
            this.successPictureBox.TabStop = false;
            // 
            // RazorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(622, 426);
            this.Controls.Add(this.successPictureBox);
            this.Controls.Add(this.rdoAlternativeSave);
            this.Controls.Add(this.rdoOriginalSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.btnGenerateRazor);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.lblSaveLocation);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RazorForm";
            this.Text = "WebForms(ASPX/ASCX) to Razor Views (CSHTML) Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dirErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.successPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSaveLocation;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnGenerateRazor;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.ErrorProvider dirErrorProvider;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ErrorProvider fileErrorProvider;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdoOriginalSave;
        private System.Windows.Forms.RadioButton rdoAlternativeSave;
        private System.Windows.Forms.ToolTip rdoOriginalToolTip;
        private System.Windows.Forms.ToolTip rdoAltLocationTip;
        private System.Windows.Forms.PictureBox successPictureBox;
    }
}

