using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    enum OperatorType
    {
        Add,                    //加
        SubstractNegate,        //减
        Multiply,               //乘
        Divide,                 //除
        Modulo,                 //取模
        Assignment,             //赋值
        Equals,                 //相等
        GreaterThan,            //大于
        LessThan,               //小于
        GreaterEquals,          //大于等于
        LessEquals,             //小于等于
        NotEquals,              //不相等
        Not,                    //非
        And,                    //与
        Or,                     //或
    }
}
