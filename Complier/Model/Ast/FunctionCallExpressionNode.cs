using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 函数调用
    /// </summary>
    public class FunctionCallExpressionNode : ExpressionNode
    {
        public string FunctionName { get; private set; }

        public IEnumerable<ExpressionNode> Arguments
        {
            get
            {
                return arguments;
            }
        }

        public int ArgumentCount
        {
            get { return arguments.Count; }
        }

        private List<ExpressionNode> arguments;

        public FunctionCallExpressionNode(string functionName)
        {
            FunctionName = functionName;

            arguments = new List<ExpressionNode>();
        }

        public FunctionCallExpressionNode(string functionName, params ExpressionNode[] args)
            : this(functionName)
        {
            AddArguments(args);
        }

        public void AddArgument(ExpressionNode arg)
        {
            arguments.Add(arg);
        }

        public void AddArguments(IEnumerable<ExpressionNode> args)
        {
            arguments.AddRange(args);
        }

        
        public override void Print()
        {
            Console.WriteLine("{0}\t\t,{1}\t ", "FunCall", this.FunctionName);
            arguments.ForEach(p=>p.Print());
        }
    }
}
