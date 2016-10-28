using System;
using System.Collections.Generic;

namespace Complier.Model.Ast
{
    public class StatementSequenceNode : AstNode
    {
        public IEnumerable<AstNode> SubNodes
        {
            get
            {
                return subNodes;
            }
        }

        List<AstNode> subNodes;

        public StatementSequenceNode()
        {
            subNodes = new List<AstNode>();
        }

        public StatementSequenceNode(IEnumerable<AstNode> subNodes)
        {
            this.subNodes.AddRange(subNodes);
        }

        public void AddStatement(AstNode node)
        {
            subNodes.Add(node);
        }

        public override void Print()
        {
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
