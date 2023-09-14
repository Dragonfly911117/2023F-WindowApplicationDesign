using System;
using System.Collections;
using System.Collections.Generic;

namespace _2023F_WindowApplicationDesign
{
    public class Model
    {
        public Model()
        {
            _operators = new List<Operator>();
            _operand = new List<float>();
            _operand.Add(0f);
        }

        public void AddOperand(string operand)
        {
            var temp = float.Parse(operand);
            if (_operand.Count <= _operators.Count)
            {
                _operand.Add(temp);
            }
            else
            {
                _operand[_operand.Count - 1] = temp;
            }
        }

        public void SetOperator(string op)
        {
            var temp = Operator.Undefined;
            switch (op)
            {
                case "+":
                    temp = Operator.Plus;
                    break;
                case "-":
                    temp = Operator.Minus;
                    break;
                case "X":
                    temp = Operator.Multiply;
                    break;
                case "/":
                    temp = Operator.Divide;
                    break;
            }

            if (_operand.Count <= _operators.Count && _operators.Count != 0)
            {
                _operators.RemoveAt(_operators.Count - 1);
            }

            _operators.Add(temp);
        }

        public string GetResult()
        {
            var result = 0f;

            for (int i = 0; i < _operand.Count; i++)
            {
                switch (_operators[i - 1])
                {
                    case Operator.Plus:
                        result += _operand[i];
                        break;
                    case Operator.Minus:
                        result -= _operand[i];
                        break;
                    case Operator.Multiply:
                        result *= _operand[i];
                        break;
                    case Operator.Divide:
                        result /= _operand[i];
                        break;
                }
            }

            return result.ToString();
        }


        private enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide,
            Undefined
        }

        private List<float> _operand;
        private List<Operator> _operators;
    }
}
