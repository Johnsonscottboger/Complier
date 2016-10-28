using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Extensions
{
    public static class EnumExtensions
    {
        public static bool HasAnyFlag(this Enum e,Enum flag)
        {
            if (flag == null)
                throw new ArgumentNullException("flag");

            if (!e.GetType().IsEquivalentTo(flag.GetType()))
                throw new ArgumentException("The enum type mismatches.", "flag");

            return (Convert.ToUInt64(e) & Convert.ToUInt64(flag)) != 0;
        }
    }
}
