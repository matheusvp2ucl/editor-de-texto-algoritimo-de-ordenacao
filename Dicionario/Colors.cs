using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicionario
{
    internal class Colors
    {

        public static void red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void reset()
        {
            Console.ResetColor();
        }

    }
}
