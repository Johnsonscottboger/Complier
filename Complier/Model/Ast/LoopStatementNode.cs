using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 循环语句
    /// </summary>
    public class LoopStatementNode : StatementSequenceNode
    {
        public override void Print()
        {
            Console.Write("{0}\t\t ", "Loop");
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
