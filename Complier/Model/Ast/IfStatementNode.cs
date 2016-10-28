using Complier.SyntaxAnalysis;

namespace Complier.Model.Ast
{
    class IfStatementNode : StatementSequenceNode
    {
        public ExpressionNode Condition { get; private set; }

        public IfStatementNode(ExpressionNode cond)
        {
            if (cond == null)
                throw new ParsingException("Parser: An If statmentent must conatain a condition!");

            Condition = cond;
        }
    }
}
