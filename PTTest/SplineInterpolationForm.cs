using System;
using System.Drawing;
using System.Windows.Forms;

namespace PTTest
{
    public partial class SplineInterpolationForm : Form
    {
        private TableLayoutPanel matrixTable;
        private TextBox textBoxXToInterpolate;
        private Button btnCalculate;
        private Button btnAddColumn;
        private Button btnRemoveColumn;
        private int columnCount = 4; // Initial number of columns

        public SplineInterpolationForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Initialize the matrix table
            matrixTable = new TableLayoutPanel
            {
                ColumnCount = columnCount,
                RowCount = 2,
                AutoSize = true,
                Location = new Point(20, 50)
            };
            for (int i = 0; i < columnCount; i++)
            {
                matrixTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                AddMatrixColumn(i);
            }
            Controls.Add(matrixTable);

            // TextBox for x value to interpolate
            //CreateLabel("Interpolate at x:", new Point(20, 200), 120);
            //textBoxXToInterpolate = CreateTextBox(new Point(150, 200), 40);

            // Add column button
            btnAddColumn = new Button
            {
                Location = new Point(100, 250),
                Size = new Size(80, 40),
                Text = "+"
            };
            btnAddColumn.Click += BtnAddColumn_Click;
            Controls.Add(btnAddColumn);

            // Remove column button
            btnRemoveColumn = new Button
            {
                Location = new Point(200, 250),
                Size = new Size(80, 40),
                Text = "-"
            };
            btnRemoveColumn.Click += BtnRemoveColumn_Click;
            Controls.Add(btnRemoveColumn);

            // Calculate button
            btnCalculate = new Button
            {
                Location = new Point(300, 250),
                Size = new Size(80, 40),
                Text = "Calculate"
            };
            btnCalculate.Click += btnCalculate_Click;
            Controls.Add(btnCalculate);

            // Clear button
            Button btnClear = new Button
            {
                Location = new Point(400, 250),
                Size = new Size(80, 40),
                Text = "Clear"
            };
            btnClear.Click += btnClear_Click;
            Controls.Add(btnClear);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Read values from matrixTable
                int n = matrixTable.ColumnCount;
                double[] x = new double[n];
                double[] f = new double[n];

                for (int i = 0; i < n; i++)
                {
                    x[i] = double.Parse(((TextBox)matrixTable.GetControlFromPosition(i, 0)).Text);
                    f[i] = double.Parse(((TextBox)matrixTable.GetControlFromPosition(i, 1)).Text);
                }

                // Perform cubic spline interpolation
                string result = ConstructNaturalCubicSpline(x, f);

                // Display the result
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnAddColumn_Click(object sender, EventArgs e)
        {
            matrixTable.ColumnCount++;
            AddMatrixColumn(matrixTable.ColumnCount - 1);
        }

        private void BtnRemoveColumn_Click(object sender, EventArgs e)
        {
            if (matrixTable.ColumnCount > 1)
            {
                matrixTable.Controls.RemoveAt(matrixTable.Controls.Count - 1);
                matrixTable.Controls.RemoveAt(matrixTable.Controls.Count - 1);
                matrixTable.ColumnCount--;
            }
        }

        private void AddMatrixColumn(int columnIndex)
        {
            TextBox xTextBox = CreateTextBox(new Point(0, 0), 40);
            TextBox fTextBox = CreateTextBox(new Point(0, 0), 40);

            matrixTable.Controls.Add(xTextBox, columnIndex, 0);
            matrixTable.Controls.Add(fTextBox, columnIndex, 1);
        }

        private TextBox CreateTextBox(Point location, int size)
        {
            TextBox textBox = new TextBox
            {
                Size = new Size(100, size),
                Location = location
            };
            this.Controls.Add(textBox);
            return textBox;
        }

        private void CreateLabel(string text, Point location, int size)
        {
            Label label = new Label
            {
                Size = new Size(size, 30),
                Text = text,
                Location = location
            };
            Controls.Add(label);
        }

        private void SplineInterpolationForm_Load(object sender, EventArgs e)
        {
            // Initialize form state or load data if necessary
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in matrixTable.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
            textBoxXToInterpolate.Text = "";
        }

        private string ConstructNaturalCubicSpline(double[] x, double[] f)
        {
            int n = x.Length;
            double[] h = new double[n - 1];
            double[] a = new double[n];
            double[] l = new double[n];
            double[] mu = new double[n];
            double[] z = new double[n];
            double[] c = new double[n];
            double[] b = new double[n - 1];
            double[] d = new double[n - 1];

            for (int i = 0; i < n; i++)
            {
                a[i] = f[i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
            }

            double[] alpha = new double[n - 1];
            for (int i = 1; i < n - 1; i++)
            {
                alpha[i] = (3 / h[i]) * (a[i + 1] - a[i]) - (3 / h[i - 1]) * (a[i] - a[i - 1]);
            }

            l[0] = 1;
            mu[0] = 0;
            z[0] = 0;

            for (int i = 1; i < n - 1; i++)
            {
                l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
                mu[i] = h[i] / l[i];
                z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
            }

            l[n - 1] = 1;
            z[n - 1] = 0;
            c[n - 1] = 0;

            for (int j = n - 2; j >= 0; j--)
            {
                c[j] = z[j] - mu[j] * c[j + 1];
                b[j] = (a[j + 1] - a[j]) / h[j] - h[j] * (c[j + 1] + 2 * c[j]) / 3;
                d[j] = (c[j + 1] - c[j]) / (3 * h[j]);
            }

            // Create a string to store the polynomials for each interval
            string polynomials = "";
            for (int i = 0; i < n - 1; i++)
            {
                polynomials += $"Interval [{x[i]}, {x[i + 1]}]:\n";
                polynomials += $"f(x) = {Math.Round(a[i], 5)} + {Math.Round(b[i], 5)}*(x - {x[i]}) + {Math.Round(c[i], 5)}*(x - {x[i]})^2 + {Math.Round(d[i], 5)}*(x - {x[i]})^3\n\n";
            }

            return polynomials;
        }
    }
}
