using Complier.Model.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.CodeGenerator
{
    interface ICodeGenerator
    {
        void Generate(ProgramNode programNode);

        void Emit(string code);
    }
}
