using System;
using System.Linq;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 二元操作符结点
    /// </summary>
    public class BinaryOperationNode : ExpressionNode
    {
        public ExpressionOperationType OperationType { get; private set; }
        public ExpressionNode OperandA { get; private set; }
        public ExpressionNode OperandB { get; private set; }

        private static readonly ExpressionOperationType[] validOperators = 
        {
            ExpressionOperationType.Add,
            ExpressionOperationType.Substract,
            ExpressionOperationType.Multiply,
            ExpressionOperationType.Divide,
            ExpressionOperationType.Modulo,
            ExpressionOperationType.Assignment,
            ExpressionOperationType.Equals,
            ExpressionOperationType.GreaterThan,
            ExpressionOperationType.LessThan,
            ExpressionOperationType.GreaterEquals,
            ExpressionOperationType.LessEquals,
            ExpressionOperationType.NotEquals,
            ExpressionOperationType.Not,
            ExpressionOperationType.And,
            ExpressionOperationType.Or,
        };

        public BinaryOperationNode(ExpressionOperationType opType, ExpressionNode operandA, ExpressionNode operandB)
        {
            if (!validOperators.Contains(opType))
                throw new ArgumentException("Invalid binary operator given!", "opType");

            OperationType = opType;
            OperandA = operandA;
            OperandB = operandB;
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", this.OperationType);
            this.OperandA.Print();
            this.OperandB.Print();
        }
    }
}
