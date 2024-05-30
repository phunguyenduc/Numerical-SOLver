using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PTTest
{
    public partial class Form1 : Form
    {
        private TextBox[,] matrixTextBoxes;
        private TextBox[] bTextBoxes;
        private TextBox[] xTextBoxes;

        public Form1()
        {
            InitializeComponent();
            CustomMotion();
        }

        private void CustomMotion()
        {
            panelmenu.Visible = false;
            panelmenu2.Visible = false;
        }

        private void appearmenu(Panel submenu)
        {
            submenu.Visible = !submenu.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any initialization logic
        }

        private void button1_Click(object sender, EventArgs e)
        {
            appearmenu(panelmenu);
        }

        private void buttonmenu2_Click(object sender, EventArgs e)
        {
            appearmenu(panelmenu2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Any logic for picture box click event
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint logic if needed
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            // Custom paint logic if needed
        }

        private void btnGenerateMatrix_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtMatrixSize.Text);

            // Clear previous TextBoxes if any
            if (matrixTextBoxes != null)
            {
                foreach (var tb in matrixTextBoxes)
                {
                    panelMatrix.Controls.Remove(tb);
                }
                foreach (var tb in bTextBoxes)
                {
                    panelMatrix.Controls.Remove(tb);
                }
                foreach (var tb in xTextBoxes)
                {
                    panelMatrix.Controls.Remove(tb);
                }
            }

            matrixTextBoxes = new TextBox[n, n];
            bTextBoxes = new TextBox[n];
            xTextBoxes = new TextBox[n];

            // Create TextBoxes for matrix 'a'
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox tb = new TextBox
                    {
                        Location = new System.Drawing.Point(j * 50, i * 25),
                        Size = new System.Drawing.Size(50, 25)
                    };
                    panelMatrix.Controls.Add(tb);
                    matrixTextBoxes[i, j] = tb;
                }
            }

            // Create TextBoxes for vector 'b'
            for (int i = 0; i < n; i++)
            {
                TextBox tbB = new TextBox
                {
                    Location = new System.Drawing.Point(n * 50 + 10, i * 25),
                    Size = new System.Drawing.Size(50, 25)
                };
                panelMatrix.Controls.Add(tbB);
                bTextBoxes[i] = tbB;
            }

            // Create TextBoxes for initial 'x'
            for (int i = 0; i < n; i++)
            {
                TextBox tbX = new TextBox
                {
                    Location = new System.Drawing.Point((n + 1) * 50 + 20, i * 25),
                    Size = new System.Drawing.Size(50, 25)
                };
                panelMatrix.Controls.Add(tbX);
                xTextBoxes[i] = tbX;
            }
        }

        private void btnGaussSeidel_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtMatrixSize.Text);
            int iterations = int.Parse(txtIterations.Text);

            float[,] aMatrix = new float[n, n];
            float[] a = new float[n * n];
            float[] b = new float[n];
            float[] x = new float[n];

            // Get values for matrix 'a' from TextBoxes
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aMatrix[i, j] = float.Parse(matrixTextBoxes[i, j].Text);
                    a[i * n + j] = aMatrix[i, j];
                }
            }

            // Get values for vector 'b'
            for (int i = 0; i < n; i++)
            {
                b[i] = float.Parse(bTextBoxes[i].Text);
            }

            // Get initial values for 'x'
            for (int i = 0; i < n; i++)
            {
                x[i] = float.Parse(xTextBoxes[i].Text);
            }

            // Prepare arguments for the C++ executable
            string arguments = $"{n} {iterations}";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arguments += $" {aMatrix[i, j]}";
                }
            }
            for (int i = 0; i < n; i++)
            {
                arguments += $" {b[i]}";
            }
            for (int i = 0; i < n; i++)
            {
                arguments += $" {x[i]}";
            }

            // Run the C++ executable
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "GaussSeidel.exe",
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        string[] results = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < n; i++)
                        {
                            x[i] = float.Parse(results[i]);
                        }
                    }
                }

                // Display final results in a MessageBox or appropriate control
                string output = "Final values of x:\n";
                for (int i = 0; i < n; i++)
                {
                    output += $"x{i + 1} = {x[i]:F6}\n";
                }
                MessageBox.Show(output, "Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running GaussSeidel.exe: {ex.Message}");
            }
        }
    }
}
