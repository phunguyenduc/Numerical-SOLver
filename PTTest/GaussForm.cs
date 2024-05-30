using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PTTest
{
    public partial class GaussForm : Form
    {
        private int count = 1; // Initialize count to 1
        private int click = 0;
        private List<TextBox> textBoxesMatrix = new List<TextBox>();
        private List<TextBox> textBoxesColumn = new List<TextBox>();
        private List<TextBox> textBoxesInitialX = new List<TextBox>();
        private TextBox textBoxIterations;
        private const int textBoxSize = 40;
        private const int textBoxMargin = 5;
        private Button btnIncrease;
        private Button btnDecrease;
        private Button btnCalculate;
        private Button btnClear;
        private DataGridView resultsGridView;

        public GaussForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            GenerateMatrix();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            // Initialize DataGridView
            this.resultsGridView = new DataGridView();
            this.resultsGridView.Location = new Point(0, 400);
<<<<<<< HEAD
            this.resultsGridView.Size = new Size(1000, 450);
=======
            this.resultsGridView.Size = new Size(800, 450);
>>>>>>> 10b2366 (fix some bugs)
            this.resultsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.resultsGridView.DefaultCellStyle.ForeColor = Color.Black;
            this.Controls.Add(this.resultsGridView);
        }
        private void InitializeCustomComponents()
        {
            // Increase button
            this.btnIncrease = new Button();
            this.btnIncrease.Location = new Point(100, 70);
            this.btnIncrease.Size = new Size(40, 40);
            this.btnIncrease.Text = "+";
            this.btnIncrease.Click += new EventHandler(this.btnIncrease_Click);
            this.Controls.Add(this.btnIncrease);

            // Decrease button
            this.btnDecrease = new Button();
            this.btnDecrease.Location = new Point(100, 120);
            this.btnDecrease.Size = new Size(40, 40);
            this.btnDecrease.Text = "-";
            this.btnDecrease.Click += new EventHandler(this.btnDecrease_Click);
            this.Controls.Add(this.btnDecrease);

            // Calculate button
            this.btnCalculate = new Button();
            this.btnCalculate.Location = new Point(80, 250);
            this.btnCalculate.Size = new Size(80, 40);
            this.btnCalculate.Text = "CAL";
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);
            this.Controls.Add(this.btnCalculate);

            // Insert 1
            this.btnIncrease = new Button();
            this.btnIncrease.Location = new Point(180, 300);
            this.btnIncrease.Size = new Size(80, 40);
            this.btnIncrease.Text = "Insert A";
            this.btnIncrease.Click += new EventHandler(this.button1_Click);
            this.Controls.Add(this.btnIncrease);

            // Insert 2
            this.btnIncrease = new Button();
            this.btnIncrease.Location = new Point(280, 300);
            this.btnIncrease.Size = new Size(80, 40);
            this.btnIncrease.Text = "Insert B";
<<<<<<< HEAD
            this.btnIncrease.Click += new EventHandler(this.button1_Click);
=======
            this.btnIncrease.Click += new EventHandler(this.button2_Click);
>>>>>>> 10b2366 (fix some bugs)
            this.Controls.Add(this.btnIncrease);

            // Insert 3
            this.btnIncrease = new Button();
            this.btnIncrease.Location = new Point(380, 300);
            this.btnIncrease.Size = new Size(80, 40);
            this.btnIncrease.Text = "Insert X";
<<<<<<< HEAD
            this.btnIncrease.Click += new EventHandler(this.button1_Click);
=======
            this.btnIncrease.Click += new EventHandler(this.button3_Click);
>>>>>>> 10b2366 (fix some bugs)
            this.Controls.Add(this.btnIncrease);
            // Clear button
            Button btnClear = new Button();
            btnClear.Location = new Point(80, 300);
            btnClear.Size = new Size(80, 40);
            btnClear.Text = "Clear";
            btnClear.Click += new EventHandler(this.btnClear_Click);
            this.Controls.Add(btnClear);

            // TextBox for iterations
            this.textBoxIterations = new TextBox();
            this.textBoxIterations.Size = new Size(textBoxSize, textBoxSize);
            this.textBoxIterations.Location = new Point(100, 197);
            this.Controls.Add(this.textBoxIterations);
            Label labelIterations = new Label();
            labelIterations.Text = "Iterations";
            labelIterations.Location = new Point(40, 200);
            this.Controls.Add(labelIterations);
        }

        private void GenerateMatrix()
        {
            // Clear existing text boxes in the mxm matrix
            foreach (var textBox in textBoxesMatrix)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }
            textBoxesMatrix.Clear();

            // Clear existing text boxes in the mx1 matrix
            foreach (var textBox in textBoxesColumn)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }
            textBoxesColumn.Clear();

            // Clear existing text boxes for initial x values
            foreach (var textBox in textBoxesInitialX)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }
            textBoxesInitialX.Clear();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Size = new Size(textBoxSize, textBoxSize);
                    textBox.Location = new Point(170 + j * (textBoxSize + textBoxMargin), 70 + i * (textBoxSize + textBoxMargin));
                    textBoxesMatrix.Add(textBox);
                    this.Controls.Add(textBox);
                }
            }

            for (int i = 0; i < count; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(textBoxSize, textBoxSize);
                textBox.Location = new Point(170 + count * (textBoxSize + textBoxMargin) + 30, 70 + i * (textBoxSize + textBoxMargin)); // Add extra margin to separate mx1 from mxm
                textBoxesColumn.Add(textBox);
                this.Controls.Add(textBox);
            }

            for (int i = 0; i < count; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Size = new Size(textBoxSize, textBoxSize);
                textBox.Location = new Point(170 + count * (textBoxSize + textBoxMargin) + 100, 70 + i * (textBoxSize + textBoxMargin)); // Add extra margin to separate x0 from b
                textBoxesInitialX.Add(textBox);
                this.Controls.Add(textBox);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Mở một hộp thoại chọn tệp
            click++;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tệp ảnh đã chọn
                string sourceFilePath = openFileDialog.FileName;

                try
                {
                    // Lấy đường dẫn thư mục chứa ứng dụng
                    string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Tạo đường dẫn đích mới
                    string destinationFolderPath = Path.Combine(appFolderPath);

                    // Đảm bảo thư mục đích tồn tại
                    if (!Directory.Exists(destinationFolderPath))
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                    }

                    // Tạo đường dẫn đầy đủ cho tệp ảnh trong thư mục đích với tên là "test1.jpg"
<<<<<<< HEAD
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test1.jpg");
=======
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test.jpg");
>>>>>>> 10b2366 (fix some bugs)

                    // Chuyển tệp ảnh
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex) { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Mở một hộp thoại chọn tệp
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tệp ảnh đã chọn
                string sourceFilePath = openFileDialog.FileName;

                try
                {
                    // Lấy đường dẫn thư mục chứa ứng dụng
                    string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Tạo đường dẫn đích mới
                    string destinationFolderPath = Path.Combine(appFolderPath);

                    // Đảm bảo thư mục đích tồn tại
                    if (!Directory.Exists(destinationFolderPath))
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                    }

                    // Tạo đường dẫn đầy đủ cho tệp ảnh trong thư mục đích với tên là "test1.jpg"
<<<<<<< HEAD
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test1.jpg");
=======
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test2.jpg");
>>>>>>> 10b2366 (fix some bugs)

                    // Chuyển tệp ảnh
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex) { }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Mở một hộp thoại chọn tệp
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tệp ảnh đã chọn
                string sourceFilePath = openFileDialog.FileName;

                try
                {
                    // Lấy đường dẫn thư mục chứa ứng dụng
                    string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Tạo đường dẫn đích mới
                    string destinationFolderPath = Path.Combine(appFolderPath);

                    // Đảm bảo thư mục đích tồn tại
                    if (!Directory.Exists(destinationFolderPath))
                    {
                        Directory.CreateDirectory(destinationFolderPath);
                    }

                    // Tạo đường dẫn đầy đủ cho tệp ảnh trong thư mục đích với tên là "test1.jpg"
<<<<<<< HEAD
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test1.jpg");
=======
                    string destinationFilePath = Path.Combine(destinationFolderPath, "test3.jpg");
>>>>>>> 10b2366 (fix some bugs)

                    // Chuyển tệp ảnh
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
                catch (Exception ex) { }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear matrix textboxes
            foreach (var textBox in textBoxesMatrix)
            {
                textBox.Text = "";
            }

            // Clear column textboxes
            foreach (var textBox in textBoxesColumn)
            {
                textBox.Text = "";
            }

            // Clear initial x textboxes
            foreach (var textBox in textBoxesInitialX)
            {
                textBox.Text = "";
            }

            // Clear tolerable error textbox
            textBoxIterations.Text = "";
        }


        private void btnIncrease_Click(object sender, EventArgs e)
        {
            count++;
            GenerateMatrix();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (count > 1)
            {
                count--;
                GenerateMatrix();
            }
            else
            {
                count = 1;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float[,] a = new float[count, count];
            float[] b = new float[count];
            float[] x = new float[count];
            int iterations = 100; // Default number of iterations
            if (click == 0)
            {
                try
                {
                    // Read matrix coefficients from textboxes
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            a[i, j] = float.Parse(textBoxesMatrix[i * count + j].Text);
                        }
                    }

                    // Read column vector from textboxes
                    for (int i = 0; i < count; i++)
                    {
                        b[i] = float.Parse(textBoxesColumn[i].Text);
                    }

                    // Read initial values of x
                    for (int i = 0; i < count; i++)
                    {
                        x[i] = float.Parse(textBoxesInitialX[i].Text);
                    }

                    // Read the number of iterations
                    iterations = int.Parse(textBoxIterations.Text);
                    // Prepare DataGridView columns
                    resultsGridView.Columns.Clear();
                    resultsGridView.Columns.Add("Iteration", "Iteration");
                    for (int i = 0; i < count; i++)
                    {
                        resultsGridView.Columns.Add($"x{i + 1}", $"x{i + 1}");
                    }
                    // StringBuilder to accumulate the results
                    StringBuilder results = new StringBuilder();

                    // Gauss-Seidel Iteration
                    for (int m = 0; m < iterations; m++)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            float sum = b[i];
                            for (int j = 0; j < count; j++)
                            {
                                if (i != j)
                                {
                                    sum -= a[i, j] * x[j];
                                }
                            }
                            x[i] = sum / a[i, i];
                        }

                        var row = new object[count + 1];
                        row[0] = m + 1;
                        for (int i = 0; i < count; i++)
                        {
                            row[i + 1] = x[i].ToString("F6");
                        }
                        resultsGridView.Rows.Add(row);

                        // Append current iteration results to StringBuilder
                        results.Append($"Iteration {m + 1}: ");
                        for (int i = 0; i < count; i++)
                        {
                            results.Append($"x{i + 1} = {x[i]:F6}    ");
                        }
                        results.AppendLine();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid numbers in all text boxes.", "Input Error");
                }
            }
            else
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.RedirectStandardInput = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    // Step 2: Start the process
                    using (Process process = new Process())
                    {
                        process.StartInfo = startInfo;
                        process.Start();

                        // Step 3: Write commands to the standard input of the process
                        using (StreamWriter sw = process.StandardInput)
                        {
                            if (sw.BaseStream.CanWrite)
                            {
                                sw.WriteLine("start py launch.py\r\nstart py launch2.py\r\nstart py launch3.py\r\n");
                            }
                        }
                        Task.Delay(10000).Wait();


                        // Step 3: Define the path to the CSV file outputted by demo.py
                        string csvFilePath = @"output.csv";
                        string[] csvLines = File.ReadAllLines(csvFilePath);
                        int count = (int)Math.Sqrt(csvLines.Length);

                        string csvFilePath2 = @"output2.csv";
                        string[] csvLines2 = File.ReadAllLines(csvFilePath2);


                        string csvFilePath3 = @"output3.csv";
                        string[] csvLines3 = File.ReadAllLines(csvFilePath3);
                        int index = 0;
                        // Read matrix coefficients from CSV file
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count; j++)
                            {
                                // Convert string to float and then parse it to a[i,j]
                                if (float.TryParse(csvLines[index++], out float floatValue))
                                {
                                    a[i, j] = floatValue;
                                }
                            }
                        }
                        int index2 = 0;
                        // Read column vector from textboxes
                        for (int i = 0; i < count; i++)
                        {
                            if (float.TryParse(csvLines2[index2++], out float floatValue2))
                            {
                                b[i] = floatValue2;
                            }
                        }
                        int index3 = 0;
                        // Read initial values of x
                        for (int i = 0; i < count; i++)
                        {
                            if (float.TryParse(csvLines3[index3++], out float floatValue3))
                            {
                                x[i] = floatValue3;
                            }
                        }

                        // Read the number of iterations
                        iterations = int.Parse(textBoxIterations.Text);
                        // Prepare DataGridView columns
                        resultsGridView.Columns.Clear();
                        resultsGridView.Columns.Add("Iteration", "Iteration");
                        for (int i = 0; i < count; i++)
                        {
                            resultsGridView.Columns.Add($"x{i + 1}", $"x{i + 1}");
                        }
                        // StringBuilder to accumulate the results
                        StringBuilder results = new StringBuilder();

                        // Gauss-Seidel Iteration
                        for (int m = 0; m < iterations; m++)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                float sum = b[i];
                                for (int j = 0; j < count; j++)
                                {
                                    if (i != j)
                                    {
                                        sum -= a[i, j] * x[j];
                                    }
                                }
                                x[i] = sum / a[i, i];
                            }

                            var row = new object[count + 1];
                            row[0] = m + 1;
                            for (int i = 0; i < count; i++)
                            {
                                row[i + 1] = x[i].ToString("F6");
                            }
                            resultsGridView.Rows.Add(row);

                            // Append current iteration results to StringBuilder
                            results.Append($"Iteration {m + 1}: ");
                            for (int i = 0; i < count; i++)
                            {
                                results.Append($"x{i + 1} = {x[i]:F6}    ");
                            }
                            results.AppendLine();
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid numbers in all text boxes.", "Input Error");
                }
            }
        } 

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control focusedControl = this.ActiveControl;
            if (focusedControl is TextBox && textBoxesMatrix.Contains((TextBox)focusedControl))
            {
                int index = textBoxesMatrix.IndexOf((TextBox)focusedControl);
                int row = index / count;
                int col = index % count;

                switch (keyData)
                {
                    case Keys.Up:
                        if (row > 0)
                            textBoxesMatrix[(row - 1) * count + col].Focus();
                        return true;

                    case Keys.Down:
                        if (row < count - 1)
                            textBoxesMatrix[(row + 1) * count + col].Focus();
                        return true;

                    case Keys.Left:
                        if (col > 0)
                            textBoxesMatrix[row * count + (col - 1)].Focus();
                        return true;

                    case Keys.Right:
                        if (col < count - 1)
                            textBoxesMatrix[row * count + (col + 1)].Focus();
                        return true;
                }
            }
            else if (focusedControl is TextBox && textBoxesColumn.Contains((TextBox)focusedControl))
            {
                int index = textBoxesColumn.IndexOf((TextBox)focusedControl);

                switch (keyData)
                {
                    case Keys.Up:
                        if (index > 0)
                            textBoxesColumn[index - 1].Focus();
                        return true;

                    case Keys.Down:
                        if (index < count - 1)
                            textBoxesColumn[index + 1].Focus();
                        return true;
                }
            }
            else if (focusedControl is TextBox && textBoxesInitialX.Contains((TextBox)focusedControl))
            {
                int index = textBoxesInitialX.IndexOf((TextBox)focusedControl);

                switch (keyData)
                {
                    case Keys.Up:
                        if (index > 0)
                            textBoxesInitialX[index - 1].Focus();
                        return true;

                    case Keys.Down:
                        if (index < count - 1)
                            textBoxesInitialX[index + 1].Focus();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GaussForm_Load(object sender, EventArgs e)
        {

        }
    }
}
