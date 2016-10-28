using Complier.SyntaxAnalysis;
using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// While循环
    /// </summary>
    class WhileLoopNode : LoopStatementNode
    {
        public ExpressionNode Condition { get; private set; }

        public WhileLoopNode(ExpressionNode cond)
        {
            if (cond == null)
                throw new ParsingException("Parser: An while loop must conatain a condition!");
        }

        public override void Print()
        {
            Console.Write("{0}\t\t ", "WhileLoop");
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
