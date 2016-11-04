using Complier.Model;
using Complier.Model.Ast;
using Complier.Model.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.SyntaxAnalysis
{
    public class Parser
    {
        public Token[] tokens { get; private set; }
        private static int readingPosition;
        private Stack<StatementSequenceNode> scopes;
        private static readonly KeywordType[] typeKeywords = { KeywordType.Int, KeywordType.Void };

        public Parser(Token[] tokens)
        {
            this.tokens = tokens;
            readingPosition = 0;
            scopes = new Stack<StatementSequenceNode>();
        }

        /// <summary>
        /// 解析成抽象语法树
        /// </summary>
        /// <returns></returns>
        public ProgramNode ParseToAst()
        {
            if(scopes.Count==0)
                scopes.Push(new ProgramNode());
            while (!Eof())
            {
                if (Peek() is KeywordToken)
                {
                    var keyword = (KeywordToken)Next();

                    if (scopes.Count == 1)
                    {
                        if (keyword.IsTypeKeyword)
                        {
                            var varType = keyword.ToVariableType();
                            
                            var name = ReadToken<IdentifierToken>();
                            //超前搜索
                            Token lookahead = Peek();
                            if (lookahead is OperatorToken && (((OperatorToken)lookahead).OperatorType == OperatorType.Assignment) || lookahead is StatementSperatorToken) 
                            {
                                if (lookahead is OperatorToken)
                                    Next(); 
                                scopes.Peek().AddStatement(new VariableDeclarationNode(varType, name.Content, ExpressionNode.CreateFromTokens(ReadUntilStatementSeperator())));
                            }
                            else if (lookahead is OpenBraceToken && (((OpenBraceToken)lookahead).BraceType == BraceType.Round)) 
                            {
                                var func = new FunctionDeclarationNode(name.Content);
                                scopes.Peek().AddStatement(func); 
                                scopes.Push(func); 
                                Next(); 
                                while (!(Peek() is CloseBraceToken && ((CloseBraceToken)Peek()).BraceType == BraceType.Round)) 
                                {
                                    var argType = ReadToken<KeywordToken>();
                                    if (!argType.IsTypeKeyword)
                                        throw new ParsingException("Expected type keyword!");
                                    var argName = ReadToken<IdentifierToken>();
                                    func.AddParameter(new ParameterDeclarationNode(argType.ToVariableType(), argName.Content));
                                    if (Peek() is ArgSeperatorToken) 
                                        Next();
                                }

                                Next();
                                var curlyBrace = ReadToken<OpenBraceToken>();
                                if (curlyBrace.BraceType != BraceType.Curly)
                                    throw new ParsingException("Wrong brace type found!");
                            }
                            else
                                throw new Exception("The parser encountered an unexpected token.");
                        }
                        else
                            throw new ParsingException("Found non-type keyword on top level.");
                    }
                    else
                    {
                        if (keyword.IsTypeKeyword)
                        {
                            var varType = keyword.ToVariableType();
                            
                            var name = ReadToken<IdentifierToken>();
                            
                            Token lookahead = Peek();
                            if (lookahead is OperatorToken && (((OperatorToken)lookahead).OperatorType == OperatorType.Assignment) || lookahead is StatementSperatorToken) //variable declaration
                            {
                                if (lookahead is OperatorToken)
                                    Next();
                                scopes.Peek().AddStatement(new VariableDeclarationNode(varType, name.Content, ExpressionNode.CreateFromTokens(ReadUntilStatementSeperator())));
                            }
                        }
                        else
                        {
                            switch (keyword.KeywordType)
                            {
                                case KeywordType.Return:
                                    scopes.Peek().AddStatement(new ReturnStatementNode(ExpressionNode.CreateFromTokens(ReadUntilStatementSeperator())));
                                    break;
                                case KeywordType.If:
                                    var @if = new IfStatementNode(ExpressionNode.CreateFromTokens(ReadUntilClosingBrace()));
                                    scopes.Peek().AddStatement(@if);
                                    scopes.Push(@if);
                                    if (Peek() is OpenBraceToken && ((OpenBraceToken)Peek()).BraceType == BraceType.Curly)
                                    {
                                        Next();
                                    }
                                    break;
                                case KeywordType.While:
                                    var @while = new WhileLoopNode(ExpressionNode.CreateFromTokens(ReadUntilClosingBrace()));
                                    scopes.Peek().AddStatement(@while);
                                    scopes.Push(@while);
                                    if(Peek() is OpenBraceToken && ((OpenBraceToken)Peek()).BraceType == BraceType.Curly)
                                    {
                                        Next();
                                    }
                                    break;
                                default:
                                    throw new ParsingException("Unexpected keyword type.");
                            }
                        }
                    }
                }
                else if (Peek() is IdentifierToken && scopes.Count > 1)
                {
                    var name = ReadToken<IdentifierToken>();
                    if (Peek() is OperatorToken && ((OperatorToken)Peek()).OperatorType == OperatorType.Assignment)
                    {
                        Next(); 
                        scopes.Peek().AddStatement(new VariableAssingmentNode(name.Content, ExpressionNode.CreateFromTokens(ReadUntilStatementSeperator())));
                    }
                    else
                        scopes.Peek().AddStatement(ExpressionNode.CreateFromTokens(new[] { name }.Concat(ReadUntilStatementSeperator())));
                }
                else if (Peek() is CloseBraceToken)
                {
                    var brace = ReadToken<CloseBraceToken>();
                    if (brace.BraceType != BraceType.Curly)
                        throw new ParsingException("Wrong brace type found!");
                    scopes.Pop();
                }
                else
                    throw new ParsingException("The parser ran into an unexpeted token.");
            }

            if (scopes.Count != 1)
                throw new ParsingException("The scopes are not correctly nested.");

            return (ProgramNode)scopes.Pop();
        }

        /// <summary>
        /// 是否到达结尾
        /// </summary>
        /// <returns></returns>
        private bool Eof()
        {
            return readingPosition >= tokens.Length;
        }

        private IEnumerable<Token> ReadTokenSeqence(params Type[] expectedTypes)
        {
            foreach (var t in expectedTypes)
            {
                if (!t.IsAssignableFrom(Peek().GetType()))
                    throw new ParsingException("Unexpected token");
                yield return Next();
            }
        }

        private IEnumerable<Token> ReadUntilClosingBrace()
        {
            //while (!Eof() && !(Peek() is CloseBraceToken))
            //    yield return Next();
            //Next();
            bool getNext = true;
            while (!Eof() && !(Peek() is CloseBraceToken))
                yield return Next();
            while (getNext)
            {
                getNext = false;
                yield return Peek();
            }
            Next();
        }

        private IEnumerable<Token> ReadUntilStatementSeperator()
        {
            while (!Eof() && !(Peek() is StatementSperatorToken))
                yield return Next();
            Next();
        }

        private TExpected ReadToken<TExpected>() where TExpected : Token
        {
            if (Peek() is TExpected)
                return (TExpected)Next();
            else
                throw new ParsingException("Unexpected token " + Peek());
        }

        private Token Peek()
        {
            if (!Eof())
                return tokens[readingPosition];
            else
                return null;
        }

        private Token Next()
        {
            var ret = Peek();
            readingPosition++;
            return ret;
        }

        
    }
}
