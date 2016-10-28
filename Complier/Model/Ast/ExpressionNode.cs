using System.Collections.Generic;
using Complier.SyntaxAnalysis;

namespace Complier.Model.Ast
{
    abstract class ExpressionNode : AstNode
    {
        protected ExpressionNode()
        { }

        public static ExpressionNode CreateFromTokens(IEnumerable<Token> tokens)
        {
            //Now we need to parse the given tokens into a expression tree.
            return new ExpressionParser().Parse(tokens);
        }

        public static ExpressionNode CreateConstantExpression(int value)
        {
            return new NumberLiteralNode(value);
        }
    }
}
