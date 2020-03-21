using DarmarkCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace EireScript
{
    public class ConsoleInputReader : IInputReader
    {
        public bool GetString(out string inputString)
        {
            inputString = Console.ReadLine();
            return true;
        }
    }
}
