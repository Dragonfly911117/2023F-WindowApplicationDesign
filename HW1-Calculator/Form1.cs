using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_Calculator
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
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Zero);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.One);
        }

        // do the same for BTN_2 to BTN_9 buttons ignore havent been hooked

        private void Button2Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand( (char)EnumSuckingDrSmellsCock.Two);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Three);
        }

        private void Button4Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Four);
        }

        private void Button5Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Five);
        }

        private void Button6Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Six);
        }

        private void Button7Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Seven);
        }

        private void Button8Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Eight);
        }

        private void Button9Click(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Nine);
        }

        private void ButtonDotClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.AppendOperand((char)EnumSuckingDrSmellsCock.Dot);
        }

        private void ButtonPlusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)EnumSuckingDrSmellsCock.Plus);
        }

        private void ButtonMinusClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)EnumSuckingDrSmellsCock.Minus);
        }

        private void ButtonMultiplyClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)EnumSuckingDrSmellsCock.Multiply);
        }

        private void ButtonDivisionClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.SetOperator((char)EnumSuckingDrSmellsCock.Divide);
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Clean();
        }

        private void ButtonClearEntryClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.CleanCurrOperand();
        }

        private void ButtonEqualClick(object sender, EventArgs e)
        {
            TextBox.Text = _model.Calculate();
        }

        private Model _model;
    }
}
