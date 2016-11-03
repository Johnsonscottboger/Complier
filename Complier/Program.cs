using Complier.CodeGenerator;
using Complier.LexicalAnalysis;
using Complier.SyntaxAnalysis;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = string.Empty;
            string defaultCode = string.Empty;
            if (!args.Any())
            {
                #region 源程序
                defaultCode = @"
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
                code = defaultCode;

                defaultCode = @"
int main()
{
    int sum = 0;
    int a = 6;
    while(a > 0)
    {
        sum = sum + a;
        a = a - 1;
    }
    return sum;
}";
                code = defaultCode;

                #endregion
            }
            else
            {
                if (File.Exists(args[0]))
                {
                    try
                    {
                        code = File.ReadAllText(args[0]);
                    }catch(FileLoadException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("打开文件失败:"+ex.Message);
                        code = defaultCode;
                    }
                }
                else
                {
                    Console.WriteLine("找不到指定文件");
                    code = defaultCode;
                }
            }



            //词法分析
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************词法分析************************");
            Console.ResetColor();
            var lexer = new Tokenizer(code);
            var tokens = lexer.Tokenize();

            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            //抽象语法树
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**********************语法分析*************************");
            Console.ResetColor();
            var parser = new Parser(tokens);
            var ast = parser.ParseToAst();

            //四元式表
            QuaternionTypeTable table = new QuaternionTypeTable();
            table.PrintAst(ast);

            var codeGeneratr = new AssemblyGenerate();
            codeGeneratr.Generate(ast);

            //编译
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************************编译***************************");
            Console.ResetColor();
            Complier.Complier complier = new Complier.Complier();
            var comCode = complier.GenerateCode(code);
            var comResult = complier.Compile(comCode);
            complier.ShowCompileResult(comResult);

            Console.ReadKey();
        }
    }
}
