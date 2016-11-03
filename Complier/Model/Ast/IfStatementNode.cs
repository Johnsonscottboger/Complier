using Complier.SyntaxAnalysis;
using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// If语句
    /// </summary>
    public class IfStatementNode : StatementSequenceNode
    {
        public ExpressionNode Condition { get; private set; }

        public IfStatementNode(ExpressionNode cond)
        {
            if (cond == null)
                throw new ParsingException("Parser: An If statmentent must conatain a condition!");

            Condition = cond;
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", "if");
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
