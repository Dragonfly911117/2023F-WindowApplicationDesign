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
            textBox1.Text = _model.AddOperand("0");
        }


        private void BTN_1_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("1");
        }

        // do the same for BTN_2 to BTN_9 buttons ignore havent been hooked

        private void BTN_2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("2");
        }

        private void BTN_3_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("3");
        }

        private void BTN_4_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("4");
        }

        private void BTN_5_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("5");
        }

        private void BTN_6_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("6");
        }

        private void BTN_7_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("7");
        }

        private void BTN_8_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("8");
        }

        private void BTN_9_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand("9");
        }

        private void BTN_dot_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.AddOperand(".");
        }

        private void BTN_plus_Click(object sender, EventArgs e)
        {
            _model.SetOperator("+");
        }

        private void BTN_minus_Click(object sender, EventArgs e)
        {
            _model.SetOperator("-");
        }

        private void BTN_multiply_Click(object sender, EventArgs e)
        {
            _model.SetOperator("X");
        }

        private void BTN_div_Click(object sender, EventArgs e)
        {
            _model.SetOperator("/");
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
            _model.Clean();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = _model.Calculate();
        }

        private Model _model;

    }
}
