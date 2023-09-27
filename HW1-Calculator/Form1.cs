using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork01_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _model = new Model();
        }

        // Brief: Add a number to the current number
        private void Button0Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Zero);
        }

        // Brief: Add a number to the current number
        private void Button1Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.One);
        }

        // Brief: Add a number to the current number
        private void Button2Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Two);
        }

        // Brief: Add a number to the current number
        private void Button3Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Three);
        }

        // Brief: Add a number to the current number
        private void Button4Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Four);
        }

        // Brief: Add a number to the current number
        private void Button5Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Five);
        }

        // Brief: Add a number to the current number
        private void Button6Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Six);
        }

        // Brief: Add a number to the current number
        private void Button7Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Seven);
        }

        // Brief: Add a number to the current number
        private void Button8Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Eight);
        }

        // Brief: Add a number to the current number
        private void Button9Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Nine);
        }

        // Brief: Add a number to the current number
        private void ButtonDotClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Dot);
        }

        // Brief: Set operator to the current operation
        private void ButtonPlusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Plus);
        }

        // Brief: Set operator to the current operation
        private void ButtonMinusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Minus);
        }

        // Brief: Set operator to the current operation
        private void ButtonMultiplyClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Multiply);
        }

        // Brief: Set operator to the current operation
        private void ButtonDivisionClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Divide);
        }

        // Brief: Clear everything from the current operation
        private void ButtonClearClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Clean();
        }

        // Brief: Clear the current number
        private void ButtonClearEntryClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.CleanCurrent();
        }

        // Brief: Calculate the result of the current operation
        private void ButtonEqualClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Calculate();
        }

        private Model _model;
    }
}
