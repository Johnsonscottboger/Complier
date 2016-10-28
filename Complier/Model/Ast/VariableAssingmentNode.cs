using System;
using Complier.SyntaxAnalysis;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 变量赋值
    /// </summary>
    class VariableAssingmentNode : AstNode
    {
        public string VariableName { get; private set; }
        public ExpressionNode ValueExpression { get; private set; }

        public VariableAssingmentNode(string name, ExpressionNode expr)
        {
            if (expr == null)
                throw new ParsingException("The assinged expression may not be null!");

            VariableName = name;
            ValueExpression = expr;
        }

        public override void Print()
        {
            Console.Write("{0}\t,{1}\t\t ", "VarAssing", this.VariableName);
            ValueExpression.Print();
        }
    }
}
