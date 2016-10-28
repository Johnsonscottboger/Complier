using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model
{
    /// <summary>
    /// 源程序代码
    /// </summary>
    public class SourceCode
    {
        private string _codeText;
        public SourceCode()
        {
        }

        public SourceCode(string sourceCode)
        {
            this._codeText = sourceCode;
        }

        /// <summary>
        /// 源程序代码文本
        /// </summary>
        public string CodeText { get { return this._codeText; } set { this._codeText = value; } }
    }
}
