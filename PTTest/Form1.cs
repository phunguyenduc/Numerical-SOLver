namespace PTTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomMotion();
        }
        private void CustomMotion()
        {
            panelmenu.Visible = false;
            panelmenu3.Visible = false;
            //neu them menu phai update
        }
        private Button _previouslyHighlightedButton;
        private Button _previouslyHighlightedButtonMenu;
        private void appearmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveButtonMenu(sender);
            appearmenu(panelmenu);
        }
        private void buttonmenu2_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void opensubform(Form subform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = subform;
            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            panelsubform.Controls.Add(subform);
            panelsubform.Tag = subform;
            subform.BringToFront();
            subform.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                Button currentButton = (Button)btnSender;

                // Disable the previously highlighted button
                DisableButton();
                // Highlight the current button
                currentButton.BackColor = Color.FromArgb(128, 0, 0); ; // Change to your desired highlight color
                currentButton.Font = new Font(currentButton.Font, FontStyle.Bold);

                // Update the reference to the currently highlighted button
                _previouslyHighlightedButton = currentButton;
            }
        }
        private void DisableButton()
        {
            if (_previouslyHighlightedButton != null)
            {
                _previouslyHighlightedButton.BackColor = Color.FromArgb(64, 64, 64);
                _previouslyHighlightedButton.Font = new Font(_previouslyHighlightedButton.Font, FontStyle.Regular);
                _previouslyHighlightedButton = null;
            }
        }
        private void ActiveButtonMenu(object btnSender)
        {
            if (btnSender != null)
            {
                Button currentButton = (Button)btnSender;

                // Disable the previously highlighted button
                DisableButtonMenu();

                // Highlight the current button
                currentButton.BackColor = Color.Red; // Change to your desired highlight color
                currentButton.Font = new Font(currentButton.Font, FontStyle.Bold);

                // Update the reference to the currently highlighted button
                _previouslyHighlightedButtonMenu = currentButton;
            }
        }
        private void DisableButtonMenu()
        {
            if (_previouslyHighlightedButtonMenu != null)
            {
                _previouslyHighlightedButtonMenu.BackColor = Color.Black;
                _previouslyHighlightedButtonMenu.Font = new Font(_previouslyHighlightedButtonMenu.Font, FontStyle.Regular);
                _previouslyHighlightedButtonMenu = null;
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void menumatrix_Click(object sender, EventArgs e)
        {
            ActiveButtonMenu(sender);
            appearmenu(panelmenu3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            opensubform(new GaussForm());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            opensubform(new JacobiForm());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void buttonTaskbar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender);
            opensubform(new JacobiForm());
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelsubform_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            opensubform(new NewtonForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            opensubform(new SplineInterpolationForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            opensubform(new RungeKuttaForm());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
