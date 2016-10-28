using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model
{
    /// <summary>
    /// 字符类型
    /// </summary>
    [Flags]
    enum CharType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0x00,
        /// <summary>
        /// 字母
        /// </summary>
        Alpha = 0x01,
        /// <summary>
        /// 数字
        /// </summary>
        Numeric = 0x02,
        /// <summary>
        /// 空格，制表符 Spaces,tabs. Whitespace, but no newline.
        /// </summary>
        LineSpace = 0x04,

        /// <summary>
        /// 换行符
        /// </summary>
        NewLine = 0x08,

        /// <summary>
        /// 操作符 +,-,*,/,%,&,|,=,&gt;,&lt;,!.
        /// </summary>
        Operator = 0x10,
        /// <summary>
        /// (,[,{.
        /// </summary>
        OpenBrace = 0x20,
        /// <summary>
        /// ),],}.
        /// </summary>
        CloseBrace = 0x40,
        /// <summary>
        /// ,.逗号，区分方法的参数
        /// </summary>
        ArgSeperator = 0x80,
        /// <summary>
        /// ;.分号，区分语句
        /// </summary>
        StatementSeperator = 0x100,


        AlphaNumeric = Alpha | Numeric,
        WhiteSpace = LineSpace | NewLine,
        Brace = OpenBrace | CloseBrace,

        /// <summary>
        /// Chars that "have a special meaning".
        /// </summary>
        MetaChar = Operator | Brace | ArgSeperator | StatementSeperator,
        All = AlphaNumeric | WhiteSpace | MetaChar,
    }
}
