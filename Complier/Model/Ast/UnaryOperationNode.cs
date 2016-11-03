using System;
using System.Linq;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 一元操作符
    /// </summary>
    public class UnaryOperationNode : ExpressionNode
    {
        public ExpressionOperationType OperationType { get; private set; }
        public ExpressionNode Operand { get; private set; }

        private static readonly ExpressionOperationType[] validOperators = { ExpressionOperationType.Negate, ExpressionOperationType.Not };

        public UnaryOperationNode(ExpressionOperationType opType, ExpressionNode operand)
        {
            if (!validOperators.Contains(opType))
                throw new ArgumentException("Invalid unary operator given!", "opType");

            OperationType = opType;
            Operand = operand;
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", this.OperationType);
            this.Operand.Print();
        }
    }
}
