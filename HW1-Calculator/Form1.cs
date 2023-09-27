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

        private void Button0Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Zero);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.One);
        }

        // do the same for BTN_2 to BTN_9 buttons ignore havent been hooked

        private void Button2Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber( (char)CharacterMap.Two);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Three);
        }

        private void Button4Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Four);
        }

        private void Button5Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Five);
        }

        private void Button6Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Six);
        }

        private void Button7Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Seven);
        }

        private void Button8Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Eight);
        }

        private void Button9Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Nine);
        }

        private void ButtonDotClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.AddNumber((char)CharacterMap.Dot);
        }

        private void ButtonPlusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Plus);
        }

        private void ButtonMinusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Minus);
        }

        private void ButtonMultiplyClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Multiply);
        }

        private void ButtonDivisionClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)CharacterMap.Divide);
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Clean();
        }

        private void ButtonClearEntryClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.CleanCurrNumber();
        }

        private void ButtonEqualClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Calculate();
        }

        private Model _model;
    }
}
