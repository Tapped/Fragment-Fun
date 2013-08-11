namespace FragmentFun
{
    partial class TextureManagerForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.glControl1 = new OpenTK.GLControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.glControl2 = new OpenTK.GLControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.glControl3 = new OpenTK.GLControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.glControl4 = new OpenTK.GLControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.glControl5 = new OpenTK.GLControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 389);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.glControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "iChannel0";
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(6, 19);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(150, 150);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl_Load);
            this.glControl1.Click += new System.EventHandler(this.glControl_OnClick);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.glControl2);
            this.groupBox2.Location = new System.Drawing.Point(172, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 178);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "iChannel1";
            // 
            // glControl2
            // 
            this.glControl2.BackColor = System.Drawing.Color.Black;
            this.glControl2.Location = new System.Drawing.Point(6, 19);
            this.glControl2.Name = "glControl2";
            this.glControl2.Size = new System.Drawing.Size(150, 150);
            this.glControl2.TabIndex = 1;
            this.glControl2.VSync = false;
            this.glControl2.Load += new System.EventHandler(this.glControl_Load);
            this.glControl2.Click += new System.EventHandler(this.glControl_OnClick);
            this.glControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl2.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.glControl3);
            this.groupBox3.Location = new System.Drawing.Point(341, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 178);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "iChannel2";
            // 
            // glControl3
            // 
            this.glControl3.BackColor = System.Drawing.Color.Black;
            this.glControl3.Location = new System.Drawing.Point(7, 19);
            this.glControl3.Name = "glControl3";
            this.glControl3.Size = new System.Drawing.Size(150, 150);
            this.glControl3.TabIndex = 2;
            this.glControl3.VSync = false;
            this.glControl3.Load += new System.EventHandler(this.glControl_Load);
            this.glControl3.Click += new System.EventHandler(this.glControl_OnClick);
            this.glControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl3.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.glControl4);
            this.groupBox4.Location = new System.Drawing.Point(510, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 178);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "iChannel3";
            // 
            // glControl4
            // 
            this.glControl4.BackColor = System.Drawing.Color.Black;
            this.glControl4.Location = new System.Drawing.Point(6, 19);
            this.glControl4.Name = "glControl4";
            this.glControl4.Size = new System.Drawing.Size(150, 150);
            this.glControl4.TabIndex = 3;
            this.glControl4.VSync = false;
            this.glControl4.Load += new System.EventHandler(this.glControl_Load);
            this.glControl4.Click += new System.EventHandler(this.glControl_OnClick);
            this.glControl4.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl4.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.glControl5);
            this.groupBox5.Location = new System.Drawing.Point(679, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 178);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "iChannel4";
            // 
            // glControl5
            // 
            this.glControl5.BackColor = System.Drawing.Color.Black;
            this.glControl5.Location = new System.Drawing.Point(6, 19);
            this.glControl5.Name = "glControl5";
            this.glControl5.Size = new System.Drawing.Size(150, 150);
            this.glControl5.TabIndex = 4;
            this.glControl5.VSync = false;
            this.glControl5.Load += new System.EventHandler(this.glControl_Load);
            this.glControl5.Click += new System.EventHandler(this.glControl_OnClick);
            this.glControl5.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl5.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files|*.bmp;*.jpeg;*.jpg;*.gif;*.png;*.tiff;*.tif;*.exif";
            this.openFileDialog1.Multiselect = true;
            // 
            // TextureManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 574);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TextureManagerForm";
            this.Text = "Texture Manager";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private OpenTK.GLControl glControl1;
        private OpenTK.GLControl glControl3;
        private OpenTK.GLControl glControl4;
        private OpenTK.GLControl glControl5;
        private OpenTK.GLControl glControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}