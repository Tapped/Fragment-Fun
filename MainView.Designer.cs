﻿namespace FragmentFun
{
    partial class MainView
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
            FreeGLObjects();
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textureManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.fpsLabel = new System.Windows.Forms.Label();
			this.startPauseButton = new System.Windows.Forms.Button();
			this.glControl1 = new OpenTK.GLControl();
			this.resetGlobalTimerButton = new System.Windows.Forms.Button();
			this.console = new System.Windows.Forms.RichTextBox();
			this.globalTimeTextBox = new System.Windows.Forms.TextBox();
			this.fragmentSourceEdit = new ScintillaNET.Scintilla();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.textureManagerToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openShaderToolStripMenuItem,
            this.saveShaderToolStripMenuItem,
            this.refreshToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openShaderToolStripMenuItem
			// 
			this.openShaderToolStripMenuItem.Name = "openShaderToolStripMenuItem";
			this.openShaderToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.openShaderToolStripMenuItem.Text = "Open Shader";
			this.openShaderToolStripMenuItem.Click += new System.EventHandler(this.openShaderToolStripMenuItem_Click);
			// 
			// saveShaderToolStripMenuItem
			// 
			this.saveShaderToolStripMenuItem.Name = "saveShaderToolStripMenuItem";
			this.saveShaderToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.saveShaderToolStripMenuItem.Text = "Save Shader";
			this.saveShaderToolStripMenuItem.Click += new System.EventHandler(this.saveShaderToolStripMenuItem_Click);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.refreshToolStripMenuItem.Text = "Refresh (F5)";
			this.refreshToolStripMenuItem.ToolTipText = "Press F5 to refresh shader source from disk.";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// textureManagerToolStripMenuItem
			// 
			this.textureManagerToolStripMenuItem.Name = "textureManagerToolStripMenuItem";
			this.textureManagerToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
			this.textureManagerToolStripMenuItem.Text = "Texture Manager";
			this.textureManagerToolStripMenuItem.Click += new System.EventHandler(this.textureManagerToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "frag";
			this.openFileDialog1.Filter = "GL shader files |*.frag|Essl shader files |*.essl;*.f.essl";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "frag";
			this.saveFileDialog1.Filter = "GL shader files |*.frag|Essl shader files |*.essl;*.f.essl";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.menuStrip1);
			this.panel1.Controls.Add(this.fpsLabel);
			this.panel1.Controls.Add(this.startPauseButton);
			this.panel1.Controls.Add(this.glControl1);
			this.panel1.Controls.Add(this.resetGlobalTimerButton);
			this.panel1.Controls.Add(this.console);
			this.panel1.Controls.Add(this.globalTimeTextBox);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1076, 861);
			this.panel1.TabIndex = 9;
			// 
			// fpsLabel
			// 
			this.fpsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fpsLabel.AutoSize = true;
			this.fpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fpsLabel.Location = new System.Drawing.Point(11, 625);
			this.fpsLabel.Name = "fpsLabel";
			this.fpsLabel.Size = new System.Drawing.Size(67, 25);
			this.fpsLabel.TabIndex = 3;
			this.fpsLabel.Text = "FPS: ";
			// 
			// startPauseButton
			// 
			this.startPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.startPauseButton.Location = new System.Drawing.Point(773, 625);
			this.startPauseButton.Name = "startPauseButton";
			this.startPauseButton.Size = new System.Drawing.Size(81, 30);
			this.startPauseButton.TabIndex = 8;
			this.startPauseButton.Text = "Start / Pause";
			this.startPauseButton.UseVisualStyleBackColor = true;
			this.startPauseButton.Click += new System.EventHandler(this.startPauseButton_Click);
			// 
			// glControl1
			// 
			this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.glControl1.BackColor = System.Drawing.Color.Black;
			this.glControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.glControl1.Location = new System.Drawing.Point(12, 43);
			this.glControl1.Name = "glControl1";
			this.glControl1.Size = new System.Drawing.Size(1024, 576);
			this.glControl1.TabIndex = 0;
			this.glControl1.VSync = true;
			this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
			this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
			this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
			// 
			// resetGlobalTimerButton
			// 
			this.resetGlobalTimerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.resetGlobalTimerButton.Location = new System.Drawing.Point(860, 625);
			this.resetGlobalTimerButton.Name = "resetGlobalTimerButton";
			this.resetGlobalTimerButton.Size = new System.Drawing.Size(75, 30);
			this.resetGlobalTimerButton.TabIndex = 7;
			this.resetGlobalTimerButton.Text = "Reset";
			this.resetGlobalTimerButton.UseVisualStyleBackColor = true;
			this.resetGlobalTimerButton.Click += new System.EventHandler(this.resetGlobalTimerButton_Click);
			// 
			// console
			// 
			this.console.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.console.Location = new System.Drawing.Point(12, 658);
			this.console.Name = "console";
			this.console.ReadOnly = true;
			this.console.Size = new System.Drawing.Size(1024, 164);
			this.console.TabIndex = 1;
			this.console.Text = "";
			this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
			// 
			// globalTimeTextBox
			// 
			this.globalTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.globalTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.globalTimeTextBox.Location = new System.Drawing.Point(941, 625);
			this.globalTimeTextBox.Name = "globalTimeTextBox";
			this.globalTimeTextBox.ReadOnly = true;
			this.globalTimeTextBox.Size = new System.Drawing.Size(86, 30);
			this.globalTimeTextBox.TabIndex = 6;
			// 
			// fragmentSourceEdit
			// 
			this.fragmentSourceEdit.Lexer = ScintillaNET.Lexer.Cpp;
			this.fragmentSourceEdit.Location = new System.Drawing.Point(1076, 0);
			this.fragmentSourceEdit.Name = "fragmentSourceEdit";
			this.fragmentSourceEdit.Size = new System.Drawing.Size(828, 861);
			this.fragmentSourceEdit.TabIndex = 10;
			this.fragmentSourceEdit.Text = "scintilla1";
			this.fragmentSourceEdit.Visible = false;
			this.fragmentSourceEdit.TextChanged += new System.EventHandler(this.fragmentSourceEdit_TextChanged);
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1904, 861);
			this.Controls.Add(this.fragmentSourceEdit);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainView";
			this.Text = "Fragment Fun";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openShaderToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveShaderToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem textureManagerToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Button startPauseButton;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button resetGlobalTimerButton;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.TextBox globalTimeTextBox;
		private ScintillaNET.Scintilla fragmentSourceEdit;
	}
}