using System.Collections.Generic;
using Complier.SyntaxAnalysis;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 抽象表达式结点
    /// </summary>
    public abstract class ExpressionNode : AstNode
    {
        protected ExpressionNode()
        { }

        public static ExpressionNode CreateFromTokens(IEnumerable<Token> tokens)
        {
            return new ExpressionParser().Parse(tokens);
        }

        public static ExpressionNode CreateConstantExpression(int value)
        {
            return new NumberLiteralNode(value);
        }
    }
}
