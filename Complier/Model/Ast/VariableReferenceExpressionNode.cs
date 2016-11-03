using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 变量引用
    /// </summary>
    public class VariableReferenceExpressionNode : ExpressionNode
    {
        public string VariableName { get; private set; }

        public VariableReferenceExpressionNode(string varName)
        {
            VariableName = varName;
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t\t,{1}", "VarRef", this.VariableName);
        }
    }
}
