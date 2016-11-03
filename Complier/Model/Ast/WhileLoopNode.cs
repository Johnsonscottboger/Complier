using Complier.SyntaxAnalysis;
using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// While循环
    /// </summary>
    public class WhileLoopNode : LoopStatementNode
    {
        public ExpressionNode Condition { get; private set; }

        public WhileLoopNode(ExpressionNode cond)
        {
            if (cond == null)
                throw new ParsingException("Parser: An while loop must conatain a condition!");
            else
                Condition = cond;
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", "WhileLoop");
            Condition.Print();
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
