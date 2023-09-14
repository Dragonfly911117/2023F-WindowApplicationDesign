using System;
using System.Collections;
using System.Collections.Generic;

namespace _2023F_WindowApplicationDesign
{
    public class Model
    {
        public Model()
        {
            _operand1 = 0f;
            _operand2 = 0f;
            _isOperand2 = false;
            _operator = Operator.Undefined;
        }

        public string AddOperand(string operand)
        {
            if (_operator == Operator.Undefined)
            {
                _operand1 *= 10;
                _operand1 += float.Parse(operand);
                return _operand1.ToString();
            }
            else
            {
                _operand2 *= 10;
                _operand2 += float.Parse(operand);
                _isOperand2 = true;
                return _operand2.ToString();
            }
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

            return _operand1.ToString();
        }

        public string Calculate()
        {
            switch (_operator)
            {
                case Operator.Plus:
                    return (_operand1 + _operand2).ToString();
                case Operator.Minus:
                    return (_operand1 - _operand2).ToString();
                case Operator.Multiply:
                    return (_operand1 * _operand2).ToString();
                case Operator.Divide:
                    return (_operand1 / _operand2).ToString();
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

        private bool _isOperand2;
        private float _operand1, _operand2;
        private Operator _operator;
    }
}
