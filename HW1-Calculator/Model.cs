using System;
using System.Globalization;

namespace HomeWork01_Calculator
{
    public class Model
    {
        public string AppendOperand(char operand)
        {
            if (_operator == Operator.Undefined)
            {
                _operand1 += operand;
                return _operand1;
            }
            else
            {
                _operand2 += operand;
                _isOperand2 = true;
                return _operand2;
            }
        }

        public string SetOperator(char symbo)
        {
            if (_isOperand2)
            {
                _operand1 = Calculate();
                _operand2 = "";
                _isOperand2 = false;
            }

            switch (symbo)
            {
                case (char)EnumSuckingDrSmellsCock.Plus:
                    _operator = Operator.Plus;
                    break;
                case (char)EnumSuckingDrSmellsCock.Minus:
                    if (_operator != Operator.Undefined && _operand2 == "")
                    {
                        return AppendOperand(symbo);
                    }

                    _operator = Operator.Minus;
                    break;
                case (char)EnumSuckingDrSmellsCock.Multiply:
                    _operator = Operator.Multiply;
                    break;
                case (char)EnumSuckingDrSmellsCock.Divide:
                    _operator = Operator.Divide;
                    break;
                default:
                    _operator = Operator.Undefined;
                    throw new ArgumentException();
            }

            return _operand1.ToString(CultureInfo.InvariantCulture);
        }

        public string Calculate()
        {
            if (_operator == Operator.Undefined || !_isOperand2)
            {
                return _operand1;
            }

            if (_operand1 == "" || _operand1[0] == (char)EnumSuckingDrSmellsCock.Dot)
            {
                _operand1 = (char)EnumSuckingDrSmellsCock.Zero + _operand1;
            }

            if (_operand2 == "" || _operand2[0] == (char)EnumSuckingDrSmellsCock.Dot)
            {
                _operand2 = (char)EnumSuckingDrSmellsCock.Zero + _operand2;
            }

            switch (_operator)
            {
                case Operator.Plus:
                    _operand1 =
                        (double.Parse(_operand1) + double.Parse(_operand2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Minus:
                    _operand1 =
                        (double.Parse(_operand1) - double.Parse(_operand2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Multiply:
                    _operand1 =
                        (double.Parse(_operand1) * double.Parse(_operand2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Divide:
                    _operand1 =
                        (double.Parse(_operand1) / double.Parse(_operand2)).ToString(CultureInfo.InvariantCulture);
                    break;
                default:
                    throw new ArgumentException("Invalid operation!");
            }

            _operand2 = "";
            _operator = Operator.Undefined;
            _isOperand2 = false;
            return _operand1;
        }

        public string CleanCurrOperand()
        {
            if (_operator == Operator.Undefined)
            {
                _operand1 = "";
            }

            _operand2 = "";
            return _operand1;
        }

        public string Clean()
        {
            _operand1 = "";
            _operand2 = "";
            _operator = Operator.Undefined;
            _isOperand2 = false;
            return ((char)EnumSuckingDrSmellsCock.Zero).ToString();
        }

        private enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide,
            Undefined
        }

        private bool _isOperand2 = false;
        private string _operand1 = "";
        private string _operand2 = "";
        private Operator _operator = Operator.Undefined;
    }
}
