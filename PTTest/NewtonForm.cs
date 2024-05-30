using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PTTest
{
    public partial class NewtonForm : Form
    {
        private int count = 1; // Initialize count to 1
        private List<TextBox> textBoxesX = new List<TextBox>();
        private List<TextBox> textBoxesY = new List<TextBox>();
        private TextBox textBoxValueToInterpolate;
        private const int textBoxSize = 40;
        private const int textBoxMargin = 5;
        private Button btnIncrease;
        private Button btnDecrease;
        private Button btnCalculate;
        //private Button btnCal;

        public NewtonForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            GenerateInputFields();
        }

        private void InitializeCustomComponents()
        {
            // Increase button
            btnIncrease = new Button
            {
                Location = new Point(100, 250),
                Size = new Size(40, 40),
                Text = "+"
            };
            btnIncrease.Click += btnIncrease_Click;
            Controls.Add(btnIncrease);

            // Decrease button
            btnDecrease = new Button
            {
                Location = new Point(150, 250),
                Size = new Size(40, 40),
                Text = "-"
            };
            btnDecrease.Click += btnDecrease_Click;
            Controls.Add(btnDecrease);

            // TextBox for value to interpolate
            textBoxValueToInterpolate = new TextBox
            {
                Size = new Size(100, textBoxSize),
                Location = new Point(100, 300)
            };
            Controls.Add(textBoxValueToInterpolate);
            Label labelValueToInterpolate = new Label
            {
                Text = "Value to Interpolate:",
                Location = new Point(20, 305)
            };
            Controls.Add(labelValueToInterpolate);

            // Calculate button
            btnCalculate = new Button
            {
                Location = new Point(100, 350),
                Size = new Size(80, 40),
                Text = "Calculate"
            };
            btnCalculate.Click += btnCalculate_Click;
            Controls.Add(btnCalculate);

            // CAL button

            // Clear button
            Button btnClear = new Button
            {
                Location = new Point(100, 400),
                Size = new Size(80, 40),
                Text = "Clear"
            };
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);
        }

        private void GenerateInputFields()
        {
            // Clear existing text boxes
            foreach (var textBox in textBoxesX)
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }
            textBoxesX.Clear();

            foreach (var textBox in textBoxesY)
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }
            textBoxesY.Clear();

            // Create new text boxes for x and y values
            for (int i = 0; i < count; i++)
            {
                TextBox textBoxX = new TextBox
                {
                    Size = new Size(textBoxSize, textBoxSize),
                    Location = new Point(200 + i * (textBoxSize + textBoxMargin), 100)
                };
                textBoxesX.Add(textBoxX);
                Controls.Add(textBoxX);

                TextBox textBoxY = new TextBox
                {
                    Size = new Size(textBoxSize, textBoxSize),
                    Location = new Point(200 + i * (textBoxSize + textBoxMargin), 150)
                };
                textBoxesY.Add(textBoxY);
                Controls.Add(textBoxY);
            }
            //LABEL X
            Label labelX = new Label
            {
                Text = "x values:",
                Location = new Point(80, 105)
            };
            Controls.Add(labelX);
            //LABEL Y
            Label labelY = new Label
            {
                Text = "y values:",
                Location = new Point(80, 155)
            };
            Controls.Add(labelY);
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            count++;
            GenerateInputFields();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (count > 1)
            {
                count--;
                GenerateInputFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear x textboxes
            foreach (var textBox in textBoxesX)
            {
                textBox.Text = "";
            }

            // Clear y textboxes
            foreach (var textBox in textBoxesY)
            {
                textBox.Text = "";
            }

            // Clear value to interpolate textbox
            textBoxValueToInterpolate.Text = "";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int n = count;
            double[] x = new double[n];
            double[] y = new double[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = double.Parse(textBoxesX[i].Text);
                y[i] = double.Parse(textBoxesY[i].Text);
            }

            // Calculating the forward difference table
            double[,] diff = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                diff[i, 0] = y[i];
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    diff[j, i] = diff[j + 1, i - 1] - diff[j, i - 1];
                }
            }

            // Displaying the forward difference table in the console (optional)
            Console.WriteLine("\nDifference Table:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(diff[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Value to interpolate at
            double value = double.Parse(textBoxValueToInterpolate.Text);

            // Initializing u and sum
            double sum = diff[0, 0];
            double u = (value - x[0]) / (x[1] - x[0]);
            for (int i = 1; i < n; i++)
            {
                sum = sum + (u_cal(u, i) * diff[0, i]) / fact(i);
            }

            MessageBox.Show($"Value at {value} is {Math.Round(sum, 6)}");
        }

        // Function to calculate factorial
        private static int fact(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }

        // Function to calculate u term
        private static double u_cal(double u, int n)
        {
            double temp = u;
            for (int i = 1; i < n; i++)
            {
                temp = temp * (u - i);
            }
            return temp;
        }

        // Add the NewtonForm_Load method
        private void NewtonForm_Load(object sender, EventArgs e)
        {
            // You can add any initialization code here if needed
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control focusedControl = ActiveControl;
            if (focusedControl is TextBox && textBoxesX.Contains((TextBox)focusedControl))
            {
                int index = textBoxesX.IndexOf((TextBox)focusedControl);

                switch (keyData)
                {
                    case Keys.Up:
                        if (index > 0)
                            textBoxesX[index - 1].Focus();
                        return true;

                    case Keys.Down:
                        if (index < count - 1)
                            textBoxesX[index + 1].Focus();
                        return true;

                    case Keys.Left:
                        if (index > 0)
                            textBoxesX[index - 1].Focus();
                        return true;

                    case Keys.Right:
                        if (index < count - 1)
                            textBoxesX[index + 1].Focus();
                        return true;
                }
            }
            else if (focusedControl is TextBox && textBoxesY.Contains((TextBox)focusedControl))
            {
                int index = textBoxesY.IndexOf((TextBox)focusedControl);

                switch (keyData)
                {
                    case Keys.Up:
                        if (index > 0)
                            textBoxesY[index - 1].Focus();
                        return true;
                    case Keys.Down:
                        if (index < count - 1)
                            textBoxesY[index + 1].Focus();
                        return true;

                    case Keys.Left:
                        if (index > 0)
                            textBoxesY[index - 1].Focus();
                        return true;

                    case Keys.Right:
                        if (index < count - 1)
                            textBoxesY[index + 1].Focus();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}