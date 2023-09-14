using System;
using System.Collections;
using System.Collections.Generic;

namespace _2023F_WindowApplicationDesign
{
    public class Model
    {
        public Model()
        {
            _operand1 = 0;
            _operand2 = 0;
            _operator = Operator.Undefined;
        }
        


        private enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide,
            Undefined
        }

        private float _operand1, _operand2;
        private Operator _operator;
    }
}
