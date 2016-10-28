using Complier.Model.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.SyntaxAnalysis
{
    /// <summary>
    /// 四元式表
    /// </summary>
    public class QuaternionTypeTable
    {
        /// <summary>
        /// 将抽象语法树转换为四元式表
        /// </summary>
        /// <param name="ast"></param>
        public void PrintAst(ProgramNode ast)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Operator    | \targ1\t | \targ2\t | \tresult\t");
            foreach(var item in ast.SubNodes)
            {
                item.Print();
            }
        }
    }
}
