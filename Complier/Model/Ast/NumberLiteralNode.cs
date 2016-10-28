using System;

namespace Complier.Model.Ast
{
    class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; private set; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }
    }
}
