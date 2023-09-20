using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023F_WindowApplicationDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _model = new Model();
        }

        private void BTN_0_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("0");
        }


        private void BTN_1_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("1");
        }

        // do the same for BTN_2 to BTN_9 buttons ignore havent been hooked

        private void BTN_2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("2");
        }

        private void BTN_3_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("3");
        }

        private void BTN_4_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("4");
        }

        private void BTN_5_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("5");
        }

        private void BTN_6_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("6");
        }

        private void BTN_7_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("7");
        }

        private void BTN_8_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("8");
        }

        private void BTN_9_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand("9");
        }

        private void BTN_dot_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AppendOperand(".");
        }

        private void BTN_plus_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.SetOperator("+");
        }

        private void BTN_minus_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.SetOperator("-");
        }

        private void BTN_multiply_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.SetOperator("X");
        }

        private void BTN_div_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.SetOperator("/");
        }

        private void BTN_equal_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.Calculate();
        }

        private void BTN_C_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.Clean();
        }


        private void BTN_CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.CleanCurrOperand();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.Calculate();
        }

        private Model _model;


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 42)
            {
                BTN_multiply_Click(sender, e);
            }
            else if (e.KeyChar == 43)
            {
                BTN_plus_Click(sender, e);
            }
            else if (e.KeyChar == 45)
            {
                BTN_minus_Click(sender, e);
            }
            else if (e.KeyChar == 47)
            {
                BTN_div_Click(sender, e);
            }
            else if (e.KeyChar == 46)
            {
                BTN_dot_Click(sender, e);
            }
            else if (e.KeyChar == 8)
            {
                BTN_CE_Click(sender, e);
            }
            else if (e.KeyChar == 27)
            {
                BTN_C_Click(sender, e);
            }
            else if (e.KeyChar == 48)
            {
                BTN_0_Click(sender, e);
            }
            else if (e.KeyChar == 49)
            {
                BTN_1_Click(sender, e);
            }
            else if (e.KeyChar == 50)
            {
                BTN_2_Click(sender, e);
            }
            else if (e.KeyChar == 51)
            {
                BTN_3_Click(sender, e);
            }
            else if (e.KeyChar == 52)
            {
                BTN_4_Click(sender, e);
            }
            else if (e.KeyChar == 53)
            {
                BTN_5_Click(sender, e);
            }
            else if (e.KeyChar == 54)
            {
                BTN_6_Click(sender, e);
            }
            else if (e.KeyChar == 55)
            {
                BTN_7_Click(sender, e);
            }
            else if (e.KeyChar == 56)
            {
                BTN_8_Click(sender, e);
            }
            else if (e.KeyChar == 57)
            {
                BTN_9_Click(sender, e);
            }
            else if (e.KeyChar == 13)
            {
                BTN_equal_Click(sender, e);
            }
        }
    }
}
