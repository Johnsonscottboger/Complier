﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complier.Model.Ast;
using System.IO;

namespace Complier.CodeGenerator
{
    public class AssemblyGenerate : ICodeGenerator
    {
        private int _indentationLevel = 0;


        public AssemblyGenerate()
        {
        }

        #region 输出
        public void Emit(string code)
        {
            Emit("{0}", code);
        }

        public void Emit(string pattern,params object[] args)
        {
            Console.WriteLine(new string(' ', 4 * _indentationLevel) + pattern, args);
        }

        public void EmitComment(string comment)
        {
            EmitComment("{0}", comment);
        }

        public void EmitComment(string comment,params object[] args)
        {
            Emit("//", comment, args);
        }
        #endregion

        public void Generate(ProgramNode programNode)
        {
            Visit(programNode);
        }

        /// <summary>
        /// 根节点
        /// </summary>
        /// <param name="programNode"></param>


        public void Visit(ProgramNode programNode)
        {
            foreach (var item in programNode.SubNodes)
            {
                Visit((Object)item);
            }
        }

        public void Visit(Object node)
        {
            if (node is VariableDeclarationNode)
                Visit(node as VariableDeclarationNode);
            else if (node is ReturnStatementNode)
                Visit(node as ReturnStatementNode);
            else if (node is IfStatementNode)
                Visit(node as IfStatementNode);
            else if (node is WhileLoopNode)
                Visit(node as WhileLoopNode);
            else if (node is VariableAssingmentNode)
                Visit(node as VariableAssingmentNode);
            else if (node is FunctionDeclarationNode)
                Visit(node as FunctionDeclarationNode);
            else if (node is ParameterDeclarationNode)
                Visit(node as ParameterDeclarationNode);
            else if (node is BinaryOperationNode)
                Visit(node as BinaryOperationNode);
            else if (node is FunctionCallExpressionNode)
                Visit(node as FunctionCallExpressionNode);
            else if (node is NumberLiteralNode)
                Visit(node as NumberLiteralNode);
            else if (node is UnaryOperationNode)
                Visit(node as UnaryOperationNode);
            else if (node is VariableReferenceExpressionNode)
                Visit(node as VariableReferenceExpressionNode);
            else
                throw new Exception("con't fint correct type.");
        }

        /// <summary>
        /// 变量定义
        /// </summary>
        /// <param name="node"></param>
        public void Visit(VariableDeclarationNode node)
        {
            var builder = new StringBuilder();
            builder.Append("变量定义：");
            builder.AppendFormat("{0} {1} {2}", node.Type, node.Name, node.InitialValueExpression);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 返回语句
        /// </summary>
        /// <param name="node"></param>
        public void Visit(ReturnStatementNode node)
        {
            var builder = new StringBuilder();
            builder.AppendLine("返回语句:");
            builder.Append(node.ValueExpression);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// if条件语句
        /// </summary>
        /// <param name="node"></param>
        public void Visit(IfStatementNode node)
        {
            var builder = new StringBuilder();
            builder.AppendLine("if条件语句：");
            builder.AppendFormat("  条件：{0}",node.Condition);
            builder.AppendLine("条件语句块:");
            foreach(var item in node.SubNodes)
            {
                Visit((Object)item);
            }
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// while语句
        /// </summary>
        /// <param name="node"></param>
        public void Visit(WhileLoopNode node)
        {
            var builder = new StringBuilder();
            builder.AppendLine("while条件语句：");
            builder.AppendFormat("  条件：{0}", node.Condition);
            builder.AppendLine("条件语句块:");
            foreach (var item in node.SubNodes)
            {
                Visit((Object)item);
            }
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 变量赋值语句
        /// </summary>
        /// <param name="node"></param>
        public void Visit(VariableAssingmentNode node)
        {
            var builder = new StringBuilder();
            builder.Append("变量赋值：");
            builder.Append(node.VariableName);
            Visit((Object)node.ValueExpression);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 函数定义
        /// </summary>
        /// <param name="node"></param>
        public void Visit(FunctionDeclarationNode node)
        {
            var builder = new StringBuilder();
            builder.AppendLine("函数定义:");
            builder.AppendFormat("    函数名称:{0}\n", node.FunctionName);
            builder.AppendLine("    函数参数:");
            foreach(var item in node.Parameters)
            {
                builder.Append(item);
            }
            builder.AppendLine("    函数体：");
            foreach(var item in node.SubNodes)
            {
                Visit((Object)item);
            }
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 函数参数定义
        /// </summary>
        /// <param name="node"></param>
        public void Visit(ParameterDeclarationNode node)
        {

        }

        /// <summary>
        /// 二元操作符
        /// </summary>
        /// <param name="node"></param>
        public void Visit(BinaryOperationNode node)
        {

        }

        /// <summary>
        /// 函数调用
        /// </summary>
        /// <param name="node"></param>
        public void Visit(FunctionCallExpressionNode node)
        {

        }

        /// <summary>
        /// 数字字面量
        /// </summary>
        /// <param name="node"></param>
        public void Visit(NumberLiteralNode node)
        {

        }

        /// <summary>
        /// 一元操作符
        /// </summary>
        /// <param name="node"></param>
        public void Visit(UnaryOperationNode node)
        {

        }

        /// <summary>
        /// 变量引用
        /// </summary>
        /// <param name="node"></param>
        public void Visit(VariableReferenceExpressionNode node)
        {

        }
    }
}
