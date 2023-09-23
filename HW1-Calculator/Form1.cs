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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)42:
                    ButtonMultiplyClick(sender, e);
                    break;
                case (char)43:
                    ButtonPlusClick(sender, e);
                    break;
                case (char)45:
                    ButtonMinusClick(sender, e);
                    break;
                case (char)47:
                    ButtonDivisionClick(sender, e);
                    break;
                case (char)46:
                    ButtonDotClick(sender, e);
                    break;
                case (char)8:
                    ButtonClearEntryClick(sender, e);
                    break;
                case (char)27:
                    ButtonClearClick(sender, e);
                    break;
                case (char)48:
                    Button0Click(sender, e);
                    break;
                case (char)49:
                    Button1Click(sender, e);
                    break;
                case (char)50:
                    Button2Click(sender, e);
                    break;
                case (char)51:
                    Button3Click(sender, e);
                    break;
                case (char)52:
                    Button4Click(sender, e);
                    break;
                case (char)53:
                    Button5Click(sender, e);
                    break;
                case (char)54:
                    Button6Click(sender, e);
                    break;
                case (char)55:
                    Button7Click(sender, e);
                    break;
                case (char)56:
                    Button8Click(sender, e);
                    break;
                case (char)57:
                    Button9Click(sender, e);
                    break;
                case (char)13:
                    ButtonEqualClick(sender, e);
                    break;
                default:
                    break;
            }
        }

        private Model _model;
    }
}
