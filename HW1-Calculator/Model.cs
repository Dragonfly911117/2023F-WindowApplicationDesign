using System;
using System.Globalization;

namespace _2023F_WindowApplicationDesign
{
    public class Model
    {
        public string AddOperand(string operand)
        {
            string res;
            if (_operator == Operator.Undefined)
            {
                _operand1 *= 10;
                _operand1 += float.Parse(operand);
                res = _operand1.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                _operand2 *= 10;
                _operand2 += float.Parse(operand);
                _isOperand2 = true;
                res = _operand2.ToString(CultureInfo.InvariantCulture);
            }

            return res;
        }

        public string SetOperator(string op)
        {
            if (_isOperand2)
            {
                _operand1 = float.Parse(Calculate());
                _operand2 = 0f;
                _isOperand2 = false;
            }

            switch (op)
            {
                case "+":
                    _operator = Operator.Plus;
                    break;
                case "-":
                    _operator = Operator.Minus;
                    break;
                case "X":
                    _operator = Operator.Multiply;
                    break;
                case "/":
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
                return _operand1.ToString(CultureInfo.InvariantCulture);
            }

            switch (_operator)
            {
                case Operator.Plus:
                    return (_operand1 + _operand2).ToString(CultureInfo.InvariantCulture);
                case Operator.Minus:
                    return (_operand1 - _operand2).ToString(CultureInfo.InvariantCulture);
                case Operator.Multiply:
                    return (_operand1 * _operand2).ToString(CultureInfo.InvariantCulture);
                case Operator.Divide:
                    return (_operand1 / _operand2).ToString(CultureInfo.InvariantCulture);
                default:
                    return "0";
            }
        }

        public string Clean()
        {
            _operand1 = 0f;
            _operand2 = 0f;
            _isOperand2 = false;
            _operator = Operator.Undefined;
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
        private float _operand1 = 0f;
        private float _operand2 = 0f;
        private Operator _operator = Operator.Undefined;
    }
}
