using Complier.Extensions;
using Complier.Model;
using Complier.Model.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.LexicalAnalysis
{
    public class Tokenizer
    {
        /// <summary>
        /// 正在读取的位置
        /// </summary>
        private int readingPosition;
        public Tokenizer(string code)
        {
            this.Code = code;
            readingPosition = 0;
        }

        /// <summary>
        /// 源代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public Token[] Tokenize()
        {
            var tokens = new List<Token>();
            var builder = new StringBuilder();
            while (!Eof())
            {
                //跳过空白符
                Skip(CharType.WhiteSpace);

                switch (PeekType())
                {
                    case CharType.Alpha: //start of identifier
                        ReadToken(builder, CharType.AlphaNumeric);
                        string s = builder.ToString();
                        if (KeywordToken.IsKeyword(s))
                            tokens.Add(new KeywordToken(s));
                        else
                            tokens.Add(new IdentifierToken(s));
                        builder.Clear();
                        break;
                    case CharType.Numeric:
                        ReadToken(builder, CharType.Numeric);
                        tokens.Add(new NumberLiteralToken(builder.ToString()));
                        builder.Clear();
                        break;
                    case CharType.Operator:
                        ReadToken(builder, CharType.Operator);
                        tokens.Add(new OperatorToken(builder.ToString()));
                        builder.Clear();
                        break;
                    case CharType.OpenBrace:
                        tokens.Add(new OpenBraceToken(Next().ToString()));
                        break;
                    case CharType.CloseBrace:
                        tokens.Add(new CloseBraceToken(Next().ToString()));
                        break;
                    case CharType.ArgSeperator:
                        tokens.Add(new ArgSeperatorToken(Next().ToString()));
                        break;
                    case CharType.StatementSeperator:
                        tokens.Add(new StatementSperatorToken(Next().ToString()));
                        break;
                    default:
                        throw new Exception("The tokenizer found an unidentifiable character.");
                }
            }

            return tokens.ToArray();
        }

        /// <summary>
        /// 字符类型
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private CharType CharTypeOf(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '&':
                case '|':
                case '=':
                    return CharType.Operator;
                case '(':
                case '[':
                case '{':
                    return CharType.OpenBrace;
                case ')':
                case ']':
                case '}':
                    return CharType.CloseBrace;
                case ',':
                    return CharType.ArgSeperator;
                case ';':
                    return CharType.StatementSeperator;
                case '\r': //\r and \n have UnicodeCategory.Control, not LineSeperator...
                case '\n':
                    return CharType.NewLine;
            }

            switch (char.GetUnicodeCategory(c))
            {
                case UnicodeCategory.DecimalDigitNumber:
                    return CharType.Numeric;
                case UnicodeCategory.LineSeparator: //just in case... (see above)
                    return CharType.NewLine;
                case UnicodeCategory.ParagraphSeparator:
                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.OtherLetter:
                case UnicodeCategory.UppercaseLetter:
                    return CharType.Alpha;
                case UnicodeCategory.SpaceSeparator:
                    return CharType.LineSpace;
            }

            return CharType.Unknown;
        }

        /// <summary>
        /// 获取当前字符
        /// </summary>
        /// <returns></returns>
        private char Peek()
        {
            return Code[readingPosition];
        }

        /// <summary>
        /// 获取下一字符
        /// </summary>
        /// <returns></returns>
        private char Next()
        {
            var result = Peek();
            readingPosition++;
            return result;
        }

        /// <summary>
        /// 获取当前字符类型
        /// </summary>
        /// <returns></returns>
        private CharType PeekType()
        {
            return CharTypeOf(Peek());
        }

        /// <summary>
        /// 获取下一字符类型
        /// </summary>
        /// <returns></returns>
        private CharType NextType()
        {
            return CharTypeOf(Next());
        }

        /// <summary>
        /// 跳过字符
        /// </summary>
        /// <param name="type"></param>
        private void Skip(CharType type)
        {
            while (PeekType().HasAnyFlag(type))
                Next();
        }

        /// <summary>
        /// 是否到达结尾
        /// </summary>
        /// <returns></returns>
        private bool Eof()
        {
            return readingPosition >= Code.Length;
        }

        /// <summary>
        /// 写入Token
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        private void ReadToken(StringBuilder builder,CharType type)
        {
            while (!Eof() && PeekType().HasAnyFlag(type))
                builder.Append(Next());
        }
    }
}
