namespace EXOStacker
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
            this.lstFilename = new System.Windows.Forms.ListBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFilename
            // 
            this.lstFilename.AllowDrop = true;
            this.lstFilename.FormattingEnabled = true;
            this.lstFilename.HorizontalScrollbar = true;
            this.lstFilename.ItemHeight = 12;
            this.lstFilename.Location = new System.Drawing.Point(12, 12);
            this.lstFilename.Name = "lstFilename";
            this.lstFilename.Size = new System.Drawing.Size(410, 412);
            this.lstFilename.TabIndex = 0;
            this.lstFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFilename_DragDrop);
            this.lstFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFilename_DragEnter);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(441, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(84, 32);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Add Files";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(441, 65);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(84, 32);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up↑";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(441, 107);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(84, 32);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "Move Down↓";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(441, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkAbout
            // 
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Location = new System.Drawing.Point(15, 440);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(235, 12);
            this.lnkAbout.TabIndex = 5;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "EXO Stacker for AviUtl, by Maverick Tse (2014)";
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(441, 248);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(84, 32);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Delete Item";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(441, 292);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 32);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 467);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.lstFilename);
            this.Name = "Form1";
            this.Text = "EXO Stacker for AviUtl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFilename;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkAbout;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
    }
}

