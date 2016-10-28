using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    public class KeywordToken:Token
    {
        private static readonly Dictionary<string, KeywordType> validKeywords = new Dictionary<string, KeywordType>()
        {
            { "if", KeywordType.If },
            { "int", KeywordType.Int },
            { "return", KeywordType.Return },
            { "void", KeywordType.Void },
            { "while", KeywordType.While },
        };

        private static readonly Dictionary<KeywordType, VariableType> keywordTypeToVariableType = new Dictionary<KeywordType, VariableType>
        {
            { KeywordType.Int, VariableType.Int },
            { KeywordType.Void, VariableType.Void },
        };

        public KeywordType KeywordType { get; private set; }

        /// <summary>
        /// 是否为关键类型
        /// </summary>
        public bool IsTypeKeyword
        {
            get { return keywordTypeToVariableType.ContainsKey(KeywordType); }
        }

        public KeywordToken(string content)
            : base(content)
        {
            if (!validKeywords.ContainsKey(content))
                throw new ArgumentException("The content is no valid keyword.", "content");

            KeywordType = validKeywords[content];
        }

        /// <summary>
        /// 是否为关键字
        /// </summary>
        public static bool IsKeyword(string s)
        {
            return validKeywords.ContainsKey(s);
        }

        /// <summary>
        /// 转换为变量类型
        /// </summary>
        public VariableType ToVariableType()
        {
            return keywordTypeToVariableType[KeywordType];
        }
    }
}
