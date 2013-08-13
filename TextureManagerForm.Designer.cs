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
            this.mipMapCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.minFilterBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.texWrapRBox = new System.Windows.Forms.ComboBox();
            this.texWrapTBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.texWrapSBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // mipMapCheckBox
            // 
            this.mipMapCheckBox.AutoSize = true;
            this.mipMapCheckBox.Location = new System.Drawing.Point(6, 54);
            this.mipMapCheckBox.Name = "mipMapCheckBox";
            this.mipMapCheckBox.Size = new System.Drawing.Size(115, 17);
            this.mipMapCheckBox.TabIndex = 0;
            this.mipMapCheckBox.Text = "Generate Mipmaps";
            this.mipMapCheckBox.UseVisualStyleBackColor = true;
            this.mipMapCheckBox.CheckedChanged += new System.EventHandler(this.mipMapCheckBox_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.minFilterBox);
            this.groupBox6.Controls.Add(this.panel2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.fileName);
            this.groupBox6.Controls.Add(this.mipMapCheckBox);
            this.groupBox6.Location = new System.Drawing.Point(12, 407);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(855, 155);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Texture options";
            // 
            // minFilterBox
            // 
            this.minFilterBox.FormattingEnabled = true;
            this.minFilterBox.Items.AddRange(new object[] {
            "Nearest",
            "Linear",
            "Nearest Mipmap Nearest",
            "Linear Mipmap Nearest",
            "Nearest Mipmap Linear",
            "Linear Mipmap Linear"});
            this.minFilterBox.Location = new System.Drawing.Point(6, 109);
            this.minFilterBox.Name = "minFilterBox";
            this.minFilterBox.Size = new System.Drawing.Size(166, 21);
            this.minFilterBox.TabIndex = 1;
            this.minFilterBox.SelectionChangeCommitted += new System.EventHandler(this.minFilterBox_SelectionChangeCommitted);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.texWrapRBox);
            this.panel2.Controls.Add(this.texWrapTBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.texWrapSBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(192, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 140);
            this.panel2.TabIndex = 3;
            // 
            // texWrapRBox
            // 
            this.texWrapRBox.FormattingEnabled = true;
            this.texWrapRBox.Items.AddRange(new object[] {
            "Clamp",
            "Repeat",
            "ClampToBorder",
            "ClampToEdge",
            "MirroreredRepeat"});
            this.texWrapRBox.Location = new System.Drawing.Point(3, 100);
            this.texWrapRBox.Name = "texWrapRBox";
            this.texWrapRBox.Size = new System.Drawing.Size(163, 21);
            this.texWrapRBox.TabIndex = 9;
            this.texWrapRBox.SelectionChangeCommitted += new System.EventHandler(this.texWrapRBox_SelectionChangeCommitted);
            // 
            // texWrapTBox
            // 
            this.texWrapTBox.FormattingEnabled = true;
            this.texWrapTBox.Items.AddRange(new object[] {
            "Clamp",
            "Repeat",
            "ClampToBorder",
            "ClampToEdge",
            "MirroreredRepeat"});
            this.texWrapTBox.Location = new System.Drawing.Point(3, 60);
            this.texWrapTBox.Name = "texWrapTBox";
            this.texWrapTBox.Size = new System.Drawing.Size(163, 21);
            this.texWrapTBox.TabIndex = 8;
            this.texWrapTBox.SelectionChangeCommitted += new System.EventHandler(this.texWrapTBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Texture Wrap R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Texture Wrap T";
            // 
            // texWrapSBox
            // 
            this.texWrapSBox.FormattingEnabled = true;
            this.texWrapSBox.Items.AddRange(new object[] {
            "Clamp",
            "Repeat",
            "ClampToBorder",
            "ClampToEdge",
            "MirroreredRepeat"});
            this.texWrapSBox.Location = new System.Drawing.Point(3, 20);
            this.texWrapSBox.Name = "texWrapSBox";
            this.texWrapSBox.Size = new System.Drawing.Size(163, 21);
            this.texWrapSBox.TabIndex = 4;
            this.texWrapSBox.SelectionChangeCommitted += new System.EventHandler(this.texWrapSBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Texture Wrap S";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texture Min Filter";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(6, 19);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(166, 20);
            this.fileName.TabIndex = 1;
            this.fileName.Text = "Filename";
            this.fileName.Click += new System.EventHandler(this.fileName_Click);
            // 
            // TextureManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 574);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TextureManagerForm";
            this.Text = "Texture Manager";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.CheckBox mipMapCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox minFilterBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox texWrapSBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox texWrapRBox;
        private System.Windows.Forms.ComboBox texWrapTBox;
    }
}