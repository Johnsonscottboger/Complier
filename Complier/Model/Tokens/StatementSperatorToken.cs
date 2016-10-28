using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    class StatementSperatorToken : Token
    {
        public StatementSperatorToken(string content)
            : base(content)
        {
            if (content != ";")
                throw new ArgumentException("The content is no statement seperator.", "content");
        }
    }
}
