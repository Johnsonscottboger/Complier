﻿using Complier.LexicalAnalysis;
using Complier.SyntaxAnalysis;
using System;
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

            var lexer = new Tokenizer(code);
            var tokens = lexer.Tokenize();

            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            Console.WriteLine();
            Console.WriteLine();

            //parsing
            var parser = new Parser(tokens);
            var ast = parser.ParseToAst();



            Console.ReadKey();
        }
    }
}
