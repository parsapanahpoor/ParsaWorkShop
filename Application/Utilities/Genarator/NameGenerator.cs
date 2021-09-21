using System;
using System.Collections.Generic;
using System.Text;

namespace Etecsho.Utilities.Genarator
{
    public class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
