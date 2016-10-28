using System;

namespace Complier.Model.Ast
{
    class VariableReferenceExpressionNode : ExpressionNode
    {
        public string VariableName { get; private set; }

        public VariableReferenceExpressionNode(string varName)
        {
            VariableName = varName;
        }
        
    }
}
