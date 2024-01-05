using System;
using System.Drawing;
using System.Windows.Forms;
using FakePowerPoint.Properties;

namespace FakePowerPoint
{
    using System;
    using System.Windows.Forms;

    namespace CoordinateDialog
    {
        public partial class CoordinatePopUp : Form
        {
            TextBox _xTextBox1, _yTextBox1, _xTextBox2, _yTextBox2;
            readonly Button _confirmButton = new();
            public Tuple<Point, Point> Coordinates { get; private set; }

            public CoordinatePopUp()
            {
                // InitializeComponent();
                InitializeUi();
            }

            void InitializeUi()
            {
                var tableLayoutPanel = new TableLayoutPanel();
                tableLayoutPanel.ColumnCount = 2;
                tableLayoutPanel.RowCount = 5;
                tableLayoutPanel.Dock = DockStyle.Fill;

                // Labels
                string[] labelNames = { "X1:", "Y1:", "X2:", "Y2:" };
                for (var i = 0; i < labelNames.Length; i++)
                {
                    var label = new Label();
                    label.Text = labelNames[i];
                    tableLayoutPanel.Controls.Add(label);
                }

                // Textboxes
                for (var i = 0; i < labelNames.Length; i++)
                {
                    var textBox = new TextBox();
                    tableLayoutPanel.Controls.Add(textBox);
                    if (i == 0) _xTextBox1 = textBox;
                    else if (i == 1) _yTextBox1 = textBox;
                    else if (i == 2) _xTextBox2 = textBox;
                    else _yTextBox2 = textBox;
                    textBox.TextChanged += TextBox_TextChanged;
                }

                // Buttons
                _confirmButton.Text = "Confirm";
                _confirmButton.Enabled = false;
                _confirmButton.Click += ConfirmButton_Click;

                var cancelButton = new Button();
                cancelButton.Text = "Cancel";
                cancelButton.Click += CancelButton_Click;

                tableLayoutPanel.Controls.Add(_confirmButton);
                tableLayoutPanel.Controls.Add(cancelButton);

                Controls.Add(tableLayoutPanel);
            }

            void ConfirmButton_Click(object sender, EventArgs e)
            {
                Coordinates = new Tuple<Point, Point>(new Point(int.Parse(_xTextBox1.Text), int.Parse(_yTextBox1.Text)),
                    new Point(int.Parse(_xTextBox2.Text), int.Parse(_yTextBox2.Text)));

                Close();
            }

            bool IsValidNumber(string text, bool isX = false)
            {
                var temp = new int();
                if (!int.TryParse(text, out temp)) return false;
                if (isX)
                {
                    return temp >= 0 && temp <= int.Parse(Resources.DEFAULT_SLIDE_WIDTH);
                }
                return temp >= 0 && temp <= int.Parse(Resources.DEFAULT_SLIDE_HEIGHT);
            }

            bool AreTextboxesValidNumbers()
            {
                return IsValidNumber(_xTextBox1.Text) && IsValidNumber(_yTextBox1.Text) &&
                       IsValidNumber(_xTextBox2.Text) && IsValidNumber(_yTextBox2.Text);
            }

            void TextBox_TextChanged(object sender, EventArgs e)
            {
                _confirmButton.Enabled = AreTextboxesValidNumbers();
            }

            void CancelButton_Click(object sender, EventArgs e)
            {
                // Close the dialog without performing any action
                Close();
            }
        }
    }
}
