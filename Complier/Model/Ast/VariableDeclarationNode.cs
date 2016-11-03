using Complier.Model.Tokens;
using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 变量定义
    /// </summary>
    public class VariableDeclarationNode : AstNode
    {
        public ExpressionNode InitialValueExpression { get; private set; }
        public VariableType Type { get; private set; }

        public string Name { get; private set; }

        private static readonly ExpressionNode DefaultIntValueExpression = ExpressionNode.CreateConstantExpression(0); //the default value for an int is zero (0).
        
        /// <summary>
        /// Creates a new instance of the VariableDeclarationNode class.
        /// </summary>
        /// <param name="type">The type of the variable.</param>
        /// <param name="name">The name of the variable.</param>
        /// <param name="initialValue">A expression used to initialise the variable initially or null to use the default value.</param>
        public VariableDeclarationNode(VariableType type, string name, ExpressionNode initialValue)
        {
            Type = type;
            Name = name;

            initialValue = initialValue ?? DefaultIntValueExpression;
            InitialValueExpression = initialValue;
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t,{1}\t\t,{2} ", "VarDeclar", this.Type, this.Name);
            InitialValueExpression.Print();
        }
    }
}
