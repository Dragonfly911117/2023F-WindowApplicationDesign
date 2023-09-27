using System;
using System.Globalization;

namespace HomeWork01_Calculator
{
    public class Model
    {
        public string AddNumber(char newNumber)
        {
            if (_operator == Operator.Undefined)
            {
                _number1 += newNumber;
                return _number1;
            }
            else
            {
                _number2 += newNumber;
                _isNumber2 = true;
                return _number2;
            }
        }

        public string SetOperator(char symbol)
        {
            if (_isNumber2)
            {
                _number1 = Calculate();
                _number2 = "";
                _isNumber2 = false;
            }

            switch (symbol)
            {
                case (char)CharacterMap.Plus:
                    _operator = Operator.Plus;
                    break;
                case (char)CharacterMap.Minus:
                    if (_operator != Operator.Undefined && _number2 == "")
                    {
                        return AddNumber(symbol);
                    }
                    _operator = Operator.Minus;
                    break;
                case (char)CharacterMap.Multiply:
                    _operator = Operator.Multiply;
                    break;
                case (char)CharacterMap.Divide:
                    _operator = Operator.Divide;
                    break;
                default:
                    _operator = Operator.Undefined;
                    throw new ArgumentException();
            }

            return _number1.ToString(CultureInfo.InvariantCulture);
        }



        public string Calculate()
        {
            if (_operator == Operator.Undefined || !_isNumber2)
            {
                return _number1;
            }

            if (_number1 == "" || _number1[0] == (char)CharacterMap.Dot)
            {
                _number1 = (char)CharacterMap.Zero + _number1;
            }

            if (_number2 == "" || _number2[0] == (char)CharacterMap.Dot)
            {
                _number2 = (char)CharacterMap.Zero + _number2;
            }

            switch (_operator)
            {
                case Operator.Plus:
                    _number1 =
                        (double.Parse(_number1) + double.Parse(_number2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Minus:
                    _number1 =
                        (double.Parse(_number1) - double.Parse(_number2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Multiply:
                    _number1 =
                        (double.Parse(_number1) * double.Parse(_number2)).ToString(CultureInfo.InvariantCulture);
                    break;
                case Operator.Divide:
                    _number1 =
                        (double.Parse(_number1) / double.Parse(_number2)).ToString(CultureInfo.InvariantCulture);
                    break;
                default:
                    const string invalidOperation = "Invalid operation!";
                    throw new ArgumentException(invalidOperation);
            }

            _number2 = "";
            _operator = Operator.Undefined;
            _isNumber2 = false;
            return _number1;
        }

        public string CleanCurrNumber()
        {
            if (_operator == Operator.Undefined)
            {
                _number1 = "";
            }

            _number2 = "";
            return _number1;
        }

        public string Clean()
        {
            _number1 = "";
            _number2 = "";
            _operator = Operator.Undefined;
            _isNumber2 = false;
            return ((char)CharacterMap.Zero).ToString();
        }

        private enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide,
            Undefined
        }

        private bool _isNumber2 = false;
        private string _number1 = "";
        private string _number2 = "";
        private Operator _operator = Operator.Undefined;
    }
}
