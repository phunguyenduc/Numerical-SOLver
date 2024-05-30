namespace PTTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel2 = new Panel();
            panelmenu3 = new Panel();
            button10 = new Button();
            button7 = new Button();
            menumatrix = new Button();
            panelmenu = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelsubform = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            buttonTaskbar = new Button();
            buttonMaximize = new Button();
            buttonClose = new Button();
            panel2.SuspendLayout();
            panelmenu3.SuspendLayout();
            panelmenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelsubform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(panelmenu3);
            panel2.Controls.Add(menumatrix);
            panel2.Controls.Add(panelmenu);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(panelLogo);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 610);
            panel2.TabIndex = 1;
            // 
            // panelmenu3
            // 
            panelmenu3.Controls.Add(button10);
            panelmenu3.Controls.Add(button7);
            panelmenu3.Dock = DockStyle.Top;
            panelmenu3.Location = new Point(0, 415);
            panelmenu3.Margin = new Padding(3, 2, 3, 2);
            panelmenu3.Name = "panelmenu3";
            panelmenu3.Size = new Size(251, 95);
            panelmenu3.TabIndex = 4;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(64, 64, 64);
            button10.Dock = DockStyle.Top;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.ForeColor = SystemColors.ControlLightLight;
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(0, 46);
            button10.Name = "button10";
            button10.Padding = new Padding(30, 0, 0, 0);
            button10.Size = new Size(251, 46);
            button10.TabIndex = 2;
            button10.Text = "   Jacobi";
            button10.TextImageRelation = TextImageRelation.ImageBeforeText;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click_1;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(64, 64, 64);
            button7.Dock = DockStyle.Top;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(0, 0);
            button7.Name = "button7";
            button7.Padding = new Padding(30, 0, 0, 0);
            button7.Size = new Size(251, 46);
            button7.TabIndex = 1;
            button7.Text = "   Gauss - Seidel";
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // menumatrix
            // 
            menumatrix.Dock = DockStyle.Top;
            menumatrix.FlatAppearance.BorderSize = 0;
            menumatrix.FlatStyle = FlatStyle.Flat;
            menumatrix.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            menumatrix.ForeColor = SystemColors.ButtonFace;
            menumatrix.Image = (Image)resources.GetObject("menumatrix.Image");
            menumatrix.ImageAlign = ContentAlignment.MiddleLeft;
            menumatrix.Location = new Point(0, 358);
            menumatrix.Margin = new Padding(3, 2, 3, 2);
            menumatrix.Name = "menumatrix";
            menumatrix.Padding = new Padding(18, 0, 0, 0);
            menumatrix.Size = new Size(251, 57);
            menumatrix.TabIndex = 3;
            menumatrix.Text = "  Matrix Menu";
            menumatrix.TextAlign = ContentAlignment.MiddleLeft;
            menumatrix.TextImageRelation = TextImageRelation.ImageBeforeText;
            menumatrix.UseVisualStyleBackColor = true;
            menumatrix.Click += menumatrix_Click;
            // 
            // panelmenu
            // 
            panelmenu.BackColor = Color.FromArgb(224, 224, 224);
            panelmenu.Controls.Add(button4);
            panelmenu.Controls.Add(button3);
            panelmenu.Controls.Add(button2);
            panelmenu.Dock = DockStyle.Top;
            panelmenu.Location = new Point(0, 220);
            panelmenu.Name = "panelmenu";
            panelmenu.Size = new Size(251, 138);
            panelmenu.TabIndex = 2;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(64, 64, 64);
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(0, 92);
            button4.Name = "button4";
            button4.Padding = new Padding(30, 0, 0, 0);
            button4.Size = new Size(251, 46);
            button4.TabIndex = 4;
            button4.Text = "   Spline Interpolation";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(64, 64, 64);
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 46);
            button3.Name = "button3";
            button3.Padding = new Padding(30, 0, 0, 0);
            button3.Size = new Size(251, 46);
            button3.TabIndex = 3;
            button3.Text = "   RungeKutta";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(30, 0, 0, 0);
            button2.Size = new Size(251, 46);
            button2.TabIndex = 2;
            button2.Text = "   Newton";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 163);
            button1.Name = "button1";
            button1.Padding = new Padding(20, 0, 0, 0);
            button1.Size = new Size(251, 57);
            button1.TabIndex = 1;
            button1.Text = "  Function Menu";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.Black;
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(251, 163);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label4
            // 
<<<<<<< HEAD
=======
            label4.Anchor = AnchorStyles.None;
