using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    public class ArgSeperatorToken : Token
    {
        public ArgSeperatorToken(string content)
            : base(content)
        {
            if (content != ",")
                throw new ArgumentException("The content is no argument seperator.", "content");
        }
    }
}
