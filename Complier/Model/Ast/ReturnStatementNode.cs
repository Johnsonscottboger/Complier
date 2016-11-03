using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// return”Ôæ‰
    /// </summary>
    public class ReturnStatementNode : AstNode
    {
        /// <summary>
        /// A expression for the value returned. Might be null, if
        /// no value is returned.
        /// </summary>
        public ExpressionNode ValueExpression { get; private set; }

        public ReturnStatementNode(ExpressionNode valueExpr)
        {
            ValueExpression = valueExpr;
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", "return");
            ValueExpression.Print();
        }
    }
}