>>>>>>> 10b2366 (fix some bugs)
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Script", 9.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(257, 446);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 6;
            label4.Text = "21021624";
            // 
            // label3
            // 
<<<<<<< HEAD
=======
            label3.Anchor = AnchorStyles.None;
>>>>>>> 10b2366 (fix some bugs)
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Script", 9.75F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(494, 446);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 5;
            label3.Text = "21020703";
            // 
            // label2
            // 
<<<<<<< HEAD
=======
            label2.Anchor = AnchorStyles.None;
>>>>>>> 10b2366 (fix some bugs)
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Script", 9.75F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(374, 446);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 2;
            label2.Text = "21021646";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ControlDark;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(251, 610);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(801, 0);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // panelsubform
            // 
            panelsubform.BackColor = Color.FromArgb(64, 64, 64);
            panelsubform.Controls.Add(label3);
            panelsubform.Controls.Add(label2);
            panelsubform.Controls.Add(label4);
            panelsubform.Controls.Add(label1);
            panelsubform.Controls.Add(pictureBox2);
            panelsubform.Dock = DockStyle.Fill;
            panelsubform.Location = new Point(251, 0);
            panelsubform.Name = "panelsubform";
            panelsubform.Size = new Size(801, 610);
            panelsubform.TabIndex = 5;
            panelsubform.Paint += panelsubform_Paint;
            // 
            // label1
            // 
<<<<<<< HEAD
=======
            label1.Anchor = AnchorStyles.None;
>>>>>>> 10b2366 (fix some bugs)
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 26.25F, FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(328, 389);
            label1.Name = "label1";
            label1.Size = new Size(187, 57);
            label1.TabIndex = 1;
            label1.Text = "LEMONS";
            label1.Click += label1_Click;
            // 
            // pictureBox2
            // 
<<<<<<< HEAD
=======
            pictureBox2.Anchor = AnchorStyles.None;
>>>>>>> 10b2366 (fix some bugs)
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(257, 163);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(318, 271);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Controls.Add(buttonTaskbar);
            panel1.Controls.Add(buttonMaximize);
            panel1.Controls.Add(buttonClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(251, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 26);
            panel1.TabIndex = 6;
            // 
            // buttonTaskbar
            // 
            buttonTaskbar.Dock = DockStyle.Right;
            buttonTaskbar.FlatAppearance.BorderSize = 0;
            buttonTaskbar.FlatStyle = FlatStyle.Flat;
            buttonTaskbar.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTaskbar.ForeColor = SystemColors.ButtonFace;
            buttonTaskbar.Image = (Image)resources.GetObject("buttonTaskbar.Image");
            buttonTaskbar.Location = new Point(723, 0);
            buttonTaskbar.Name = "buttonTaskbar";
            buttonTaskbar.Size = new Size(26, 26);
            buttonTaskbar.TabIndex = 2;
            buttonTaskbar.UseVisualStyleBackColor = true;
            buttonTaskbar.Click += buttonTaskbar_Click;
            // 
            // buttonMaximize
            // 
            buttonMaximize.Dock = DockStyle.Right;
            buttonMaximize.FlatAppearance.BorderSize = 0;
            buttonMaximize.FlatStyle = FlatStyle.Flat;
            buttonMaximize.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonMaximize.ForeColor = SystemColors.ButtonFace;
            buttonMaximize.Image = (Image)resources.GetObject("buttonMaximize.Image");
            buttonMaximize.Location = new Point(749, 0);
            buttonMaximize.Name = "buttonMaximize";
            buttonMaximize.Size = new Size(26, 26);
            buttonMaximize.TabIndex = 1;
            buttonMaximize.UseVisualStyleBackColor = true;
            buttonMaximize.Click += buttonMaximize_Click;
            // 
            // buttonClose
            // 
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = SystemColors.ButtonFace;
            buttonClose.Image = (Image)resources.GetObject("buttonClose.Image");
            buttonClose.Location = new Point(775, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(26, 26);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(1052, 610);
            Controls.Add(panel1);
            Controls.Add(panelsubform);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1052, 610);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel2.ResumeLayout(false);
            panelmenu3.ResumeLayout(false);
            panelmenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelsubform.ResumeLayout(false);
            panelsubform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panelmenu;
        private Button button1;
        private Panel panelLogo;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelsubform;
        private Panel panelmenu3;
        private Button menumatrix;
        private Button button7;
        private Panel panel1;
        private Button buttonClose;
        private Button buttonTaskbar;
        private Button buttonMaximize;
        private Button button10;
        private Button button4;
        private Button button3;
        private Button button2;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
