using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Model
{
    public class Token
    {
        public Token()
        {
        }

        public Token(string content)
        {
            this.Content = content;
        }


        public string Content { get; private set; }

        public override string ToString()
        {
            return string.Format("[{0}] - {1}]", this.GetType().Name, Content);
        }
    }
}
