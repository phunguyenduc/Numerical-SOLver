using System;
using System.Drawing;
using System.Windows.Forms;
using NCalc; // Ensure you have the correct using directive

namespace PTTest
{
    public partial class RungeKuttaForm : Form
    {
        private TextBox textBoxFunction;
        private TextBox textBoxStepSize;
        private TextBox textBoxNumSteps;
        private TextBox textBoxInitialX;
        private TextBox textBoxInitialY;
        private const int textBoxSize = 40;
        private const int textBoxMargin = 5;
        private Button btnCalculate;

        public RungeKuttaForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // TextBox for function
            textBoxFunction = new TextBox
            {
                Size = new Size(200, textBoxSize),
                Location = new Point(150, 50),
                TabIndex = 0
            };
            textBoxFunction.KeyDown += TextBox_KeyDown;
            Controls.Add(textBoxFunction);
            Label labelFunction = new Label
            {
                Text = "Function dy/dx = f(x, y):",
                Location = new Point(20, 55)
            };
            Controls.Add(labelFunction);

            // TextBox for initial x value
            textBoxInitialX = new TextBox
            {
                Size = new Size(100, textBoxSize),
                Location = new Point(150, 100),
                TabIndex = 1
            };
            textBoxInitialX.KeyDown += TextBox_KeyDown;
            Controls.Add(textBoxInitialX);
            Label labelInitialX = new Label
            {
                Text = "Initial x:",
                Location = new Point(20, 105)
            };
            Controls.Add(labelInitialX);

            // TextBox for initial y value
            textBoxInitialY = new TextBox
            {
                Size = new Size(100, textBoxSize),
                Location = new Point(150, 150),
                TabIndex = 2
            };
            textBoxInitialY.KeyDown += TextBox_KeyDown;
            Controls.Add(textBoxInitialY);
            Label labelInitialY = new Label
            {
                Text = "Initial y:",
                Location = new Point(20, 155)
            };
            Controls.Add(labelInitialY);

            // TextBox for step size
            textBoxStepSize = new TextBox
            {
                Size = new Size(100, textBoxSize),
                Location = new Point(150, 200),
                TabIndex = 3
            };
            textBoxStepSize.KeyDown += TextBox_KeyDown;
            Controls.Add(textBoxStepSize);
            Label labelStepSize = new Label
            {
                Text = "Step Size:",
                Location = new Point(20, 205)
            };
            Controls.Add(labelStepSize);

            // TextBox for number of steps
            textBoxNumSteps = new TextBox
            {
                Size = new Size(100, textBoxSize),
                Location = new Point(150, 250),
                TabIndex = 4
            };
            textBoxNumSteps.KeyDown += TextBox_KeyDown;
            Controls.Add(textBoxNumSteps);
            Label labelNumSteps = new Label
            {
                Text = "Number of Steps:",
                Location = new Point(20, 255)
            };
            Controls.Add(labelNumSteps);

            // Calculate button
            btnCalculate = new Button
            {
                Location = new Point(100, 300),
                Size = new Size(80, 40),
                Text = "Calculate",
                TabIndex = 5
            };
            btnCalculate.Click += btnCalculate_Click;
            Controls.Add(btnCalculate);

            // Clear button
            Button btnClear = new Button
            {
                Location = new Point(200, 300),
                Size = new Size(80, 40),
                Text = "Clear",
                TabIndex = 6
            };
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);
        }

        private void RungeKuttaForm_Load(object sender, EventArgs e)
        {
            // Initialize form state or load data if necessary
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            textBoxFunction.Text = "";
            textBoxStepSize.Text = "";
            textBoxNumSteps.Text = "";
            textBoxInitialX.Text = "";
            textBoxInitialY.Text = "";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double stepSize = double.Parse(textBoxStepSize.Text);
                int numSteps = int.Parse(textBoxNumSteps.Text);
                double x0 = double.Parse(textBoxInitialX.Text);
                double y0 = double.Parse(textBoxInitialY.Text);
                string function = textBoxFunction.Text;

                // Initialize a string to accumulate the results
                string result = "x0\ty0\tyn\n------------------\n";
                result += $"{x0}\t{y0}\t-\n";

                // Variables to store the final x and y values
                double finalX = x0;
                double finalY = y0;

                // Runge-Kutta method
                for (int i = 1; i <= numSteps; i++)
                {
                    double k1 = stepSize * EvaluateFunction(function, finalX, finalY);
                    double k2 = stepSize * EvaluateFunction(function, finalX + stepSize / 2, finalY + k1 / 2);
                    double k3 = stepSize * EvaluateFunction(function, finalX + stepSize / 2, finalY + k2 / 2);
                    double k4 = stepSize * EvaluateFunction(function, finalX + stepSize, finalY + k3);
                    finalY = finalY + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    finalX = finalX + stepSize;

                    // Append the results to the string
                    result += $"{Math.Round(finalX, 6)}\t{Math.Round(finalY - (k1 + 2 * k2 + 2 * k3 + k4) / 6, 6)}\t{Math.Round(finalY, 6)}\n";
                }

                // Append the final result message
                result += $"Value of y at x = {Math.Round(finalX, 6)} is {Math.Round(finalY, 6)}";

                // Display the results in a message box
                MessageBox.Show(result, "Runge-Kutta Results");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private double EvaluateFunction(string function, double x, double y)
        {
            try
            {
                NCalc.Expression ncalcExpression = new NCalc.Expression(function);
                ncalcExpression.Parameters["x"] = x;
                ncalcExpression.Parameters["y"] = y;
                return Convert.ToDouble(ncalcExpression.Evaluate());
            }
            catch
            {
                throw new Exception("Failed to evaluate function.");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true; // Suppress the default beep
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, false, true, true, true);
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
