using System;
using System.Windows.Forms;
using CalculatorLibrary;
namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        TextBox textBox1, textBox2;
        Label labelResult;
        Button btnAdd, btnSubtract, btnMultiply, btnDivide;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            textBox1 = new TextBox { Left = 10, Top = 10, Width = 150, PlaceholderText = "First number", Font = new System.Drawing.Font("Arial", 12) };
            textBox2 = new TextBox { Left = 10, Top = 40, Width = 150, PlaceholderText = "Second number", Font = new System.Drawing.Font("Arial", 12) };
            labelResult = new Label { Left = 10, Top = 70, Width = 200, Text = "Result: ", Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold) };

            btnAdd = new Button { Text = "+", Left = 220, Top = 10, Width = 50, Height = 50, BackColor = System.Drawing.Color.LightGreen, Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold) };
            btnSubtract = new Button { Text = "-", Left = 220, Top = 60, Width = 50, Height = 50, BackColor = System.Drawing.Color.LightBlue, Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold) };
            btnMultiply = new Button { Text = "*", Left = 220, Top = 110, Width = 50, Height = 50, BackColor = System.Drawing.Color.LightYellow, Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold) };
            btnDivide = new Button { Text = "/", Left = 220, Top = 160, Width = 50, Height = 50, BackColor = System.Drawing.Color.LightPink, Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold) };
            btnAdd.Click += (s, e) => PerformOperation("add");
            btnSubtract.Click += (s, e) => PerformOperation("sub");
            btnMultiply.Click += (s, e) => PerformOperation("mul");
            btnDivide.Click += (s, e) => PerformOperation("div");

            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(labelResult);
            Controls.Add(btnAdd);
            Controls.Add(btnSubtract);
            Controls.Add(btnMultiply);
            Controls.Add(btnDivide);
        }

        private void PerformOperation(string op)
        {
            Calculator calc = new Calculator();
            double a, b;

            if (!double.TryParse(textBox1.Text, out a) || !double.TryParse(textBox2.Text, out b))
            {
                labelResult.Text = "Error: Please enter valid numbers!";
                return;
            }

            try
            {
                double result = op switch
                {
                    "add" => calc.Add(a, b),
                    "sub" => calc.Subtract(a, b),
                    "mul" => calc.Multiply(a, b),
                    "div" => calc.Divide(a, b),
                    _ => 0
                };
                labelResult.Text = "Result: " + result;
            }
            catch (DivideByZeroException)
            {
                labelResult.Text = "Can't divide by zero!";
            }
        }
    }
}