using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model.Tokens
{
    class NumberLiteralToken : Token
    {
        private int number;
        public int Number
        {
            get { return number; }
        }


        public NumberLiteralToken(string content)
            : base(content)
        {
            if (!int.TryParse(content, out number))
                throw new ArgumentException("The content is no valid number.", "content");
        }
    }
}
