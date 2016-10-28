using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 数字字面量
    /// </summary>
    class NumberLiteralNode : ExpressionNode
    {
        public int Value { get; private set; }

        public NumberLiteralNode(int value)
        {
            Value = value;
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t\t,{1}","Number", Value);
        }
    }
}
