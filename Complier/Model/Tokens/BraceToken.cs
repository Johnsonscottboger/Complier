using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    abstract class BraceToken : Token
    {
        public BraceType BraceType { get; protected set; }

        public BraceToken(string content)
            : base(content)
        { }
    }
}
