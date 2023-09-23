using System;
using System.Globalization;

namespace HW01_Calculator
{
    public class Model
    {
        public string AppendOperand(char op)
        {
            if (_operator == Operator.Undefined)
            {
                _operand1 += op;
                return _operand1;
            }
            else
            {
                _operand2 += op;
                _isOperand2 = true;
                return _operand2;
            }
        }

        public string SetOperator(char op)
        {
            if (_isOperand2)
            {
                _operand1 = Calculate();
                _operand2 = "";
                _isOperand2 = false;
            }

            switch (op)
            {
                case '+':
                    _operator = Operator.Plus;
                    break;
                case '-':
                    if (_operator != Operator.Undefined && _operand2 == "")
                    {
                        return AppendOperand(op);
                    }

                    _operator = Operator.Minus;
                    break;
                case 'X':
                    _operator = Operator.Multiply;
                    break;
                case '/':
                    _operator = Operator.Divide;
                    break;
                default:
                    _operator = Operator.Undefined;
                    throw new ArgumentException("Invalid operator");
            }

            return _operand1.ToString(CultureInfo.InvariantCulture);
        }

        public string Calculate()
        {
            if (_operator == Operator.Undefined || !_isOperand2)
            {
                return _operand1;
            }

            if (_operand1 == "" || _operand1[0] == '.')
            {
                _operand1 = "0" + _operand1;
            }

            if (_operand2 == "" || _operand2[0] == '.')
            {
                _operand2 = "0" + _operand2;
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
            return "0";
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
