using Complier.LexicalAnalysis;
using Complier.SyntaxAnalysis;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 源程序
            string code = @"
int a = 5;

int func(int b)
{
    int c = (5*b)+7;
    return c;
}

int main()
{
    a = 6;
    func(4);
    return a*2;
}";
            #endregion

            //词法分析
            var lexer = new Tokenizer(code);
            var tokens = lexer.Tokenize();

            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }
            
            //抽象语法树
            var parser = new Parser(tokens);
            var ast = parser.ParseToAst();

            //四元式表
            QuaternionTypeTable table = new QuaternionTypeTable();
            table.PrintAst(ast);

            //编译


            Console.ReadKey();
        }
    }
}
