using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Ast
{
    /// <summary>
    /// 函数声明
    /// </summary>
    public class FunctionDeclarationNode : StatementSequenceNode
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

        public string ParameterToString()
        {
            var builder =new StringBuilder();
            foreach(var item in Parameters)
            {
                builder.Append(item.Type+",");
            }
            return builder.ToString();
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t,{1}\t\t,{2}\t ", "FunDeclar", ParameterToString(), this.FunctionName);
            foreach(var item in SubNodes)
            {
                item.Print();
            }
        }
    }
}
