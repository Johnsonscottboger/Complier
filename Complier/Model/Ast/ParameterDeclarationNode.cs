using Complier.Model.Tokens;
using System;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 参数定义
    /// </summary>
    public class ParameterDeclarationNode
    {
        public VariableType Type { get; private set; }
        public string Name { get; private set; }

        public ParameterDeclarationNode(VariableType type, string name)
        {
            Type = type;
            Name = name;
        }

        public void Print()
        {
            Console.WriteLine("{0}\t\t,{1},{2}", "ParameterDeclar", this.Type, this.Name);
        }
    }
}
