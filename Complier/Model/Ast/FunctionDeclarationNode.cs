using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Ast
{
    class FunctionDeclarationNode : StatementSequenceNode
    {
        public string FunctionName { get; private set; }

        public IEnumerable<ParameterDeclarationNode> Parameters
        {
            get
            {
                return paramters;
            }
        }

        private List<ParameterDeclarationNode> paramters;

        public FunctionDeclarationNode(string name)
        {
            FunctionName = name;

            paramters = new List<ParameterDeclarationNode>();
        }

        public void AddParameter(ParameterDeclarationNode param)
        {
            paramters.Add(param);
        }
    }
}
