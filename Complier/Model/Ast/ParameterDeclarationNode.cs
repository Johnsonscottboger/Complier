using Complier.Model.Tokens;

namespace Complier.Model.Ast
{
    class ParameterDeclarationNode
    {
        public VariableType Type { get; private set; }
        public string Name { get; private set; }

        public ParameterDeclarationNode(VariableType type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
